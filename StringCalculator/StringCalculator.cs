using System;
using System.Text;

namespace StringCalculatorLibrary
{
    public class StringCalculator
    {
        public int GetCalledCount()
        {
            return 0;
        }

        public (bool isHasNegatives, StringBuilder negativeNumbers) NegativesNumbersCheck(List<int> numbers)
        {
            bool isHasNegatives = false;
            StringBuilder negatives = new StringBuilder();
            foreach(var number in numbers)
            {
                if(number < 0)
                {
                    negatives.Append(number).Append(" ");
                    isHasNegatives = true;
                }                    
            }

            return (isHasNegatives, negatives);
        }

        public int Add(string numbers)
        {
            int addingResult = 0;

            // If string is empty
            if (numbers == "")
                return addingResult;

            // Set up the delimeters
            char[] delimiters = new char[3] {',', '\n', ' '};
            if (numbers.Contains("//"))
            {
                delimiters[2] = numbers[2];
            }

            // Split string into numbers
            var stringNumbers = numbers.Split(delimiters);

            // Getting the numbers
            List<int> intNumbers = new List<int>();
            int intNumber = 0;
            foreach (var stringNumber in stringNumbers)
            {
                if (int.TryParse(stringNumber, out intNumber))
                {
                    intNumbers.Add(intNumber);
                }
            }

            // Negative numbers check
            var negatives = NegativesNumbersCheck(intNumbers);
            if(negatives.isHasNegatives)
                throw new ArgumentException("Negatives not allowed: " + negatives.negativeNumbers.ToString());

            // Getting the sum of numbers
            addingResult = intNumbers.Sum();

            return addingResult;
        }
    }
}