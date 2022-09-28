using System;
using System.Text;
using System.Linq;

namespace StringCalculatorLibrary
{
    public class StringCalculator
    {
        private int calledCount = 0;

        public event Action<string, int> AddOccured = null;

        public int GetCalledCount()
        {
            return calledCount;
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
            calledCount++;
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
            var numberSum = from number in intNumbers
                            where number <= 1000
                            select number;

            addingResult = numberSum.Sum();

            // Trigger an event
            AddOccured?.Invoke("Method is called ", GetCalledCount());

            return addingResult;
        }
    }
}