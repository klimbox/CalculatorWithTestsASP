using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalcTextBoxes.Models;

namespace CalcTest
{
    [TestClass]
    public class APITests
    {
        [DataTestMethod]
        [DataRow(5, 4, "+", 9)]
        [DataRow(5, 4, "-", 1)]
        [DataRow(5, 4, "*", 20)]
        [DataRow(20, 4, "/", 5)]
        public void CalcAPITest(int a, int b, string op, int exp)
        {
            Calc c = new Calc();
            c.num1 = a;
            c.num2 = b;
            c.opr = op;
            c.CalcRes();
            Assert.AreEqual(exp, c.res);
        }
    }
}
