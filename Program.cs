using System;

namespace Lab_3_4_v0._1_with_array
{
    class Program

    {
        public struct Student
        {
            public string name;
            public string surname;
            public int n;
            public double[] homeworks;
            public double exam;
            public override string ToString()
            {
                double vid = 0;
                for (int i = 0; i < n; i++)
                {
                    vid += homeworks[i];
                }
                double med = 0;
                if (n % 2 == 0)
                {
                    med += homeworks[n / 2];
                    med += homeworks[n / 2 - 1];
                    med = med / 2;
                }
                else if (n % 2 == 1)
                {
                    med = homeworks[n / 2];
                }
                vid = ((vid / n) * 0.3) + (0.7 * exam);
                Console.WriteLine("Pasirinkite:\n 1 - vidurkis\n 2 - mediana \n");
                int s = Int32.Parse(Console.ReadLine());
                switch (s)
                {
                    case 1:
                        return string.Format("Surname        Name           Final points(Avg.)\n" +
                    "------------------------------------------------\n" +
                    "{0, -15}{1, -29}{2:0.00}", surname,
                       name, vid);
                        break;
                    case 2:
                        return string.Format("Surname        Name           Final points(Med.)\n" +
                    "------------------------------------------------\n" +
                    "{0, -15}{1, -29}{2:0.00}", surname,
                       name, med);
                        break;
                    default:
                        break;
                }
                return string.Format("Surname       Name        Final points(Avg.)\n" +
                    "---------------------------------------------\n" +
                    "{0}        {1}             {2}", surname,
                       name, vid);
            }
        }
        static void Main(string[] args)
        {
            Random rnd = new Random();
            Console.WriteLine("Meniu:");
            Console.WriteLine("1. Ivesti studenta.");
            string input = Console.ReadLine();
            int a;
            Student student = new Student();
            try
            {
                a = Int32.Parse(input);
                switch (a)
                {
                    case 1:
                        Console.WriteLine("Ivesti studento varda ir pavarde:");
                        student.name = Console.ReadLine();
                        student.surname = Console.ReadLine();
                        Console.WriteLine("Ivesti namu darbu kieki:");
                        student.n = Int32.Parse(Console.ReadLine());
                        student.homeworks = new double[student.n];
                        Console.WriteLine("Ivesite 1 - ranka ar 2 - sugeneretuoti:");
                        int b = Int32.Parse(Console.ReadLine());
                        switch (b)
                        {
                            case 1:
                                for (int i = 0; i < student.n; i++)
                                {
                                    Console.WriteLine("Ivesti {0} namu darbo rezultata:", i + 1);
                                    student.homeworks[i] = Double.Parse(Console.ReadLine());
                                }
                                break;
                            case 2:
                                for (int i = 0; i < student.n; i++)
                                {
                                    int random = rnd.Next(1, 11);
                                    Console.WriteLine("Sugeneruotas: {0}", random);
                                    student.homeworks[i] = random;
                                }
                                break;
                            default:
                                Console.WriteLine("Ivedete neteisingai");
                                break;
                        }
                        Console.WriteLine("Ivesti egzamino rezultata:");
                        student.exam = Double.Parse(Console.ReadLine());
                        Console.WriteLine(student.ToString());
                        break;
                    default:
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine();
            }

        }

    }

}
