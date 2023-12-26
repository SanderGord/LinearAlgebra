using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject;

public class MatrixNumberMultiplySingleTestData
{
    public double number;
    public double[][] baseMatrixCoeffs;
    public double[][] expectedMatrixCoeffs;

    public MatrixNumberMultiplySingleTestData (double number, double[][] baseMatrixCoeffs, double[][] expectedMatrixCoeffs)
    {
        this.number = number;
        this.baseMatrixCoeffs = baseMatrixCoeffs;
        this.expectedMatrixCoeffs = expectedMatrixCoeffs;
    }
}
