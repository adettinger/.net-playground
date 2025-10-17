using System;

namespace GenericStackDemo
{
    
    class GenericStack<T>
    {
        private List<T> items = new List<T>();

        public void Push(T item)
        {
            Console.WriteLine($"Pushing: {item}");
            items.Add(item);
        }

        public T Pop()
        {
            if (items.Count <= 0)
            {
                throw new InvalidOperationException("Cannot pop when stack is empty");
            }
            Console.WriteLine($"Popping: {items[items.Count - 1]}");
            T poppedItem = items[items.Count - 1];

            items.RemoveAt(items.Count - 1);

            return poppedItem;
        }

        public void Display()
        {
            Console.WriteLine("Current Items:");
            foreach (T item in items)
            {
                Console.WriteLine(item);
            }
        }
    }

    public class StackProgram {

        public static void Main()
        {
            // Example usage with integers

            GenericStack<int> intStack = new GenericStack<int>();

            intStack.Push(10);

            intStack.Push(20);

            intStack.Display();

            Console.WriteLine($"Popped item: {intStack.Pop()}");

            intStack.Display();

            // Example usage with strings

            GenericStack<string> stringStack = new GenericStack<string>();

            stringStack.Push("Hello");

            stringStack.Push("World");

            stringStack.Display();

            Console.WriteLine($"Popped item: {stringStack.Pop()}");

            stringStack.Display();

            // Example usage with custom objects

            GenericStack<Person> personStack = new GenericStack<Person>();

            personStack.Push(new Person("John", 25));
            personStack.Push(new Person("Alice", 30));
            personStack.Display();
            Console.WriteLine($"Popped item: {personStack.Pop()}");
            personStack.Display();
        }
    }

    class Person
    {
        string Name { get; set; }
        int Age { get; set; }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}";
        }
    }
}