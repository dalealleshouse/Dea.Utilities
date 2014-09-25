//  --------------------------------
//  <copyright file="ITypeLocator.cs">
//      Copyright (c) 2014 All rights reserved.
//  </copyright>
//  <author>Alleshouse, Dale</author>
//  <date>09/24/2014</date>
//  ---------------------------------

namespace Dea.Utilities.Reflection
{
    using System;

    public interface ITypeLocator
    {
        Type FindType(string typeName);
    }
}