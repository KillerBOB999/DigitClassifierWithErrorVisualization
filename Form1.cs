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
        }


        // Global variables----------------------------------------------------------
        // Filenames of the files that contain the test and training data
        const string TEST_FILENAME = "optdigits-3.tes";
        const string TRAIN_FILENAME = "optdigits-3.tra";

        // Datasets to be used loaded into memory
        List<DigitEntry> testDigitEntries;
        List<DigitEntry> trainDigitEntries;

        public void collectData()
        {
            FileStream testFile = File.OpenRead(TEST_FILENAME);
            FileStream trainFile = File.OpenRead(TRAIN_FILENAME);

            List<float> rawTestData = parseData(ref testFile);
        }

        public List<float> parseData(ref FileStream inFile)
        {
            string line = "";
            string current = "";
            List<float> rawData = new List<float>();

            using (StreamReader streamReader = new StreamReader(inFile))
            {
                while (line != null)
                {
                    line = streamReader.ReadLine();
                    foreach (char ch in line)
                    {
                        if (ch != ',' && ch != '\n') current += ch;
                        else
                        {
                            rawData.Add((float)Convert.ToDouble(current));
                            current = "";
                        }
                    }
                }
            }

            return rawData;
        }
    }
}
