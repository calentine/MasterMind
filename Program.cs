using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * Main function Prints greeting for the game
             * Executes game within loop until the correct answer is found or exceeded the amount of tries (10)
             * Once either of the above contraints are met the game will end and a message will be printed based on result
             */
            PrintGreeting();
            int attempts = 0;
            bool correct = false;
            //random number returned based on 1-6
            string randomNum = GetRandomNumber();
            //testNum for manual entry and used to replace randomNum for testing purposes
            string testNum = "1234";
            while (attempts < 10 && !correct)
            {
                string guessedNum = Console.ReadLine();
                Console.WriteLine($"You entered: {guessedNum}");
                string result = CompareGuessedNumber(randomNum, guessedNum);
                attempts++;
                //if digits all match set bool to drop out of loop, else print hint and remaining attempts
                if (result == "++++")
                {
                    correct = true;
                }
                else
                {
                    Console.WriteLine("hint: " + result);
                    Console.WriteLine($"You have: {10 - attempts} more attempts.");
                }
            }
            if (correct)
            {
                Console.WriteLine("You have guess correctly, you're a mastermind!");
            }
            else
            {
                Console.WriteLine("You have Lost!");
            }
        }
        /*
         * Provides greeting to explain rules to player
        */
        public static void PrintGreeting()
        {
            Console.WriteLine("Welcome to Novice Mind!\n");
            Console.WriteLine("Rules are as follows:\nEnter a 4 digit number, with each digit ranging from 1-6.");
            Console.WriteLine("The goal of the game is to guess what 4 digit number the Master Mind will choose.");
            Console.WriteLine("Please Enter your Guess: ");
        }

        /*
         * constructs number by getting a value (1-6) iteratively
         * multiplies it by powers of 10
         * adds it to the current number until we have 4 digit number
         * return as a string for later comparison to guessed number
         */
        public static string GetRandomNumber()
        {
            int number = 0;
            Random random = new Random();
            for (int i = 3; i >= 0; i--)
            {
                int value = random.Next(1, 6);
                value *= (int)(Math.Pow(10, i));
                number += value; 
            }

            return number.ToString();
        }
        /*
         * Create 2 int variables to store how many matches and non-matched numbers
         * Create 2 strings that will remove the numbers that have already been matched
         * loop over and increment matched numbers between guess and random, else construct new non-matched strings
         * loop over new strings(randomRemoveMatch, guessRemoveMatch) and increment noMatch for non-intersecting numbers from (new strings) 
         */
        public static string CompareGuessedNumber(string random, string guess)
        {
            int match = 0;
            int noMatch = 0;
            string randomRemoveMatch = "";
            string guessRemoveMatch = "";
            for (int i = 0; i < guess.Length;i++)
            {
                if(guess[i] == random[i])
                {
                    match++; 
                }
                else
                {
                    randomRemoveMatch += random[i];
                    guessRemoveMatch += guess[i];
                }
            }

            for(int i =0; i < guessRemoveMatch.Length;i++)
            {
                if (!randomRemoveMatch.Contains(guessRemoveMatch[i]))
                {
                    noMatch++;
                }
            }

            return ConstructResult(match, noMatch);
        }

        /*
         * Takes in 2 integers to determine how many times each (hint character: +,-, or " ") will be added to result string
         * Created a contains integer because we know if we take the sum of match & unMatch we can find the amount of numbers that intersect
         * Finally we construct the result by looping over the count of (matched, contains, and unMatched) and then return the result
         */
        public static string ConstructResult(int match, int noMatch)
        {
            string constructedResult = "";
            int contains = 4 -(match + noMatch);
            for (int i = 0; i < match; i++)
            {
                constructedResult += "+";
            }
            for (int i = 0; i < contains; i++)
            {
                constructedResult += "-";
            }
            for (int i = 0; i < noMatch; i++)
            {
                constructedResult += " ";
            }

            return constructedResult;
        }

    }
}
