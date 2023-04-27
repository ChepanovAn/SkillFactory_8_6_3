using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillFactory_8_6_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string folderPathInfo = "/Users/anatoliy.chepanov/Desktop/Example";

            DirectoryInfo folderPath = new DirectoryInfo("/Users/anatoliy.chepanov/Desktop/Example");

            if (Directory.Exists(folderPathInfo))
            {
                DateTime dt = File.GetLastAccessTime(folderPathInfo);

                Console.WriteLine("Последнее время обращения к папке: " + dt);

                DateTime DateLimit = dt.AddMinutes(30);

                if (DateTime.Now > DateLimit)
                {

                    try
                    {

                        Console.WriteLine($"Исходный размер папки: {DirectoryExtension.DirSize(folderPath)} байт");

                        var memory = DirectoryExtension.DirSize(folderPath);

                        if (memory > 0)
                        {

                            try
                            {
                                DirectoryInfo dirInfo = new DirectoryInfo("/Users/anatoliy.chepanov/Desktop/Example");

                                foreach (FileInfo file in dirInfo.GetFiles())
                                {
                                    file.Delete();
                                }

                                foreach (DirectoryInfo dir in dirInfo.GetDirectories())
                                {
                                    dir.Delete(true);
                                }

                                Console.WriteLine($"Освобождено: {memory} байт\nТекущий размер папки: {DirectoryExtension.DirSize(folderPath)} байт");
                            }
                            catch (Exception)
                            {
                                Console.WriteLine();
                            }
                        }

                        else Console.WriteLine($"Папка {folderPath.Name} пустая");
                    }

                    catch (Exception)
                    {
                        Console.WriteLine(folderPath.Name + $" - Не удалось рассчитать размер");
                    }
                }

                else Console.WriteLine($"Время обращения к папке {folderPath.Name} еще не закончилось.");

            }

            else Console.WriteLine("Папка по заданному адресу не существует, передан некорректный путь.");

            Console.ReadKey();
        }

    }
}
