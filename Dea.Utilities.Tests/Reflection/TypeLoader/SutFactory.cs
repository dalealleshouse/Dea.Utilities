//  --------------------------------
//  <copyright file="SutFactory.cs">
//      Copyright (c) 2014 All rights reserved.
//  </copyright>
//  <author>Alleshouse, Dale</author>
//  <date>09/12/2014</date>
//  ---------------------------------

namespace Dea.Utilities.Tests.Reflection.TypeLoader
{
    using Dea.Utilities.Reflection;

    public class SutFactory<T>
        where T : class
    {
        public TypeLoader<T> Build()
        {
            return new TypeLoader<T>(new TypeLocator());
        }
    }
}