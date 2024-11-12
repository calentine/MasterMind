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

            PrintGreeting();
            int attempts = 0;
            bool correct = false;
            int randomNum = GetRandomNumber();
            while (attempts < 10 && !correct)
            {
                int guessedNum = int.Parse(Console.ReadLine());
                Console.WriteLine($"You entered: {guessedNum}");
                string result = CompareGuessedNumber(randomNum, guessedNum);
                attempts++;
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
        public static void PrintGreeting()
        {
            Console.WriteLine("Welcome to Novice Mind!\n");
            Console.WriteLine("Rules are as follows:\nEnter a 4 digit number, with each digit ranging from 1-6.");
            Console.WriteLine("The goal of the game is to guess what 4 digit number the Master Mind will choose.");
            Console.WriteLine("Please Enter your Guess: ");
        }

        public static int GetRandomNumber()
        {
            int number = 0;
            Random random = new Random();
            for (int i = 3; i >= 0; i--)
            {
                int value = random.Next(1, 6);
                value *= (int)(Math.Pow(10, i));
                number += value; 
            }

            return number;
        }

        public static string CompareGuessedNumber(int randomNum, int guessedNum)
        {
            string random = randomNum.ToString();
            string guess = guessedNum.ToString();

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
