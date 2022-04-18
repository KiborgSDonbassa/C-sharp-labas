using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Net.Sockets;

namespace Laba4
{
    abstract class Trans
    {
        protected string CarMake;
        protected string NumberPlate;
        protected static List<Trans> tr = new List<Trans>();
        protected int speed;
        protected int loadСapacity;
        
        abstract public void Info();

        public static void AllTransportInfo()
        {
            for (int i = 0; i < tr.Count; i++)
            {
                tr[i].Info();
            }
        }
    }

    class PassengerСar : Trans
    {
    
    
    
    
    
        public PassengerСar()
        {
            Console.WriteLine("Легкова автівка");
            Console.Write("Марка авто: ");
            CarMake = Console.ReadLine();
            Console.Write("Номерний знак: ");
            NumberPlate = Console.ReadLine();
            Console.Write("Швидкість: ");
            speed = Convert.ToInt32(Console.ReadLine());
            Console.Write("Вантажопідйомність: ");
            loadСapacity = Convert.ToInt32(Console.ReadLine());
            tr.Add(this);
        }
        override public void Info()
        {
            Console.WriteLine("Легкова автівка: ");
            Console.WriteLine("\tМарка транспорту: " + CarMake);
            Console.WriteLine("\tНомер: " + NumberPlate);
            Console.WriteLine("\tШвидкість: " + speed);
            Console.WriteLine("\tВантажопідйомність: " + loadСapacity);
        }
    }

    class Motorcycle : Trans
    {
        private bool carriage;
        
        public Motorcycle()
        {
            Console.WriteLine("Мотоцикл");
            Console.Write("Марка мотоцикла: ");
            CarMake = Console.ReadLine();
            Console.Write("Номерний знак: ");
            NumberPlate = Console.ReadLine();
            Console.Write("Швидкість: ");
            speed = Convert.ToInt32(Console.ReadLine());
            Console.Write("Вантажопідйомність: ");
            loadСapacity = Convert.ToInt32(Console.ReadLine());
            Console.Write("Наявність коляски(ДА,НЕ): ");
            if (Console.ReadLine() == "ДА") 
                carriage = true;
            else 
                carriage = false;
            if (carriage == false) loadСapacity = 0;
            Trans.tr.Add(this);
        }
        
        override public void Info()
        {
            Console.WriteLine("Мотоцикл: ");
            Console.WriteLine("\tМарка мотоцикла: " + CarMake);
            Console.WriteLine("\tНомер: " + NumberPlate);
            Console.WriteLine("\tШвидкість: " + speed);
            Console.WriteLine("\tВантажопідйомність: " + loadСapacity);
            Console.WriteLine("\tНаявність коляски: " + carriage);
        }
    }
    class Track : Trans
    {
        private bool trailer;
        public Track()
        {
            Console.WriteLine("Вантажівка");
            Console.Write("Марка вантажівки: ");
            CarMake = Console.ReadLine();
            Console.Write("Номерний знак: ");
            NumberPlate = Console.ReadLine();
            Console.Write("Швидкість: ");
            speed = Convert.ToInt32(Console.ReadLine());
            Console.Write("Вантажопідйомність: ");
            loadСapacity = Convert.ToInt32(Console.ReadLine());
            Console.Write("Наявність прицепа(ДА,НЕ): ");
            if (Console.ReadLine() == "ДА") 
                trailer = true;
            else 
                trailer = false;
            if (trailer == false) loadСapacity *= 2;
            Trans.tr.Add(this);
        }

        override public void Info()
        {
            Console.WriteLine("Вантажівка: ");
            Console.WriteLine("\tМарка вантажівки: " + CarMake);
            Console.WriteLine("\tНомер: " + NumberPlate);
            Console.WriteLine("\tШвидкість: " + speed);
            Console.WriteLine("\tВантажопідйомність: " + loadСapacity);
            Console.WriteLine("\tНаявність прицепа: " + trailer);
        }
    }
    class laba4
    {
        static void Main(string[] args)
        {
            Track[] tracks = new Track[2];
            for (int i = 0; i < tracks.Length; i++) tracks[i] = new Track();
            Motorcycle[] motorcycles = new Motorcycle[3];
            for (int i = 0; i < motorcycles.Length; i++) motorcycles[i] = new Motorcycle();
            PassengerСar[] passengerСars = new PassengerСar[1];
            for (int i = 0; i < passengerСars.Length; i++) passengerСars[i] = new PassengerСar();
            Trans.AllTransportInfo();
        }
    }
        
}
