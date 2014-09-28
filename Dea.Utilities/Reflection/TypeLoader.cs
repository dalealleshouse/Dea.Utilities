//  --------------------------------
//  <copyright file="TypeLoader.cs">
//      Copyright (c) 2014 All rights reserved.
//  </copyright>
//  <author>Alleshouse, Dale</author>
//  <date>09/24/2014</date>
//  ---------------------------------

namespace Dea.Utilities.Reflection
{
    using System;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.Linq;

    public class TypeLoader<T> : ITypeLoader<T>
        where T : class
    {
        private readonly ITypeLocator _typeLocator;

        public TypeLoader(ITypeLocator typeLocator)
        {
            if (typeLocator == null)
            {
                throw new ArgumentNullException("typeLocator");
            }

            this._typeLocator = typeLocator;
        }

        public T LoadType(string typeName, params object[] constructorArgs)
        {
            if (constructorArgs == null)
            {
                constructorArgs = new object[0];
            }

            var type = this._typeLocator.FindType(typeName);

            var types = new Collection<Type>();
            foreach (var constructorArg in constructorArgs)
            {
                types.Add(constructorArg.GetType());
            }

            var constructor = type.GetConstructor(types.ToArray());

            if (constructor == null)
            {
                throw new ConstructorNotFoundException(
                    string.Format(CultureInfo.InvariantCulture, @"Unable to find a constructor with the specifed type arguments. Name: {0}", typeName));
            }

            var result = constructor.Invoke(constructorArgs) as T;

            if (result == null)
            {
                throw new InvalidCastException(
                    string.Format(CultureInfo.InvariantCulture, @"Unable to cast to the specifed type. Name: {0}, Type: {1}", typeName, typeof(T)));
            }

            return result;
        }
    }
}