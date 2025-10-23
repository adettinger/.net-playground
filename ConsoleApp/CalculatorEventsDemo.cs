using System;

namespace CalculatorEventsDemo
{
    public delegate void MathOperationHandler(double result);

    public class MathOperations
    {
        // Define Event handlers
        public event MathOperationHandler AdditionPerformed;
        public event MathOperationHandler SubtractionPerformed;
        public event MathOperationHandler MultiplicationPerformed;
        public event MathOperationHandler DevisionPerformed;

        public void Add(double x, double y)
        {
            double result = x + y;
            AdditionPerformed?.Invoke(result);
        }

        public void Subtract(double x, double y)
        {
            double result = x - y;
            SubtractionPerformed?.Invoke(result);
        }

        public void Multiply(double x, double y)
        {
            double result = x * y;
            MultiplicationPerformed?.Invoke(result);
        }

        public void Devide(double x, double y)
        {
            if (y != 0)
            {
                double result = x / y;
                DevisionPerformed?.Invoke(result);
            }
            else
            {
                Console.WriteLine("Error: Division by zero is not allowed");
            }
        }
    }

    public class ResultDisplay
    {
        public void AdditionHandler(double result)
        {
            Console.WriteLine($"Addition Result: {result}");
        }

        public void SubtractionHandler(double result)
        {
            Console.WriteLine($"Subtraction Result: {result}");
        }

        public void MultiplicationHandler(double result)
        {
            Console.WriteLine($"Multiplication Result: {result}");
        }

        public void DivisionHandler(double result)
        {
            Console.WriteLine($"Division Result: {result}");
        }
    }

    public class CalculatorProgam
    {
        public static void Main()
        {
            MathOperations mathOperations = new MathOperations();
            ResultDisplay resultDisplay = new ResultDisplay();

            mathOperations.AdditionPerformed += resultDisplay.AdditionHandler;
            mathOperations.SubtractionPerformed += resultDisplay.SubtractionHandler;
            mathOperations.MultiplicationPerformed += resultDisplay.MultiplicationHandler;
            mathOperations.DevisionPerformed += resultDisplay.DivisionHandler;

            while (true)
            {
                Console.WriteLine("\nEnter the first number");
                if (!double.TryParse(Console.ReadLine(), out double num1))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number");
                    continue;
                }

                Console.WriteLine("\nEnter the second number");
                if (!double.TryParse(Console.ReadLine(), out double num2))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number");
                    continue;
                }

                Console.WriteLine("Select the operation (+, -, *, /) or 'exit' to end:");
                string operation = Console.ReadLine();
                if (operation == "exit")
                {
                    break;
                }
                switch (operation)
                {
                    case "+":
                        mathOperations.Add(num1, num2);
                        break;
                    case "-":
                        mathOperations.Subtract(num1, num2);
                        break;
                    case "*":
                        mathOperations.Multiply(num1, num2);
                        break;
                    case "/":
                        mathOperations.Devide(num1, num2);
                        break;
                    default:
                        Console.WriteLine("Invalid operation");
                        break;
                }
            }
        }
    }
}