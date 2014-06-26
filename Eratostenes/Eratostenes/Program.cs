namespace Eratostenes
{
    using System;
    using System.Text;

    /// <summary>
    /// Sieve of Eratosthenes program class.
    /// </summary>
    public class Program
    {
        private const int StartingPrimeNumber = 2;

        /// <summary>
        /// Starting point of the Console App.
        /// </summary>
        public static void Main()
        {
            Console.WriteLine("Welcome to the Sieve of Eratosthenes.\n" +
                              "The program will find all prime numbers up to a given limit\n");

            var limit = GetLimit();

            var numbers = new bool[limit + 1];

            for (var i = StartingPrimeNumber; i < numbers.Length; i++)
            {
                numbers[i] = true;
            }

            var resultMessage = GetPrimeNumbers(numbers);

            Console.WriteLine(resultMessage);
            Console.ReadLine();
        }

        private static int GetLimit()
        {
            bool success = false;

            int limit = 0;

            while (!success)
            {
                Console.WriteLine("Please provide a valid limit: ");
                var line = Console.ReadLine();
                success = int.TryParse(line, out limit) && limit > 2;
            }

            return limit;
        }

        private static StringBuilder GetPrimeNumbers(bool[] numbers)
        {
            var resultMessage = new StringBuilder("Result: ");

            for (int i = StartingPrimeNumber; i < numbers.Length; i++)
            {
                var isPrimeNumber = numbers[i];
                if (isPrimeNumber)
                {
                    resultMessage.AppendFormat("{0} ", i);
                    MarkMultiplesOfPrimeNumber(numbers, i);
                }
            }

            return resultMessage;
        }

        private static void MarkMultiplesOfPrimeNumber(bool[] numbers, int primeNumber)
        {
            for (int n = primeNumber * 2; n < numbers.Length; n = n + primeNumber)
            {
                numbers[n] = false;
            }
        }
    }
}
