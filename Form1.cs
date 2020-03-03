using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigitClassifierWithErrorVisualization
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            neuralNetwork = new NeuralNetwork(
                Convert.ToInt32(output_NodesInInput.Text), // Nodes in input layer
                Convert.ToInt32(output_NodesInOutput.Text) // Nodes in output layer
                );
            CollectData();
        }

        // Event Listeners----------------------------------------------------------
        private void button_Run_Click(object sender, EventArgs e)
        {
            ChangeInputStates();
            ChangeButtonStates();
            StartSimulation();
        }

        private void button_AddLayerWithNNodes_Click(object sender, EventArgs e)
        {
            neuralNetwork.AddHiddenLayer(Convert.ToInt32(input_nNodesInNewHiddenLayer.Text));
            output_NumberOfHiddenLayers.Text = (neuralNetwork.nodesPerLayer.Count - 2).ToString();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                Update();
                Application.DoEvents();
            }
            catch
            {
                // Handle unknown errors gracefully
                timer.Enabled = false;
                MessageBox.Show("Oops, something went wrong!", "ERROR");
                button_Reset.PerformClick();
            }
        }

        // Global variables----------------------------------------------------------
        // Path to data files
        const string DATA_PATH = "../../data/";

        // Filenames of the files that contain the test and training data
        const string TRAIN_FILENAME = "optdigits-3.tra";
        const string TEST_FILENAME = "optdigits-3.tes";

        // Percent of the training data to be used as a validation set
        const double VALIDATION_PORTION = 0.2f;

        // Datasets to be used loaded into memory
        List<DigitEntry> trainDigitEntries = new List<DigitEntry>();
        List<DigitEntry> validationDigitEntries = new List<DigitEntry>();
        List<DigitEntry> testDigitEntries = new List<DigitEntry>();

        // Helpful variables
        Timer timer;
        int epoch;
        double numCorrect;
        double numIncorrect;
        double trainingMSE;
        double validationMSE;
        NeuralNetwork neuralNetwork;
        bool runsim;
        bool runmain;

        // User input variables
        double learningRate;

        // Data Collection functions-------------------------------------------------
        private void CollectData()
        {
            // Set up file handlers
            FileStream trainFile = File.OpenRead(DATA_PATH + TRAIN_FILENAME);
            FileStream testFile = File.OpenRead(DATA_PATH + TEST_FILENAME);

            // Create local variable for containing the raw data from the files
            List<double> rawTrainData = ParseData(ref trainFile);
            List<double> rawValidationData;
            List<double> rawTestData = ParseData(ref testFile);

            // Prepare helper variabls for validation set initialization
            int validationDataStartIndex = 0;
            int validationDataCount = (int)(rawTrainData.Count / 65 * VALIDATION_PORTION) * 65;

            // Collect raw validation set data from raw training set data
            rawValidationData = rawTrainData.GetRange(validationDataStartIndex, validationDataCount);
            rawTrainData.RemoveRange(validationDataStartIndex, validationDataCount);

            // Initialize each data set
            InitializeDataset(ref trainDigitEntries, ref rawTrainData);
            InitializeDataset(ref validationDigitEntries, ref rawValidationData);
            InitializeDataset(ref testDigitEntries, ref rawTestData);
        }

        private List<double> ParseData(ref FileStream inFile)
        {
            string line = "";
            string current = "";
            List<double> rawData = new List<double>();

            using (StreamReader streamReader = new StreamReader(inFile))
            {
                line = streamReader.ReadLine();
                while (line != null)
                {
                    foreach (char ch in line)
                    {
                        if (ch != ',') current += ch;
                        else
                        {
                            rawData.Add(Convert.ToDouble(current));
                            current = "";
                        }
                    }
                    rawData.Add(Convert.ToDouble(current));
                    current = "";
                    line = streamReader.ReadLine();
                }
            }

            return rawData;
        }

        private void InitializeDataset(ref List<DigitEntry> dataset, ref List<double> rawData)
        {
            for (int i = 0; i < rawData.Count; i += DigitEntry.NUM_PIX_VALUES + 1)
            {
                List<double> dataSection = rawData.GetRange(i, DigitEntry.NUM_PIX_VALUES + 1);
                dataset.Add(new DigitEntry(dataSection));
            }
        }

        // Helper functions----------------------------------------------------------
        private void ChangeInputStates()
        {
            input_nNodesInNewHiddenLayer.Enabled = !input_nNodesInNewHiddenLayer.Enabled;
            input_LearningRate.Enabled = !input_LearningRate.Enabled;
        }

        private void ChangeButtonStates()
        {
            button_AddLayerWithNNodes.Enabled = !button_AddLayerWithNNodes.Enabled;
            button_Run.Enabled = !button_Run.Enabled;
            button_PlayPause.Enabled = !button_PlayPause.Enabled;
            button_Reset.Enabled = !button_Reset.Enabled;
        }

        private void CollectInputs()
        {
            learningRate = Convert.ToDouble(input_LearningRate.Text);
        }

        public void SetUpTimer()
        {
            timer = new Timer();
            timer.Tick += Timer_Tick;
            timer.Interval = 1;
            timer.Start();
        }

        public void Update()
        {
            output_Epoch.Text = epoch.ToString();
            output_Accuracy.Text = (100 * numCorrect / (numCorrect + numIncorrect)).ToString() + "%";
            output_TrainingMSE.Text = trainingMSE.ToString();
            output_ValidationMSE.Text = validationMSE.ToString();
            chart_MSEs.Width = splitContainer1.Panel2.Width;
            chart_MSEs.Height = splitContainer1.Panel2.Height;
        }

        private int FindIndexOfMax(List<double> list)
        {
            int indexOfMax = 0;
            for (int i = 0; i < list.Count; ++i)
            {
                indexOfMax = list[indexOfMax] < list[i] ? i : indexOfMax;
            }
            return indexOfMax;
        }

        private double CalcMSE(List<double> target, List<double> actual)
        {
            double mse = 0;
            for (int i = 0; i < target.Count; ++i)
            {
                mse += Math.Pow(target[i] - actual[i], 2);
            }
            return mse;
        }

        // Starting point of the main application-------------------------------------
        private void StartSimulation()
        {
            try
            {
                CollectInputs();
                epoch = 0;
                runsim = true;
                runmain = true;
                chart_MSEs.Visible = true;

                neuralNetwork.BuildWeightMatrices();
                SetUpTimer();
                while (runmain)
                {
                    chart_MSEs.Height = splitContainer1.Panel2.Height;
                    chart_MSEs.Width = splitContainer1.Panel2.Width;
                    while (runsim)
                    {
                        if (epoch % 10 == 0)
                        {
                            numCorrect = 0;
                            numIncorrect = 0;
                            trainingMSE = 0;
                            validationMSE = 0;

                            foreach (DigitEntry entry in testDigitEntries)
                            {
                                List<double> classification = neuralNetwork.FeedForward(entry.getDataValues());
                                if (FindIndexOfMax(classification) == FindIndexOfMax(entry.getDesiredOutputs())) numCorrect++;
                                else numIncorrect++;
                            }

                            foreach (DigitEntry entry in trainDigitEntries)
                            {
                                List<double> classification = neuralNetwork.FeedForward(entry.getDataValues());
                                trainingMSE += CalcMSE(entry.getDesiredOutputs(), classification);
                            }
                            trainingMSE /= trainDigitEntries.Count;
                            chart_MSEs.Series[0].Points.AddXY(epoch, trainingMSE);

                            foreach (DigitEntry entry in validationDigitEntries)
                            {
                                List<double> classification = neuralNetwork.FeedForward(entry.getDataValues());
                                validationMSE += CalcMSE(entry.getDesiredOutputs(), classification);
                            }
                            validationMSE /= validationDigitEntries.Count;
                            chart_MSEs.Series[1].Points.AddXY(epoch, validationMSE);
                        }
                        else
                        {
                            foreach (DigitEntry entry in trainDigitEntries)
                            {
                                neuralNetwork.Train(entry.getDataValues(), entry.getDesiredOutputs(), learningRate);
                            }
                        }
                        epoch++;
                        Application.DoEvents();
                    }
                    Application.DoEvents();
                }
            }
            catch
            {
                MessageBox.Show("Oops, something went wrong!", "ERROR");
                button_Reset.PerformClick();
            }
        }

        private void button_PlayPause_Click(object sender, EventArgs e)
        {
            string resume = "Resume Simulation";
            string pause = "Pause Simulation";
            button_PlayPause.Text = runsim ? resume : pause;
            runsim = !runsim;
        }

        private void button_Reset_Click(object sender, EventArgs e)
        {
            ChangeButtonStates();
            ChangeInputStates();
            runsim = false;
            runmain = false;
            button_PlayPause.Text = "Pause Simulation";
            chart_MSEs.Series[0].Points.Clear();
            chart_MSEs.Series[1].Points.Clear();
            chart_MSEs.Visible = false;
            neuralNetwork = new NeuralNetwork(
                Convert.ToInt32(output_NodesInInput.Text), // Nodes in input layer
                Convert.ToInt32(output_NodesInOutput.Text) // Nodes in output layer
                );
            output_NumberOfHiddenLayers.Text = (neuralNetwork.nodesPerLayer.Count - 2).ToString();
        }
    }
}
