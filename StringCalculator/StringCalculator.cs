using System;
using System.Text;

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

            bool isHasNegatives = false;
            List<int> negativeNumbers = new List<int>();
            foreach (var number in numbers.Split(delimiters))
            {
                int num;

                if (int.TryParse(number, out num))
                {
                    if (num < 0)
                    {
                        isHasNegatives = true;
                        negativeNumbers.Add(num);
                    }

                    result += num;
                }

            }

            if (isHasNegatives)
            {
                StringBuilder negatives = new StringBuilder();

                foreach (var negativeNumber in negativeNumbers)
                    negatives.Append(negativeNumber);

                throw new ArgumentException("Negatives not allowed: " + negatives.ToString());
            }

            return result;
        }
    }
}