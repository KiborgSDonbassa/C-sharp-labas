using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace Laba3
{
    class doctor
    {
        private string secondName;
        private string specialization;

        public doctor(string a, string b)
        {
            secondName = a;
            specialization = b;
        }
        public void SNameLenght()
        {
            Console.WriteLine("Довжина прізвища: " + secondName.Length);
        }
    }

    class reception
    {
        private DateTime Day = new DateTime(2022, 3, 0);
        private int Zmina;
        private int countOfVisitors;
        private static int AllVisitors = 0;
        private static List<reception> AllReceptions = new List<reception>();
        private int CountOfVisitors
        {
            set
            {
                countOfVisitors = value;
                AllVisitors += countOfVisitors;
            }
        }
        public reception(int day, int zmina, int count)
        {
            AllReceptions.Add(this);
            Day += new TimeSpan(day);
            Zmina = zmina;
            CountOfVisitors = count;
        }
        static public void AllVisitorsCount()
        {
            Console.WriteLine("Загальна кількість відвідувачів: " + reception.AllVisitors);
        }
        static public void MinVisitors()
        {
            int min = AllReceptions[0].countOfVisitors;
            for (int i = 0; i < AllReceptions.Count; i++)
            {
                if (AllReceptions[i].countOfVisitors < min)
                {
                    min = AllReceptions[i].countOfVisitors;
                }
            }
            Console.WriteLine("Мінімальна кількість відвідувачів: " + min);
        }
    }
    class laba3
    {
        static void Main(string[] args)
        {
            doctor doc = new doctor("Maxim", "dermatolog");
            reception nn = new reception(4, 4, 8);
            reception nn2 = new reception(4, 4, 5);
            reception nn3 = new reception(4, 4, 9);
            doc.SNameLenght();
            reception.AllVisitorsCount();
            reception.MinVisitors();
        }
    }
}

class MailAccount
{
    private string E_mail;
    private string Name;
    
}

class Spam
{
    private DateTime date;
    private int SpamMessagesCount;
    public static int AllSpamMessagesCount = 0;

    Spam()
    {
        AllSpamMessagesCount++;
    }
}
