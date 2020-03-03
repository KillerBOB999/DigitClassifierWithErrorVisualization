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

        List<Matrix<double>> layers = new List<Matrix<double>>();

        Matrix<double> desiredOutputLayer;

        // List of calculated error for each node in every layer
        // after the input layer. Input layer NOT included.
        List<Matrix<double>> costPerNodePerLayer = new List<Matrix<double>>();

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

            costPerNodePerLayer.Add(Matrix<double>.Build.Dense(numOutputs, 1));
        }

        // Adds hidden layer just before the output layer
        public void AddHiddenLayer(int numOfNodes)
        {
            nodesPerLayer.Insert(nodesPerLayer.Count - 1, numOfNodes);
            costPerNodePerLayer.Insert(costPerNodePerLayer.Count - 1, Matrix<double>.Build.Dense(numOfNodes, 1));
        }

        // Build the weight matrices for each of the layers
        public void BuildWeightMatrices()
        {
            weights = new List<Matrix<double>>();
            hiddenLayers = new List<Matrix<double>>();
            layers.Add(inputLayer);
            for (int layer = 0; layer < nodesPerLayer.Count - 1; ++layer)
            {
                weights.Add(Matrix<double>.Build.Random(nodesPerLayer[layer + 1], nodesPerLayer[layer]));
                if (layer > 0)
                {
                    hiddenLayers.Add(Matrix<double>.Build.Dense(nodesPerLayer[layer], 1));
                    layers.Add(hiddenLayers[hiddenLayers.Count - 1]);
                }
            }
            layers.Add(outputLayer);
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
            layers[layers.Count - 1] = outputLayer;

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

            // Derivative stuff
            // Derivative of sigmoid == sigmoid(x) * (1 - sigmoid(x))
            // Derivative of Cost == 2(actualOutput - targetOutput)
            // Derivative of the activation == activation of Layer L-1

            // Find output layer cost
            costPerNodePerLayer[costPerNodePerLayer.Count - 1] = LayerCost(ref outputLayer, ref desiredOutputLayer);
            Matrix<double> activeLayer;
            Matrix<double> activeWeights;
            Matrix<double> layerLminus1;
            Matrix<double> activeErrors;

            for (int weightMatrixIndex = weights.Count - 1; weightMatrixIndex >= 0; --weightMatrixIndex)
            {
                activeLayer = layers[weightMatrixIndex + 1];
                activeWeights = weights[weightMatrixIndex];
                layerLminus1 = layers[weightMatrixIndex];
                activeErrors = costPerNodePerLayer[weightMatrixIndex];
                if (weightMatrixIndex != 0) costPerNodePerLayer[weightMatrixIndex - 1] = LayerCost(ref layerLminus1, ref activeErrors, ref activeWeights);

                Matrix<double> gradient = FindGradient(ref activeLayer, ref layerLminus1, ref activeErrors, ref activeWeights);
                weights[weightMatrixIndex] = weights[weightMatrixIndex] - learningRate * gradient;
            }
        }

        private Matrix<double> FindGradient(ref Matrix<double> LayerL, ref Matrix<double> LayerLminus1, ref Matrix<double> errorOfLayerL, ref Matrix<double> weightsBetweenLayers)
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
                                2 * errorOfLayerL[rowInGradient, 0] *
                                LayerLminus1[rowInLayerLminus1, 0]
                                //weightsBetweenLayers[rowInGradient, colInGradient]
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

        private Matrix<double> LayerCost(ref Matrix<double> actualLayer, ref Matrix<double> desiredLayer)
        {
            Matrix<double> layerCost = Matrix<double>.Build.Dense(actualLayer.RowCount, actualLayer.ColumnCount);
            for (int i = 0; i < desiredLayer.RowCount; ++i)
            {
                layerCost[i, 0] = actualLayer[i, 0] - desiredLayer[i, 0];
            }
            return layerCost;
        }

        private Matrix<double> LayerCost(ref Matrix<double> layerL, ref Matrix<double> layerLplus1Errors, ref Matrix<double> weightsBetweenLandLplus1)
        {
            Matrix<double> layerCost = Matrix<double>.Build.Dense(layerL.RowCount, layerL.ColumnCount);

            for (int row = 0; row < weightsBetweenLandLplus1.RowCount; ++row)
            {
                for (int col = 0; col < weightsBetweenLandLplus1.ColumnCount; ++col)
                {
                    layerCost[col, 0] += weightsBetweenLandLplus1[row, col] * layerLplus1Errors[row, 0];
                }
            }

            return layerCost;
        }
    }
}
