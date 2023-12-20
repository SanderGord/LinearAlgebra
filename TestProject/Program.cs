using LinearAlgebra;
using System.Numerics;
using NUnit.Framework;

namespace TestConsoleProject;

public class Program
{
    static void Main(string[] args)
    {
        var a = new RealAriphmeticLine(new double[] { 1, 2, 3});
        Console.WriteLine(a);
    }
}