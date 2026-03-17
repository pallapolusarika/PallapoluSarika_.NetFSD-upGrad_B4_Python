/*Problem 1 – Level 1
Scenario:
A small organization wants to store simple log messages into a text file using a C# console application.
Requirements:
1.Accept a message from the user.
2. Write the message into a file using FileStream.
3.Append multiple messages to the same file.
4. Display confirmation after writing the data.
Technical Constraints:
• Use FileStream class.
• Use appropriate FileMode and FileAccess.
• Implement exception handling for file access errors.
Expectations:
The application should successfully write user messages to the file and allow multiple entries.
Learning Outcome:
Students will learn how to create and write data into files using FileStream.*/

using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        string filePath = "log.txt";

        try
        {
            Console.Write("Enter your message: ");
            string message = Console.ReadLine();

          
            byte[] data = Encoding.UTF8.GetBytes(message + Environment.NewLine);

        
            using (FileStream fs = new FileStream(filePath, FileMode.Append, FileAccess.Write))
            {
                fs.Write(data, 0, data.Length);
            }

            Console.WriteLine("Message written successfully!");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Error: No permission to access the file.");
        }
        catch (IOException)
        {
            Console.WriteLine("Error: File operation failed.");
        }
        finally
        {
            Console.WriteLine("Operation completed.");
        }
    }
}