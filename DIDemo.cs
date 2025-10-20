using System;

namespace DIDemo
{
    public interface IDataProcessor
    {
        string ProcessData(string input);
    }

    public class UserInputProcessor : IDataProcessor
    {
        public string ProcessData(string input)
        {
            return input.ToUpper();
        }
    }

    public class DataProcessingService
    {
        private readonly IDataProcessor _dataProcessor;

        public DataProcessingService(IDataProcessor dataProcessor)
        {
            this._dataProcessor = dataProcessor;
        }

        public void ProcessAndDisplay(string input)
        {
            string processedData = _dataProcessor.ProcessData(input);

            Console.WriteLine($"Processed Data: {processedData}");
        }
    }

    public class DIDemoProgram
    {
        public static void Main()
        {
            IDataProcessor userInputProcessor = new UserInputProcessor();

            DataProcessingService dataProcessingService = new DataProcessingService(userInputProcessor);

            Console.Write("Enter data for processing: ");

            string userInput = Console.ReadLine();

            dataProcessingService.ProcessAndDisplay(userInput);
            
        }
    }
}