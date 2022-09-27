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

            if (numbers.Contains("//"))
            {
                delimiters[2] = numbers[2];
            }

            foreach (var number in numbers.Split(delimiters))
            {
                int num;

                if (int.TryParse(number, out num))
                {
                    if (num < 0)
                        throw new ArgumentException();

                    result += num;
                }
                    
            }

            return result;
        }
    }
}