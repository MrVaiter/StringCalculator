using System;

namespace StringCalculatorLibrary
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            int result = 0;
            char[] delimiters = new char[3] {',', '\n', ' '};

            if (numbers == "")
                return 0;

            foreach (var number in numbers.Split(delimiters))
            {
                result += int.Parse(number);
            }

            return result;
        }
    }
}