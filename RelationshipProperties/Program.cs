using System;

namespace RelationshipProperties
{
    class Program
    {
        static void Main(string[] args)
        {
            MatrixInput();
            CheckProperties();
        }

        static int[,] mat;

        static void MatrixInput()
        {
            string vvod = "";

            while (vvod != "1"/* || vvod != "2"*/)
            {
                Console.WriteLine("Выберете способ ввода матрицы: 1 - вручную, 2 - из файла");
                vvod = Console.ReadLine();
            }

            switch (vvod)
            {
                case "1": ManualMatrixInput(); break;
            }
        }

        static void ManualMatrixInput()
        {
            string vvod = "";
            int n;

            while (!int.TryParse(vvod, out n) || n < 3 || n > 5)
            {
                Console.WriteLine("Введите размер квадратной матрицы (3 - 5)");
                vvod = Console.ReadLine();
            }

            mat = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    string str = "";
                    while (!int.TryParse(str, out mat[i, j]))
                    {
                        Console.WriteLine($"Введите элемент {i + 1}.{j + 1}:");
                        str = Console.ReadLine();
                    }
                }
            }
        }

        static void CheckProperties()
        {
            Console.WriteLine("\nСвойства отношений:");

            if (Reflexivity())
                Console.WriteLine("Рефлексивное");
            else if (Antireflexitivity())
                Console.WriteLine("Антирефлексивное");

            if (Symmetry())
                Console.WriteLine("Симметричное");
            else if (Asymmetry())
                Console.WriteLine("Ассимитричное");
            else
                Console.WriteLine("Антисимметричное");
        }

        // ==== Properties ====
        static bool Reflexivity()
        {
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                if (mat[i, i] == 0) return false;
            }
            return true;
        }

        static bool Antireflexitivity()
        {
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                if (mat[i, i] == 1) return false;
            }
            return true;
        }

        static bool Symmetry()
        {
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); i++)
                {
                    if (mat[i, j] != mat[j, i]) return false;
                }
            }
            return true;
        }

        static bool Asymmetry()
        {
            if (!Antireflexitivity()) return false;

            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); i++)
                {
                    if (mat[i, j] * mat[j, i] == 1) return false;
                }
            }
            return true;
        }
    }
}