using System;

namespace NeuralNetworkTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var neural_network = new NeuralNetwork(new int[]{3, 10,5});
            //Console.WriteLine($"Random starting synaptic weights: {neural_network.synaptic_weights[0,0]},{neural_network.synaptic_weights[1,0]},{neural_network.synaptic_weights[2,0]}");
           

            double[,] trainingset_inputs = { { 0, 0, 1 }, { 1, 1, 1 }, { 1, 0, 1 }, { 0, 1, 1 }};
            double[,] trainingset_outputs = { { 0 },{ 1 },{ 1 }, { 0 } };
            neural_network.train(trainingset_inputs,trainingset_outputs,100000);
            //neural_network.train(trainingset_inputs, trainingset_outputs, 5);

            //Console.WriteLine($"New synaptic weights after training: {neural_network.synaptic_weights[0,0]},{neural_network.synaptic_weights[1,0]},{neural_network.synaptic_weights[2,0]}");
            Console.WriteLine($"Predicted probability of [1,0,0] -> {neural_network.predict(new double[,]{ { 1, 0, 0 } })[0,0]}");
            Console.ReadLine();
        }
    }
}