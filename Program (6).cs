using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Lab_3_4
{
    class Program
    {
        public struct Stud
        {
            public string name;
            public string surname;
            public double finalScore;
            
        }
        static void Main(string[] args)
        {
            string name="", surname="";
            int n = 0;
            double exam = 0;
            Random rnd = new Random();
            Console.WriteLine("Meniu:");
            List<StudentClass> studentList = new List<StudentClass>();
            LinkedList<StudentClass> studentLinkedList = new LinkedList<StudentClass>();
            Queue<StudentClass> studentQueue = new Queue<StudentClass>();

            Console.WriteLine("Ar norite 1-ivesti studenta, ar 2-nuskaityti is failo, ar 3-10000 failas, 4-100000, 5-1000000, 6-10000000\n 7 - test Containers");
            try
            {
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
                        StudentClass student = new StudentClass(name, surname, n, hwList, exam);
                        studentList.Add(student);

                        break;
                    case 2:
                        try
                        {
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
                                StudentClass student1 = new StudentClass(name, surname, n, hwList1, exam);
                                studentList.Add(student1);
                            }
                        }
                        catch (IOException ioe)
                        {
                            Console.WriteLine(ioe);
                            Console.WriteLine("Iveskite ranka:");
                            goto case 1;
                        }
                        break;
                    case 3:
                        List<Stud> stdList = new List<Stud>();
                        for(int i = 0; i < 10000; i++)
                        {
                            Stud std = new Stud();
                            string names = "Name";
                            string surnames = "Surname";
                            n = 5;
                            List<double> hwList2 = new List<double>();
                            name = names + i.ToString();
                            surname = surnames + i.ToString();
                            double vidurk = 0;
                            for (int j = 0; j < 5; j++)
                            {
                                int random = rnd.Next(1, 11);
                                hwList2.Add(random);
                                vidurk += random; 
                            }
                            exam = rnd.Next(1,11);
                            vidurk = ((vidurk / n) * 0.3) + (exam * 0.7);
                            //studentList.Add(new StudentClass(name, surname, n, hwList2, exam));
                            std.name = name;
                            std.surname = surname;
                            std.finalScore = vidurk;
                            stdList.Add(std);
                        }
                        Console.WriteLine("File creation"); //169 ms
                        Console.ReadLine();

                        stdList = stdList.OrderBy(o => o.finalScore).ToList();
                        Console.WriteLine("Data Sorting"); //184 ms
                        Console.ReadLine();
                        List<Stud> stdListB = new List<Stud>();
                        List<Stud> stdListL = new List<Stud>();
                        stdListL = stdList.Where(c => c.finalScore < 5).ToList();
                        stdListB = stdList.Where(c => c.finalScore >= 5).ToList();
                        Console.WriteLine("Data splitting"); //154 ms
                        Console.ReadLine();
                        foreach (var line in stdListL)
                        {
                            File.AppendAllText("StudentFile1.csv", $"{line.name},{line.surname},{line.finalScore:0.00}\n");
                        }
                        foreach (var line in stdListB)
                        {
                            File.AppendAllText("StudentFile2.csv", $"{line.name},{line.surname},{line.finalScore:0.00}\n");
                        }
                        Console.WriteLine("File saving");//4,469 s
                        Console.ReadLine();
                        break;
                    case 4:
                        List<Stud> stdList1 = new List<Stud>();
                        for (int i = 0; i < 100000; i++)
                        {
                            Stud std = new Stud();
                            string names = "Name";
                            string surnames = "Surname";
                            n = 5;
                            List<double> hwList2 = new List<double>();
                            name = names + i.ToString();
                            surname = surnames + i.ToString();
                            double vidurk = 0;
                            for (int j = 0; j < 5; j++)
                            {
                                int random = rnd.Next(1, 11);
                                hwList2.Add(random);
                                vidurk += random;
                            }
                            exam = rnd.Next(1, 11);
                            vidurk = ((vidurk / n) * 0.3) + (exam * 0.7);
                            //studentList.Add(new StudentClass(name, surname, n, hwList2, exam));
                            std.name = name;
                            std.surname = surname;
                            std.finalScore = vidurk;
                            stdList1.Add(std);
                        }
                        Console.WriteLine("File creation");// 381,57 ms
                        Console.ReadLine();
                        stdList1 = stdList1.OrderBy(o => o.finalScore).ToList();
                        Console.WriteLine("Data Sorting");//508,761 ms
                        Console.ReadLine();
                        List<Stud> stdListL1 = new List<Stud>();
                        List<Stud> stdListB1 = new List<Stud>();
                        stdListL1 = stdList1.Where(c => c.finalScore < 5).ToList();
                        stdListB1 = stdList1.Where(c => c.finalScore >= 5).ToList();
                        Console.WriteLine("Data splitting");//381,571 ms
                        Console.ReadLine();
                        foreach (var line in stdListL1)
                        {
                            File.AppendAllText("StudentFile1.csv", $"{line.name},{line.surname},{line.finalScore:0.00}\n");
                        }
                        foreach (var line in stdListB1)
                        {
                            File.AppendAllText("StudentFile2.csv", $"{line.name},{line.surname},{line.finalScore:0.00}\n");
                        }
                        Console.WriteLine("File saving"); //49,476 s
                        Console.ReadLine();
                        break;
                    case 5:
                        List<Stud> stdList2 = new List<Stud>();
                        for (int i = 0; i < 1000000; i++)
                        {
                            Stud std = new Stud();
                            string names = "Name";
                            string surnames = "Surname";
                            n = 5;
                            List<double> hwList2 = new List<double>();
                            name = names + i.ToString();
                            surname = surnames + i.ToString();
                            double vidurk = 0;
                            for (int j = 0; j < 5; j++)
                            {
                                int random = rnd.Next(1, 11);
                                hwList2.Add(random);
                                vidurk += random;
                            }
                            exam = rnd.Next(1, 11);
                            vidurk = ((vidurk / n) * 0.3) + (exam * 0.7);
                            //studentList.Add(new StudentClass(name, surname, n, hwList2, exam));
                            std.name = name;
                            std.surname = surname;
                            std.finalScore = vidurk;
                            stdList2.Add(std);
                        }
                        Console.WriteLine("File creation"); // 1,423 s
                        Console.ReadLine();
                        stdList2 = stdList2.OrderBy(o => o.finalScore).ToList();
                        Console.WriteLine("Data Sorting"); // 913,01 ms
                        Console.ReadLine();
                        List<Stud> stdListL2 = new List<Stud>();
                        List<Stud> stdListB2 = new List<Stud>();
                        stdListL2 = stdList2.Where(c => c.finalScore < 5).ToList();
                        stdListB2 = stdList2.Where(c => c.finalScore >= 5).ToList();
                        Console.WriteLine("Data splitting");// 336,372 ms
                        Console.ReadLine();
                        foreach (var line in stdListL2)
                        {
                            File.AppendAllText("StudentFile1.csv", $"{line.name},{line.surname},{line.finalScore:0.00}\n");
                        }
                        foreach (var line in stdListB2)
                        {
                            File.AppendAllText("StudentFile2.csv", $"{line.name},{line.surname},{line.finalScore:0.00}\n");
                        }
                        Console.WriteLine("File saving");// 7,41 min.
                        Console.ReadLine();
                        break;
                    case 6:
                        List<Stud> stdList3 = new List<Stud>();
                        for (int i = 0; i < 10000000; i++)
                        {
                            Stud std = new Stud();
                            string names = "Name";
                            string surnames = "Surname";
                            n = 5;
                            List<double> hwList2 = new List<double>();
                            name = names + i.ToString();
                            surname = surnames + i.ToString();
                            double vidurk = 0;
                            for (int j = 0; j < 5; j++)
                            {
                                int random = rnd.Next(1, 11);
                                hwList2.Add(random);
                                vidurk += random;
                            }
                            exam = rnd.Next(1, 11);
                            vidurk = ((vidurk / n) * 0.3) + (exam * 0.7);
                            //studentList.Add(new StudentClass(name, surname, n, hwList2, exam));
                            std.name = name;
                            std.surname = surname;
                            std.finalScore = vidurk;
                            stdList3.Add(std);
                        }
                        Console.WriteLine("File creation");//12,806 s
                        Console.ReadLine();
                        stdList3 = stdList3.OrderBy(o => o.finalScore).ToList();
                        Console.WriteLine("Data Sorting");//7,904 s
                        Console.ReadLine();
                        List<Stud> stdListL3 = new List<Stud>();
                        List<Stud> stdListB3 = new List<Stud>();
                        stdListL3 = stdList3.Where(c => c.finalScore < 5).ToList();
                        stdListB3 = stdList3.Where(c => c.finalScore >= 5).ToList();
                        Console.WriteLine("Data splitting");//2,98 s
                        Console.ReadLine();
                        foreach (var line in stdListL3)
                        {
                            File.AppendAllText("StudentFile1.csv", $"{line.name},{line.surname},{line.finalScore:0.00}\n");
                        }
                        foreach (var line in stdListB3)
                        {
                            File.AppendAllText("StudentFile2.csv", $"{line.name},{line.surname},{line.finalScore:0.00}\n");
                        }
                        Console.WriteLine("File saving");// 75.49 min
                        Console.ReadLine();
                        break;
                    case 7: 
                        try
                        {
                            var lines1 = File.ReadAllLines("ContainerTestFile.csv");
                            foreach (var i in lines1)
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
                                StudentClass student1 = new StudentClass(name, surname, n, hwList1, exam);
                                studentList.Add(student1); //5 min su List<> ir isvedant i ekrana
                                //studentLinkedList.AddFirst(student1); // 5,17 min. su LikendList<>
                                //studentQueue.Enqueue(student1);// 4,57 min. su Queue<>
                            }
                        }
                        catch (IOException ioe)
                        {
                            Console.WriteLine(ioe);
                            Console.WriteLine("Iveskite ranka:");
                            goto case 1;
                        }
                        break;
                    default:
                        Console.WriteLine("Ivedete neteisingai");
                        goto case 1;
                }

                string obj = string.Empty;
                Console.WriteLine("Pasirinkite:\n 1 - vidurkis\n 2 - mediana \n");
                try
                {
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
                catch(FormatException fe)
                {
                    Console.WriteLine(fe);
                }
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe);
            }

        }

    }

}
