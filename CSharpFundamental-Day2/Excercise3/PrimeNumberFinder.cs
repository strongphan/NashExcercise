using System.Collections.Concurrent;
using System.Diagnostics;

namespace Excercise3
{
    public class PrimeNumberFinder
    {
        /// <summary>
        /// Use to check the number is prime
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static bool IsPrime(int n)
        {
            if (n < 2)
            {
                return false;
            }
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }

        /// <summary>
        /// Use to find prime by using asynchronous
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static async Task<List<int>> FindPrimesAsync(int start, int end)
        {
            var primes = new ConcurrentBag<int>();
            int numberOfTasks = 100;
            int range = (end - start + 1) / numberOfTasks;

            var tasks = Enumerable.Range(0, numberOfTasks)
                .Select(taskNumber => Task.Run(() =>
                {
                    int rangeStart = start + taskNumber * range;
                    int rangeEnd = (taskNumber == numberOfTasks - 1) ? end : rangeStart + range - 1;

                    for (int i = rangeStart; i <= rangeEnd; i++)
                    {
                        if (IsPrime(i))
                            primes.Add(i);
                    }

                    return Task.CompletedTask;
                }))
                .ToList();

            await Task.WhenAll(tasks);
            return [.. primes];
        }
        /// <summary>
        /// Use to find prime without asynchronous
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static List<int> FindPrimes(int start, int end)
        {
            var primes = new List<int>();

            for (int i = start; i <= end; i++)
            {
                if (IsPrime(i))
                {
                    primes.Add(i);
                }
            }
            return primes;
        }

        public static async Task Implement()
        {
            int start, end;
            bool validInput = false;

            do
            {
                Console.Write("Enter the start value: ");
                if (int.TryParse(Console.ReadLine(), out start))
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter an integer.");
                }
            } while (!validInput);

            validInput = false;

            do
            {
                Console.Write("Enter the end value: ");
                if (int.TryParse(Console.ReadLine(), out end))
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter an integer.");
                }
            } while (!validInput);

            var stopWatch1 = new Stopwatch();
            var stopWatch3 = new Stopwatch();
            stopWatch1.Start();
            await Task.Delay(1000);
            var primesAsync = await FindPrimesAsync(start, end);
            stopWatch1.Stop();
            stopWatch3.Start();
            await Task.Delay(1000);
            var primes = FindPrimes(start, end);
            stopWatch3.Stop();
            if (primes.Count != 0)
            {
                Console.WriteLine("Time to complete with asynchronous: {0}", stopWatch1.ElapsedMilliseconds);
                Console.WriteLine("Number of elements found: {0}", primesAsync.Count);
                Console.WriteLine("Time to complete without asynchronous: {0}", stopWatch3.ElapsedMilliseconds);
                Console.WriteLine("Number of elements found: {0}", primes.Count);
            }
        }
        public static async Task Main(string[] args)
        {
            await Implement();

        }
    }
}
