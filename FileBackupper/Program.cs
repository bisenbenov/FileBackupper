using System;

namespace FileBackupper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Начинаю копирование!");
            FileBackupper fileBackupper = new FileBackupper(ConfigurationData.GetDataFromJson("config.json"));
            fileBackupper.StartBackup();
            Console.WriteLine("Копирование завершено!");
        }
    }
}
