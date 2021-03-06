﻿using System;
using System.Linq;
using System.Reflection;
[AttributeUsage(AttributeTargets.Class)]
public class AutoFlagsAttribute : Attribute
{
    public readonly string Id;
    public AutoFlagsAttribute(string id) { this.Id = id; }
}
[AttributeUsage(AttributeTargets.Field)]
public class FlagNameAttribute : Attribute
{
    public readonly string Name;
    public FlagNameAttribute(string name) { Name = name; }
}
[AttributeUsage(AttributeTargets.Field)]
public class FlagPrefixAttribute : Attribute
{
    public readonly string Name;
    public FlagPrefixAttribute(string name) { Name = name; }
}
[AutoFlags("{1b8d50a1-b073-44c1-ae52-10a89fdbc6d7}")]
public static class Flags
{
    [FlagName("独自拡張設定1")]
    public static int 独自拡張設定1 = 123;
    [FlagPrefix("独自拡張設定2")]
    public static bool 独自拡張設定2 = true;
}
class Program
{
    public static void WalkAll(Action<FieldInfo, string, string> action)
    {
        foreach (var t in AppDomain.CurrentDomain.GetAssemblies().SelectMany(c => c.GetTypes()))
        {
            if (t.GetCustomAttribute<AutoFlagsAttribute>(true) is AutoFlagsAttribute autoFlagAttr)
                foreach (var m in t.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static))
                {
                    if (m.GetCustomAttribute<FlagNameAttribute>(true) is FlagNameAttribute flagName) action(m, autoFlagAttr.Id, flagName.Name);
                    if (m.GetCustomAttribute<FlagPrefixAttribute>(true) is FlagPrefixAttribute prefix) action(m, autoFlagAttr.Id, prefix.Name);
                }
        }
    }
    static void Main()
    {
        WalkAll((fi, id, name) =>
        {
            Console.WriteLine("{0}={1}={2}", id, name, fi.GetValue(null));
        });
    }
}
