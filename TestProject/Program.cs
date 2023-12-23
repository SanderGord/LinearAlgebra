using LinearAlgebra;
using System.Numerics;
using NUnit.Framework;

namespace TestConsoleProject;

public class Program
{
    static void Main(string[] args)
    {
        var a = "aaaa";
        var b = a.Split(' ');
        Console.WriteLine(b[^1]);
    }
}