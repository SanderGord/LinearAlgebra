using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearAlgebra;

public class LinalgMethods
{
    public static bool PlaceNumberOneDimensionCorrectCheck(int placeNumber, int dimensionLength)
    {
        return placeNumber < 0 || placeNumber >= dimensionLength;
    }

    public static void PlaceMatrixCheck(RealNumberMatrix matrix, int stringNumber, int columnNumber)
    {
        if (PlaceNumberOneDimensionCorrectCheck(stringNumber, matrix.StringsNumber))
        {
            throw new ArgumentException("String with number: " + stringNumber.ToString() + " doesn't exist in current matrix");
        }
        if (PlaceNumberOneDimensionCorrectCheck(columnNumber, matrix.ColumnsNumber))
        {
            throw new ArgumentException("Column with number: " + columnNumber.ToString() + " doesn't exist in current matrix");
        }
    }

    public static RealNumberMatrix FirstMinor(RealNumberMatrix matrix, int stringNumber, int columnNumber)
    {
        var finishMatrixCoeffs = new List<List<double>>();
        PlaceMatrixCheck(matrix, stringNumber, columnNumber);

        for (var i = 0; i < matrix.StringsNumber; i++)
        {
            var currString = new List<double>();
            for (var j = 0; j < matrix.ColumnsNumber; j++)
            {
                if (j != columnNumber)
                {
                    currString.Add(matrix[i, j]);
                }
            }
            if (i != stringNumber)
            {
                finishMatrixCoeffs.Add(currString);
            }
        }
        return new RealNumberMatrix(finishMatrixCoeffs);
    }

    public static double Determinant(RealNumberMatrix matrix)
    {
        if (matrix.StringsNumber != matrix.ColumnsNumber)
        {
            throw new ArgumentException("Can't calculate determinant of none-square matrix");
        }

        if (matrix.StringsNumber == 1)
        {
            return matrix[0, 0];
        }

        var result = 0d;
        for (var i = 0; i < matrix.ColumnsNumber; i++) 
        {
            if (i % 2 == 0)
            {
                result += matrix[0, i] * Determinant(FirstMinor(matrix, 0, i));
            } else
            {
                result -= matrix[0, i] * Determinant(FirstMinor(matrix, 0, i));
            }
        }
        return result;
    }
}