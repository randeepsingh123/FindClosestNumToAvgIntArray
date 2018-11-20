using System;
using System.Linq;

namespace FindClosestNumInArrayWithLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 1, 2, 3, 5, -1, 7, 145, -33, 22, 14 };
            Nullable<int> output = getClosestElementtoAverage(array);
            Console.WriteLine("output::" + output.ToString());
            Console.ReadLine();
        }

        //This function finds and return the closest number to the average of int array that is passed as a parameter to this function
        private static Nullable<int> getClosestElementtoAverage(int[] arr)
        {
            //check the edge case if the array is null
            if (arr != null)
            {
                //use LINQ to get the array in ascending order
                var sortedValues = (from value in arr

                                 orderby (int)value ascending
                                 select value);
                //LINQ to get average of integer array
                double average = sortedValues.Average();
                //check the case if the average is 0 and the list contains only 1 element
                if (average != 0 && sortedValues.Count() > 1)
                {
                    //if the average is present in the input integer array, return average
                    if (!sortedValues.Contains((int)average))
                    {
                        //get the element in the array that is less than average
                        var OneLessValue = sortedValues.TakeWhile(p => p < average).Last();
                        //get the element in the array that is greater than average
                        var OneMoreValue = sortedValues.SkipWhile(p => p <= average).First();
                        //print average
                        Console.WriteLine("Average::" + sortedValues.Average());
                        //check if the element that is less than or greater than average is closer to average
                        if (average - OneLessValue < OneMoreValue - average)
                        {
                            //return OneLessValue if difference to average is less
                            return OneLessValue;
                        }
                        else
                        {
                            //return OneMoreValue if difference to average is less
                            return OneMoreValue;
                        }
                    }
                    else
                    {
                        //return average if the number exists in the array
                        return (int)average;
                    }
                }
                else
                {
                    //return the first element
                    return (sortedValues.ElementAt(0));
                }
            }
            else
            {
                //return null
                return null;
            }
        }
    }
}
