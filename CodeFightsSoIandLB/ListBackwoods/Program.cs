using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListBackwoods
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var VARIABLE in volleyballPositions(
                new[]
                {
                    new[] { "empty", "Player5", "empty" },
                    new[] { "Player4", "empty", "Player2" },
                    new[] { "empty", "Player3", "empty" },
                    new[] { "Player6", "empty", "Player1" }
                },2))
            {
                foreach (var i in VARIABLE)
                    Console.Write(i + " ");
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.ReadKey();
        }
        public static int[] extractMatrixColumn(int[][] matrix, int column)
        {
            return matrix.Select(x => x[column]).ToArray();
        }
        public static bool areIsomorphic(int[][] array1, int[][] array2)
        {
            if (array1.Length == array2.Length)
            {
                if (array1.Where((t, i) => t.Length != array2[i].Length).Any()) return false;
            }
            else return false;
            return true;
            //if (array1.Length != array2.Length) return false;
            //return array1.Select((row, i) => row.Length == array2[i].Length).All(t => t);
        }
        public static int[][] reverseOnDiagonals(int[][] matrix)
        {
            int temp;
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length / 2; j++)
                {
                    if (i == j)
                    {
                        temp = matrix[i][j];
                        matrix[i][j] = matrix[matrix.Length - 1 - i][matrix[i].Length - 1 - j];
                        matrix[matrix.Length - 1 - i][matrix[i].Length - 1 - j] = temp;
                    }
                    if (i + j == matrix.Length - 1)
                    {
                        temp = matrix[i][j];
                        matrix[i][j] = matrix[j][i];
                        matrix[j][i] = temp;
                    }
                }
            }
            return matrix;
            //var n = matrix.Length;
            //for (int i = 0; i < n / 2; i++)
            //{
            //    var temp = matrix[i][i];
            //    matrix[i][i] = matrix[n - (1 + i)][n - (1 + i)];
            //    matrix[n - (1 + i)][n - (1 + i)] = temp;

            //    temp = matrix[i][n - (1 + i)];
            //    matrix[i][n - (1 + i)] = matrix[n - (1 + i)][i];
            //    matrix[n - (1 + i)][i] = temp;
            //}
            //return matrix;

            //int l = matrix.Length;
            //for (int i = 0; i < l / 2; i++)
            //{
            //    int j = l - 1 - i;

            //    int a1 = matrix[i][i];
            //    int a2 = matrix[i][j];
            //    int b1 = matrix[j][i];
            //    int b2 = matrix[j][j];

            //    matrix[j][j] = a1;
            //    matrix[j][i] = a2;
            //    matrix[i][j] = b1;
            //    matrix[i][i] = b2;
            //}
            //return matrix;
        }
        public static int[][] swapDiagonals(int[][] matrix)
        {
            int temp;
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (i == j)
                    {
                        temp = matrix[i][j];
                        matrix[i][j] = matrix[i][matrix.Length - i - 1];
                        matrix[i][matrix.Length - i - 1] = temp;
                    }
                }
            }
            return matrix;
            //for (int i = 0; i < matrix.Length; i++)
            //{
            //    int x = matrix[i][i];
            //    matrix[i][i] = matrix[i][matrix.Length - 1 - i];
            //    matrix[i][matrix.Length - 1 - i] = x;
            //}
            //return matrix;
        }
        public static int crossingSum(int[][] matrix, int a, int b)
        {
            return matrix[a].Sum() + matrix.Sum(x => x[b]) - matrix[a][b];
        }
        public static char[][] drawRectangle(char[][] canvas, int[] rectangle)
        {
            canvas[rectangle[1]][rectangle[0]] = '*';
            canvas[rectangle[3]][rectangle[0]] = '*';
            canvas[rectangle[1]][rectangle[2]] = '*';
            canvas[rectangle[3]][rectangle[2]] = '*';

            for (int i = rectangle[1]; i <= rectangle[3]; i++)
            {
                for (int j = rectangle[0]; j <= rectangle[2]; j++)
                {
                    if ((i == rectangle[1] && j > rectangle[0] && j < rectangle[2]) ||
                        (i == rectangle[3] && j > rectangle[0] && j < rectangle[2])) canvas[i][j] = '-';
                    if ((j == rectangle[0] && i > rectangle[1] && i < rectangle[3]) ||
                        (j == rectangle[2] && i > rectangle[1] && i < rectangle[3])) canvas[i][j] = '|';
                }
                //for (int i = rectangle[0] + 1; i < rectangle[2]; i++)
                //{
                //    canvas[rectangle[1]][i] = '-';
                //    canvas[rectangle[3]][i] = '-';
                //}

                //for (int i = rectangle[1] + 1; i < rectangle[3]; i++)
                //{
                //    canvas[i][rectangle[0]] = '|';
                //    canvas[i][rectangle[2]] = '|';
                //}
            }
            return canvas;
            //return canvas.Select((row, i) => row.Select((c, j) => {
            //    if ((j == rectangle[0] || j == rectangle[2]) &&
            //        (i == rectangle[1] || i == rectangle[3])) return '*';
            //    if ((j == rectangle[0] || j == rectangle[2]) &&
            //        i > rectangle[1] && i < rectangle[3]) return '|';
            //    if ((i == rectangle[1] || i == rectangle[3]) &&
            //        j > rectangle[0] && j < rectangle[2]) return '-';
            //    return c;
            //}).ToArray()).ToArray();
        }
        public static string[][] volleyballPositions(string[][] formation, int k)
        {
            var queue = new Queue<string>();
            queue.
        }
    }
}
