using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DigitClassifierWithErrorVisualization
{
    class DigitEntry
    {
        // STATIC VARIABLES-------------------------------------------------------------------
        // 0-inclusive number of possible classes
        public static readonly int NUM_POSSIBLE_DIGITS = 4;

        // Maximum of integer values used to represent each pixel
        public static readonly int MAX_PIX_VALUE = 16;

        // Number of pixel values that represent the digit
        public static readonly int NUM_PIX_VALUES = 64;

        // Desired output for incorrect classes
        public static readonly double DESIRED_INCORRECT = 0.01;

        // Desired output for correct classes
        public static readonly double DESIRED_CORRECT = 0.99;

        // PRIVATE VARIABLES------------------------------------------------------------------
        // Values that represent the data. Should be normalized and have a size of 64.
        private List<double> dataValues = new List<double>();

        // Desired output vector of classifier where the index of the maximum value . Should
        // have a size of NUM_POSSIBLE_DIGITS.
        private List<double> desiredOutputs = new List<double>();

        // Actual class of the digit
        private readonly int actualClass;

        // GETTERS----------------------------------------------------------------------------
        public ref List<double> getDataValues() { return ref dataValues; }
        public ref List<double> getDesiredOutputs() { return ref desiredOutputs; }

        // CONSTRUCTORS-----------------------------------------------------------------------
        public DigitEntry(List<double> rawData)
        {
            // Set the actual class value
            actualClass = (int)rawData[rawData.Count - 1];

            // Remove the class from the raw data to make it only the pixel data
            rawData.RemoveAt(rawData.Count - 1);

            // Normalize and set the pixel data values
            normalizeAndSetDataValues(ref rawData);

            // Define the desired output list
            setDesiredOutputs();
        }

        // HELPERS----------------------------------------------------------------------------
        // Normalize the data and assign the normalized values to the dataValues list.
        private void normalizeAndSetDataValues(ref List<double> digitData)
        {
            foreach (double value in digitData)
            {
                dataValues.Add(value / MAX_PIX_VALUE);
            }
        }

        // Define the desired output list where the index of the maximum value of the list
        // represents the actual digit classification.
        private void setDesiredOutputs()
        {
            double initialValue;
            // Initialize all values to 0.1
            for (int i = 0; i < NUM_POSSIBLE_DIGITS; ++i)
            {
                initialValue = i == actualClass ? DESIRED_CORRECT : DESIRED_INCORRECT;
                desiredOutputs.Add(initialValue);
            }
        }
    }
}
