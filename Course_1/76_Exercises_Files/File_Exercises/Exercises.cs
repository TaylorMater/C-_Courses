using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace File_Exercises
{
    public class Exercises
    {
        //
        //1- Write a program that reads a text file and displays the number of words.
        //
        public static int CountWordsInFile(string testFilePath)
        {
            var fileContents = File.ReadAllText(testFilePath);
            char[] parseDelimiters = new char[] { ' ', '.' };
            var splitFileContents = fileContents.Split(parseDelimiters, StringSplitOptions.RemoveEmptyEntries);    //are there more nuanced ways of getting file contents?
            return splitFileContents.Length;
        }

        public static void RunExerciseOne()
        {
            //we should be setting this somewhere, injecting it through the code. For now, we just have it defined here 
            string testFilePath = @"C:\Users\rttay\Projects\TestProjects\C#_Tutorial\76_Exercises_Files\Related_Files\test.txt";
            Console.WriteLine("1. Determining the number of words in " + testFilePath);
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            var count = CountWordsInFile(testFilePath);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"You have {count} words in " + testFilePath);
            Console.WriteLine();
        }


        //
        //2- Write a program that reads a text file and displays the longest word in the file
        //
        public static string findLongestWordInFile(string testFilePath) 
        {
            var fileContents = File.ReadAllText(testFilePath);
            char[] parseDelimiters = new char[] { ' ', '.' };
            var splitFileContents = fileContents.Split(parseDelimiters, StringSplitOptions.RemoveEmptyEntries);    //are there more nuanced ways of getting file contents?

            string toReturn = "";
            foreach ( var word in splitFileContents)
            {
                if (word.Length > toReturn.Length)
                {
                    toReturn = word;
                }
            }
            return toReturn;
        }

        public static void RunExerciseTwo()
        {
            //we should be setting this somewhere, injecting it through the code. For now, we just have it defined here 
            string testFilePath = @"C:\Users\rttay\Projects\TestProjects\C#_Tutorial\76_Exercises_Files\Related_Files\test.txt";
            Console.WriteLine("2. Determining the longest word in " + testFilePath);
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            var longestWord = findLongestWordInFile(testFilePath);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"The longest word is " + longestWord);
            Console.WriteLine();
        }



    }
}
