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
        static readonly int NUM_POSSIBLE_DIGITS = 4;

        // Maximum of integer values used to represent each pixel
        static readonly int MAX_PIX_VALUE = 16;

        // Number of pixel values that represent the digit
        static readonly int NUM_PIX_VALUES = 64;

        // Desired output for incorrect classes
        static readonly float DESIRED_INCORRECT = 0.1f;

        // Desired output for correct classes
        static readonly float DESIRED_CORRECT = 0.9f;

        // PRIVATE VARIABLES------------------------------------------------------------------
        // Values that represent the data. Should be normalized and have a size of 64.
        private List<float> dataValues;

        // Desired output vector of classifier where the index of the maximum value . Should
        // have a size of NUM_POSSIBLE_DIGITS.
        private List<float> desiredOutputs;

        // Actual class of the digit
        private readonly int actualClass;

        // GETTERS----------------------------------------------------------------------------
        public ref List<float> getDataValues() { return ref dataValues; }
        public ref List<float> getDesiredOutputs() { return ref desiredOutputs; }

        // CONSTRUCTORS-----------------------------------------------------------------------
        public DigitEntry(ref List<float> rawData)
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
        private void normalizeAndSetDataValues(ref List<float> digitData)
        {
            foreach (float value in digitData)
            {
                dataValues.Add(value / (float)MAX_PIX_VALUE);
            }
        }

        // Define the desired output list where the index of the maximum value of the list
        // represents the actual digit classification.
        private void setDesiredOutputs()
        {
            // Define the list type
            desiredOutputs = new List<float>(NUM_POSSIBLE_DIGITS);

            // Initialize all values to 0.1
            for (int i = 0; i < desiredOutputs.Count; ++i)
            {
                desiredOutputs[i] = i == actualClass ? DESIRED_CORRECT : DESIRED_INCORRECT;
            }
        }
    }
}
