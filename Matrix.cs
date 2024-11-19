using System;

namespace laba3
{
    public class Matrix
    {
        private int[,] data; //прив поле, которое будет хранить двум массив

        public Matrix(int n, int m) //строки, столбцы
        {
            data = new int[n, m]; //новый двум массив
            Console.WriteLine("Введите элементы массива:");
            for (int i = 0; i < n; i++)
            {
                for (int j = m - 1; j >= 0; j--) //с конца строки
                {
                    data[i, j] = int.Parse(Console.ReadLine());
                }
            }
        }


        public Matrix(int n)
        {
            data = new int[n, n];
            Random random = new Random(); //объект для генер случайных чисел
            for (int i = 0; i < n; i++) //по строкам
            {
                for (int j = 0; j < n; j++) //по столбцам
                {
                    if (i > j)
                    {
                        data[i, j] = random.Next(-17, 37);
                    }
                    else
                    {
                        data[i, j] = random.Next(100, 10001);
                    }
                }
            }
        }


        public Matrix(int n, int m, bool isC)
        {
            data = new int[n, n];

            int num = 1;
            for (int startRow = n - 1; startRow >= 0; startRow--) //с последней строки
            {
                int row = startRow; //тек строка
                int col = 0; //тек столбец
                while (row < n && col < n)
                {
                    data[row, col] = num++;
                    row++;
                    col++;
                }
            }
        }



        public override string ToString()
        {
            var result = new System.Text.StringBuilder(); // класс для создания и изменения строк. для накопления строк
            for (int i = 0; i < data.GetLength(0); i++) //по строкам, возвращает кол-во строк в массиве data
            {
                for (int j = 0; j < data.GetLength(1); j++) //по столбцам, возвращает кол-во столбцов в массиве data
                {
                    result.Append(data[i, j].ToString().PadRight(10)); //преобразуется в строку и добавляет 10 пробелов
                }
                result.AppendLine(); //новая строка
            }
            return result.ToString(); //возвращает итоговую строку
        }


        public int FindMax(int n, int m)
        {
            int[,] arr = new int[2, n * m + 1]; //двумерный массив arr с двумя строками (для хранения уникальных значений и количество вхождений) и n * m + 1 столбцами

            for (int i = 0; i < n; i++) //по всем эл (строки)
            {
                for (int j = 0; j < m; j++) //(столб)
                {

                    int s = 1;
                    if (data[i, j] != 0)
                    {
                        while (s < n * m && arr[0, s] != data[i, j] && arr[0, s] != 0) //идем пока не находим дубликат или свободную ячейку
                        {
                            s++;
                        }


                        if (arr[0, s] != 0) //если ячейка заполнена повтор зн
                        {
                            if (arr[0, s] == data[i, j]) //совпадает ли тек знач с тем, что хранится в arr[0, s]
                            {
                                arr[1, s]++; //увеличиваем количество вхождений этого зн
                            }

                        }
                        else //если ячейка заполнена новым значением
                        {
                            arr[0, s] = data[i, j]; //добавляем новое зн
                            arr[1, s]++; //ставим счетчик на 1

                        }
                    }
                    else
                    {
                        arr[1, 0]++; //если эл равен 0, то увел кол-во нулей в массиве
                    }
                }


            }

            int MAX = 0;
            int f = 0;
            while (arr[1, f] != 1 && f < n * m) //кол-во вхождений равно 1 и не выходит за пределы мас
            {
                f++;
            }
            if (arr[1, f] == 1) //Если найдено значение с кол-вом вхождений 1
            {
                MAX = arr[0, f]; // первое найденное неповторяющ число
                for (int i = 0; i < n * m; i++)
                {
                    if (MAX < arr[0, i] && arr[1, i] == 1)
                    {
                        MAX = arr[0, i]; //обновляет макс, если нашел большее
                    }
                }

            }
            else
            {
                Console.WriteLine("Неповторяющихся чисел нет.");
            }
            return (MAX);
        }
    }
}