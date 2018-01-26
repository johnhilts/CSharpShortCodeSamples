﻿using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] a = { 1, 2, 3, 1 };
        int[] b = { 1, 3, 5, 3 };
        var a2 = a.ToHashSet();
        var b2 = b.ToHashSet();
        Console.WriteLine("unique a");
        foreach (var item in a2) Console.Write(item);
        Console.WriteLine();
        Console.WriteLine("unique b");
        foreach (var item in b2) Console.Write(item);
        Console.WriteLine();
        Console.WriteLine("union a and b and unique");
        var union = a2.Union(b2);
        foreach (var item in union) Console.Write(item);
        Console.WriteLine();
    }
}
