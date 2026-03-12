/*Level - 1 Problem 1: Student Score Analyzer Using Arrays and Maps
Scenario:
A training institute wants to analyze student scores stored in an array. The system should calculate total marks, average, highest score, and count of students scoring above a threshold.
Requirements:
-Store student marks in an array.
- Use array methods (push, map, filter, reduce) for processing.
- Store subject-wise highest marks using a Map (key - value pair).
-Display total, average, and filtered results.
Technical Constraints:
-Must use array indexing and iteration.
- Use reduce() for total calculation.
- Use filter() for threshold-based filtering.
- Use Map or Dictionary for subject-highest mapping.
Sample Input:
Marks: [78, 85, 90, 67, 88]
Threshold: 80
Sample Output:
Total Marks: 408
Average Marks: 81.6
Students above 80: 3
Highest Score: 90
Expectations:
-Clean and modular implementation.
- Proper use of array methods.
- Efficient iteration logic.
Learning Outcome:
-Understand array manipulation.
-Use Map for key-value storage.
- Apply functional programming methods.*/

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] marks = { 78, 85, 90, 67, 88 };

        int total = marks.Sum();
        double avg = marks.Average();
        int highest = marks.Max();

        int threshold = 80;
        var aboveThreshold = marks.Where(m => m > threshold);

        Console.WriteLine("Total Marks: " + total);
        Console.WriteLine("Average Marks: " + avg);
        Console.WriteLine("Students above 80: " + aboveThreshold.Count());
        Console.WriteLine("Highest Score: " + highest);

        var subjectHighest = GetSubjectHighestMarks();

        Console.WriteLine("Subject-wise Highest Marks:");
        foreach (var subject in subjectHighest)
        {
            Console.WriteLine(subject.Key + " : " + subject.Value);
        }
    }

    static Dictionary<string, int> GetSubjectHighestMarks()
    {
        Dictionary<string, int[]> subjectMarks = new Dictionary<string, int[]>
        {
            { "Math", new int[] {78,85,90,67,88} },
            { "Physics", new int[] {80,70,95,88,84} },
            { "Chemistry", new int[] {60,75,89,92,77} }
        };

        Dictionary<string, int> subjectHighest = new Dictionary<string, int>();

        foreach (var subject in subjectMarks)
        {
            int highest = subject.Value.Max();
            subjectHighest.Add(subject.Key, highest);
        }

        return subjectHighest;
    }
}