﻿using System.Linq;

class Program
{
    static void Main()
    {
        int[] a = { };
        double ave = a.DefaultIfEmpty(-1).Average();
        System.Console.WriteLine(ave);
    }
}
