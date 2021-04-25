﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Simplic.CoreLib.ExceptionTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ExceptionParameterTest()
        {
            var exception = new CoreException("S00001", Guid.Empty.ToString());

            Assert.AreEqual(exception.Code, "S00001");
            Assert.AreEqual(exception.Id, Guid.Empty.ToString());
        }

        [TestMethod]
        public void ExceptionParameterTest_Error()
        {
            var exception = new CoreException("S00001", Guid.Empty.ToString(), () => int.Parse("abc").ToString());

            Assert.AreEqual(exception.Parameter.Count, 1);
            Assert.IsTrue(exception.Parameter[0].Contains("Invalid parameter"));
        }

        [TestMethod]
        public void ExceptionParameterTest_Success()
        {
            var exception = new CoreException("S00001", Guid.Empty.ToString(), () => "ABC");

            Assert.AreEqual(exception.Parameter.Count, 1);
            Assert.AreEqual(exception.Parameter[0], "ABC");
        }
    }
}
