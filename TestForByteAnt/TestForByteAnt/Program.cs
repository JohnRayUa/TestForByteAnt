using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForByteAnt
{
    class Program
    {
        static void Main(string[] args)
        {
            bool[,] number = new bool[3, 27];
            char ch;
            int Tchar = 0;
            int Trow = 0;
            StreamReader reader;
            reader = new StreamReader(Environment.CurrentDirectory + @"\TestTask.txt");
            do
            {
                ch = (char)reader.Read();
                Console.Write(ch);

                if (ch == '\r' || ch == '\n')
                {
                    continue;
                }

                number[Trow, Tchar] = (ch != ' ');

                if (Tchar == 26)
                {
                    if (Trow == 2)
                    {
                        Console.WriteLine(" ");
                        printNumbers(number);
                        Trow = 0;
                    }
                    else
                    {
                        Trow++;
                    }
                    Tchar = 0;
                }
                else
                {
                    Tchar++;
                }
            } while (!reader.EndOfStream);
            reader.Close();
            reader.Dispose();
            Console.WriteLine(" ");
            Console.WriteLine(Tchar.ToString() + " characters");
            Console.ReadLine();
        }

        private static void printNumbers(bool[,] row)
        {
            for (int i = 0; i < 27; i += 3)
            {
                if (row[1, i])
                {
                    if (row[1, i + 2])
                    {
                        if (row[2, i])
                        {
                            if (row[1, i + 1])
                            {
                                Console.Write(8);
                            }
                            else
                            {
                                Console.Write(0);
                            }
                        }
                        else
                        {
                            if (row[0, i + 1])
                            {
                                Console.Write(9);
                            }
                            else
                            {
                                Console.Write(4);
                            }
                        }
                    }
                    else
                    {
                        if (row[2, i])
                        {
                            Console.Write(6);
                        }
                        else
                        {
                            Console.Write(5);
                        }
                    }
                }
                else
                {
                    if (row[1, i + 1])
                    {
                        if (row[2, i])
                        {
                            Console.Write(2);
                        }
                        else
                        {
                            Console.Write(3);
                        }
                    }
                    else
                    {
                        if (row[0, i + 1])
                        {
                            Console.Write(7);
                        }
                        else
                        {
                            Console.Write(1);
                        }
                    }
                }
            }
            Console.WriteLine(" ");
        }
    }
}
