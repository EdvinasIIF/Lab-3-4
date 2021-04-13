using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Lab_3_4_v0._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "", surname = "";
            int n = 0;
            double exam = 0;
            Random rnd = new Random();
            Console.WriteLine("Meniu:");
            Console.WriteLine("1. Ivesti studenta.");
            string input = Console.ReadLine();
            int a;
            List<Student> studentList = new List<Student>();
           
                a = Int32.Parse(input);
                switch (a)
                {
                    case 1:
                        Console.WriteLine("Ar norite 1-ivesti studenta ar 2-nuskaityti is failo");
                       
                            int e = Int32.Parse(Console.ReadLine());
                            switch (e)
                            {
                                case 1:
                                    Console.WriteLine("Ivesti studento varda");
                                    name = Console.ReadLine();
                                    Console.WriteLine("Ivesti studento pavarde");
                                    surname = Console.ReadLine();
                                    Console.WriteLine("Ivesti namu darbu kieki:");
                                    n = Int32.Parse(Console.ReadLine());
                                    Console.WriteLine("Ivesite 1 - ranka ar 2 - sugeneretuoti:");
                                    int b = Int32.Parse(Console.ReadLine());
                                    List<double> hwList = new List<double>();
                                    switch (b)
                                    {
                                        case 1:
                                            for (int i = 0; i < n; i++)
                                            {

                                                Console.WriteLine("Ivesti {0} namu darbo rezultata:", i + 1);
                                                hwList.Add(Double.Parse(Console.ReadLine()));
                                            }
                                            break;
                                        case 2:
                                            for (int i = 0; i < n; i++)
                                            {
                                                int random = rnd.Next(1, 11);
                                                Console.WriteLine("Sugeneruotas: {0}", random);
                                                hwList.Add(random);
                                            }
                                            break;
                                        default:
                                            Console.WriteLine("Ivedete neteisingai");
                                            break;
                                    }
                                    Console.WriteLine("Ivesti egzamino rezultata:");
                                    exam = Double.Parse(Console.ReadLine());
                                    Student student = new Student(name, surname, n, hwList, exam);
                                    studentList.Add(student);

                                    break;
                                case 2:
                                    
                                        var lines = File.ReadAllLines("students.csv");
                                        foreach (var i in lines)
                                        {
                                            List<double> hwList1 = new List<double>();
                                            var val = i.Split(',');
                                            name = val[0];
                                            surname = val[1];
                                            n = 5;
                                            for (int j = 2; j < 7; j++)
                                            {
                                                hwList1.Add(double.Parse(val[j], CultureInfo.InvariantCulture));
                                            }
                                            exam = double.Parse(val[7], CultureInfo.InvariantCulture);
                                            Student student1 = new Student(name, surname, n, hwList1, exam);
                                            studentList.Add(student1);
                                        }
                                    
                                    break;
                                default:
                                    Console.WriteLine("Ivedete neteisingai");
                                    goto case 1;
                                    break;
                            }
                        break;
                    default:
                        break;
                }
                string obj = string.Empty;
                Console.WriteLine("Pasirinkite:\n 1 - vidurkis\n 2 - mediana \n");
               
                    int s = Int32.Parse(Console.ReadLine());
                    studentList = studentList.OrderBy(o => o.Name).ToList();
                    switch (s)
                    {
                        case 1:
                            obj += string.Format("Surname        Name           Final points(Avg.)\n" +
                            "------------------------------------------------\n");
                            foreach (var i in studentList)
                            {
                                double vidurk = 0;
                                for (int j = 0; j < i.N; j++)
                                {
                                    vidurk += i.Homeworks[j];
                                }
                                vidurk = ((vidurk / n) * 0.3) + (exam * 0.7);
                                obj += string.Format("{0, -15}{1, -29}{2:0.00}\n", i.Surname, i.Name, vidurk);
                            }
                            Console.WriteLine(obj);
                            break;
                        case 2:
                            obj += string.Format("Surname        Name           Final points(Med.)\n" +
                            "------------------------------------------------\n");
                            int index1 = 0;
                            foreach (var i in studentList)
                            {
                                double median = 0;
                                if (i.N % 2 == 0)
                                {

                                    median += i.Homeworks[i.N / 2];
                                    median += i.Homeworks[i.N / 2 - 1];
                                    median = median / 2;
                                }
                                else if (n % 2 == 1)
                                {
                                    median = i.Homeworks[i.N / 2];
                                }
                                obj += string.Format("{0, -15}{1, -29}{2:0.00}\n", i.Surname, i.Name, median);
                                index1++;
                            }
                            Console.WriteLine(obj);
                            break;
                        default:
                            break;
                    }
        }
    }
}
