using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2_8
{
    internal static class DZ
    {
        //Объедините две предыдущих работы(практические работы 2 и 3): поиск файла и поиск текста в файле 
        //написав утилиту которая ищет файлы определенного расширения с указанным текстом.Рекурсивно.
        //Пример вызова утилиты: utility.exe txt текст.
        public static void FileSearch()
        {
            Console.WriteLine("Введите искомый файл");
            string lookingFile = Console.ReadLine()!;
            Console.WriteLine("Введите искомый текст");
            string lookingText = Console.ReadLine()!;
            Console.WriteLine("Введите директорию для поиска(необязательно)");
            string? directory = Console.ReadLine();
            if (lookingFile == null || lookingText == null) Console.WriteLine("Для поиска введите имя искомого файла и искомого текста");
            else RecursiveSearch(lookingFile, lookingText, directory); //RecursiveSearch("test.txt", "1", null);
        }
        private static void RecursiveSearch(in string lookingFile,in string lookingText, string? directory)
        {
            if (directory == null) directory = @"C:\Users\ASUS\Study$";
            var directories = Directory.EnumerateDirectories(directory);
            foreach (var d in directories)
            {
                RecursiveSearch(in lookingFile, in lookingText, d);
            }
            var fils = Directory.EnumerateFiles(directory);
            foreach (var file in fils)
            {
                if (file.Contains(lookingFile)){
                    WriteFile(directory, file);
                    SearchByFile(file, lookingText);
                }
            }
        }

        private static void SearchByFile(string file, string lookingText)
        {
            using (var sr = new StreamReader(file))
            {
                bool flag = false;
                while (!sr.EndOfStream)
                {
                    string value = sr.ReadLine()!;
                    if (value.Contains(lookingText)){
                        flag = true;
                        Console.WriteLine(value);
                    }
                }
                if (!flag) Console.WriteLine("Файл не содержит искомой записи");
                Console.WriteLine();
            }
        }

        private static void WriteFile(string directory, string fileName)
        {
            fileName = fileName.Split(@"\")[fileName.Split(@"\").Length - 1];
            Console.WriteLine(fileName + "\t" + directory);
        }
    }
}
