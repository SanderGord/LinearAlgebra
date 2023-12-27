using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject;

public class DeterminantAndTraceSingleTestData
{
    public readonly double[][] matrixCoeffs;
    public readonly double expectedDeterminant;
    public readonly double expectedTrace;

    public DeterminantAndTraceSingleTestData(double[][] matrixCoeffs, double expectedDeterminant = 0, double expectedTrace = 0)
    {
        this.matrixCoeffs = matrixCoeffs;
        this.expectedDeterminant = expectedDeterminant;
        this.expectedTrace = expectedTrace;
    }
}
