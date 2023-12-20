using NUnit.Framework;
using NUnit.Framework.Legacy;
using LinearAlgebra;

namespace TestProject1;

[TestFixture]
public class RealAriphmeticLineTest
{
    [Test]
    public void ZeroLineTest()
    {
        for (var i = 1; i < 100; i++) 
        {
            var testedLine = new RealAriphmeticLine(i);
            
            for (var j = 0; j < testedLine.Dimension; j++)
            {
                ClassicAssert.AreEqual(testedLine[j], 0);
            }
        }
    }

    [TestCase(new double[] {1, 2, 3}, new double[] {1, 2, 3}, true)]
    [TestCase(new double[] {1, 4}, new double[] {1, 5}, false)]
    [TestCase(new double[] {1, 4, 7}, new double[] {5, 3}, false)]
    [TestCase(new double[] {4 / 2 * 2}, new double[] {4}, true)]
    [TestCase(new double[] {0, 0, 0, 0}, new double[] {0, 0, 0, 0}, true)]
    [TestCase(new double[] {0}, new double[] {}, false)]
    [TestCase(new double[] {1, 0, 0}, new double[] {0, 0, 0}, false)]
    [TestCase(new double[] {-3, -8, 3}, new double[] {0 - 3, 4 - 12, 3}, true)]
    [TestCase(new double[] {10, -7, 5}, new double[] {-10, -7, -5}, false)]
    [TestCase(new double[] {4.44, -2.3}, new double[] {4.44, -2.3}, true)]
    public void VectorsEqualTest(double[] firstVectorCoeffs, double[] secondVectorCoeffs, bool areVectorsTrullyEqual)
    {
        var firstVector = new RealAriphmeticLine(firstVectorCoeffs);
        var secondVector = new RealAriphmeticLine(secondVectorCoeffs);
        var areVectorsEqual = firstVector == secondVector;
        ClassicAssert.AreEqual(areVectorsTrullyEqual, areVectorsEqual);
    }

    [TestCase(new double[] {1, 0, 94}, new double[] { 3, 5, 0 }, new double[] {4, 5, 94})]
    [TestCase(new double[] {4, 8, 10, 44}, new double[] {88, 74, 12, 4}, new double[] {92, 82, 22, 48})]
    [TestCase(new double[] {-9, -1}, new double[] {1, 3}, new double[] {-8, 2})]
    [TestCase(new double[] {-3, 4, 1, 43, 42}, new double[] {0, 0, 0, 0, 0}, new double[] {-3, 4, 1, 43, 42})]
    public void VectorSummTest(double[] firstVectorCoeffs, double[] secondVectorCoeffs, double[] expectedVectorCoeffs) 
    {
        var firstVector = new RealAriphmeticLine(firstVectorCoeffs);
        var secondVector = new RealAriphmeticLine(secondVectorCoeffs);
        var summVector = firstVector + secondVector;
        var expectedVector = new RealAriphmeticLine(expectedVectorCoeffs);
        ClassicAssert.AreEqual(true, summVector == expectedVector);
    }

    [TestCase(new double[] {1, 4, 3, 2}, 42, new double[] {42, 168, 126, 84})]
    [TestCase(new double[] {3, 1, 4}, -4.45, new double[] {-13.35, -4.45, -17.8})]
    [TestCase(new double[] {3.4, 2.9}, -4.1, new double[] {-13.94, -11.89})]
    public void VectorNumberMultiplyTest(double[] baseVectorCoeffs, double number, double[] expectedVectorCoeffs)
    {
        var baseVector = new RealAriphmeticLine(baseVectorCoeffs);
        var expectedVector = new RealAriphmeticLine(expectedVectorCoeffs);
        var multipliedVector = number * baseVector;
        ClassicAssert.AreEqual(true, multipliedVector == expectedVector);
    }

    [TestCase(new double[] {9, 3, 4}, new double[] {1, 4, 8}, 9 + 3 * 4 + 4 * 8)]
    [TestCase(new double[] {-3, 4, -3, 6}, new double[] {93, 1, 2, -99}, -3 * 93 + 4 * 1 - 3 * 2 - 6 * 99)]
    [TestCase(new double[] {3.0 / 7, -4, 1}, new double[] {1, 1.0 / 3, 4}, 3.0 / 7 - 4 / 3.0 + 4)]
    public void VectorSkalapProductTest(double[] firstVectorCoeffs, double[] secondVectorCoeffs, double expectedResult)
    {
        var firstVector = new RealAriphmeticLine(firstVectorCoeffs);
        var secondVector = new RealAriphmeticLine(secondVectorCoeffs);
        var ourSkalapProduct = RealAriphmeticLine.ScalarVectorProduct(firstVector, secondVector);
        ClassicAssert.AreEqual(expectedResult, ourSkalapProduct, 1e-12);
    }

    [TestCase(new double[] {3, 4, 3}, 5.8309518948453004708741528775456)]
    [TestCase(new double[] {-1, 4, 4}, 5.7445626465380286598506114682189)]
    [TestCase(new double[] {-5, -7, -11}, 13.964240043768941169883924541086)]
    [TestCase(new double[] {0, 0, 0, 0, 0}, 0)]
    public void VectorAbsTest(double[] vectorCoeffs, double expectedAbs)
    {
        var vector = new RealAriphmeticLine(vectorCoeffs);
        var ourAbs = vector.Abs();
        ClassicAssert.AreEqual(expectedAbs, ourAbs, 1e-12);
    }
}