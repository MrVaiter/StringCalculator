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

        public string[] SetUpDelimiters(string numbers)
        {
            List<string> delimiters = new List<string>();

            delimiters.Add(",");
            delimiters.Add("\n");

            if (numbers.Contains("//["))
            {
                int indexOfDelimiterBegin = numbers.IndexOf("[") + 1;
                int indexOfDelimiterEnd = numbers.IndexOf("]");
                int delimiterLength = indexOfDelimiterEnd - indexOfDelimiterBegin;

                delimiters.Add(numbers.Substring(indexOfDelimiterBegin, delimiterLength));
            }
            else
            {
                if (numbers.Contains("//"))
                {
                    int delimiterIndex = 2;
                    delimiters.Add(numbers[delimiterIndex].ToString());
                }
            }

            return delimiters.ToArray();
        }

        public int Add(string numbers)
        {
            calledCount++;
            int addingResult = 0;

            // If string is empty
            if (numbers == "")
                return addingResult;

            // Set up the delimeters
            var delimiters = SetUpDelimiters(numbers);

            // Split string into numbers
            var stringNumbers = numbers.Split(delimiters, StringSplitOptions.None);

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