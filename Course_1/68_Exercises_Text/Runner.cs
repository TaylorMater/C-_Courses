using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _68_Exercises_Text
{
    public class Runner
    {

        public static void performExercise(int num)
        {
            switch (num)
            {
                case 1:
                    Exercises.ExerciseOne();
                    break;
                case 2:
                    Exercises.ExerciseTwo();
                    break;
                case 3:
                    Exercises.ExerciseThree();
                    break;
                case 4:
                    Exercises.ExerciseFour();
                    break;
                case 5:
                    Exercises.ExerciseFive();
                    break;
                default:
                    break;
            }
        }



        static void Main(string[] args)
        {
            int exerciseCount = 1;
            
            while (exerciseCount < 6) {
                Console.WriteLine($"Do you want to test Exercise {exerciseCount}? Enter yes for y or yes for yes, all other input will count as no. Enter q to quit.");

                switch (Console.ReadLine().Trim()) 
                {
                    case "q":
                        return;
                    case "yes":
                    case "y":
                        performExercise(exerciseCount);
                        break;
                    default:
                        Console.WriteLine($"Input interpreted as no, will not perform exercise {exerciseCount}");
                        break;
                }

                Console.WriteLine();
                Console.WriteLine("--- Next Exercise ---");
                Console.WriteLine();

                exerciseCount++;

            }


        }


    }
}
