using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Words randomly chosen for user to guess
            string[] words = { "rain", "school", "programming", "google", "whatever", "interest" };
            Random random = new Random();
            string selectedWord = words[random.Next(0, words.Length)];

            // Hiding the letters with ***
            string hiddenWord = "";

            for(int i= 0; i < selectedWord.Length; i++)
            {
                hiddenWord = hiddenWord.Insert(0, "*");
            }

            // Suggesting the user to guess a letter and keep doing so until all are guessed correct

            Console.WriteLine("Guess the word.");

            do
            {
                Console.Write("Word: {0} >>", hiddenWord);
                string userGuess = Console.ReadLine();

                if (selectedWord.Contains(userGuess))
                {
                    // at this point using selectedWord and hiddenWord strings like parallel arrays
                    for(int j = 0; j < selectedWord.Length; j++)
                    {
                        if(selectedWord[j] == char.Parse(userGuess))
                        {
                            // replacing stars with letters
                            hiddenWord = hiddenWord.Remove(j, 1);
                            hiddenWord = hiddenWord.Insert(j, userGuess);
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Correct! Letter {0} exists in this word!", userGuess);
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Oops! Letter {0} doesn't exists in this word!", userGuess);
                    Console.ResetColor();
                }
            } while (hiddenWord != selectedWord);

            Console.WriteLine("Congratulations! You win! The word is {0}.", selectedWord);



        }
       
    }
}
