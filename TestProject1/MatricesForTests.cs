using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TestProject;

public class MatricesForTests
{
    public static readonly double[][][][] MatricesForSummTest = new double[][][][]
    {
        new double[][][]
        {
            new double[][]
            {
                new double [] { 2, 3 },
                new double [] { 4, 5 },
            },
            new double[][]
            {
                new double [] { 1, 4 },
                new double [] { 8, 5 },
            },

            new double [][]
            {
                new double [] { 3, 7 },
                new double [] { 12, 10 },
            }
        },

        new double[][][]
        {
            new double [][]
            {
                new double [] { 1 }
            },
            new double [][] 
            {
                new double [] { -5 }
            },

            new double[][]
            {
                new double [] { -4 }
            }
        },

        new double [][][]
        {
            new double[][]
            {
                new double [] { -1, 4 },
                new double [] { 1, 4 },
                new double [] { -3, 5 }
            },
            new double[][]
            {
                new double [] { 9, 4 },
                new double [] { 9, -89 },
                new double [] { -11, 9 }
            },

            new double[][]
            {
                new double [] { 8, 8, },
                new double [] { 10, -85 },
                new double [] { -14, 14 }
            }
        },
        
        new double [][][] 
        {
            new double[][]
            {
                new double [] { 9 / 4, 7 / 3 },
                new double [] { -3 / 9, 4 / 2 }
            },
            new double[][]
            {
                new double [] { -1 / 4, 2 / 5 },
                new double [] { 7 / 11, 22 / 2 }
            },

            new double[][]
            {
                new double [] { 2, 41 / 15 },
                new double [] { 10 / 33, 13}
            }
        },
        
        new double [][][]
        {
            new double[][]
            {
                new double[] { 1, 3, 1},
                new double[] { 2, 3, -1},
            },
            new double[][]
            {
                new double[] { 3, 4, 2 },
                new double[] { 4, 5, -1},
            },

            new double[][]
            {
                new double[] { 4, 7, 3 },
                new double[] { 6, 8, -2}
            }
        }
    };

    public static readonly MatrixNumberMultiplySingleTestData[] MatrixNumberMultiplyTestData =
    {
        new MatrixNumberMultiplySingleTestData
            (
                1,
                new double[][]
                {
                    new double []{ 1, 3 },
                },
                new double[][]
                {
                    new double [] { 1, 3 }
                }
            ),

        new MatrixNumberMultiplySingleTestData 
            (
                6,
                new double[][]
                {
                    new double [] { -4, 6 },
                    new double [] { -5, 7 },
                },
                new double [][] 
                {
                    new double [] { -24, 36},
                    new double [] { -30, 42 }
                }
            ),

        new MatrixNumberMultiplySingleTestData 
            (
                -4,
                new double [][] 
                { 
                    new double [] { 6, 1.0/4 },
                    new double [] { -3, 1 }
                },
                new double [][] 
                {
                    new double [] { -24, -1 },
                    new double [] { 12, -4 }
                }
            ),

        new MatrixNumberMultiplySingleTestData 
            (
                5.0/6,
                new double [][]
                {
                    new double [] { 3, 5 }
                },
                new double [][]
                {
                    new double [] { 2.5, 25.0/6 }
                }
            ),

        new MatrixNumberMultiplySingleTestData 
            (
                4,
                new double[][]
                {
                    new double[] { 3, 5 },
                    new double[] { -3, 5 },
                    new double[] { 1, 0 }
                },
                new double[][]
                {
                    new double[] { 12, 20 },
                    new double[] { -12, 20 },
                    new double[] { 4, 0 },
                }
            )
    };

    public static readonly double[][][][] MatricesForMultiplyTest = new double[][][][]
    {
        new double[][][]
        {
            new double[][]
            {
                new double[] { 1, 1 },
                new double[] { 1, 1 }
            },
            new double[][]
            {
                new double[] { 1, 1 },
                new double[] { 1, 1 }
            },

            new double[][]
            {
                new double[] { 2, 2 },
                new double[] { 2, 2 }
            }
        },

        new double[][][]
        {
            new double[][] 
            {
                new double[] { 4, 7 },
                new double[] { 5, 6 }
            },
            new double[][]
            {
                new double[] { 1, 0 },
                new double[] { 0, 1 }
            },

            new double[][]
            {
                new double[] { 4, 7 },
                new double[] { 5, 6 }
            }
        },

        new double[][][]
        {
            new double[][]
            {
                new double[] { 3, 1, 2 },
                new double[] { 5, 4, 1 },
            },
            new double[][]
            {
                new double[] { 2, -3 },
                new double[] { 3, -2 },
                new double[] { 2, 1 }
            },

            new double[][]
            {
                new double [] { 13, -9 },
                new double [] { 24, -22 },
            }
        },

        new double[][][]
        {
            new double[][]
            {
                new double[] { 1, 2 },
                new double[] { 2, 3 },
                new double[] { 3, 4 }
            },
            new double[][]
            {
                new double[] { 3, 1, 2 },
                new double[] { -3, -5, 1},
            },

            new double[][]
            {
                new double[] { -3, -9, 4 },
                new double[] { -3, -13, 7 },
                new double[] { -3, -17, 10 }
            }
        }
    };
}
