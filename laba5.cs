using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Net.Sockets;
using System.Numerics;

namespace Laba5
{
    class Monitor
    {
        private static List<Monitor> AllMonitors = new List<Monitor>();
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

        public static void AllMonitorsInfo()
        {
            foreach (Monitor i in AllMonitors)
            {
                i.OutputInfo();
            }
        }
    }
    class laba5
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
                Console.WriteLine("4. Вийти");
                Console.Write("Що робити: ");
                int i = Convert.ToInt32(Console.ReadLine());
                switch (i)
                {
                    case (1):
                        Monitor b = new Monitor();
                        b.InputInfo();
                        a.Add(b);
                        break;
                    case (2):
                        Monitor.AllMonitorsInfo();
                        break;
                    case (3):
                        Console.Write("Номер монітора: ");
                        int f = Convert.ToInt32(Console.ReadLine());
                        a.RemoveAt(f);
                        break;
                    case (4):
                        return;
                }
            }
        }
    }
        
}
