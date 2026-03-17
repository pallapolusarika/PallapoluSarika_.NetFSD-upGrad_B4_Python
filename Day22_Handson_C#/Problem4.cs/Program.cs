using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            Console.Write("Enter root directory path: ");
            string path = Console.ReadLine();

           
            if (!Directory.Exists(path))
            {
                Console.WriteLine("Invalid directory path!");
                return;
            }
            DirectoryInfo dir = new DirectoryInfo(path);
            DirectoryInfo[] subDirs = dir.GetDirectories();
            Console.WriteLine("\nFolder Details:\n");
            foreach (DirectoryInfo subDir in subDirs)
            {
                FileInfo[] files = subDir.GetFiles();

                Console.WriteLine("Folder Name: " + subDir.Name);
                Console.WriteLine("Number of Files: " + files.Length);
                Console.WriteLine("---------------------------");
            }
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Error: Access denied.");
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
