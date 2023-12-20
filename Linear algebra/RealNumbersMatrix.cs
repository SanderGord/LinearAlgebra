using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearAlgebra;

public class RealNumbersMatrix
{
    private RealAriphmeticLine[] MatrixStringRepresentation;
    public readonly int StringsNumber;
    private RealAriphmeticLine[] MatrixColumnRepresentation;
    public readonly int ColumnsNumber;

    public double this[int x, int y] { get => MatrixStringRepresentation[x][y]; }
    public RealAriphmeticLine this[int x] { get => MatrixStringRepresentation[x]; }


    
    public RealNumbersMatrix(List<List<double>> matrixCoeffs)
    {
        StringsNumber = matrixCoeffs.Count;
        ColumnsNumber = matrixCoeffs[0].Count;

        MatrixStringRepresentation = new RealAriphmeticLine[StringsNumber];
        MatrixColumnRepresentation = new RealAriphmeticLine[ColumnsNumber];
    }

    //Constructors
    public RealNumbersMatrix(RealAriphmeticLine[] matrixLines)
    {
        StringsNumber = matrixLines.Length;
        ColumnsNumber = matrixLines[0].Dimension;
        MatrixStringRepresentation = new RealAriphmeticLine[StringsNumber];


        for (var i =  0; i < matrixLines.Length; i++)
        {
            MatrixStringRepresentation[i]  = new RealAriphmeticLine(matrixLines[i]);
        }
    }
}
