using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LinearAlgebra;

public class RealAriphmeticLine
{
    private double[] Coordinates {  get; set; }
    public readonly int Dimension;
    public double this[int i] { get => Coordinates[i]; }



    //Constructors
    public RealAriphmeticLine(List<double> baseCoordinates)
    {
        Dimension = baseCoordinates.Count;
        Coordinates = new double[Dimension];

        for (int i = 0; i < Dimension; i++)
        {
            Coordinates[i] = baseCoordinates[i];
        }
    }

    public RealAriphmeticLine(double[] baseCoordinates) : this(baseCoordinates.ToList()) { }

    public RealAriphmeticLine(int dimension, double everyPositionValue) 
    {
        Dimension = dimension;
        Coordinates = new double[Dimension];
        for (var i = 0; i < Dimension; i++)
        {
            Coordinates[i] = everyPositionValue;
        }
    }

    public RealAriphmeticLine(int dimension) : this(dimension, 0) { }

    public RealAriphmeticLine(RealAriphmeticLine baseLine) : this(baseLine.ToList()) { }



    //Vector space operations
    public static RealAriphmeticLine Summ(RealAriphmeticLine firstVector, RealAriphmeticLine secondVector)
    {
        if (firstVector.Dimension !=  secondVector.Dimension)
        {
            throw new ArgumentException("Unsummable vectors with different Dimensions");
        }

        var finishCoordinates = new double[firstVector.Dimension];
        for (var i = 0; i  < firstVector.Dimension; i++) 
        {
            finishCoordinates[i] = firstVector[i] + secondVector[i];
        }

        return new RealAriphmeticLine(finishCoordinates);
    }

    public static RealAriphmeticLine RealNumberMultiply(RealAriphmeticLine vector, double number)
    {
        var finishCoordinates = new double[vector.Dimension];
        for (var i = 0; i < vector.Dimension; i++) 
        {
            finishCoordinates[i] = vector[i] * number;
        }
        return new RealAriphmeticLine(finishCoordinates);
    }

    public static RealAriphmeticLine Difference(RealAriphmeticLine firstVector, RealAriphmeticLine secondVector)
    {
        return Summ(firstVector, RealNumberMultiply(secondVector, -1));
    }

    public static RealAriphmeticLine RealNumberDivide(RealAriphmeticLine vector, double number)
    {
        if (Math.Abs(number) <= 1e-12)
        {
            throw new DivideByZeroException();
        }
        return RealNumberMultiply(vector, 1 / number);
    }
    
    public static RealAriphmeticLine operator +(RealAriphmeticLine firstVector, RealAriphmeticLine secondVector) => Summ(firstVector, secondVector);
    public static RealAriphmeticLine operator *(double scalar, RealAriphmeticLine vector) => RealNumberMultiply(vector, scalar);
    public static RealAriphmeticLine operator -(RealAriphmeticLine firstVector) => -1 * firstVector;
    public static RealAriphmeticLine operator -(RealAriphmeticLine firstVector, RealAriphmeticLine secondVector) => Difference(firstVector, secondVector);
    public static RealAriphmeticLine operator /(RealAriphmeticLine vector, double scalar) => RealNumberDivide(vector, scalar);



    //scalar product operations
    public static double ScalarVectorProduct(RealAriphmeticLine firstVector, RealAriphmeticLine secondVector)
    {
        if (firstVector.Dimension != secondVector.Dimension)
        {
            throw new ArgumentException("Vectors with different dimensions can't be skalarly producted");
        }

        var finalProduct = 0d;
        for (var i = 0; i < firstVector.Dimension; i++)
        {
            finalProduct += firstVector[i] * secondVector[i];
        }
        return finalProduct;
    }

    public static double operator *(RealAriphmeticLine firstVector, RealAriphmeticLine secondVector) => ScalarVectorProduct(firstVector, secondVector);

    public double Abs()
    {
        return Math.Sqrt(ScalarVectorProduct(this, this));
    }



    //compare operations
    public static bool AreEqual(RealAriphmeticLine firstVector, RealAriphmeticLine secondVector)
    {
        if (firstVector.Dimension != secondVector.Dimension)
        {
            return false;
        }

        var finish = true;
        for (var i = 0; i < firstVector.Dimension; i++)
        {
            finish = finish && (Math.Abs(firstVector[i] - secondVector[i]) < 1e-12);
        }
        return finish;
    }

    public static bool IsLineAllZero(RealAriphmeticLine line)
    {
        var zeroLine = new RealAriphmeticLine(line.Dimension);
        return AreEqual(zeroLine, line);
    }

    public static bool operator ==(RealAriphmeticLine firstVector, RealAriphmeticLine secondVector) => AreEqual(firstVector, secondVector);
    public static bool operator !=(RealAriphmeticLine firstVector, RealAriphmeticLine secondVector) => !AreEqual(firstVector, secondVector);


    //other operations
    public override string ToString()
    {
        var stringRepresentation = new StringBuilder();
        for (var i = 0; i < Dimension; i++)
        {
            stringRepresentation.Append(this[i]);
            stringRepresentation.Append(' ');
        }
        return stringRepresentation.ToString();
    }
    
    public List<double> ToList()
    {
        var list = new List<double>();
        for (var i = 0; i < Dimension; i++)
        {
            list.Add(this[i]);
        }
        return list;
    }
}
