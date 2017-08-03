using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetworkTest
{
    public static class MatrixOperations
    {
        public static T[,] Transpose<T>(this T[,] arr)
        {
            int rowCount = arr.GetLength(0);
            int columnCount = arr.GetLength(1);
            T[,] transposed = new T[columnCount,rowCount];
            for (int column = 0; column < columnCount; column++)
            {
                for (int row = 0; row < rowCount; row++)
                {
                    transposed[column,row] = arr[row,column];
                }
            }
            
            return transposed;
        }

        public static double[,] Dot(this double[,] arr1, double[,] arr2)
        {
            int rowCount1 = arr1.GetLength(0);
            int columnCount1 = arr1.GetLength(1);
            int rowCount2 = arr2.GetLength(0);
            int columnCount2 = arr2.GetLength(1);
            if(columnCount1 != rowCount2 && columnCount2 == rowCount1)
            {
                return arr2.Dot(arr1);
            }
            if (columnCount1 != rowCount2)
            {
                throw new Exception();
            }

            double[,] output = new double[rowCount1, columnCount2];
            for (int c = 0; c < columnCount2; c++)
                {
                for (int r = 0; r < rowCount1; r++)
                {
                    double sum = 0.0;
                    for(int i = 0; i < columnCount1; i++)
                    {
                         sum += arr1[r, i] * arr2[i, c];
                    }
                    output[r, c] = sum;
                }

            }

            return output;

        }

        public static double[,] Sub (this double[,] arr1, double[,] arr2)
        {
            int rowCount1 = arr1.GetLength(0);
            int columnCount1 = arr1.GetLength(1);
            int rowCount2 = arr2.GetLength(0);
            int columnCount2 = arr2.GetLength(1);

            var res = new double[rowCount1, columnCount2];

            if(columnCount2 > 1 || rowCount1 != rowCount2)
            {
                throw new Exception();
            }

            for (int c = 0; c < columnCount1; c++)
            {
                for (int r=0; r<rowCount1; r++)
                {
                    res[r, c] = arr1[r, c] - arr2[r, 0];
                }
            }

            return res;
        }

        public static double[,] Add(this double[,] arr1, double[,] arr2)
        {
            int rowCount1 = arr1.GetLength(0);
            int columnCount1 = arr1.GetLength(1);
            int rowCount2 = arr2.GetLength(0);
            int columnCount2 = arr2.GetLength(1);

            var res = new double[rowCount1, columnCount2];

            if ((columnCount2 > 1 && columnCount1 != columnCount2) || rowCount1 != rowCount2)
            {
                throw new Exception();
            }
            if (columnCount1 != columnCount2)
            {
                for (int c = 0; c < columnCount1; c++)
                {
                    for (int r = 0; r < rowCount1; r++)
                    {
                        res[r, c] = arr1[r, c] + arr2[r, 0];
                    }
                }
            }
            else
            {
                for (int c = 0; c < columnCount1; c++)
                {
                    for (int r = 0; r < rowCount1; r++)
                    {
                        res[r, c] = arr1[r, c] + arr2[r, c];
                    }
                }
            }

            return res;
        }

        public static double[,] Mult(this double[,] arr1, double[,] arr2)
        {
            int rowCount1 = arr1.GetLength(0);
            int columnCount1 = arr1.GetLength(1);
            int rowCount2 = arr2.GetLength(0);
            int columnCount2 = arr2.GetLength(1);

            var res = new double[rowCount1, columnCount2];

            if ((columnCount2 > 1 && columnCount1 != columnCount2) || rowCount1 != rowCount2)
            {
                throw new Exception();
            }
            if(columnCount1 != columnCount2)
            {
                for (int c = 0; c < columnCount1; c++)
                {
                    for (int r = 0; r < rowCount1; r++)
                    {
                        res[r, c] = arr1[r, c] * arr2[r, 0];
                    }
                }
            }
            else
            {
                for (int c = 0; c < columnCount1; c++)
                {
                    for (int r = 0; r < rowCount1; r++)
                    {
                        res[r, c] = arr1[r, c] * arr2[r, c];
                    }
                }
            }
           

            return res;
        }
    }
}
