using System;

namespace ErrorHandlingDemo
{
    public class ErrorHandlingProgram
    {
        public static void Main()
        {
            FileProcessor fileProcessor = new FileProcessor();

            string inputFilePath = "C:\\Users\\adetting\\OneDrive - Capgemini\\Desktop\\Testfile.txt";
            string outputFilePath = "C:\\Users\\adetting\\OneDrive - Capgemini\\Desktop\\TestOutputFile.txt";

            string inputData = fileProcessor.ReadDataFromFile(inputFilePath);
            if (inputData != null)
            {
                bool writeSuccess = fileProcessor.WriteDataToFile(outputFilePath, inputData);
                if (writeSuccess)
                {
                    Console.WriteLine("Data written to the output file successfully");
                }
                else
                {
                    Console.WriteLine("Failed to write output data");
                }
            }
            else
            {
                Console.WriteLine("Failed to read data from the input file");
            }
        }
    }

    public class FileProcessor
    {
        public string ReadDataFromFile(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                    throw new FileNotFoundException($"File not found: {filePath}");

                string data = File.ReadAllText(filePath);
                return data;

            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}", ex);
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}", ex);
                return null;
            }
        }

        public bool WriteDataToFile(string filePath, string data)
        {
            try
            {
                File.WriteAllText(filePath, data);
                return true;
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"Error: {ex.Message}. Check file permissions.");
                return false;
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}. Check if the directory exists.");
                return false;
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error writing to file: {ex.Message}.");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected Error: {ex.Message}.");
                return false;
            }
        }
    }
}