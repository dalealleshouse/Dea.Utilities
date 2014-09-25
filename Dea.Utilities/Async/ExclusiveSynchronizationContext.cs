//  --------------------------------
//  <copyright file="ExclusiveSynchronizationContext.cs">
//      Copyright (c) 2014 All rights reserved.
//  </copyright>
//  <author>Alleshouse, Dale</author>
//  <date>09/24/2014</date>
//  ---------------------------------

namespace Dea.Utilities.Async
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    public class ExclusiveSynchronizationContext : SynchronizationContext, IDisposable
    {
        private readonly Queue<Tuple<SendOrPostCallback, object>> _items = new Queue<Tuple<SendOrPostCallback, object>>();

        private readonly AutoResetEvent _workItemsWaiting = new AutoResetEvent(false);

        private bool _done;

        public Exception InnerException { get; set; }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~ExclusiveSynchronizationContext()
        {
            this.Dispose(false);
        }

        public override void Send(SendOrPostCallback d, object state)
        {
            throw new NotSupportedException("We cannot send to our same thread");
        }

        public override void Post(SendOrPostCallback d, object state)
        {
            lock (this._items)
            {
                this._items.Enqueue(Tuple.Create(d, state));
            }

            this._workItemsWaiting.Set();
        }

        public void EndMessageLoop()
        {
            this.Post(_ => this._done = true, null);
        }

        public void BeginMessageLoop()
        {
            while (!this._done)
            {
                Tuple<SendOrPostCallback, object> task = null;
                lock (this._items)
                {
                    if (this._items.Count > 0)
                    {
                        task = this._items.Dequeue();
                    }
                }

                if (task != null)
                {
                    task.Item1(task.Item2);

                    // the method threw an exception
                    if (this.InnerException != null)
                    {
                        throw new AggregateException("AsyncHelpers.Run method threw an exception.", this.InnerException);
                    }
                }
                else
                {
                    this._workItemsWaiting.WaitOne();
                }
            }
        }

        public override SynchronizationContext CreateCopy()
        {
            return this;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this._workItemsWaiting != null)
                {
                    this._workItemsWaiting.Dispose();
                }
            }
        }
    }
}