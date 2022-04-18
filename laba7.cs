using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Net.Sockets;
using System.Numerics;

namespace Laba7
{
    class Monitor
    {
        public static List<Monitor> AllMonitors = new List<Monitor>();
        private string model;
        private int Screen_resolution_X;
        private int Screen_resolution_Y;
        private int Brightness;
        private int Price;

        public Monitor()
        {
            AllMonitors.Add(this);
        }

        public void InputInfo()
        {
            Console.WriteLine("Монітор: ");
            Console.Write("\tМодель: ");
            model = Console.ReadLine();
            Console.WriteLine("\tРозширення екрану: ");
            Console.Write("\t\tX: ");
            Screen_resolution_X = Convert.ToInt32(Console.ReadLine());
            Console.Write("\t\tY: ");
            Screen_resolution_Y = Convert.ToInt32(Console.ReadLine());
            Console.Write("\tЯркість: ");
            Brightness = Convert.ToInt32(Console.ReadLine());
            Console.Write("\tЦіна: ");
            Price = Convert.ToInt32(Console.ReadLine());
        }

        public void OutputInfo()
        {
            Console.WriteLine("Монітор: ");
            Console.WriteLine("\tМодель: " + model);
            Console.WriteLine("\tРозширення екрану: " + Screen_resolution_X + "/" + Screen_resolution_Y);
            Console.WriteLine("\tЯркість екрану: " + Brightness);
            Console.WriteLine("\tЦіна: " + Price);
        }

        public static void AllMonitorsInfo(List<Monitor> a)
        {
            foreach (Monitor i in a)
            {
                i.OutputInfo();
            }
        }

        public static void AllMonitorsWriteFile()
        {
            for (int i = 0; i < AllMonitors.Count; i++)
            {
                string path = "C:/Users/GSM-service/Desktop/Laba7_Files/" + i + "_Monitor";
                Directory.CreateDirectory(path);
                WriteFile(path + "/model", AllMonitors[i].model);
                WriteFile(path + "/X_resolution", AllMonitors[i].Screen_resolution_X.ToString());
                WriteFile(path + "/Y_resolution", AllMonitors[i].Screen_resolution_Y.ToString());
                WriteFile(path + "/brightness", AllMonitors[i].Brightness.ToString());
                WriteFile(path + "/price", AllMonitors[i].Price.ToString());
            }
        }

        public static List<Monitor> ReadMonitorsFromDirectory(string pathDirectory)
        {
            List<Monitor> monitorsFromFile = new List<Monitor>();
            int monitorsCount;
            monitorsCount = new DirectoryInfo(pathDirectory).GetDirectories().Length;
            Console.WriteLine("Кількість моніторів в файлі: " + monitorsCount);
            for (int i = 0; i < monitorsCount; i++)
            {
                Monitor a = new Monitor();
                a.model = ReadFile(pathDirectory + "/" + i + "_Monitor/model");
                a.Screen_resolution_X = Int32.Parse(ReadFile(pathDirectory + "/" + i + "_Monitor/X_resolution"));
                a.Screen_resolution_Y = Int32.Parse(ReadFile(pathDirectory + "/" + i + "_Monitor/Y_resolution"));
                a.Brightness = Int32.Parse(ReadFile(pathDirectory + "/" + i + "_Monitor/brightness"));
                a.Price = Int32.Parse(ReadFile(pathDirectory + "/" + i + "_Monitor/price"));
                monitorsFromFile.Add(a);
            }

            return monitorsFromFile;
        }
        
        static void WriteFile(string filePath, string info)
        { 
            using (FileStream fStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                byte[] bStream = System.Text.Encoding.Default.GetBytes(info);
                fStream.Write(bStream, 0, bStream.Length);
            }
        }
        
        static string ReadFile(string filePath)
        { 
            using (FileStream fStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            { 
                byte[] bStream = new byte[(int)fStream.Length];
                fStream.Read(bStream, 0, bStream.Length);
                return System.Text.Encoding.Default.GetString(bStream);
            }
        }
    }

    class laba7
    {
        static void Main(string[] args)
        {
            List<Monitor> a = new List<Monitor>();
            while (true)
            {
                Console.WriteLine("Кількість моніторів: " + a.Count);
                Console.WriteLine("1. Додати новий монітор");
                Console.WriteLine("2. Інформація про всі монітори");
                Console.WriteLine("3. Видалити монітор за номером");
                Console.WriteLine("4. Запис всіх моніторів у файл");
                Console.WriteLine("5. Вивід моніторів з папки");
                Console.WriteLine("6. Вийти");
                Console.Write("Виберіть опцію: ");
                int i = Convert.ToInt32(Console.ReadLine());
                switch (i)
                {
                    case (1):
                        Monitor b = new Monitor();
                        b.InputInfo();
                        a.Add(b);
                        break;
                    case (2):
                        Monitor.AllMonitorsInfo(Monitor.AllMonitors);
                        break;
                    case (3):
                        Console.Write("Номер монітора: ");
                        int f = Convert.ToInt32(Console.ReadLine());
                        a.RemoveAt(f);
                        break;
                    case (4):
                        Monitor.AllMonitorsWriteFile();
                        break;
                    case (5):
                        string path;
                        Console.Write("Введіть шлях до папки: ");
                        path = Console.ReadLine();
                        Monitor.AllMonitorsInfo(Monitor.ReadMonitorsFromDirectory(path));
                        break;
                    case (6):
                        return;
                }
            }
        }
    }
}
