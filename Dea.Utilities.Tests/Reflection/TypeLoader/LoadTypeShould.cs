//  --------------------------------
//  <copyright file="LoadTypeShould.cs">
//      Copyright (c) 2014 All rights reserved.
//  </copyright>
//  <author>Alleshouse, Dale</author>
//  <date>09/12/2014</date>
//  ---------------------------------

namespace Dea.Utilities.Tests.Reflection.TypeLoader
{
    using System;

    using Dea.Utilities.Reflection;
    using Dea.Utilities.Tests.Reflection.TypeTestClasses;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LoadTypeShould
    {
        [TestMethod]
        public void LoadSpecifedType()
        {
            var sut = new SutFactory<ITestType>().Build();

            var result = sut.LoadType("TestType");
            Assert.IsInstanceOfType(result, typeof(ITestType));
            Assert.IsInstanceOfType(result, typeof(TestType));
        }

        [ExpectedException(typeof(TypeNotFoundException))]
        [TestMethod]
        public void ThrowIfClassNotFound()
        {
            var sut = new SutFactory<ITestType>().Build();
            sut.LoadType("NotFoundType");
        }

        [ExpectedException(typeof(InvalidCastException))]
        [TestMethod]
        public void ThrowIfClassCantBeCastToTargetType()
        {
            var sut = new SutFactory<ITestType>().Build();
            sut.LoadType("AnotherTestType");
        }
    }
}