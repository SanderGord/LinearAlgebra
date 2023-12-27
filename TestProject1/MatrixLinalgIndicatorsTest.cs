using LinearAlgebra;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TestProject;

[TestFixture]
public class MatrixLinalgIndicatorsTest
{
    [Test]
    public void DeterminantTraceTest()
    {
        foreach (var testData in MatricesForTests.DeterminantTraceTestMatrices)
        {
            DeterminantSingleTest(testData.matrixCoeffs, testData.expectedDeterminant);
            TraceSingleTest(testData.matrixCoeffs, testData.expectedTrace);
        }
    }

    public void DeterminantSingleTest(double[][] matrixCoeffs, double expectedDeterminant)
    {
        var matrix = new RealNumberMatrix(matrixCoeffs);
        var determinant = matrix.Determinant();
        ClassicAssert.AreEqual(expectedDeterminant, determinant, 1e-12);
    }

    public void TraceSingleTest(double[][] matrixCoeffs, double expectedTrace)
    {
        var matrix = new RealNumberMatrix(matrixCoeffs);
        var trace = matrix.Trace();
        ClassicAssert.AreEqual(expectedTrace, trace, 1e-12);
    }
}
