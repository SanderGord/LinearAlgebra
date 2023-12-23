using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearAlgebra;

public class RealNumberMatrix
{
    private RealAriphmeticLine[] MatrixStringRepresentation;
    public readonly int StringsNumber;
    private RealAriphmeticLine[] MatrixColumnRepresentation;
    public readonly int ColumnsNumber;

    public double this[int x, int y] { get => MatrixStringRepresentation[x][y]; }
    public RealAriphmeticLine this[int x] { get => MatrixStringRepresentation[x]; }

    //supporting methods for constructors
    private static List<List<double>> ListTranspose(List<List<double>> list)
    {
        var finishList = new List<List<double>>();

        for (var i = 0; i < list.Count; i++)
        {
            var currColumn = new List<double>();
            for (var j = 0; j < list[i].Count; j++)
            {
                currColumn.Add(list[j][i]);
            }
            finishList.Add(currColumn);
        }
        return finishList;
    }

    private static List<List<double>> CastToBaseConstructorType(RealAriphmeticLine[] lines)
    {
        var finishList = new List<List<double>>();
        for (var i = 0; i < lines.Length; i++)
        {
            finishList.Add(lines[i].ToList());
        }
        return finishList;
    }

    private static List<List<double>> CastToBaseConstructorType(double[,] table)
    {
        var finishList = new List<List<double>>();

        for (var i = 0; i < table.GetLength(0); i++)
        {
            var currentLine = new List<double>();
            for (var j = 0; j < table.GetLength(1); j++)
            {
                currentLine.Add(table[i, j]);
            }
            finishList.Add(currentLine);
        }

        return finishList;
    }

    private static List<List<double>> CastToBaseConstructorType(double[][] table)
    {
        var finishList = new List<List<double>>();
        for (var i = 0; i < table.GetLength(0); i++)
        {
            var currentLine = new List<double> { };
            for (var j = 0; j < table[i].GetLength(1); j++)
            {
                currentLine.Add(table[i][j]);
            }
            finishList.Add(currentLine);
        }
        return finishList;
    }

    private static List<double> CreateLineWithZerosAndOneValue(int length, int valuePlace, double value)
    {
        var finishList = new List<double>(length);
        for (var i = 0; i < length; i++)
        {
            if (i == valuePlace)
            {
                finishList[i] = value;
            } else
            {
                finishList[i] = 0;
            }
        }
        return finishList;
    }

    private static List<List<double>> CreateDiagonalMatrix(int dimension, double diagonalValue)
    {
        var finishList = new List<List<double>> { };
        for (var i = 0; i < dimension; i++)
        {
            finishList.Add(CreateLineWithZerosAndOneValue(dimension, i, diagonalValue));
        }
        return finishList;
    }


    //Constructors
    public RealNumberMatrix(List<List<double>> matrixCoeffs)
    {
        StringsNumber = matrixCoeffs.Count;
        ColumnsNumber = matrixCoeffs[0].Count;

        MatrixStringRepresentation = new RealAriphmeticLine[StringsNumber];
        MatrixColumnRepresentation = new RealAriphmeticLine[ColumnsNumber];
        var matrixCoeffsTranspose = ListTranspose(matrixCoeffs);

        for (var i = 0; i < StringsNumber; i++)
        {
            if (matrixCoeffs[i].Count != ColumnsNumber)
            {
                throw new ArgumentException();
            }
            MatrixStringRepresentation[i] = new RealAriphmeticLine(matrixCoeffs[i]);
        }

        for (var i = 0; i < ColumnsNumber; i++)
        {
            if (matrixCoeffsTranspose[i].Count != StringsNumber)
            {
                throw new ArgumentException();
            }
            MatrixColumnRepresentation[i] = new RealAriphmeticLine(matrixCoeffsTranspose[i]);
        }
    }

    public RealNumberMatrix(RealAriphmeticLine[] matrixLines) : this(CastToBaseConstructorType(matrixLines)) { }

    public RealNumberMatrix(double[,] matrixCoeffs) : this(CastToBaseConstructorType(matrixCoeffs)) { }

