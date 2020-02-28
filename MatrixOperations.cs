using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitClassifierWithErrorVisualization
{
    abstract class MatrixOperations<T>
    {
        static List<T> Multiply(List<List<T>> first, List<T> second)
        {
            int numRowsInFirst = first.Count;
            int numColsInFirst = first[0].Count;

            int numRowsInSecond = 1;
            int numColsInSecond = second.Count;

            List<T> result = new List<T>();

            if (numColsInFirst != numColsInSecond)
            {
                result = null;
                return result;
            }
            else
            {
               // TODO: Implement matrix multiplication
            }
        }
    }
}
