using System;

namespace StringCalculatorLibrary
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            int result = 0;

            if (numbers == "")
                return 0;

            if (!numbers.Contains(","))
                return int.Parse(numbers);

            foreach (var number in numbers.Split(',', '\n'))
            {
                result += int.Parse(number);
            }

            return result;
        }
    }
}