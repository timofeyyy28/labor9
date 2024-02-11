namespace лаба99999
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student s = new Student("тима", 18, 5.8);
            Student s3 = new Student("даниил", 21, 9.3);
            s.Show();
            s3.Show();

            Student s1 = new Student(s);
            s1.Show();

            Student s2 = new Student();
            s2.Show();

            Console.WriteLine("____Унарные операции____");
            Console.WriteLine("1 буква заглавная, остальные строчные");
            s.Show();
            Console.WriteLine(~s);
            Console.WriteLine("________________________");
            Console.WriteLine("Увеличение возраста студента на 1");
            Student s4 = new Student(s1);
            s4.Show();
            ++s4;
            s4.Show();
            Console.WriteLine("________________________");
            Console.WriteLine("Операции приведения типа");
            Console.WriteLine("Явная операция int");
            s3.Show();
            int y = (int)s3;
            Console.WriteLine("________________________");
            Console.WriteLine("Неявная операция bool");
            s4.Show();
            bool x = s4;
            Console.WriteLine(x);
            Console.WriteLine("________________________");
            Console.WriteLine("Бинарные операции");
            Console.WriteLine("Новое имя, возраст и gpa - те же");
            Student s5 = new Student("Богдан", 19, 7.8);
            s5.Show();
            Student s6 = s5 % "Артем";
            s6.Show();
            Console.WriteLine("________________________");
            Console.WriteLine("Уменьшение gpa на заданное число");
            Student s7 = s3 - 1.9;
            s7.Show();
                
            Student.ShowCount();

            Console.WriteLine($"\n----------------\n ");
            Console.WriteLine("1 studentarray");
            StudentArray arr = new StudentArray(8);
            arr.Show();
            Console.WriteLine("2 studentarray");
            StudentArray arr1 = new StudentArray(arr);
            arr1.Show();
            arr[0] = new Student("Миша", 19, 5.6);
            Console.WriteLine(arr[0]);
            Console.WriteLine("1 studentarray");
            arr.Show();
            Console.WriteLine("2 studentarray");
            arr1.Show();
            try
            {
                arr[100] = new Student("Миша", 19, 5.6); 
                arr.Show();
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
            }                       
            StudentArray arr3 = new StudentArray("Введите количество студентов:");
            arr3.Show();
            StudentArray.ShowCount();

        }
    }
}