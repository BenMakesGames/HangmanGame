using System;
using System.Linq;

namespace HangmanGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var wordToGuess = PickAWord();

            var guessedLetters = "";

            var guessesRemaining = 6;

            while (guessesRemaining > 0)
            {
                Console.WriteLine($"You have {guessesRemaining} guesses remaining.");
                Console.WriteLine($"Available letters: {GetAvailableLetters(guessedLetters)}");

                DrawHangman(guessesRemaining);
                DisplayWord(wordToGuess, guessedLetters);

                Console.Write("Please guess a letter: ");

                string? guess = null;

                while(true)
                {
                    guess = Console.ReadLine()?.Trim().ToLower();

                    if (guess?.Length != 1)
                    {
                        Console.WriteLine("Please enter a single letter.");
                        continue;
                    }

                    if (guessedLetters.Contains(guess))
                    {
                        Console.WriteLine("You have already guessed that letter.");
                        continue;
                    }

                    if (!IsLetter(guess))
                    {
                        Console.WriteLine("Please enter a letter.");
                        continue;
                    }

                    guessedLetters += guess;

                    break;
                }

                if (wordToGuess.Contains(guess))
                {
                    Console.WriteLine($"Good guess!");
                }
                else
                {
                    guessesRemaining--;
                    Console.WriteLine($"Oops! That letter is not in my word!");
                }

                if (IsWordGuessed(wordToGuess, guessedLetters))
                {
                    Console.WriteLine("Congratulations, you won!");
                    return;
                }
            }
        }

        private static string PickAWord()
        {
            var possibleWords = new string[] {
                "rainbow",
                "xenon",
                "pikachu",
                "marshmallow",
                "candy",
                "chocolate",
                "icecream",
                "sugar",
                "cotton candy",
                "cotton",
                "candy cane",
                "horse",
                "unicorn",
                "zebra",
                "rhinoceros",
                "giraffe",
                "elephant",
                "lion",
                "house",
                "apartment",
                "palace",
                "castle",
                "hotel",
                "motel",
                "cabin",
                "inn",
                "hostel",
                "orange",
                "white",
                "red",
                "yellow",
                "green",
                "blue",
                "purple",
                "black",
                "brown",
            };

            var random = new Random();
            var randomIndex = random.Next(0, possibleWords.Length);
            return possibleWords[randomIndex];
        }

        private static string GetAvailableLetters(string guessedLetters)
        {
            return "abcdefghijklmnopqrstuvwxyz"
                .Where(letter => !guessedLetters.Contains(letter))
                .Aggregate("", (current, letter) => current + letter)
            ;
        }

        private static void DrawHangman(int guessesRemaining)
        {
            switch (guessesRemaining)
            {
                case 6:
                    Console.WriteLine("  _________");
                    Console.WriteLine("  |       |");
                    Console.WriteLine("  |");
                    Console.WriteLine("  |");
                    Console.WriteLine("  |");
                    Console.WriteLine("  |");
                    Console.WriteLine("  |");
                    Console.WriteLine("  |");
                    Console.WriteLine("__|__");
                    break;
                case 5:
                    Console.WriteLine("  _________");
                    Console.WriteLine("  |       |");
                    Console.WriteLine("  |       O");
                    Console.WriteLine("  |");
                    Console.WriteLine("  |");
                    Console.WriteLine("  |");
                    Console.WriteLine("  |");
                    Console.WriteLine("  |");
                    Console.WriteLine("__|__");
                    break;
                case 4:
                    Console.WriteLine("  _________");
                    Console.WriteLine("  |       |");
                    Console.WriteLine("  |       O");
                    Console.WriteLine("  |       |");
                    Console.WriteLine("  |");
                    Console.WriteLine("  |");
                    Console.WriteLine("  |");
                    Console.WriteLine("  |");
                    Console.WriteLine("__|__");
                    break;
                case 3:

                    Console.WriteLine("  _________");
                    Console.WriteLine("  |       |");
                    Console.WriteLine("  |       O");
                    Console.WriteLine("  |      /|\\");
                    Console.WriteLine("  |");
                    Console.WriteLine("  |");
                    Console.WriteLine("  |");
                    Console.WriteLine("  |");
                    Console.WriteLine("__|__");
                    break;
                case 2:
                    Console.WriteLine("  _________");
                    Console.WriteLine("  |       |");
                    Console.WriteLine("  |       O");
                    Console.WriteLine("  |      /|\\");
                    Console.WriteLine("  |      /");
                    Console.WriteLine("  |");
                    Console.WriteLine("  |");
                    Console.WriteLine("  |");
                    Console.WriteLine("__|__");
                    break;
                case 1:
                case 0:
                    Console.WriteLine("  _________");
                    Console.WriteLine("  |       |");
                    Console.WriteLine("  |       O");
                    Console.WriteLine("  |      /|\\");
                    Console.WriteLine("  |      / \\");
                    Console.WriteLine("  |");
                    Console.WriteLine("  |");
                    Console.WriteLine("  |");
                    Console.WriteLine("__|__");
                    break;

            }
        }

        private static void DisplayWord(string wordToGuess, string guessedLetters)
        {
            var wordToDisplay = wordToGuess
                .ToCharArray()
                .Select(letter => guessedLetters.Contains(letter) ? letter : '_')
                .Aggregate("", (current, letter) => current + letter)
            ;

            Console.WriteLine($"The word is: {wordToDisplay}");
        }

        private static bool IsLetter(string? guess)
        {
            return guess?.Length == 1 && char.IsLetter(guess[0]);
        }

        private static bool IsWordGuessed(string wordToGuess, string guessedLetters)
        {
            return wordToGuess
                .ToCharArray()
                .All(letter => guessedLetters.Contains(letter))
            ;
        }
    }
}
