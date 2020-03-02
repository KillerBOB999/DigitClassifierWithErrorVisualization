using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Included from NuGet package MathNet.Numerics
// for Matrix operations
using MathNet.Numerics.LinearAlgebra;

namespace DigitClassifierWithErrorVisualization
{
    class NeuralNetwork
    {
        // Value information
        Matrix<double> inputLayer;
        List<Matrix<double>> weights;
        List<Matrix<double>> hiddenLayers;
        Matrix<double> outputLayer;

        Matrix<double> desiredOutputLayer;

        // Number of Neurons in each layer where [0] == input and [Count-1] == output
        public List<int> nodesPerLayer = new List<int>();

        public NeuralNetwork(int numInputs, int numOutputs)
        {
            // Initialize the layers themselves
            inputLayer = Matrix<double>.Build.Dense(numInputs, 1);
            outputLayer = Matrix<double>.Build.Dense(numOutputs, 1);
            desiredOutputLayer = Matrix<double>.Build.Dense(numOutputs, 1);

            nodesPerLayer.Add(numInputs);
            nodesPerLayer.Add(numOutputs);
        }

        // Adds hidden layer just before the output layer
        public void AddHiddenLayer(int numOfNodes)
        {
            nodesPerLayer.Insert(nodesPerLayer.Count - 1, numOfNodes);
        }

        // Build the weight matrices for each of the layers
        public void BuildWeightMatrices()
        {
            Random rng = new Random();
            weights = new List<Matrix<double>>();
            hiddenLayers = new List<Matrix<double>>();
            for (int layer = 0; layer < nodesPerLayer.Count - 1; ++layer)
            {
                weights.Add(Matrix<double>.Build.Random(nodesPerLayer[layer + 1], nodesPerLayer[layer]));
                if (layer > 0) hiddenLayers.Add(Matrix<double>.Build.Dense(nodesPerLayer[layer], 1));
            }
        }

        public void Train(List<double> input, List<double> desiredOutputs, double learningRate)
        {
            ListToMatrix(ref desiredOutputs, ref desiredOutputLayer);
            FeedForward(input);
            Backpropagate(desiredOutputs, learningRate);
        }

        // Feed the input forward through the network
        public List<double> FeedForward(List<double> input)
        {
            ListToMatrix(ref input, ref inputLayer);

            Matrix<double> currentProgress = inputLayer;
            //foreach (Matrix<double> weightMatrix in weights)
            //{
            //    currentProgress = weightMatrix * currentProgress;
            //    for (int row = 0; row < currentProgress.RowCount; ++row)
            //    {
            //        for (int col = 0; col < currentProgress.ColumnCount; ++col)
            //        {
            //            currentProgress[row, col] = Sigmoid(currentProgress[row, col]);
            //        }
            //    }
            //}
            for (int weightMatrixIndex = 0; weightMatrixIndex < weights.Count; ++weightMatrixIndex)
            {
                currentProgress = weights[weightMatrixIndex] * currentProgress;
                for (int row = 0; row < currentProgress.RowCount; ++row)
                {
                    for (int col = 0; col < currentProgress.ColumnCount; ++col)
                    {
                        currentProgress[row, col] = Sigmoid(currentProgress[row, col]);
                        if (weights.Count > 1 && weightMatrixIndex < weights.Count - 1) 
                            hiddenLayers[weightMatrixIndex][row, col] = currentProgress[row, col];
                    }
                }
            }
            outputLayer = currentProgress;

            // Convert the newly calculated output into a List
            // for easier use and for dependency segmentation
            List<double> output = new List<double>();
            for (int nodeIndex = 0; nodeIndex < nodesPerLayer[nodesPerLayer.Count - 1]; ++nodeIndex)
            {
                output.Add(currentProgress[nodeIndex, 0]);
            }
            return output;
        }

        private void Backpropagate(List<double> desiredOutputs, double learningRate)
        {
            // weight = weight - learningRate * Gradient
            ListToMatrix(ref desiredOutputs, ref desiredOutputLayer);
            //double error = Cost();

            // Derivative stuff
            // Derivative of sigmoid == sigmoid(x) * (1 - sigmoid(x))
            // Derivative of Cost == 2(actualOutput - targetOutput)
            // Derivative of the activation == activation of Layer L-1
            for (int weightMatrixIndex = weights.Count - 1; weightMatrixIndex >= 0; --weightMatrixIndex)
            {
                Matrix<double> gradient = FindGradient(ref outputLayer, ref inputLayer, ref desiredOutputLayer, weights[weightMatrixIndex]);
                weights[weightMatrixIndex] = weights[weightMatrixIndex] - learningRate * gradient;
            }
        }

        private Matrix<double> FindGradient(ref Matrix<double> LayerL, ref Matrix<double> LayerLminus1, ref Matrix<double> targetOfLayerL, Matrix<double> weightsBetweenLayers)
        {
            Matrix<double> gradient = Matrix<double>.Build.Dense(weightsBetweenLayers.RowCount, weightsBetweenLayers.ColumnCount);
            for (int rowInGradient = 0; rowInGradient < gradient.RowCount; ++rowInGradient)
            {
                for (int colInGradient = 0; colInGradient < gradient.ColumnCount; ++colInGradient)
                {
                    for (int rowInLayerLminus1 = 0; rowInLayerLminus1 < LayerLminus1.RowCount; ++rowInLayerLminus1)
                    {
                        gradient[rowInGradient, colInGradient] += (
                                LayerL[rowInGradient, 0] * (1 - LayerL[rowInGradient, 0]) *
                                2 * (LayerL[rowInGradient, 0] - targetOfLayerL[rowInGradient, 0]) *
                                LayerLminus1[rowInLayerLminus1, 0]
                            );
                    }
                }
            }
            return gradient;
        }

        // Sigmoid activation function
        private double Sigmoid(double nodeValue)
        {
            return (1.0 / (1.0 + Math.Pow(Math.E, -nodeValue)));
        }

        private Matrix<double> ListToMatrix(ref List<double> list, ref Matrix<double> matrix)
        {
            // Convert the list into a Matrix format that the 
            // MathNet.Numerics.LinearAlgebra library can handle
            for (int i = 0; i < list.Count; ++i)
            {
                matrix[i, 0] = list[i];
            }
            return matrix;
        }

        private double Cost(ref Matrix<double> actualLayer, ref Matrix<double> desiredLayer)
        {
            double sum = 0;
            for (int i = 0; i < desiredLayer.RowCount; ++i)
            {
                sum += Math.Pow(actualLayer[i, 0] - desiredLayer[i, 0], 2);
            }
            return sum;
        }
    }
}
