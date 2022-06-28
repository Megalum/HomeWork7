using System;

namespace HomeWork7
{
    class Program
    {
        static void Main(string[] args)
        {
            int task;
            do
            {
                Task();
                task = InputInteger("Введите номер задания: ");
                Console.Clear();

                switch (task)
                {
                    case 1:                        
                        PrintMatrixDouble(CreateRandomMatrixDouble());                        
                        break;

                    case 2:                        
                        int[,] matrixFirst = CreateRandomMatrixInteger();
                        PrintMatrixInteger(matrixFirst);
                        int position = InputInteger("Укажите позицию числа: ");
                        if (position / 10 < matrixFirst.GetLength(0) && position % 10 < matrixFirst.GetLength(1) && position >= 0)
                        {
                            Console.WriteLine($"Значение найдено, результат {matrixFirst[position / 10, position % 10]}");
                        }
                        else Console.WriteLine("Такого числа в массиве нет");
                        break;

                    case 3:
                        int[,] matrixSecond = CreateRandomMatrixInteger();
                        double sum = 0;
                        PrintMatrixInteger(matrixSecond);
                        Console.Write("Среднее арифметическое каждого столбца: ");
                        for (int j = 0; j < matrixSecond.GetLength(1); j++)
                        {
                            for (int i = 0; i < matrixSecond.GetLength(0); i++)
                            {
                                sum += matrixSecond[i, j];
                            }
                            Console.Write("{0:0.0} ", sum / matrixSecond.GetLength(0));
                            sum = 0;
                        }
                        Console.WriteLine();
                        break;
                }

                Console.WriteLine("Press key to continue...");
                Console.ReadKey();
            } while (task < 4);

            double[,] CreateRandomMatrixDouble()
            {
                int row = InputInteger("Укажите колличество строк: ");
                int column = InputInteger("Укажите колличество столбцов: ");
                double[,] matrix = new double[row, column];
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < column; j++)
                    {
                        matrix[i, j] = Convert.ToDouble(new Random().Next(-100, 100)) / 3;
                    }
                }

                return matrix;
            }

            int[,] CreateRandomMatrixInteger()
            {
                int row = InputInteger("Укажите колличество строк: ");
                int column = InputInteger("Укажите колличество столбцов: ");
                int[,] matrix = new int[row, column];
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < column; j++)
                    {
                        matrix[i, j] = new Random().Next(-100, 100);
                    }
                }

                return matrix;
            }

            int InputInteger(string str)
            {
                Console.Write(str);
                return Convert.ToInt32(Console.ReadLine());
            }

            void PrintMatrixDouble(double[,] matrix)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        Console.Write("{0:0.00} ", Math.Round(matrix[i, j], 2));
                    }
                    Console.WriteLine();
                }
            }           

            void PrintMatrixInteger(int[,] matrix)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        Console.Write("{0} ", matrix[i, j]);
                    }
                    Console.WriteLine();
                }
            }

            void Task()
            {
                Console.Clear();
                Console.WriteLine("Условия заданий:");
                Console.WriteLine("1 - Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.");
                Console.WriteLine("2 - Напишите программу, которая на вход принимает позиции элемента в двумерном массиве, " +
                    "и возвращает значение этого элемента или же указание, что такого элемента нет.");
                Console.WriteLine("3 - Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце");
                Console.WriteLine("4 - Exit");
            }
        }
    }
}
