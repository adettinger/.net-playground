using System;
using System.Runtime.CompilerServices;

namespace GenericHeapDemo
{
    class GenericHeap<T>
    {
        private LinkedList<T> items = new LinkedList<T>();
        private bool verbose = false;

        public GenericHeap(bool verbose = false)
        {
            this.verbose = verbose;
        }

        public void Push(T item)
        {
            if (verbose)
                Console.WriteLine($"Pushing: {item}");
            items.AddFirst(item);
        }

        public T Pop()
        {
            if (items.Count <= 0)
                throw new InvalidOperationException("Cannot pop from an empty heap");

            T poppedItem = items.First();

            if (verbose)
                Console.WriteLine($"Popping: {poppedItem}");

            items.RemoveFirst();
            return poppedItem;
        }

        public void Display()
        {
            Console.WriteLine("Current items in heap:");
            foreach (T item in items)
            {
                Console.WriteLine(item);
            }
        }
    }

    public class HeapProgram {

        public static void Main()
        {
            // Example usage with integers

            GenericHeap<int> intStack = new GenericHeap<int>(true);

            intStack.Push(10);

            intStack.Push(20);

            intStack.Display();

            Console.WriteLine($"Popped item: {intStack.Pop()}");

            intStack.Display();

            // Example usage with strings

            GenericHeap<string> stringStack = new GenericHeap<string>(true);

            stringStack.Push("Hello");

            stringStack.Push("World");

            stringStack.Display();

            Console.WriteLine($"Popped item: {stringStack.Pop()}");

            stringStack.Display();

            // Example usage with custom objects

            GenericHeap<Person> personStack = new GenericHeap<Person>(true);

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