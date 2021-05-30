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



class Solution
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> a = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(aTemp => Convert.ToInt32(aTemp)).ToList();
        int countSwaps = 0;
        for(int j = 0;j<a.Count;j++){
            
            for(int i = 0;i<a.Count-1;i++){
                if(a[i] > a[i+1]){
                    int first = a[i];
                    int second = a[i+1];
                    a.RemoveAt(i);
                    a.Insert(i, second);
                    a.RemoveAt(i+1);
                    a.Insert(i+1, first);
                    countSwaps++;
                }
            
            }
            if(countSwaps == 0){
                break;
            }
        }
        Console.WriteLine("Array is sorted in {0} swaps.",countSwaps);
        Console.WriteLine("First Element: " + a[0]);
        Console.WriteLine("Last Element: " + a[a.Count-1]);
        // Write your code here
    }
}