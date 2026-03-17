/*Problem 2 – Level 1:
Scenario:
An administrator wants to check file properties stored in a particular folder for auditing purposes.
Requirements:
1.Accept a folder path from the user.
2. Display file name, file size, and creation date.
3. Count and display the total number of files.
Technical Constraints:
• Use FileInfo class.
• Handle invalid directory paths.
Expectations:
The program should list file details clearly in the console.
Learning Outcome:
Students will understand how to retrieve file metadata using FileInfo.*/

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            Console.Write("Enter folder path: ");
            string path = Console.ReadLine();

            
            if (!Directory.Exists(path))
            {
                Console.WriteLine("Invalid directory path!");
                return;
            }

          
            string[] files = Directory.GetFiles(path);

            int count = 0;

            Console.WriteLine("\nFile Details:\n");

            foreach (string file in files)
            {
                FileInfo fi = new FileInfo(file);

                Console.WriteLine("Name: " + fi.Name);
                Console.WriteLine("Size: " + fi.Length + " bytes");
                Console.WriteLine("Created: " + fi.CreationTime);
                Console.WriteLine("---------------------------");

                count++;
            }

            Console.WriteLine("Total number of files: " + count);
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Error: Access denied to the folder.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            Console.WriteLine("\nOperation completed.");
        }
    }
}
