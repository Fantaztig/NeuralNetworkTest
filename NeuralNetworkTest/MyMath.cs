using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetworkTest
{
    class MyMath
    {
        public static double sigmoid(double x)
        {
            return 1.0 / (1.0 + Math.Exp(-x));
        }

        public static double[,] sigmoid(double[,] arrx)
        {
            var res = (double[,])arrx.Clone();
            for (int r= 0; r < arrx.GetLength(0); r++){
                for (int c = 0; c < arrx.GetLength(1); c++)
                {
                    res[r, c] = sigmoid(arrx[r, c]);
                }
            }
            return res;
        }

        public static double sigmoid_derivative(double x)
        {
            return x * (1 - x);
        }

        public static double[,] sigmoid_derivative(double[,] arrx)
        {
            var res = (double[,])arrx.Clone();
            for (int r = 0; r < arrx.GetLength(0); r++)
            {
                for (int c = 0; c < arrx.GetLength(1); c++)
                {
                    res[r, c] = sigmoid_derivative(arrx[r, c]);
                }
            }
            return res;
        }
    }
}
