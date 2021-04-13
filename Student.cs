using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_3_4_v0._2
{
    class Student
    {
        private string name;
        private string surname;
        private int n;
        private List<double> homeworks;
        private double exam;

        public Student()
        {
        }

        public Student(string name, string surname, int n, List<double> homeworks, double exam)
        {
            this.Name = name;
            this.Surname = surname;
            this.N = n;
            this.Homeworks = homeworks;
            this.Exam = exam;
        }

        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public int N { get => n; set => n = value; }
        public List<double> Homeworks { get => homeworks; set => homeworks = value; }
        public double Exam { get => exam; set => exam = value; }
    }

}
