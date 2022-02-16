using System;
using System.IO;

namespace Filipenko
{

    class Program
    {

        static int[,] readMatrix()
        {

            string[] allRows = File.ReadAllLines("Input.txt");

            int size = allRows.Length;

            if (size == 0)
                return new int[,] { { }, { } };

            int[,] result = new int[size, size];

            for (int i = 0; i < size; i++)
            {

                string[] row = allRows[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < size; j++)
                {

                    result[i, j] = int.Parse(row[j]);

                }

            }

            return result;

        }

        static bool isMagicSquare(int[,] matrix)
        {

            int size = matrix.GetLength(0);

            bool result = true;

            //Сумма всех элементов строк одинакова
            int sumFirstRow = 0;

            for (int i = 0; i < size; i++)
            {

                int sumRow = 0;

                for (int j = 0; j < size; j++)
                {

                    sumRow += matrix[i, j];

                }

                if (sumFirstRow == 0)
                {

                    sumFirstRow = sumRow;

                }
                else
                {

                    if (sumRow != sumFirstRow)
                    {

                        result = false;

                        break;

                    }

                }

            }

            //Сумма всех элементов столбцов одинакова
            int sumFirstColumn = 0;

            for (int i = 0; i < size; i++)
            {

                int sumCol = 0;

                for (int j = 0; j < size; j++)
                {

                    sumCol += matrix[j, i];

                }

                if (sumFirstColumn == 0)
                {

                    sumFirstColumn = sumCol;

                }
                else
                {

                    if (sumCol != sumFirstColumn)
                    {

                        result = false;

                        break;

                    }

                }

            }

            //Сумма всех элементов диагоналей одинакова
            int leftUpToRightDown = 0;
            int leftDownToRightUp = 0;

            for (int i = 0; i < size; i++)
            {

                leftUpToRightDown += matrix[i, i];
                leftDownToRightUp += matrix[i, size - i - 1];

            }


            //Проверка всех сумм
            if (leftDownToRightUp != leftUpToRightDown)
                result = false;

            if (sumFirstColumn != sumFirstRow)
                result = false;

            if (leftUpToRightDown != sumFirstRow)
                result = false;

            return result;

        }

        static bool isSymmetric(int[,] matrix)
        {

            int size = matrix.GetLength(0);

            bool result = true;

            int formula = size * size + 1;

            for (int i = 0; i < size; i++)
            {

                int left = matrix[i, 0];
                int right = matrix[size - i - 1, size - 1];

                int up = matrix[0, i];
                int bottom = matrix[size - 1, size - i - 1];

                if(formula != left + right || formula != up + bottom)
                {

                    result = false;

                    break;

                }

            }

            return result;

        }

        static int Proccess(int[,] matrix)
        {

            int size = matrix.Length;

            if (size == 0) { return 0; }

            bool isMagic = isMagicSquare(matrix);

            if (isMagic)
            {

                bool isSymmetrical = isSymmetric(matrix);

                if (isSymmetrical) { return 3; }

            }
            else
            {
                return 0;
            }

            return 2;

        }

        static void Main(string[] args)
        {

            int[,] matrix = readMatrix();

            int result = Proccess(matrix);

            Console.WriteLine(result);

        }

    }

}
