﻿using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        var listOfLists = new HashSet<int>[]
        {
                new HashSet<int> { 1, 2, 3 },
                new HashSet<int> { 0, 2, 4 },
                new HashSet<int> { 0, 1, 2 }
        };
        var r = listOfLists.Skip(1).Aggregate(listOfLists.First(), (h, e) => { h.IntersectWith(e); return h; });
        foreach (var item in r) System.Console.WriteLine(item);
    }
}
