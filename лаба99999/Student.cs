using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лаба99999
{
    public class Student
    {
        int age;
        string name;
        double gpa;
        int num;
        private static int objectCount = 0;

        public int N
        {
            get => num;
            set => num = value;
        }

        public int Age
        {
            get => age;
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Ошибка: возраст не может быть отрицательным!");
                }
                age = value;
            }
        }

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    Console.WriteLine("Ошибка: имя не может быть пустым");
                }
                else
                {
                    name = value;
                }
            }
        }

        public double GPA
        {
            get => gpa;
            set
            {
                if (value < 0 || value > 10)
                {
                    Console.WriteLine("Ошибка: значение gpa может принимать значения от 0 до 10");
                }
                gpa = value;
            }
        }

        public object Gpa { get; set; }

        public Student()// конструктор без параметров
        {
            age = 0;
            gpa = 0;
            name = "Имя отсутствует";
            objectCount++;
            N = objectCount;
        }

        public Student(string n, int a, double g)// конструктор с параметрами
        {
            name = n;
            age = a;
            gpa = g;
            objectCount++;
            N = objectCount;
        }

        public Student(Student s)// конструктор копирования
        {
            this.name = s.name;
            this.age = s.age;
            this.gpa = s.gpa;
            objectCount++;
            N = objectCount;
        }
        public void Show()
        {
            Console.WriteLine($"Имя студента: {this.name}, возраст студента: {this.age}, GPA студента: {this.gpa}");
        }
        public static void Show(Student s)
        {
            Console.WriteLine($"Имя студента: {s.name}, возраст студента: {s.age}, GPA студента: {s.gpa}");
        }
        public static void ShowCount()
        {
            Console.WriteLine($"{objectCount} студентов создано");
        }

        public string CompareTo(Student otherStudent)
        {
            string comparisonResult = "";

            if (this.Age < otherStudent.Age)
                comparisonResult += $"{this.Name} младше, чем {otherStudent.Name}. ";
            else if (this.Age > otherStudent.Age)
                comparisonResult += $"{this.Name} старше, чем {otherStudent.Name}. ";
            else
                comparisonResult += $"{this.Name} и {otherStudent.Name} ровесники. ";

            if (this.GPA > otherStudent.GPA)
                comparisonResult += $"\nGPA {this.Name} выше, чем GPA {otherStudent.Name}.";
            else if (this.GPA < otherStudent.GPA)
                comparisonResult += $"\nGPA {this.Name} ниже, чем GPA {otherStudent.Name}.";
            else
                comparisonResult += $"\nGPA {this.Name} равен GPA {otherStudent.Name}.";

            return comparisonResult;
        }
        public static string CompareStudents(Student s1, Student s2)
        {
            string comparisonResult = "";

            if (s1.Age < s2.Age)
                comparisonResult += $"{s1.Name} младше, чем {s2.Name}. ";
            else if (s1.Age > s2.Age)
                comparisonResult += $"{s1.Name} старше, чем {s2.Name}. ";
            else
                comparisonResult += $"{s1.Name} и {s2.Name} ровесники. ";

            if (s1.GPA > s2.GPA)
                comparisonResult += $"\nGPA {s1.Name} выше, чем GPA {s2.Name}.";
            else if (s1.GPA < s2.GPA)
                comparisonResult += $"\nGPA {s1.Name} ниже, чем GPA {s2.Name}.";
            else
                comparisonResult += $"\nGPA {s1.Name} равен GPA {s2.Name}.";

            return comparisonResult;
        }

        public static string operator ~(Student s)
        {
            if (s.name == null)
            {
                return string.Empty;
            }

            string newname = s.name.ToLower();
            if (newname.Length > 0)
            {
                newname = char.ToUpper(newname[0]) + newname.Substring(1);
               } 
                s.name = newname;
                return ($"Имя студента: {s.name}, возраст студента: {s.age}, GPA студента: {s.gpa}");           
            
        }
        public static Student operator ++(Student s)
        {
            s.Age++;
            return s;
        }
        public static explicit operator int(Student s)
        {
            int age = s.Age;
            int course = 0;

            if (age >= 18 && age < 19)
            {
                course = 1;
                Console.WriteLine("Студент обучается на 1 курсе");
            }
            else if (age >= 19 && age < 20)
            {
                course = 2;
                Console.WriteLine("Студент обучается на 2 курсе");
            }
            else if (age >= 20 && age < 21)
            {
                course = 3;
                Console.WriteLine("Студент обучается на 3 курсе");
            }
            else if (age >= 21 && age <= 22)
            {
                course = 4;
                Console.WriteLine("Студент обучается на 4 курсе");
            }
            else if (age > 22)
            {
                course = -1;
                Console.WriteLine("Студент не может быть зачислен на курс");
            }

            return course;
        }
        public static implicit operator bool(Student  s)
        {
            if (s.GPA < 6)
                return true;
            else
            {
                return false;
            }

        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Student otherStudent = (Student)obj;
            return name == otherStudent.name && age == otherStudent.age && gpa == otherStudent.gpa;
        }
        public static Student operator %(Student s, string newName)
        {
            return new Student(newName, s.Age, s.GPA);
        }
        public static Student operator -(Student s, double d)
        {
            double newGPA = s.GPA - d;
            newGPA = Math.Round(newGPA, 1); // Округляем до одной цифры после запятой

            if (newGPA < 0)
            {
                Console.WriteLine("Ошибка: GPA не может быть меньше 0!");
                return s;
            }

            Student newStudent = new Student(s.Name, s.Age, newGPA);
            return newStudent;
        }

    }
}
