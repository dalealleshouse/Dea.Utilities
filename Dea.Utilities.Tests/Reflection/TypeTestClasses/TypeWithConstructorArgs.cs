//  --------------------------------
//  <copyright file="TypeWithConstructorArgs.cs">
//      Copyright (c) 2014 All rights reserved.
//  </copyright>
//  <author>Alleshouse, Dale</author>
//  <date>09/24/2014</date>
//  ---------------------------------

namespace Dea.Utilities.Tests.Reflection.TypeTestClasses
{
    using System;

    public class TypeWithConstructorArgs
    {
        private readonly string _arg;

        private readonly string _arg2;

        public TypeWithConstructorArgs(string arg, string arg2)
        {
            if (arg == null)
            {
                throw new ArgumentNullException("arg");
            }

            if (arg2 == null)
            {
                throw new ArgumentNullException("arg2");
            }

            this._arg = arg;
            this._arg2 = arg2;
        }

        public string Arg
        {
            get
            {
                return this._arg;
            }
        }

        public string Arg2
        {
            get
            {
                return this._arg2;
            }
        }
    }
}