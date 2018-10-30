using System;
using System.Linq;

namespace NeuralNetworkTest
{
    internal class NeuralNetwork
    {
        public double[][,] weights;
        private static Random rnd = new Random(1);
        private int layers;
        //[3,4,4] -> 3 input variables, 3 layers, 1 output (fixed)
        public NeuralNetwork(int[] inputs_per_layer)
        {
            layers = inputs_per_layer.Length;
            inputs_per_layer = inputs_per_layer.Append(1).ToArray();
            weights = new double[layers][,];
            for(int i = 0; i < layers; i++)
            {
                weights[i] = initWeigths(inputs_per_layer[i], inputs_per_layer[i + 1]);
            }
        }

        private static double[,] initWeigths(int rows, int columns)
        {
            var res = new double[rows, columns];
            for(int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    res[r,c] = rnd.NextDouble() * 2 - 1;
                }
            }
            return res;
        }

        public double[,] predict (double[,] inputs)
        {
            for (int i = 0; i < layers; i++)
            {
                inputs = MyMath.sigmoid(inputs.Dot(weights[i]));
            }
            
            return inputs;
        }

        public void train(double[,] inputs, double[,] outputs, int num_iterations)
        {

            for (int i = 0; i < num_iterations; i++)
            {
                double[][,] input = new double[layers+1][,];
                input[0] = inputs;
                //Calculate layer inputs + output (input[layers] == output)
                for (int j = 0; j < layers; j++)
                {
                    input[j+1] = MyMath.sigmoid(input[j].Dot(weights[j]));
                }

                var del = new double[layers][,];
                //Calculate error based on expected output
                del[layers-1] = outputs.Sub(input[layers]).Mult(MyMath.sigmoid_derivative(input[layers])).Transpose();
                //Calculate remaining errors
                for(int j = layers - 1; j > 0; j--)
                {
                    del[j - 1] = weights[j].Dot(del[j]).Mult(MyMath.sigmoid_derivative(input[j]).Transpose());
                }
                //transpose 4 the lulz
                del[layers-1] = del[layers-1].Transpose();

                //Adjust weights
                var adj = new double[layers][,];
                //First one is different again for whatever reasons
                adj[layers - 1] = input[layers - 1].Transpose().Dot(del[layers - 1]);
                weights[layers - 1] = weights[layers - 1].Add(adj[layers - 1]);

                for(int j = layers - 1; j > 0; j--)
                {
                    adj[j-1] = input[j-1].Dot(del[j-1]).Transpose();
                    weights[j - 1] = weights[j - 1].Add(adj[j - 1]);
                }
            }
        }

        
    }

    
}
