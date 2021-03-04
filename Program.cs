using System;
using System.IO;
using System.Collections.Generic;
using CsvHelper;
namespace Task2
{
    class Program
    {
        
        static void Main(string[] args)
        {
            List<Int32> numbers = new List<Int32>();
            // Путь к файлу numbers.csv
            string path = "C:/numbers.csv";
            // Создание потока чтения в файл
            using (StreamReader streamRead = new StreamReader(path))
            {
                // Настраиваем разделитель csv файла
                var config = new CsvHelper.Configuration.CsvConfiguration(System.Globalization.CultureInfo.CurrentCulture) { Delimiter = "," };
                // Создание потока чтения csv файла на основе потока чтения файла
                using (CsvReader csvRead = new CsvReader(streamRead, config))
                {
                    // Считываем строку из файла numbers.csv
                    csvRead.Read();
                    // Цикл чтения столбцов
                    for (int i = 0; i < 100; i++)
                    {
                        // Считываем и выводим в консоль числа
                        numbers.Add(Convert.ToInt32(csvRead.GetField(i)));
                    }
                }
            }
            numbers = Sortirovka(numbers);
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(numbers[i]);
            }
        }
        // Функция сортировки
        static List<Int32> Sortirovka(List<Int32> inputArray)
        {
            // Буферная переменная
            int temporary = 0;
            // Цикл сортировки 
            for (int i = 0; i < inputArray.Count; i++)
            {
                for (int j = i + 1; j < inputArray.Count; j++)
                {
                    if (inputArray[i] > inputArray[j])
                    {
                        temporary = inputArray[i];
                        inputArray[i] = inputArray[j];
                        inputArray[j] = temporary;
                    }
                }
            }
            // Возврат массива
            return inputArray;
        }
    }
}
