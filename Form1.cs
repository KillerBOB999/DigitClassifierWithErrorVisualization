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
            button_Run.Enabled = false;
            button_PlayPause.Enabled = true;
            button_Reset.Enabled = true;
            ChangeInputStates();
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
                //if (epoch % 10 == 0) UpdateChart();
                //else Train();
                //Update();
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
        Bitmap bitmap;
        NeuralNetwork neuralNetwork;

        // User input variables
        double validationSetPortion;
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
            input_ValidationSetPortion.Enabled = !input_ValidationSetPortion.Enabled;
        }

        private void CollectInputs()
        {
            validationSetPortion = Convert.ToDouble(input_ValidationSetPortion.Text);
            learningRate = Convert.ToDouble(input_LearningRate.Text);
        }

        public void SetUpTimer()
        {
            timer = new Timer();
            timer.Tick += Timer_Tick;
            timer.Interval = 1; // Set interval to 0.5 seconds
            timer.Start();
        }

        // Train the neural network
        private void Train()
        {
            foreach (DigitEntry entry in trainDigitEntries)
            {
                neuralNetwork.Train(entry.getDataValues(), entry.getDesiredOutputs(), learningRate);
            }
        }

        // Starting point of the main application-------------------------------------
        private void StartSimulation()
        {
            try
            {
                CollectInputs();
                bitmap = new Bitmap(splitContainer1.Panel2.Width, splitContainer1.Panel2.Height);
                epoch = 0;
                neuralNetwork.BuildWeightMatrices();
                neuralNetwork.Train(
                    trainDigitEntries[0].getDataValues(),
                    trainDigitEntries[0].getDesiredOutputs(),
                    learningRate
                    );
                SetUpTimer();
            }
            catch
            {
                MessageBox.Show("Oops, something went wrong!", "ERROR");
                button_Reset.PerformClick();
            }
        }
    }
}
