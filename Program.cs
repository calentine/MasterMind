using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace NoviceMind
{
    internal class Program
    {
        static void Main(string[] args)
        {

            PrintGreeting();
            int attempts = 0;
            bool correct = false;
            while (attempts < 10 || !correct)
            {
                int number = int.Parse(Console.ReadLine());
                Console.WriteLine($"You entered: {number} compare: {GetRandomNumber()}");
                attempts++;
            }

        }
        public static void PrintGreeting()
        {
            Console.WriteLine("Welcome to Novice Mind!\n");
            Console.WriteLine("Rules are as follows:\nEnter a 4 digit number, with each digit ranging from 0-6.");
            Console.WriteLine("The goal of the game is to guess what 4 digit number the Novice Mind will choose.");
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

        public static string CompareGuessedNumber(int value, int guess)
        {

            return "";
        }

    }
}
