//  --------------------------------
//  <copyright file="FindTypeShould.cs">
//      Copyright (c) 2014 All rights reserved.
//  </copyright>
//  <author>Alleshouse, Dale</author>
//  <date>09/24/2014</date>
//  ---------------------------------

namespace Dea.Utilities.Tests.Reflection.TypeLocator
{
    using Dea.Utilities.Reflection;
    using Dea.Utilities.Testing;
    using Dea.Utilities.Tests.Reflection.TypeTestClasses;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class FindTypeShould
    {
        [ExpectedException(typeof(TypeNotFoundException))]
        [TestMethod]
        public void ThrowIfClassNotFound()
        {
            var sut = new SutBuilder<TypeLocator>().Build();
            sut.FindType("NotFoundType");
        }

        [TestMethod]
        public void ReturnType()
        {
            var sut = new SutBuilder<TypeLocator>().Build();
            var result = sut.FindType("TestType");
            Assert.AreEqual(typeof(TestType), result);
        }
    }
}