using LinearAlgebra;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject;

[TestFixture]
public class RealNumberMatrixOperatorsTest
{
    [Test]
    public void DiagonalMatrixTest()
    {
        var randomGenerator = new Random();
        for (var i = 1; i <= 50; i++)
        {
            var value = randomGenerator.NextDouble();
            var diagonalMatrix = new RealNumberMatrix(i, value);

            for (var j = 0; j < diagonalMatrix.StringsNumber; j++)
            {
                for (var k = 0; k < diagonalMatrix.ColumnsNumber; k++)
                {
                    if (j == k)
                    {
                        ClassicAssert.AreEqual(value, diagonalMatrix[j, k], 1e-12);
                    } else
                    {
                        ClassicAssert.AreEqual(0, diagonalMatrix[j, k]);
                    }
                }
            }
        }
    }

    public void CheckMatricesEqual(RealNumberMatrix ourMatrix, double[][] expectedMatrixCoeffs)
    {
        for (var i = 0; i < ourMatrix.StringsNumber; i++)
        {
            for (var j = 0; j < ourMatrix.ColumnsNumber; j++)
            {
                ClassicAssert.AreEqual(expectedMatrixCoeffs[i][j], ourMatrix[i, j], 1e-12);
            }
        }
    }

    [Test]
    public void MatrixSummTest()
    {
        foreach (var currMatrixSet in MatricesForTests.MatricesForSummTest)
        {
            MatrixSummSingleTest(currMatrixSet[0], currMatrixSet[1], currMatrixSet[2]);
        }
    }

    public void MatrixSummSingleTest(double[][] leftMatrixCoeffs, double[][] rightMatrixCoeffs, double[][] expectedFinishMatrixCoeffs)
    {
        var leftMatrix = new RealNumberMatrix(leftMatrixCoeffs);
        var rightMatrix = new RealNumberMatrix(rightMatrixCoeffs);

        var finishMatrix = leftMatrix + rightMatrix;
        CheckMatricesEqual(finishMatrix, expectedFinishMatrixCoeffs);
    }

    [Test]
    public void MatrixNumberMultiplicationTest()
    {
        for (var i = 0; i < MatricesForTests.MatrixNumberMultiplyTestData.Length; i++)
        {
            var currTestData = MatricesForTests.MatrixNumberMultiplyTestData[i];
            MatrixNumberMultiplicationSingleTest(currTestData.baseMatrixCoeffs, currTestData.number, currTestData.expectedMatrixCoeffs);
        }
    }

    public void MatrixNumberMultiplicationSingleTest(double[][] baseMatrixCoeffs, double number, double[][] expectedFinishMatrixCoeffs)
    {
        var baseMatrix = new RealNumberMatrix(baseMatrixCoeffs);
        var finishMatrix = number * baseMatrix;

        CheckMatricesEqual(finishMatrix, expectedFinishMatrixCoeffs);
    }

    [Test]
    public void MatricesMultiplyTest() 
    {
        foreach (var currMatrixSet in MatricesForTests.MatricesForMultiplyTest)
        {
            MatricesMultiplySingleTest(currMatrixSet[0], currMatrixSet[1], currMatrixSet[2]);
        }
    }

    public void MatricesMultiplySingleTest(double[][] leftMatrixCoeffs, double[][] rightMatrixCoeffs, double[][] expectedFinishMatrixCoeffs)
    {
        var leftMatrix = new RealNumberMatrix(leftMatrixCoeffs);
        var rightMatrix = new RealNumberMatrix(rightMatrixCoeffs);

        var finishMatrix = leftMatrix * rightMatrix;
        CheckMatricesEqual(finishMatrix, expectedFinishMatrixCoeffs);
    }
}
