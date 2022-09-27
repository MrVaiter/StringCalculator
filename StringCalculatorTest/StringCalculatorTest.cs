using System;
using StringCalculatorLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringCalculatorTest
{
    [TestClass]
    public class TestMethods
    {

        [TestMethod]
        public void Add_EmptyString_0returned()
        {
            StringCalculator calc = new StringCalculator();

            Assert.AreEqual(calc.Add(""), 0);
        }

        [TestMethod]
        public void Add_OneNumber_NumberReturned()
        {
            StringCalculator calc = new StringCalculator();

            Assert.AreEqual(calc.Add("1"), 1);
        }

        [TestMethod]
        public void Add_TwoNumber_SumReturned()
        {
            StringCalculator calc = new StringCalculator();

            Assert.AreEqual(calc.Add("13,26"), 39);
        }

        [TestMethod]
        public void Add_NumbersWithNewLine_SumReturned()
        {
            StringCalculator calc = new StringCalculator();

            Assert.AreEqual(calc.Add("1\n2,3"), 6);
        }

        [TestMethod]
        public void Add_DifferentDelimiters_SumReturned()
        {
            StringCalculator calc = new StringCalculator();

            Assert.AreEqual(calc.Add("//;\n1;2"), 3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Add_NegativeNumber_ExceptionThrowed()
        {
            StringCalculator calc = new StringCalculator();

        }

    }
}