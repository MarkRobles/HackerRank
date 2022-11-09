using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'diagonalDifference' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts 2D_INTEGER_ARRAY arr as parameter.
     */

    public static int diagonalDifference(List<List<int>> arr)
    {
        int totalFilas = arr.Count();
        List<int> NumbersToSumLR = new List<int>();
        List<int> NumbersToSumRL = new List<int>();
        //Read left to rigth
        for (int i = 0; i < totalFilas; i++)
        {
            for (int j = 0; j < arr[i].Count; j++)
            {
                if (i == j)
                {
                    NumbersToSumLR.Add(arr[i][j]);
                    continue;
                }
               
            }
        
        }

        //Read righ to left
        for (int i = 0; i < totalFilas; i++)
        {
            for (int j = arr[i].Count-1; j >-1; j--)
            {
                if (j== (totalFilas-(i+1)))
                {
                    NumbersToSumRL.Add(arr[i][j]);
                    continue;
                }

            }

        }

        int sumLR = NumbersToSumLR.Sum();
        int sumRL = NumbersToSumRL.Sum();

      int  result = sumLR - sumRL;
        return Math.Abs( result);
    }

    /*
    * Complete the 'plusMinus' function below.
    *
    * The function accepts INTEGER_ARRAY arr as parameter.
    */
    public static void plusMinus(List<int> arr)
    {
        //Count positive elements 
      decimal PositiveItems =  arr.Count(x=> x > 0);
        //Count negative elements
        decimal NegativeItems = arr.Count(x => x < 0);
        //Count zero elements
        decimal ZeroItems = arr.Count(x => x == 0);
        //Divide each one by N
        decimal PositiveRatio =  decimal.Divide( PositiveItems ,decimal.Parse(arr.Count().ToString()));
        decimal NegativeRatio = decimal.Divide(NegativeItems, decimal.Parse(arr.Count().ToString()));
        decimal ZeroRatio = decimal.Divide(ZeroItems, decimal.Parse(arr.Count().ToString()));
        //Print them with 6 decimal digits

        Console.WriteLine(PositiveRatio.ToString("N6"));
        Console.WriteLine(NegativeRatio.ToString("N6"));
        Console.WriteLine(ZeroRatio.ToString("N6"));
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        //DiagonalDifference();
        PlusMinus();
    }

    public static void PlusMinus()
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        Result.plusMinus(arr);
    }
    private static void DiagonalDifference()
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<List<int>> arr = new List<List<int>>();

        for (int i = 0; i < n; i++)
        {
            arr.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList());
        }

        int result = Result.diagonalDifference(arr);

        Console.WriteLine(result);
        Console.WriteLine("Presiona una tecla para finalizar");
        Console.ReadKey();
        //textWriter.WriteLine(result);

        //textWriter.Flush();
        //textWriter.Close();
    }
}
