//  --------------------------------
//  <copyright file="TypeLocator.cs">
//      Copyright (c) 2014 All rights reserved.
//  </copyright>
//  <author>Alleshouse, Dale</author>
//  <date>09/24/2014</date>
//  ---------------------------------

namespace Dea.Utilities.Reflection
{
    using System;
    using System.Globalization;
    using System.Linq;

    public class TypeLocator : ITypeLocator
    {
        public Type FindType(string typeName)
        {
            Type type = null;

            foreach (var a in AppDomain.CurrentDomain.GetAssemblies())
            {
                type = a.DefinedTypes.FirstOrDefault(t => t.Name == typeName);

                if (type != null)
                {
                    break;
                }
            }

            if (type == null)
            {
                throw new TypeNotFoundException(string.Format(CultureInfo.InvariantCulture, @"Unable to find a type with the specified name. Name: {0}", typeName));
            }

            return type;
        }
    }
}