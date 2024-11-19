using System;

namespace laba3
{
    class Program
    {
        static void Main(string[] args)
        {
            //// Ввод размерности первого массива
            //Console.WriteLine("Введите размерность первого массива (n x m):");
            //Console.Write("Введите n: ");
            //int n = int.Parse(Console.ReadLine());
            //Console.Write("Введите m: ");
            //int m = int.Parse(Console.ReadLine());

            //// Создание и вывод первого массива
            //Matrix A = new Matrix(n, m);
            //Console.WriteLine("Матрица A:");
            //Console.WriteLine(A);
            //Console.WriteLine("Максимальный неповторяющийся элемент:" + A.FindMax(n, m));

            //// Создание и вывод второго массива (n x n)
            //Matrix B = new Matrix(n);
            //Console.WriteLine("Матрица B:");
            //Console.WriteLine(B);

            //// Создание и вывод третьего массива (n x n)
            //Matrix C = new Matrix(n, m, true);
            //Console.WriteLine("Матрица C:");
            //Console.WriteLine(C);


            //4 задание
            Console.WriteLine("Задание 4. Четные числа");
            Console.WriteLine("Введите количество элементов для генерации");
            int Nelem = int.Parse(Console.ReadLine()); //Кол-во элементов в файле
            string path = @"C:\Users\Marin\Downloads\\ex4.bin"; //Путь к файлу 4 задания
            FileOperations.Nef4(path, Nelem);

            //5 задание
            Console.WriteLine("Задание 5. Багаж");
            Console.WriteLine("Введите количество багажа:");
            int Nbag = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите допустимое отклонение m:");
            double mas = double.Parse(Console.ReadLine());
            path = @"C:\Users\Marin\Downloads\\ex5.bin"; //Путь к файлу 5 задания
            FileOperations.Nef5(path, Nbag, mas);

            Console.WriteLine("Задание 6. Разность суммы первой и второй половины");
            Console.WriteLine("Введите кол-во пар элементов для генерации");
            Nelem = int.Parse(Console.ReadLine());
            path = @"C:\Users\Marin\Downloads\\ex6.txt"; //Путь к файлу 6 задания
            FileOperations.Nef6(path, Nelem);

            Console.WriteLine("Задание 7. Сумма элементов в файле");
            Nelem = 6;//Количество строк для генерации
            path = @"C:\Users\Marin\Downloads\\ex7.txt"; //Путь к файлу 7 задания
            FileOperations.Nef7(path, Nelem);

            Console.WriteLine("Задание 8. min и max строки");
            Console.WriteLine("Введите количество слов:");
            Nelem = int.Parse(Console.ReadLine());//Количество строк для генерации
            path = @"C:\Users\Marin\Downloads\\ex8.txt"; //Путь к файлу 8 задания
            FileOperations.Nef8(path, Nelem);


        }
    }
}