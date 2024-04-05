using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            //program.ex1BubbleSort();
            //program.ex2statistics();
            program.ex3MatrixOperations();
        }
        public void ex1BubbleSort()
        {
            List<int> numbers = new List<int>();
            while (true)
            {
                Console.WriteLine("Enter an integer (enter 'x' to stop):");
                string input = Console.ReadLine();

                if (input == "x")
                {
                    break;
                }

                int number;
                if (int.TryParse(input, out number))
                {
                    numbers.Add(number);
                }
                else
                {
                    Console.WriteLine("Please enter an integer.");
                }
            }
            for (int i = 0; i < numbers.Count - 1; i++)
            {
                for (int j = 0; j < numbers.Count - i - 1; j++)
                {
                    if (numbers[j] > numbers[j + 1])
                    {
                        int temp = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = temp;
                    }
                }
            }
            Console.WriteLine("By using bubble sort we got: ");
            foreach (int element in numbers)
            {
                Console.WriteLine(element + " ");
            }
        }

        public void ex2statistics()
        {
            Console.WriteLine("Welcome to C# statistics program ! How many elements would you like to enter ? ");
            string sizeOfArray = Console.ReadLine();
            if (int.TryParse(sizeOfArray, out int sizeOfArrayINT))
            {
                double[] array = new double[sizeOfArrayINT];
                Console.WriteLine("Please, enter your values.");
                for (int i = 0; i < sizeOfArrayINT; i++)
                {
                    Console.WriteLine("Enter element number " + (i + 1) + ":");
                    string input = Console.ReadLine();
                    double inputDouble;
                    if (double.TryParse(input, out inputDouble))
                    {
                        if (isValueOk(inputDouble)) array[i] = inputDouble;
                        else
                        {
                            Console.WriteLine("Entered value is not valid");
                            i--;
                        }
                    }
                    else Console.WriteLine("Please enter valid number !");
                }
                Console.WriteLine("Your array:");
                for (int i = 0; i < sizeOfArrayINT; i++)
                {
                    Console.WriteLine(array[i] + " ");
                }
                double average = array.Average();
                Console.WriteLine(" avg: " + average);
                Console.WriteLine("------------------->");

                double max = array.Max();
                double min = array.Min();

                Console.WriteLine("Max value:" + max + " Min value:" + min);
                Console.WriteLine("------------------->");
                Console.WriteLine("Greater than avg:");
                for (int i = 0; i < sizeOfArrayINT; i++)
                {
                    if (array[i] > average) Console.WriteLine(array[i] + " ");
                }
                Console.WriteLine("------------------->");

                Console.WriteLine("Lower than avg:");
                for (int i = 0; i < sizeOfArrayINT; i++)
                {
                    if (array[i] < average) Console.WriteLine(array[i] + " ");
                }
                Console.WriteLine("------------------->");

                Dictionary<double, int> counts = new Dictionary<double, int>();

                foreach (double num in array)
                {
                    if (counts.ContainsKey(num))
                    {
                        counts[num]++;
                    }
                    else
                    {
                        counts[num] = 1;
                    }
                }

                foreach (var pair in counts)
                {
                    Console.WriteLine("Element: " + pair.Key + " x " + pair.Value);
                }
                
                 Console.WriteLine("------------------->");
                 Console.WriteLine("Średnie odchylenie standardowe: ");
                 Console.WriteLine(CalculateStandardDeviation(array, average));

            }
            else Console.WriteLine("Please enter valid number !");

        }
        public bool isValueOk(double number)
        {
            if (number == 2 || number == 3 || number == 3.5 || number == 4 || number == 4.5 || number == 5) return true;
            else return false;
        }

        public static double CalculateStandardDeviation(double[] array, double average)
    {
        double sumOfSquaredDifferences = 0;

        foreach (double num in array)
        {
            sumOfSquaredDifferences += Math.Pow(num - average, 2);
        }

        double variance = sumOfSquaredDifferences / array.Length;
        double standardDeviation = Math.Sqrt(variance);

        return standardDeviation;
    }




        public void ex3MatrixOperations()
        {
            Console.WriteLine("Choose operation:");
            Console.WriteLine("1. +");
            Console.WriteLine("2. -");
            Console.WriteLine("3. *");
            Console.WriteLine("Your choie(enter number):");

            string option = Console.ReadLine();

            Console.WriteLine("Podaj liczbę wierszy macierzy:");
            int.TryParse(Console.ReadLine(), out int rows);
            Console.WriteLine("Podaj liczbę kolumn macierzy:");
            int.TryParse(Console.ReadLine(), out int cols);

            int[,] matrixa = CreateMatrix(rows, cols,true);
            int[,] matrixb = null;
            int[,] resultMatrix = null;
            int rows2 = 0;
            int cols2 = 0;

            if (option == "1" || option == "2")
            {
                matrixb = CreateMatrix(rows, cols,true);
                resultMatrix = CreateMatrix(rows, cols,false);
            }
            else if (option == "3")
            {
                do
                {
                    Console.WriteLine("Podaj liczbę wierszy 2 macierzy:");
                    int.TryParse(Console.ReadLine(), out rows2);
                    Console.WriteLine("Podaj liczbę kolumn 2 macierzy:");
                    int.TryParse(Console.ReadLine(), out cols2);

                    if (cols != rows2)
                    {
                        Console.WriteLine("Liczba wierszy pierwszej macierzy musi być równa ilości kolumn macierzy drugiej, podaj wymiary jeszcze raz.");
                    }
                } while (cols != rows2);

                matrixb = CreateMatrix(rows2, cols2,true);
                resultMatrix = CreateMatrix(rows, cols2,false);
            }

            Console.WriteLine("Oto macierz A:");
            PrintMatrix(matrixa);

            Console.WriteLine("Oto macierz B:");
            PrintMatrix(matrixb);

            switch (option)
            {
                case "1":
                    Console.WriteLine("Wybrałeś dodawanie macierzy.");

                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < cols; j++)
                        {
                            resultMatrix[i, j] = matrixa[i, j] + matrixb[i, j];
                        }
                    }

                    break;
                case "2":
                    Console.WriteLine("Wybrałeś odejmowanie macierzy.");

                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < cols; j++)
                        {
                            resultMatrix[i, j] = matrixa[i, j] - matrixb[i, j];
                        }
                    }

                    break;
                case "3":
                    Console.WriteLine("Wybrałeś mnożenie macierzy.");

                    for (int i = 0; i < rows; i++)
                    {
                        for (int k = 0; k < cols2; k++)
                        {
                            for (int j = 0; j < cols; j++)
                            {
                                resultMatrix[i, k] += matrixa[i, j] * matrixb[j, k];
                            }
                        }
                    }

                    break;
                default:
                    Console.WriteLine("Nieprawidłowy wybór. Wybierz liczbę od 1 do 3.");
                    break;
            }

            PrintMatrix(resultMatrix);
            Console.WriteLine("Naciśnij dowolny klawisz, aby zakończyć...");
            Console.ReadKey();
        }

        static int[,] CreateMatrix(int rows, int cols, bool fill)
        {
            int[,] matrix = new int[rows, cols];
            
            Random random = new Random();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if(fill) matrix[i, j] = random.Next(-10, 11);
                    else matrix[i,j] = 0;
                }
            }

            return matrix;
        }

        static void PrintMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}