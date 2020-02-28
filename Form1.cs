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
            CollectData();
            Task learn = Task.Run(() =>
            {
                MainLoop();
            });
        }


        // Global variables----------------------------------------------------------
        // Path to data files
        const string DATA_PATH = "../../data/";

        // Filenames of the files that contain the test and training data
        const string TRAIN_FILENAME = "optdigits-3.tra";
        const string TEST_FILENAME = "optdigits-3.tes";

        // Percent of the training data to be used as a validation set
        const float VALIDATION_PORTION = 0.2f;

        // Datasets to be used loaded into memory
        List<DigitEntry> trainDigitEntries = new List<DigitEntry>();
        List<DigitEntry> validationDigitEntries = new List<DigitEntry>();
        List<DigitEntry> testDigitEntries = new List<DigitEntry>();

        private void CollectData()
        {
            // Set up file handlers
            FileStream trainFile = File.OpenRead(DATA_PATH + TRAIN_FILENAME);
            FileStream testFile = File.OpenRead(DATA_PATH + TEST_FILENAME);

            // Create local variable for containing the raw data from the files
            List<float> rawTrainData = ParseData(ref trainFile);
            List<float> rawValidationData;
            List<float> rawTestData = ParseData(ref testFile);

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

        private List<float> ParseData(ref FileStream inFile)
        {
            string line = "";
            string current = "";
            List<float> rawData = new List<float>();

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
                            rawData.Add((float)Convert.ToDouble(current));
                            current = "";
                        }
                    }
                    rawData.Add((float)Convert.ToDouble(current));
                    current = "";
                    line = streamReader.ReadLine();
                }
            }

            return rawData;
        }

        private void InitializeDataset(ref List<DigitEntry> dataset, ref List<float> rawData)
        {
            for (int i = 0; i < rawData.Count; i += DigitEntry.NUM_PIX_VALUES + 1)
            {
                List<float> dataSection = rawData.GetRange(i, DigitEntry.NUM_PIX_VALUES + 1);
                dataset.Add(new DigitEntry(dataSection));
            }
        }

        private void MainLoop()
        {
            // TODO: Implement the core of the program
        }
    }
}
