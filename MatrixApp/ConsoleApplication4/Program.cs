using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            this is the Welcome Screen for my Application.
            */
            Console.WriteLine("<------------Hello ! Welcome to my Application------------>\n");
       
            /*
            initialization of the main matrix we are going to work with (not always).
            */
            Matrix m = new Matrix(3, 3);

            Console.WriteLine("Your Initialized Main Matrix : \n{0}", m.ToString());

            /*
            initialization of a while loop will serve as our main menu.
            whils the variable 'exitBool' is true,we will preform actions in the menu.
            we can choose from 8 actions,or we can exit the program.
            */
            bool exitBool = true;
            while (exitBool)
            {
                /*
                Main Menu. uses a switch statment to detect the user input and preform
                pre-defined actions and customizable inputs.
                */
                Console.WriteLine("<             M a i n  M a n u             >\n\n" +
                    "A) get a value?\n" +
                     "B) set a value?\n" +
                     "C) get the Max value in your Matrix?\n" +
                      "D) get the number of cells in your Matrix?\n" +
                       "E) add two Matrix's ?\n" +
                        "F) multiply two Matrix's ?\n" +
                         "G) increment all values by 1?\n" +
                         "H) reset the main matrix?\n" +
                         "I) Exit the program?\n\n"
                    + "(type in A / B / C / D / E / F / G / H / I )\n");
                string choice = Convert.ToString(Console.ReadLine());
                choice.ToUpper();
                switch (choice)
                {
                    /*
                    "A) get a value"
                    this option sends a value ,in the main matrix,
                    by its index of row and colmun.
                    */
                    case "A":
                        try
                        {
                            Console.WriteLine(m.ToString());
                            Console.WriteLine("Rows number ( 0,1,2...): ");
                            int r = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Column number ( 0,1,2..): ");
                            int c = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Youre number is : {0}", m.GetValue(r, c));
                            Console.ReadKey();
                        }
                        catch (IndexOutOfRangeException e)
                        {
                            Console.WriteLine(e.StackTrace);
                            Console.WriteLine(e.Message);
                            throw;
                        }
                        break;

                    /*
                    "B) set a value?"
                    this option sets a new value in your main matrix,
                    in a specified row and colmun.
                    */
                    case "B":
                        try
                        {
                            Console.WriteLine("the value : ");
                            int x = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Rows number(0, 1, 2...): ");
                            int y = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Colmun number ( 0,1,2...): ");
                            int z = Convert.ToInt32(Console.ReadLine());
                            
                            m.SetValue(x, y, z);
                            Console.WriteLine(m.ToString());
                            Console.ReadKey();
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine(e.StackTrace);
                            Console.WriteLine(e.Message);
                            throw;
                        }
                        break;

                    /*
                    "C) get the Max value in your Matrix?"
                    this option searche for the lowest value in your main
                    matrix and displays it to the user.
                    */
                    case "C":
                        try
                        {
                            Console.WriteLine(m.Max);
                            Console.ReadKey();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.StackTrace);
                            Console.WriteLine(e.Message);
                            throw;
                        }
                        break;

                    /*
                    "D) get the number of cells in your Matrix?"
                    this option displays the number of cells in your main matrix
                    */
                    case "D":
                        try
                        {
                            Console.WriteLine("the number of cells in your Matrix is: {0}", m.Cells);
                            Console.ReadKey();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.StackTrace);
                            Console.WriteLine(e.Message);
                            throw;
                        }
                        break;

                    /*
                   "E) add two Matrix's ?"
                   this option allows the user to create two instances of the Matrix class,
                   and add the together by using the '+' operator;
                    */
                    case "E":
                        try
                        {
                            int m1Row;
                            int m1Col;

                            Console.WriteLine("---Matrix number 1---");
                            Console.WriteLine("number of rows:");
                            m1Row = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("number of cols:");
                            m1Col = Convert.ToInt32(Console.ReadLine());
                            Matrix m1 = new Matrix(m1Row, m1Col);

                            for (int i = 0; i < m1Row; i++)
                            {
                                for (int j = 0; j < m1Col; j++)
                                {
                                    Console.Write("Cell [{0},{1}] :\t", i, j);
                                    m1.SetValue(Convert.ToInt32(Console.ReadLine()), i,j);
                                }
                                Console.WriteLine();
                            }

                            int m2Row;
                            int m2Col;

                            Console.WriteLine("---Matrix number 2---");
                            Console.WriteLine("number of rows:");
                            m2Row = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("number of cols:");
                            m2Col = Convert.ToInt32(Console.ReadLine());
                            Matrix m2 = new Matrix(m2Row, m2Col);


                            for (int i = 0; i < m2Row; i++)
                            {
                                for (int j = 0; j < m2Col; j++)
                                {
                                    Console.Write("Cell [{0},{1}] :\t", i, j);
                                    m2.SetValue(Convert.ToInt32(Console.ReadLine()), i, j);
                                }
                                Console.WriteLine();
                            }
                            
                            if ((m1.Rows != m2.Rows) || (m1.Cols != m2.Cols))
                            {
                                Console.WriteLine("ERROR !!! " +
                                    "<number of columns and rows in Matrix 1 " +
                                    "and Matrix 2 HAVE to be equal !>");
                                exitBool = false;
                                break;
                            }
                            Matrix m3 = m1 + m2;
                            Console.WriteLine(m3.ToString());
                            Console.ReadKey();
                        }
                        catch (IndexOutOfRangeException e)
                        {
                            Console.WriteLine(e.StackTrace);
                            Console.WriteLine(e.Message);
                            throw;
                        }
                        break;

                    /*
                    "F) multiply two Matrix's ?"
                    this option allows the user to create two instances of the Matrix class,
                    and multiply them together by using the '*' operator;
                    */
                    case "F":
                        try
                        {
                            int m1Row;
                            int m1Col;

                            Console.WriteLine("---Matrix number 1---");
                            Console.WriteLine("number of rows:");
                            m1Row = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("number of cols:");
                            m1Col = Convert.ToInt32(Console.ReadLine());
                            Matrix m1 = new Matrix(m1Row, m1Col);
                            
                            for (int i = 0; i < m1Row; i++)
                            {
                                for (int j = 0; j < m1Col; j++)
                                {
                                    Console.Write("Cell [{0},{1}] :\t", i, j);
                                    m1.SetValue(Convert.ToInt32(Console.ReadLine()), i, j);
                                }
                                Console.WriteLine();
                            }

                            int m2Row;
                            int m2Col;

                            Console.WriteLine("---Matrix number 2---");
                            Console.WriteLine("number of rows:");
                            m2Row = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("number of cols:");
                            m2Col = Convert.ToInt32(Console.ReadLine());
                            Matrix m2 = new Matrix(m2Row, m2Col);
                            
                            for (int i = 0; i < m2Row; i++)
                            {
                                for (int j = 0; j < m2Col; j++)
                                {
                                    Console.Write("Cell [{0},{1}] :\t", i, j);
                                    m2.SetValue(Convert.ToInt32(Console.ReadLine()), i, j);
                                }
                                Console.WriteLine();
                            }
                            if (m1.Cols != m2.Rows)
                            {
                                Console.WriteLine("ERROR !!! " +
                                    "<number of columns in Matrix 1" +
                                    "and number of rows in Matrix 2" +
                                    " HAVE to be equal !>");
                                exitBool = false;
                                break;
                            }

                            Matrix m3 = m1 * m2;
                            Console.WriteLine(m3.ToString());
                            Console.ReadKey();
                        }
                        catch (IndexOutOfRangeException e)
                        {
                            Console.WriteLine(e.StackTrace);
                            Console.WriteLine(e.Message);
                            throw;
                        }
                        break;

                    /*
                    "G) increment all values by 1?"
                    this option pass over all the main matrix values and increment
                    all the values by 1. 
                    */
                    case "G":
                        try
                        {
                            Console.WriteLine("Befor:\n");
                            Console.WriteLine(m.ToString());
                            m++;
                            Console.WriteLine("After:\n");
                            Console.WriteLine(m.ToString());
                            Console.ReadKey();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.StackTrace);
                            Console.WriteLine(e.Message);
                            throw;
                        }
                        break;

                    /*
                     "H) reset the main matrix?\n" +
                     this option reset's the main matrix values to 0.
                    */
                    case "H":
                        try
                        {
                            MatrixExtention.resetMatrix(m);
                            Console.WriteLine(m.ToString());
                            Console.ReadKey();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.StackTrace);
                            Console.WriteLine(e.Message);
                            throw;
                        }
                        break;
                    /*
                     "I) Exit the program?"
                     if 'I' is selected'break' is exacuted and
                     the value of 'exitBool' changes to false,
                     causing the while loop to end, and the Main Manu to exit.
                    */
                    case "I":
                        exitBool = false;
                        break;
                }
            }
            Console.WriteLine("<-------------E-N-D---O-F---P-R-O-G-R-A-M------------------->");
            Console.ReadKey();

            Console.WriteLine("<-----------C-O-M-E---B-A-C-K---S-O-O-N---!---!---!--------->");
            Console.ReadKey();

        }
    }
}