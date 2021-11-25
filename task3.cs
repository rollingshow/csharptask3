using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        string inputLine;
        string[] inputArray;
        double[,] matrix;
        double[] roots;
        int
            alpha,
            beta,
            k,
            k1;
        int size;

        try
        {
            // Размер СЛАУ
            inputLine = Console.ReadLine();
            size = Convert.ToInt32(inputLine);

            // Подготовка массива
            matrix = new double[size, size];
            roots = new double[size];

            for (int i = 0; i < size; i++)
            {
                inputLine = Console.ReadLine();
                inputArray = inputLine.Split(" ");

                for (int j = 0; j < size + 1; j++)
                {
                    if (j != size)
                    {
                        matrix[i, j] = Convert.ToDouble(inputArray[j]);
                    }
                    else
                    {
                        roots[i] = Convert.ToDouble(inputArray[j]);
                    }
                }
            }

            // Находим корни
            for (k = 0; k < size; k++)
            {
                k1 = k + 1;
                for (alpha = k; alpha < size; alpha++)
                {
                    if (matrix[alpha, k] != 0)
                    {
                        for (beta = k1; beta < size; beta++)
                        {
                            matrix[alpha, beta] /= matrix[alpha, k];
                        }
                        roots[alpha] /= matrix[alpha, k];
                    }
                }
                for (alpha = k1; alpha < size; alpha++)
                {
                    if (matrix[alpha, k] != 0)
                    {
                        for (beta = k1; beta < size; beta++)
                        {
                            matrix[alpha, beta] -= matrix[k, beta];
                        }
                        roots[alpha] -= roots[k];
                    }
                }
            }
            for (alpha = size - 2; alpha >= 0; alpha--)
            {
                for (beta = size - 1; beta >= alpha + 1; beta--)
                {
                    roots[alpha] -= matrix[alpha, beta] * roots[beta];
                }
            }

            for (int i = 0; i < roots.Length; i++)
            {
                Console.Write(Math.Round(roots[i]) + " ");
            }
        }
        catch
        {
            Console.WriteLine("Input Error!");
        }
    }
}
