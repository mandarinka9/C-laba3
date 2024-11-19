using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace laba3
{
    public static class FileOperations
    {
        //4 задание
        public static void Nef4(string path, int Nelem)//Пути к файлам
        {
            File.Create(path).Close();//Создание файла
            Fillnefrand(path, Nelem);//Заполнение файла
            Readchet(path, Nelem);// чтение файла
        }

        public static void Fillnefrand(string path, int Nelem) //заполнение файла ранд числами
        {
            Random rand = new Random();

            for (int i = 0; i < Nelem; i++)//Кол-во элементов
            {
                // дозапись в конец файла
                File.AppendAllText(path, (rand.Next(0, 100)).ToString() + "\n");
            }
        }

        public static void Readchet(string path, int Nelem)
        {
            File.Create(@"C:\Users\Marin\Downloads\\ex4-2.bin").Close(); //файл для четных чисел
            using (StreamReader sr = new StreamReader(path)) //читаем
            {
                for (int i = 0; i < Nelem; i++)
                {
                    int num = int.Parse(sr.ReadLine()); //строка в число
                    if (num % 2 == 0)
                    {
                        File.AppendAllText(@"C:\Users\Marin\Downloads\\ex4-2.bin", num + "\n");
                    }

                }


            }
            Console.WriteLine("Четные элементы файла записаны в новый файл");
        }


        //5 задание
        public struct Baggage
        {
            public string Name;
            public double Weight;
        }

        public static void Nef5(string path, int Nbag, double mas)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create))) //открываем бинарный файл
            {
                string bag;
                double weight;

                var baggages = new Baggage[Nbag]; //созд массив для хранения количества багажа

                for (int i = 0; i < Nbag; i++) //вводим данные о каждом багаже
                {
                    Console.WriteLine("Введите название багажа:");
                    bag = Console.ReadLine();

                    Console.WriteLine("Введите массу багажа:");
                    weight = double.Parse(Console.ReadLine());
                    baggages[i] = new Baggage(); //новая структура
                    baggages[i].Name = bag; // уст название багажа
                    baggages[i].Weight = weight; //уст вес багажа
                }


                foreach (var baggage in baggages) //перебирает каждый эл в массиве baggages и записывает в бин файл
                {
                    writer.Write(baggage.Name);
                    writer.Write(baggage.Weight);
                }
            }



            double totalWeight = 0;
            int count = 0; //кол-во багажа

            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                while (reader.BaseStream.Position != reader.BaseStream.Length) //пока не конец файла
                {
                    string name = reader.ReadString(); //считывает назв и вес
                    double weight = reader.ReadDouble();
                    totalWeight += weight;
                    count++;
                }
            }

            double overallAverage = totalWeight / count; //ср вес багажа

            // Теперь найдем багаж, средняя масса которого отличается не более чем на m кг
            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                Console.WriteLine("Багаж, соответствующий критериям:");
                while (reader.BaseStream.Position != reader.BaseStream.Length)
                {
                    string name = reader.ReadString();
                    double weight = reader.ReadDouble();

                    if (Math.Abs(weight - overallAverage) <= mas)
                    {
                        Console.WriteLine($"Название: {name}, Масса: {weight}");
                    }
                }
            }
        }

        //6 задание
        public static void Nef6(string path, int Nelem)
        {
            File.Create(path).Close();

            Fillnefrand(path, Nelem * 2); //Заполнение файла числами

            PartvsPart(path, Nelem);

        }
        public static void PartvsPart(string path, int Nelem)
        {

            using (StreamReader sr = new StreamReader(path))
            {
                double part1 = 0;
                double part2 = 0;
                for (int i = 0; i < Nelem * 2; i++) //проходим по каждому эл
                {
                    double num = double.Parse(sr.ReadLine()); //чтение строк из файла и преобразование в тип double
                    if (i < Nelem)
                    {
                        part1 += num;
                    }
                    else
                    {
                        part2 += num;
                    }

                }
                part1 = part1 - part2;
                Console.WriteLine("Разность суммы двух частей равна: " + part1);

            }
        }


        //7 задание
        public static void Nef7(string path, int Nelem)
        {
            File.Create(path).Close();

            Fillnef7(path, Nelem); //Заполнение файла числами

            Sumnef7(path, Nelem); //Поиск и вывод суммы всех чисел
        }


        public static void Fillnef7(string path, int Nelem)
        {
            Random rand = new Random();
            int StrElem = rand.Next(1, 10);
            for (int i = 0; i < Nelem; i++)//Кол-во строк
            {
                for (int j = 0; j < StrElem; j++)//Заполнение строк элементами
                {
                    // дозапись в конец файла
                    File.AppendAllText(path, (rand.Next(0, 100)).ToString() + " ");
                }
                File.AppendAllText(path, "\n");

            }
        }

        public static void Sumnef7(string path, int Nelem)
        {

            using (StreamReader sr = new StreamReader(path))
            {
                int sum = 0;
                for (int i = 0; i < Nelem; i++) //читать все строки из файла
                {
                    string[] nums = sr.ReadLine().Split(' '); //разбиваем на строки массива по пробелам. 
                    for (int j = 0; j < nums.Length - 1; j++) //проходим по всем эл мас nums, кроме посл (пробел)
                    {
                        sum += int.Parse(nums[j]); //строка в число и +сум
                    }


                }

                Console.WriteLine("Сумма всех элементов равна: " + sum);

            }
        }

        //8 задание
        public static void Nef8(string path, int Nelem)
        {
            File.Create(path).Close();

            Fillnefrandword8(path, Nelem); //Заполнение файла словами

            Minmax8(path, Nelem); //Поиск и запись в другой файл минимального и максимального слова
        }

        public static void Fillnefrandword8(string path, int Nelem)
        {
            Random rand = new Random();
            string word = "";
            int ran = rand.Next(1, 30); //случ кол-во символов
            string symbols = "qwertyuiopasdfghjklzxcvbnm";
            for (int i = 0; i < Nelem; i++)//Кол-во слов
            {
                for (int j = 0; j < ran; j++) //для формирования слова
                {
                    word += symbols[(rand.Next(0, symbols.Length))]; 
                }
                File.AppendAllText(path, word + "\n"); //слово в файл
                word = ""; //обнуляем слово для формиров след
                ran = rand.Next(1, 30);
            }
        }

        public static void Minmax8(string path, int Nelem)
        {
            string min, max, next;
            using (StreamReader sr = new StreamReader(path))
            {
                min = (sr.ReadLine()); //читаем первое слово из файла
                max = min;
                for (int i = 0; i < Nelem - 1; i++) //читает все строчки
                {
                    next = sr.ReadLine();
                    if (next.Length < min.Length)
                    {
                        min = next;
                    }
                    if (next.Length > max.Length)
                    {
                        max = next;
                    }
                }

            }

            File.Create(@"C:\Users\Marin\Downloads\\ex8-2.txt").Close();
            File.AppendAllText(@"C:\Users\Marin\Downloads\\ex8-2.txt", min + "\n");
            File.AppendAllText(@"C:\Users\Marin\Downloads\\ex8-2.txt", max + "\n");
            Console.WriteLine("Результаты записаны в файл");





        }


    }
}