using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject {
    class Program {
        static void Main (string[] args) {

            int lives = 5;
            string secretWord;
            string shownWord = "";

            Console.WriteLine("Write down a sentence all in lowercase.");
            secretWord = Console.ReadLine ();

            Console.Clear ();

            for (int i = 0; i < secretWord.Length; i++) {
                if (!(secretWord[i] == ' ')) {
                    shownWord += "*";
                } else {
                    shownWord += " ";
                }
            }

            Console.WriteLine("Your secret sentence is \"" + shownWord + "\" and you have " + lives + " lives left.");

            while (lives > 0 && !(shownWord == secretWord)) {
                string charTry;
                charTry = Console.ReadLine ();

                while (string.IsNullOrWhiteSpace(charTry) || charTry.Length > 1) {
                    Console.Clear();
                    Console.WriteLine("Your secret sentence is \"" + shownWord + "\" and you have " + lives + " lives left.");
                    Console.WriteLine("Please input just one letter per try.");
                    charTry = Console.ReadLine();
                }

                if (secretWord.Contains(charTry)) {
                    string tempWord = string.Empty;
                    for (int i = 0; i < secretWord.Length; i++) {
                        if (secretWord[i] == charTry[0]) {
                            tempWord += secretWord[i];
                        } else {
                            tempWord += shownWord[i];
                        }
                    }
                    shownWord = tempWord;
                } else {
                    lives--;
                }

                Console.Clear();
                Console.WriteLine("Your secret sentence is \"" + shownWord + "\" and you have " + lives + " lives left.");
            }

            Console.WriteLine("Game finished. Press any key to close.");
            Console.ReadKey();
        }
    }
}
