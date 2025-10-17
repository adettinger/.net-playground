

using System;

namespace PersonLINQDemo
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }

        public Person(string name, int age, decimal salary)
        {
            this.Name = name;
            this.Age = age;
            this.Salary = salary;
        }
    }

    public class DemoProgram
    {
        public static void Main()
        {
            List<Person> PersonList = new List<Person>();

            while (true)
            {
                Console.WriteLine("Enter person details or type 'exit' to end:");
                Console.Write("Name: ");
                string name = Console.ReadLine();
                if (name.ToLower() == "exit")
                {
                    break;
                }
                Console.Write("Age: ");
                if (!int.TryParse(Console.ReadLine(), out int age))
                {
                    Console.WriteLine("Invalid age. Please enter a valid number");
                    continue;
                }
                Console.Write("Salary: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal salary))
                {
                    Console.WriteLine("Invalid salary. Please enter a valid number");
                    continue;
                }
                PersonList.Add(new Person(name, age, salary));

                // Perform LINQ queries
                Console.WriteLine("\nLINQ queries: ");

                var filteredPeople = PersonList.Where(p => p.Age > 30).ToList();
                DisplayResults("People above 30:", filteredPeople);

                var sortedPeopleByName = PersonList.OrderBy(p => p.Name).ToList();
                DisplayResults("People sorted by name:", sortedPeopleByName);

                var averageSalary = PersonList.Average(p => p.Salary);
                Console.WriteLine($"\nAverage Salary: {averageSalary}");

                var totalAge = PersonList.Sum(p => p.Age);
                Console.WriteLine($"\nTotal Age: {totalAge}\n");

                static void DisplayResults(string heading, List<Person> people)
                {
                    Console.WriteLine($"\n{heading}");
                    foreach (var person in people)
                    {
                        Console.WriteLine($"{person.Name}, Age: {person.Age}, Salary: {person.Salary:C}");
                    }
                }
            }
        }
    }
}