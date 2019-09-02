using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class sortingAlgorithm
    {
        public void startSort(string sortType)
        {
            Console.WriteLine("input integer value to sort then press enter..., " +
                "repeat until finished then type complete to begin the sorting process");
            List<double> values = new List<double>();
            string choice;
            while (true)
            {
                choice = Console.ReadLine();
                if (choice == "complete") { break; }
                try
                {
                    values.Add(double.Parse(choice));
                }
                catch
                {
                    Console.WriteLine("incorrect input, please use numberical values");
                }
            }

            switch (sortType)
            {
                case "bubble":
                    bubbleSort(values);
                    printValues(values);
                    break;
                case "quick":
                    values = quickSortArray(values);
                    printValues(values);
                    break;
                case "merge":
                    values = mergeSort(values);
                    printValues(values);
                    break;
                case "insertion":
                    values = insertionSort(values);
                    printValues(values);
                    break;
                default:
                    break;
            }
        }
        public List<double> bubbleSort(List<double> values)
        {
            for (int i = 0; i < values.Count - 1; i++)
            {
                if (values[i] > values[i + 1])
                {
                    double temp = values[i];
                    values[i] = values[i + 1];
                    values[i + 1] = temp;
                    i = -1;
                }
            }
            return values;
        }

        public List<double> insertionSort(List<double> values)
        {
            int inc = 0;
            while(inc < values.Count)
            {
                if(inc == 0)
                {
                    inc++;
                    continue;
                }
                else
                {
                    int dec = inc - 1;
                    while (dec >= 0)
                    {
                        if (dec == 0)
                        {
                            if (values[inc] < values[dec])
                            {
                                double temp = values[inc];
                                values.RemoveAt(inc);
                                values.Insert(0, temp);
                            }
                            break;
                        }
                        else if (values[inc] < values[dec] && values[inc] > values[dec - 1])
                        {
                            values.Insert(dec, values[inc]);
                            values.RemoveAt(inc);
                            break;
                        }
                        else
                        {
                            dec--;
                        }
                    }
                    inc++;
                }
            }
            return values;
        }

        public List<double> mergeSort(List<double> values)
        {
            //split the array until only 1 value remains
            if (values.Count == 1) { return values; }
            else
            {
                List<double> left = new List<double>();
                List<double> right = new List<double>();

                int splitPoint = values.Count / 2;
                left = values.GetRange(0, splitPoint);
                right = values.GetRange(splitPoint, values.Count - splitPoint);

                mergeSort(left);
                mergeSort(right);

                List<double> output = merge(left, right);

                return output;
            }
        }
        public static List<double> merge(List<double> A, List<double> B)
        {
            List<double> output = new List<double>();
            List<double> combinedList = A;
            foreach(double d in B)
            {
                combinedList.Add(d);
            }

            while(combinedList.Count > 0)
            {
                double smallestVal = combinedList[0];
                int smallestValIndex = 0;
                for(int x = 0; x < combinedList.Count; x++)
                {
                    if(combinedList[x] <= smallestVal)
                    {
                        smallestVal = combinedList[x];
                        smallestValIndex = x;
                    }
                }
                output.Add(smallestVal);
                combinedList.RemoveAt(smallestValIndex);
            }

            return output;
        }
        
        public List<double> quickSortArray(List<double> values)
        {
            if(values.Count < 2) { return values; }
            else
            {
                //Console.Write("values in");
                //printValues(values);
                int I = 0;
                int J = -1;
                int pivot = values.Count - 1;

                while (true)
                {
                    if (values[I] < values[pivot])
                    {
                        J++;
                        double temp = values[I];
                        values[I] = values[J];
                        values[J] = temp;
                    }
                    I++;
                    if (I == pivot)
                    {
                        break;
                    }
                }
                double tempPivot = values[pivot];
                values[pivot] = values[J + 1];
                values[J + 1] = tempPivot;
                pivot = J + 1;

                List<double> lowList = new List<double>();
                List<double> highList = new List<double>();
                for (int i = 0; i < pivot; i++)
                {
                    lowList.Add(values[i]);
                }
                for (int i = pivot + 1; i < values.Count; i++)
                {
                    highList.Add(values[i]);
                }

                lowList = quickSortArray(lowList);
                highList = quickSortArray(highList);

                List<double> output = new List<double>();
                foreach (double d in lowList) { output.Add(d); }
                output.Add(values[pivot]);
                foreach (double d in highList) { output.Add(d); }

                return output; 
            }
        }

        public static void printValues(List<double> values)
        {
            foreach (double d in values)
            {
                Console.Write(d + ":");
            }
            Console.WriteLine("");
        }
    }

    class searchAlgorithms
    {
        public void startSearch(string searchType)
        {
            Console.WriteLine("input integer value to sort then press enter..., " +
                "repeat until finished then type complete to begin the sorting process");
            Console.WriteLine("If the inputted values are not in order, they will be sorted before they are searched");
            List<double> values = new List<double>();
            string choice;
            while (true)
            {
                choice = Console.ReadLine();
                if (choice == "complete") { break; }
                try
                {
                    values.Add(double.Parse(choice));
                }
                catch
                {
                    Console.WriteLine("incorrect input, please use numberical values");
                }
            }

            double searchItem;
            Console.WriteLine("choose a value to  search for");
            searchItem = double.Parse(Console.ReadLine());

            switch(searchType)
            {
                case "linear":
                    linear(values, searchItem);
                    break;
                case "binary":
                    break;
                case "interpolation":
                    break;
                default:
                    break;
            }
        }

        public static void linear(List<double> values, double searchVal)
        {
            int index;
            for(int i = 0; i < values.Count; i++)
            {
                if(values[i] == searchVal)
                {
                    Console.WriteLine("value has been found at position {0}", i);
                    index = i;
                    break;
                }
            }
            Console.WriteLine("Item has not been found");
        }
    }
}
