using LinearAlgebra;
using System.Numerics;
using NUnit.Framework;

namespace TestConsoleProject;

public class Program
{
    static void Main(string[] args)
    {
        var a = new double[][] { new double[] { 1 } }; 
        var DiagMatrix = new RealNumberMatrix(20, 12);
        Console.WriteLine(DiagMatrix[19, 19]);
    }
}