//  --------------------------------
//  <copyright file="ITypeLoader.cs">
//      Copyright (c) 2014 All rights reserved.
//  </copyright>
//  <author>Alleshouse, Dale</author>
//  <date>09/24/2014</date>
//  ---------------------------------

namespace Dea.Utilities.Reflection
{
    public interface ITypeLoader<T>
        where T : class
    {
        T LoadType(string typeName, params object[] constructorArgs);
    }
}