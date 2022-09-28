using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculatorLibrary;

namespace StringCalculatorMSTest
{
    [TestClass]
    public class UnitTest1
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
        public void Add_NegativeNumber_ExceptionThrowed()
        {
            StringCalculator calc = new StringCalculator();

            try
            {
                calc.Add("-5, 3");

                Assert.Fail();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Assert.Fail();
            }

        }

        [TestMethod]
        public void Add_MultipleNegatives_ExceptionThrowed()
        {
            StringCalculator calc = new StringCalculator();

            try
            {
                calc.Add("-5, -3, -5");

                Assert.Fail();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Assert.Fail();
            }

        }

        [TestMethod]
        public void GetCalledCount_TwoReturned()
        {
            StringCalculator calc = new StringCalculator();

            calc.Add("//;\n1;2");
            calc.Add("1\n2,3");

            Assert.AreEqual(calc.GetCalledCount(), 2);

        }

        [TestMethod]
        public void CallTheEvent_MessageIsShown()
        {
            StringCalculator calc = new StringCalculator();
            StringBuilder result = new StringBuilder();

            calc.AddOccured += delegate (string message, int count)
            {
                result.Append(message).Append(count).Append(" times\n");
            };

            calc.Add("//;\n1;2");
            calc.Add("1\n2,3");

            Assert.AreEqual(result.ToString(), "Method is called 1 times\nMethod is called 2 times\n");

        }

        [TestMethod]
        public void Add_BigNumbers_BigNumbersIgnored()
        {
            StringCalculator calc = new StringCalculator();

            Assert.AreEqual(calc.Add("1\n2000,3"), 4);
        }

        [TestMethod]
        public void Add_LongDelimiters_SumReturned()
        {
            StringCalculator calc = new StringCalculator();

            Assert.AreEqual(6, calc.Add("//[***]\n1***2***3"));
        }

        [TestMethod]
        public void Add_MultypleDelimiters_SumReturned()
        {
            StringCalculator calc = new StringCalculator();

            Assert.AreEqual(6, calc.Add("//[*][%]\n1*2%3"));
        }

    }
}