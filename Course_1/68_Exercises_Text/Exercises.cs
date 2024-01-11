using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _68_Exercises_Text
{
    public class Exercises
    {

        //1- Write a program and ask the user to enter a few numbers separated by a hyphen.
        //Work out if the numbers are consecutive. For example, if the input is "5-6-7-8-9" or "20-19-18-17-16",
        //display a message: "Consecutive"; otherwise, display "Not Consecutive".

        public static void ExerciseOne()
        {
            Console.WriteLine("(1) you try entering a list of numbers, separated by hyphens.");
            var userInput = Console.ReadLine();


            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine("Why you gotta suck homie");
                return;
            }

            var numberPieces = userInput.Split('-');         

            if (numberPieces.Length <= 1)
            {
                Console.WriteLine("Not much of a list is it bud.");
                Console.WriteLine("Consecutive");
                return;
            }

            var previousNum = int.Parse(numberPieces[0]);

            for (int i = 1; i < numberPieces.Length; i++)
            {
                var temp = int.Parse((numberPieces[i]));
                if (temp != previousNum+1)
                {
                    Console.WriteLine("Shucks bucko. Not consecutive");
                    return;
                }
                previousNum = temp;
            }

            Console.WriteLine("If you made it this far, then you're a real one. Consecutive.");
            return;

        }


        //2- Write a program and ask the user to enter a few numbers separated by a hyphen.
        //If the user simply presses Enter, without supplying an input, exit immediately;
        //otherwise, check to see if there are duplicates.If so, display "Duplicate" on the console.

        public static void ExerciseTwo()
        {
            Console.WriteLine("(2) try entering a list of numbers, separated by hyphens.");
            var userInput = Console.ReadLine();

            if (string.IsNullOrEmpty(userInput))
            {
                Console.WriteLine("You need to enter some input next time");
                return;
            }

            //lets use a hashset, because .add() method will return false if the member already exists, and it's very fast
            var numberPieces = userInput.Split('-');

            HashSet<int> numbers = new HashSet<int>();

            foreach (var num in numberPieces)
            {
                if (! numbers.Add(int.Parse(num)) )
                {
                    Console.WriteLine("Duplicate");
                    return;
                }
            }

        }


        //3- Write a program and ask the user to enter a time value in the 24-hour time format(e.g. 19:00).
        //A valid time should be between 00:00 and 23:59. If the time is valid, display "Ok";
        //otherwise, display "Invalid Time". If the user doesn't provide any values, consider it as invalid time.

        public static void ExerciseThree()
        {
            Console.WriteLine("Please enter a time in the 24 hour time format, e.g. 19:00");
            var userInput = Console.ReadLine();

            try
            {
                var inputTime = userInput.Split(':');
                if (inputTime.Length != 2) 
                {
                    Console.WriteLine("Hey - give us a proper input. Invalid time (should only have two parts separated by a colon)");
                    return;
                }
                
                foreach (string timePart in inputTime)
                {
                    if (timePart.Trim().Length != 2)
                    {
                        Console.WriteLine("Hey - give us a proper input. Invalid time (too many characters for each time)");
                        return;
                    }
                }

                if (int.Parse(inputTime[0]) < 0 || int.Parse(inputTime[0]) > 23) 
                {
                    Console.WriteLine("Hey - give us a proper input. Invalid time (hours out of bounds)");
                    return;
                }

                if (int.Parse(inputTime[1]) < 0 || int.Parse(inputTime[1]) > 59)
                {
                    Console.WriteLine("Hey - give us a proper input. Invalid time (minutes out of bounds)");
                    return;
                }

                Console.WriteLine("I guess you got yourself a valid time there bud");
                //I wonder if there is a better way to do this  


            }
            catch
            {
                Console.WriteLine("there was a problem, sorry bud");
            }
        }


        //4- Write a program and ask the user to enter a few words separated by a space.
        //Use the words to create a variable name with PascalCase.
        //For example, if the user types: "number of students", display "NumberOfStudents".
        //Make sure that the program is not dependent on the input.
        //So, if the user types "NUMBER OF STUDENTS", the program should still display "NumberOfStudents".

        public static void ExerciseFour()
        {
            Console.WriteLine("Please enter a few words separated by a space.");
            var userInput = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine("Empty or null, ignoring.");
                return;
            }

            try
            {
                var inputParts = userInput.Split(' ');
                string[] theInputArray = new string[inputParts.Length];
                for (int i = 0;  i < inputParts.Length; i++){
                    theInputArray[i] = inputParts[i].Trim();
                }

                if (!ExerciseFourValidateWords(theInputArray))
                {
                    Console.WriteLine("Issue with input - words are not all letters");
                    return;
                }

                StringBuilder pascalVariable = new StringBuilder();
                
                for (int i = 0; i < theInputArray.Length; i++)
                {

                    var temp = theInputArray[i].ToLower();

                    pascalVariable.Append(char.ToUpper(temp[0]));
                    pascalVariable.Append(temp.Substring(1));       //grabs remainder of lowercase letters
                    
                }

                Console.WriteLine(pascalVariable.ToString());
            }
            catch
            {
                Console.WriteLine("We ran into a problem - caught exception.");
            }

        }

        public static bool ExerciseFourValidateWords(string[] words)
        {
            foreach (string word in words)
            {
                if (!word.All(char.IsLetter))
                {
                    Console.WriteLine("I won't tolerate numbers or whitespace in my variable names");
                    return false;
                }
            }
            return true;
        }


        //5- Write a program and ask the user to enter an English word.
        //Count the number of vowels (a, e, o, u, i) in the word.
        //So, if the user enters "inadequate", the program should display 6 on the console.

        public static void ExerciseFive()
        {
            Console.WriteLine("Please enter a single English word.");
            var userInput = Console.ReadLine();

            int count = 0;

            foreach (char letter in userInput)
            {
                switch (letter)
                {
                    case 'a':
                    case 'e':
                    case 'i':
                    case 'o':
                    case 'u':
                        count++;
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine($"The number of vowels in {userInput} is {count}");

        }

    }
}
