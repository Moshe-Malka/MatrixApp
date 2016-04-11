using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApplication4
{
    /*
    this class describes a two dimensional matrix all of the
    values are presented as UInt to 
    make sure the user can't enter -1 as Row/Column number.
    */
    class Matrix
    {
        /*
        class veriables (eg. rows,cols) are presented as Properties to restrict access.
        */
        private int rows;
        public int Rows
        {
            get { return rows; }
            set { rows = value; }
        }

        private int cols;
        public int Cols
        {
            get { return cols; }
            set { cols = value; }
        }

        private int[,] matritza;

        /*
        Q1
        the main Constructor of the matrix instance.
        */
        public Matrix(int row, int colm)
        {
            Rows = row;
            Cols = colm;

            matritza = new int[Rows, Cols];
        }

        /*
        Q2
        sets a value by given position.
        */
        public void SetValue(int valueToSet, int r, int c)
        {
            matritza[r, c] = valueToSet;
        }

        /*
        Q3
        get's a value by position (Rows and Columns)
        */
        public int GetValue(int x, int y)
        {
            return matritza[x, y];
        }

        /*
        Q5
        this property return the number of cells of the Matrix.
        */
        public int Cells
        {
            get { return (Rows * Cols); }
        }

        /*
        Q6
        this property returns the max value in the Matrix.
        */
        private int max = 0;
        public int Max
        {
            get
            {
                for (int i = 0; i < Rows; i++)
                {
                    for (int j = 0; j < Cols; j++)
                    {
                        if (matritza[i, j] > max)
                        {
                            max = matritza[i, j];
                        }
                    }
                }
                return max;
            }
        }

        /*
        Q7-a
        this operator overload allows us to add two Matrix's into one Matrix.
        */
        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            if (m1.Rows != m2.Rows || m1.Cols != m2.Cols)
                return null;

            Matrix m3 = new Matrix(m1.Rows, m2.Cols);
            for (int i = 0; i < m3.Rows; i++)
            {
                for (int j = 0; j < m3.Cols; j++)
                {
                    m3.SetValue(m1.GetValue(i, j)
                        + m2.GetValue(i, j)
                        , i, j);
                }
            }
            return m3;
        }

        /*
        Q7-b
        this operator overload allows us to multiply two Matrix's into one Matrix.
        */
        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            Matrix m3 = new Matrix(m1.Rows, m2.Cols);

            for (int i = 0; i < m3.Rows; i++)
            {
                for (int j = 0; j < m3.Cols; j++)
                {
                    m3[i, j] = 0;
                    for (int k = 0; k < m1.Cols; k++)
                    {
                        m3[i, j] += m1[i, k] * m2[k, j];
                    }
                }
            }
            return m3;
        
        }

        /*
        Q8
        this function overload the ++ operator, such that when applied,
        every value increses by one.
        */
        public static Matrix operator ++(Matrix m5)
        {
            for (int i = 0; i < m5.Rows; i++)
            {
                for (int j = 0; j < m5.Cols; j++)
                {
                    m5.SetValue(m5.GetValue(i, j) + 1, i, j);
                }
            }
            return m5;
        }

        /*
        Q9
        this operator overload allows us to use the [i,j] sign to replace
        the GetValue and SetValue functions.
        */
        public int this[int r, int c]
        {
            get
            {
                return GetValue(r, c);
            }
            set
            {
                SetValue(value, r, c);
            }
        }

        /*
        Q10
        this function is an implicit operator that turns
        the Matrix into a one-dimensional array.
        */
        public static implicit operator int[] (Matrix m6)
        {

            if (!m6.Equals(null))
            {
                int[] tmp = new int[m6.Cols * m6.Rows];
                int indexer = 0;

                for (int i = 0; i < m6.Rows; i++)
                {
                    for (int j = 0; j < m6.Cols; j++)
                    {
                        tmp[indexer] = m6[i, j];
                        indexer++;
                    }
                }
                return tmp;
            }
            else
                return null;
        }

        /*
        Q4
        this is an override of the original ToString method.
        */
        public override string ToString()
        {
            string tmp = "";

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    tmp += "(" + matritza[i, j];
                    tmp += ")         ";
                }
                tmp += "               \n\n";
            }
            return tmp;
        }
    }
}
