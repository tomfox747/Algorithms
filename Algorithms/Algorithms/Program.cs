using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Algorithm tester is running");
            Console.WriteLine("Choose an algorithm to run/test [bubble sort][merge sort][quick sort][insertion sort]");
            string algorithmChoice = Console.ReadLine();
            sortingAlgorithm alg = new sortingAlgorithm();
            searchAlgorithms srch = new searchAlgorithms();

            switch (algorithmChoice)
            {
                case "bubble sort":
                    alg.startSort("bubble");
                    Console.WriteLine("sorting ended");
                    break;
                case "quick sort":
                    alg.startSort("quick");
                    break;
                case "merge sort":
                    alg.startSort("merge");
                    break;
                case "insertion sort":
                    alg.startSort("insertion");
                    break;
                case "linear search":
                    srch.startSearch("linear");
                    break;
                default:
                    break;
            }
        }
    }
}
