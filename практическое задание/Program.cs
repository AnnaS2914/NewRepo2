using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace практическое_задание
{
    internal class Program
    {
public class TotalRoundnessCalculator
    {
        private List<int> primes;

      
        public TotalRoundnessCalculator()
        {
            primes = new List<int>();
        }

           //Решето Эратосфена для нахождения простых чисел до n
       private void GeneratePrimes(int n)
            {
                bool[] isPrime = new bool[n + 1];
                for (int i = 2; i <= n; i++)
                    isPrime[i] = true;

                for (int p = 2; p * p <= n; p++)
                {
                    if (isPrime[p])
                    {
                        for (int i = p * p; i <= n; i += p)
                            isPrime[i] = false;
                    }
                }

                primes.Clear();
            for (int i = 2; i <= n; i++)
            {
                if (isPrime[i])
                    primes.Add(i);
            }
        }

        private Dictionary<int, int> FactorizeFactorial(int n)
        {
            var factors = new Dictionary<int, int>();

            foreach (int p in primes)
            {
                if (p > n) break;

                int count = 0;
                int temp = n;
                while (temp > 0)
                {
                    temp /= p;
                    count += temp;
                }

                factors[p] = count;
            }

            return factors;
        }

   
        public long CalculateTotalRoundness(int n)
        {

            GeneratePrimes(n);

            var factorialFactors = FactorizeFactorial(n);


            int maxK = 0;
            foreach (var pair in factorialFactors)
            {
                if (pair.Value > maxK)
                    maxK = pair.Value;
            }

            long total = 0;

            for (int k = 1; k <= maxK; k++)
            {
                long count = 1;
                foreach (var pair in factorialFactors)
                {
                    int exp = pair.Value;
                    count *= (exp / k + 1);
                }
              
                count--; 

                if (count == 0)
                    break;

                total += count;
            }

            return total;
        }
    }

    
        static void Main(string[] args)
        {
            var calculator = new TotalRoundnessCalculator();

           // Проверка на 10! из условия
           // Console.WriteLine("Проверка: R(10!) = (312)" + calculator.CalculateTotalRoundness(10));

            int[] values = { 13, 15, 20, 30 };
            foreach (int n in values)
            {
                long result = calculator.CalculateTotalRoundness(n);
                Console.WriteLine($"R({n}!) = {result}");

    }
        }
    }
}