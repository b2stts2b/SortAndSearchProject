using System;
using System.Diagnostics;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAndSort
{
    class Program
    {
        static Stopwatch sw;
        static void Main(string[] args)
        {
            sw = new Stopwatch();
            //Själva programmet
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Vad vill du göra?");
                Console.WriteLine("1. Hitta alla primtal upp till n.");
                Console.WriteLine("2. Jämför linSearch och BinSearch.");
                Console.WriteLine("3. Testa BinSearch");
                Console.WriteLine("10. Avsluta programmet.");
                
                //Användaren väljer vad som ska hända
                long choice = long.Parse(Console.ReadLine());
                //Switch kör vad användaren valde
                switch (choice)
                {
                    case 1:
                        //Hitta primtal mellan 0 och n
                        FindPrimes();
                        break;
                    case 2:
                        CompareSearch();
                        break;
                    case 3:
                        TryBinarySearch();
                        break;
                    case 10:
                        //Avslutar Programmet
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
        }

        public static void FindPrimes()
        {
            List<long> primes = new List<long>();

            Console.Clear();
            Console.WriteLine("Hitta alla primtal upp till och med n.");
            Console.WriteLine("Vilket tal 'n' vill du söka till?");
            long choice = long.Parse(Console.ReadLine());

            if (choice < 2)
            {
                Console.WriteLine("Det finns inga primtal mindre än 2!");
            }
            else
            {
                primes.Add(2);
                for (int i = 3; i <= choice; i+=2)
                {
                    bool isPrime = true;
                    long sq = (long)Math.Sqrt((double)i);
                    foreach (int prime in primes)
                    {
                        if (prime > sq)
                        {
                            break;
                        }
                        else if(i % prime == 0)
                        {
                            isPrime = false;
                            break;
                        }
                    }
                    if (isPrime) primes.Add(i);
                }
            }

            Console.WriteLine();
            Console.WriteLine("Det finns " + primes.Count + " st primtal upp till och med " + choice);
            Console.WriteLine("Vill du skriva upp dem?");
            string answer = Console.ReadLine();
            if (answer.ToLower() == "ja")
            {
                for (int i = 0; i < primes.Count; i++)
                {
                    Console.WriteLine((i+1) + ". " + primes[i]);
                }
            }

            Console.WriteLine("Tryck enter för att återvända till start");
            Console.ReadLine();
            
        }

        public static void CompareSearch()
        {
            Console.Clear();
            //Intro
            Console.WriteLine("Jämför Linear Search och Binary Search");
            //Fråga efter maxTal
            Console.WriteLine("Välj hur många tal från 1 till och med n som ska sökas igenom.");
            Console.Write("n: ");
            long n = long.Parse(Console.ReadLine());
            //Fråga efter det sökta talet
            long tal = n+1;
            while (tal > n)
            {
                Console.WriteLine("Välj vilket tal som ska sökas upp.");
                Console.WriteLine("tal: ");
                tal = long.Parse(Console.ReadLine());
            }
            //Starta timer, kör linSearch, stanna timer, spara tid
            sw.Start();
            LinearSearch(n,tal);
            sw.Stop();
            long time1 = sw.ElapsedMilliseconds;
            sw.Reset();

            //Starta timer, kör Binsearch, stanna timer, spara tid
            sw.Start();
            BinarySearch(n,tal);
            sw.Stop();
            long time2 = sw.ElapsedMilliseconds;
            sw.Reset();

            Console.WriteLine("Det tog " + time1 + " ms för LinearSearch.");
            Console.WriteLine("Det tog " + time2 + " ms för BinarySearch");
            Console.WriteLine("Enter för att komma till start");
            Console.ReadLine();
        }

        public static void LinearSearch(long n, long t)
        {
            for (long i = 1; i <= n; i++)
            {
                if (i == t)
                {
                    break;
                }
            }
        }

        public static void BinarySearch(long n, long t)
        {
            long start = 1;
            long end = n;
            while(start <= end)
            {
                long mid = (start + end) / 2;
                if (mid == t)
                {
                    break;
                }
                else if (mid < t)
                {
                    start = mid + 1;
                }
                else if (mid > t)
                {
                    end = mid - 1;
                }
            }
        }

        public static void TryBinarySearch()
        {
            Console.Clear();
            Console.WriteLine("Testa Binary Search");
            Console.WriteLine("Välj tal n att söka upp till. (0-1.8*10^19)");
            Console.Write("n: ");
            long n = long.Parse(Console.ReadLine());
            Console.WriteLine("Välj tal t att leta upp.");
            long t = long.Parse(Console.ReadLine());

            sw.Start();
            BinarySearch(n,t);
            sw.Stop();
            double time = ConvertTicksToMilliseconds(sw.ElapsedTicks);
            sw.Reset();
            Console.WriteLine("Det tog " + time.ToString("0.##") + "ms.");
            Console.WriteLine("Tryck enter för att gå till start.");
            Console.ReadLine();
        }

        public static double ConvertTicksToMilliseconds(long ticks)
        {
            long freq = Stopwatch.Frequency;
            return ((double)ticks * 1000 / freq);
        }
    }
}