    public RealNumberMatrix(double[][] matrixCoeffs) : this(CastToBaseConstructorType(matrixCoeffs)) { }

    public RealNumberMatrix(int dimension, double diagonalValue) : this(CreateDiagonalMatrix(dimension, diagonalValue)) { }


    //ariphmetic operations
    public static RealNumberMatrix MatrixSumm(RealNumberMatrix firstMatrix, RealNumberMatrix secondMatrix)
    {
        if (firstMatrix.ColumnsNumber != secondMatrix.ColumnsNumber || firstMatrix.StringsNumber != secondMatrix.ColumnsNumber)
        {
            throw new ArgumentException("Matrices with different size");
        }

        var finishMatrixCoeffs = new double[firstMatrix.StringsNumber, firstMatrix.ColumnsNumber];
        for (var i = 0; i < firstMatrix.StringsNumber; i++)
        {
            for (var j = 0; j < firstMatrix.ColumnsNumber; j++)
            {
                finishMatrixCoeffs[i, j] = firstMatrix[i, j] + secondMatrix[i,j];
            }
        }
        return new RealNumberMatrix(finishMatrixCoeffs);
    }

    public static RealNumberMatrix MatrixNumberMultiply(RealNumberMatrix matrix, double number)
    {
        var finishMatrixCoeffs = new double[matrix.StringsNumber, matrix.ColumnsNumber];
        for (var i = 0; i < matrix.StringsNumber; i++)
        {
            for (var j = 0; j < matrix.ColumnsNumber; i++)
            {
                finishMatrixCoeffs[i, j] = matrix[i, j] * number;
            }
        }
        return new RealNumberMatrix(finishMatrixCoeffs);
    }
    
    public static RealNumberMatrix MatrixDifference(RealNumberMatrix leftMatrix, RealNumberMatrix rightMatrix)
    {
        return MatrixSumm(leftMatrix, MatrixNumberMultiply(rightMatrix, -1));
    }

    public static RealNumberMatrix MatrixNumberDivide(RealNumberMatrix matrix, double number)
    {
        if (Math.Abs(number) < 1e-12)
        {
            throw new DivideByZeroException();
        }
        return MatrixNumberMultiply(matrix, 1 / number) ;
    }

    public static RealNumberMatrix MatricesMultiply(RealNumberMatrix leftMatrix, RealNumberMatrix rightMatrix)
    {
        if (leftMatrix.ColumnsNumber != rightMatrix.StringsNumber)
        {
            throw new ArgumentException("Matrices can't be multiplied");
        }

        var finalMatrixCoeffs = new double[leftMatrix.StringsNumber, rightMatrix.ColumnsNumber];
        for (var i = 0; i < leftMatrix.StringsNumber; i++)
        {
            for (var j = 0; j < rightMatrix.ColumnsNumber; j++)
            {
                finalMatrixCoeffs[i, j] = leftMatrix.MatrixStringRepresentation[i] * rightMatrix.MatrixColumnRepresentation[j];
            }
        }

        return new RealNumberMatrix(finalMatrixCoeffs);
    }

    public static RealNumberMatrix operator +(RealNumberMatrix leftMatrix, RealNumberMatrix rightMatrix) => MatrixSumm(leftMatrix, rightMatrix);
    public static RealNumberMatrix operator *(double number, RealNumberMatrix matrix) => MatrixNumberMultiply(matrix, number);
    public static RealNumberMatrix operator *(RealNumberMatrix matrix, double number) => MatrixNumberMultiply(matrix, number);
    public static RealNumberMatrix operator /(RealNumberMatrix matrix, double number) => MatrixNumberDivide(matrix, number);
    public static RealNumberMatrix operator -(RealNumberMatrix matrix) => MatrixNumberMultiply(matrix, -1);
    public static RealNumberMatrix operator -(RealNumberMatrix left, RealNumberMatrix right) => MatrixDifference(left, right);
    public static RealNumberMatrix operator *(RealNumberMatrix leftMatrix, RealNumberMatrix rightMatrix) => MatricesMultiply(leftMatrix, rightMatrix);
}
