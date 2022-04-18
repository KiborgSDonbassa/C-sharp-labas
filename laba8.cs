using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Net.Mail;
using System.Net.Sockets;
using System.Numerics;
using System.Xml;

namespace Laba8
{
    public class Subject
    {
        public string name;
        public string teacherName;
        public string testForm;
        public int half;
        public int hoursCount;
        public int subjectID;
        public static List<Subject> allSubj = new List<Subject>();

        public Subject(string _name, string _teacherName, string _testForm, int _half, int _hoursCount, int _subjectID)
        {
            name = _name;
            teacherName = _teacherName;
            testForm = _testForm;
            half = _half;
            hoursCount = _hoursCount;
            subjectID = _subjectID;
            allSubj.Add(this);
        }
    }
    
    public class Profession
    {
        public int ID;
        public string name;
        public int hall;
        public static List<Profession> allProf = new List<Profession>();

        public Profession(int _ID, string _name, int _hall)
        {
            ID = _ID;
            name = _name;
            hall = _hall;
            allProf.Add(this);
        }
    }
    
    public class Program
    {
        static void z1(int i)
        {
            List<Subject> subj = (from a in Subject.allSubj where a.half == i select a).ToList();
            for (int j = 0; j < subj.Count; j++)
            {
                Console.WriteLine(subj[j].name + "\t" + subj[j].teacherName + "\t" +
                                  subj[j].testForm + "\t\t" + subj[j].half.ToString() + "\t" +
                                  subj[j].hoursCount);
            }
        }

        static void z2(string testForm)
        {
            List<Subject> subj = (from a in Subject.allSubj where a.testForm == testForm select a).ToList();
            for (int j = 0; j < subj.Count; j++)
            {
                Console.WriteLine(subj[j].name + "\t" + subj[j].teacherName + "\t" +
                                  subj[j].testForm + "\t\t" + subj[j].half.ToString() + "\t" +
                                  subj[j].hoursCount);
            }
        }

        static void z3(int border1, int border2)
        {
            List<Subject> subj = (from a in Subject.allSubj where a.hoursCount >= border1 && 
                                                                 a.hoursCount <= border2 select a).ToList();
            for (int j = 0; j < subj.Count; j++)
            {
                Console.WriteLine(subj[j].name + "\t" + subj[j].teacherName + "\t" +
                                  subj[j].testForm + "\t" + subj[j].half.ToString() + "\t" +
                                  subj[j].hoursCount);
            }
        }

        static void z4(int half)
        {
            List<Subject> subj = (from a in Subject.allSubj where a.half == half select a).ToList();
            for (int j = 0; j < subj.Count; j++)
            {
                Console.WriteLine(subj[j].teacherName + "\t" + subj[j].name);
            }
        }

        static void z5(string teacherName)
        {
            int count = (from a in Subject.allSubj where a.teacherName == teacherName select a.hoursCount).Sum();
            Console.WriteLine("Кількість годин: " + count);
        }

        static void z6()
        {
            var subj = from a in Subject.allSubj group a by a.subjectID;
            foreach (var a in subj)
            {
                string name = (from df in Profession.allProf where df.ID == a.Key select df.name).FirstOrDefault();
                Console.WriteLine("Дисципліна: " + name);
                foreach (var d in a)
                {
                    Console.WriteLine(d.name + "\t" + d.teacherName + "\t" +
                                                      d.testForm + "\t\t" + d.half.ToString() + "\t" +
                                                      d.hoursCount);
                }
                Console.WriteLine();
                
            }
        }

        static void z7()
        {
            var aboba = from subj in Subject.allSubj join prof in Profession.allProf on subj.subjectID equals prof.ID
                select new {name = subj.name, half = subj.half, profName = prof.name, hall = prof.hall};
            foreach (var a in aboba)
            {
                Console.WriteLine(a.name + "\t" + a.half + "\t" +
                                  a.profName + "\t" + a.hall);
            }
        }
        
        static void Main(string[] args)
        {
            if (true)
            {
                Subject s1 = new Subject("Математика", "Токар Максим Дмитрович", "Test", 1, 19, 1);
                Subject s2 = new Subject("Iнформатика", "Токар Артем Дмитрович", "Nothing", 2, 24, 1);
                Subject s3 = new Subject("Англ. Мова", "Токар Едуард Дмитрович", "Money", 1, 35, 2);
                Subject s4 = new Subject("Лiтература", "Токар Вiталiй Дмитрович", "Money", 2, 16, 1);
                Subject s5 = new Subject("Iсторiя--а", "Токар Максим Дмитрович", "Test", 2, 11, 2);
                Subject s6 = new Subject("Географiя", "Токар Анатолiй Дмитрович", "Test", 2, 29, 2);

                Profession p1 = new Profession(2, "Трубочист", 1);

                Profession p2 = new Profession(1, "Программiст", 3);

                Console.WriteLine("Назва дисциплiни" + "\t" + "Iм'я викладача" + "\t" 
                                  + "Форма тестування" + "\t" + "Семестр" + "\t" + "Кiлькiсть годин");
                for (int i = 0; i < Subject.allSubj.Count; i++)
                {
                    Console.WriteLine(Subject.allSubj[i].name + "\t" + Subject.allSubj[i].teacherName + "\t" +
                                      Subject.allSubj[i].testForm + "\t\t" + Subject.allSubj[i].half.ToString() + "\t" +
                                      Subject.allSubj[i].hoursCount);
                }
                Console.WriteLine();
                Console.WriteLine("Назва" + "\t" + "Вiддiлення");
                for (int i = 0; i < Profession.allProf.Count; i++)
                {
                    Console.WriteLine(Profession.allProf[i].name + "\t" + Profession.allProf[i].hall);
                }
                Console.WriteLine();
                Console.WriteLine("1. Дисципліни за вказаний семестр");
                Console.WriteLine("2. Дисципліни за формою підсумкового контролю");
                Console.WriteLine("3. Дисципліни за діапазоном годин");
                Console.WriteLine("4. ПІБ викладачів та назви дисциплін за семестр");
                Console.WriteLine("5. Кількість годин за вказаним викладачем");
                Console.WriteLine("6. Список усіх дисциплін по спеціальності");
                Console.WriteLine("7. Назва та семестри дисциплін з зазначенням спеціальності та відділення");
            }

            while (true)
            {
                Console.Write("Виберіть опцію: ");
                int a = Convert.ToInt32(Console.ReadLine());
                switch (a)
                {
                    case (1):
                        Console.Write("Введіть семестр(1,2): ");
                        int sem = Convert.ToInt32(Console.ReadLine());
                        z1(sem);
                        break;
                    case (2):
                        Console.Write("Введіть форму контролю(Test, Nothing, Money): ");
                        string form = Console.ReadLine();
                        z2(form);
                        break;
                    case (3):
                        Console.WriteLine("Введіть діапазон годин: ");
                        Console.Write("\tВід: ");
                        int bor1 = Convert.ToInt32(Console.ReadLine());
                        Console.Write("\tДо: ");
                        int bor2 = Convert.ToInt32(Console.ReadLine());
                        z3(bor1, bor2);
                        break;
                    case (4):
                        Console.Write("Введіть семестр(1,2): ");
                        int semm = Convert.ToInt32(Console.ReadLine());
                        z4(semm);
                        break;
                    case (5):
                        Console.Write("Введіть ім'я викладача: ");
                        string tName = Console.ReadLine();
                        z5(tName);
                        break;
                    case (6):
                        z6();
                        break;
                    case (7):
                        z7();
                        break;
                }
            }
        }
    }
}
