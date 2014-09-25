//  --------------------------------
//  <copyright file="LoadTypeWithConstructorArgumentsShould.cs">
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
    public class LoadTypeWithConstructorArgumentsShould
    {
        [TestMethod]
        public void LoadType()
        {
            const string Expected = "Argument One";
            const string Expected2 = "Argument Two";
            var sut = new SutFactory<TypeWithConstructorArgs>().Build();

            var result = sut.LoadTypeWithConstructorArguments("TypeWithConstructorArgs", Expected, Expected2);
            Assert.IsNotNull(result);
            Assert.AreEqual(Expected, result.Arg);
            Assert.AreEqual(Expected2, result.Arg2);
        }

        [TestMethod]
        public void LoadTypeWithNoArguments()
        {
            var sut = new SutFactory<ITestType>().Build();

            var result = sut.LoadTypeWithConstructorArguments("TestType");
            Assert.IsInstanceOfType(result, typeof(ITestType));
            Assert.IsInstanceOfType(result, typeof(TestType));
        }

        [ExpectedException(typeof(ConstructorNotFoundException))]
        [TestMethod]
        public void ThrowIfConstructorNotFound()
        {
            var sut = new SutFactory<ITestType>().Build();
            sut.LoadTypeWithConstructorArguments("TestType", "an argument");
        }

        [ExpectedException(typeof(TypeNotFoundException))]
        [TestMethod]
        public void ThrowIfClassNotFound()
        {
            var sut = new SutFactory<ITestType>().Build();
            sut.LoadTypeWithConstructorArguments("NotFoundType");
        }

        [ExpectedException(typeof(InvalidCastException))]
        [TestMethod]
        public void ThrowIfClassCantBeCastToTargetType()
        {
            var sut = new SutFactory<ITestType>().Build();
            sut.LoadTypeWithConstructorArguments("AnotherTestType");
        }
    }
}