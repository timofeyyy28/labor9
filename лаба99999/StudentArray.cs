using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лаба99999
{
    public class StudentArray
    {
        private Student[] studentArray;
        private int num;
        public static int count = 0;

        public int N
        {
            get => num;
            set => num = value;
        }

        public int Length
        {
            get => studentArray.Length;
        }
        public StudentArray()
        {
            studentArray = new Student[0];
            num = 0;
        }
        public StudentArray(int length)
        {
            studentArray = new Student[length];
            count = 0;

            Random rnd = new Random();
            for (int i = 0; i < length; i++)
            {
                double randomGPA = rnd.NextDouble() * (10.0 - 0.0) + 0.0;
                int randomAge = rnd.Next(18, 23);
                studentArray[i] = new Student("RandomName", randomAge, randomGPA);
                count++;
                N = count;
            }
        }
        public StudentArray(string userInput)
        {
            Console.WriteLine($"{userInput}");
            int length = int.Parse(Console.ReadLine());

            studentArray = new Student[length];
            count = 0;

            for (int i = 0; i < length; i++)
            {
                Console.WriteLine($"Введите данные студента {i + 1}:");
                Console.Write("Имя: ");
                string name = Console.ReadLine();

                Console.Write("Возраст (от 18 до 22): ");
                int age = int.Parse(Console.ReadLine());
                while (age < 18 || age > 22)
                {
                    Console.WriteLine("Пожалуйста, введите возраст от 18 до 22:");
                    age = int.Parse(Console.ReadLine());
                }

                Console.Write("Средний балл (от 0 до 10): ");
                double gpa = double.Parse(Console.ReadLine());
                while (gpa < 0 || gpa > 10)
                {
                    Console.WriteLine("Пожалуйста, введите средний балл от 0 до 10:");
                    gpa = double.Parse(Console.ReadLine());
                }

                studentArray[i] = new Student(name, age, gpa);
                count++;
                N = count;
            }
        }

        public StudentArray(StudentArray other)
        {
            studentArray = new Student[other.Length];
            for (int i = 0; i < other.Length; i++)
            {
                studentArray[i] = new Student(other.studentArray[i]);
            }
            count++;
            N = count;
        }

        public void Show()
        {
            for (int i = 0; i < Length; i++)
            {
                studentArray[i].Show();
            }
        }
        public Student this[int index]
        {
            get
            {
                if (0 <= index && index < this.Length)
                    return studentArray[index];
                else
                    throw new Exception("Индекс выходит за пределы коллекции");
            }
            set
            {
                if (0 <= index && index < this.Length)
                    studentArray[index] = value;
                else
                    Console.WriteLine("Индекс выходит за пределы коллекции");
            }
        }
        public static void ShowCount()
        {
            Console.WriteLine($"{count} студентов создано");
        }      
    }
}