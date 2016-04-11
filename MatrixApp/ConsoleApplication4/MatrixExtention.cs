using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
    /*
    Q11
    this class extends the current functions in the Matrix class.
    */
    static class MatrixExtention
    {
        /*
        Q11
        this function reset's the matrix with the value of 0. 
        */
        public static void resetMatrix(Matrix m7)
        {
            for (int i = 0; i < m7.Rows; i++)
            {
                for (int k = 0; k < m7.Cols; k++)
                {
                    m7[i, k] = 0;
                }
            }
        }
    }
}
