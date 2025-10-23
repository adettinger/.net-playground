using System.Transactions;

namespace StudentPractice
{
    internal class Student
    {
        private int studentId;
        private string studentName;

        public Student()
        {
            studentId = 101;
            studentName = "new";
        }

        public Student(int studentId, string studentName)
        {
            this.studentId = studentId;
            this.studentName = studentName;
        }

        public void inputDetails()
        {
            Console.Write("Enter Student Id: ");
            studentId = int.Parse(Console.ReadLine());
            Console.Write("Enter Student Name: ");
            studentName = Console.ReadLine();
        }

        public void displayDetails()
        {
            Console.WriteLine("Student ID: " + studentId);
            Console.WriteLine("Student Name: " + studentName);
        }
    }
}