//  --------------------------------
//  <copyright file="TestTypeWithNonInterfaceArgument.cs">
//      Copyright (c) 2014 All rights reserved.
//  </copyright>
//  <author>Alleshouse, Dale</author>
//  <date>09/24/2014</date>
//  ---------------------------------

namespace Dea.Utilities.Tests.Testing.SutBuilder
{
    using System.Diagnostics.CodeAnalysis;

    public class TestTypeWithNonInterfaceArgument
    {
        [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        private readonly TestType _testType;

        [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        private readonly ITestType _testType2;

        public TestTypeWithNonInterfaceArgument(TestType testType, ITestType testType2)
        {
            this._testType = testType;
            this._testType2 = testType2;
        }
    }
}