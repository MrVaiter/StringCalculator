using System;
using NUnit.Framework;
using StringCalculatorLibrary;

namespace StringCalculatorTest
{
    [TestFixture]
    public class Tests
    {

        [Test]
        public void Add_EmptyString_0returned()
        {
            StringCalculator calc = new StringCalculator();

            Assert.AreEqual(calc.Add(""), 0);
        }

        [Test]
        public void Add_OneNumber_NumberReturned()
        {
            StringCalculator calc = new StringCalculator();

            Assert.AreEqual(calc.Add("1"), 1);
        }

        [Test]
        public void Add_TwoNumber_SumReturned()
        {
            StringCalculator calc = new StringCalculator();

            Assert.AreEqual(calc.Add("13,26"), 39);
        }

        [Test]
        public void Add_NumbersWithNewLine_SumReturned()
        {
            StringCalculator calc = new StringCalculator();

            Assert.AreEqual(calc.Add("1\n2,3"), 6);
        }

        [Test]
        public void Add_DifferentDelimiters_SumReturned()
        {
            StringCalculator calc = new StringCalculator();

            Assert.AreEqual(calc.Add("//;\n1;2"), 3);
        }

    }
}