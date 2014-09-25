//  --------------------------------
//  <copyright file="ConstructorNotFoundException.cs">
//      Copyright (c) 2014 All rights reserved.
//  </copyright>
//  <author>Alleshouse, Dale</author>
//  <date>09/24/2014</date>
//  ---------------------------------

namespace Dea.Utilities.Reflection
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class ConstructorNotFoundException : Exception
    {
        public ConstructorNotFoundException()
        {
        }

        public ConstructorNotFoundException(string message)
            : base(message)
        {
        }

        public ConstructorNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected ConstructorNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}