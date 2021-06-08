using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace StringCalculatorKata
{
    public class StringCalculator
    {
        public static int Add(string numbers)
        {
            if (numbers == String.Empty)
            {
                return 0;
            }
            else if (numbers.Length == 1)
            {
                return Convert.ToInt32(numbers);
            }

            //string pattern = @"[\/a-zA-Z%,.;\\\\?*\s\n[\]]+";
            //string[] arrNumbers = Regex.Split(numbers, pattern);
            string[] arrNumbers = numbers.Split(new char[] { ',', ';', ' ', '/', '*', '[', ']', '%', '*'}, StringSplitOptions.RemoveEmptyEntries);

            var sum = 0;
            var negatives = new List<int>();

            foreach (var value in arrNumbers)
            {
                if (Convert.ToInt32(value) < 0)
                {
                    negatives.Add(Convert.ToInt32(value));
                }

                if (Convert.ToInt32(value) <= 1000)
                {
                    sum += Convert.ToInt32(value);
                }
            }

            if (negatives.Count > 0)
            {
                var negativesList = string.Join(',', negatives);
                var exceptionMessage = $"Negative numbers not allowed: {negativesList}.";
                Console.WriteLine(exceptionMessage);
                throw new ArgumentException(exceptionMessage);
            }


            return sum;
        }
    }
}
