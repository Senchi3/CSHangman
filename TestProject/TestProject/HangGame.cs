using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject {
    class HangGame {

        public GuessTest guessTest;

        public HangGame() {
            Console.WriteLine("Choose your word: ");
            guessTest = new GuessTest(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Your secret word is " + guessTest.shownWord);

        }

        public void Run() {
            string charTry;
            charTry = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(charTry) || charTry.Length > 1) {
                if (charTry == guessTest.secretWord) { break; }
                Console.Clear();
                Console.WriteLine("Your secret word is " + guessTest.shownWord);
                Console.WriteLine("Please input just one letter per try");
                charTry = Console.ReadLine();
            }

            if (charTry == guessTest.secretWord) {
                guessTest.shownWord = charTry;
            } else {

                if (guessTest.secretWord.Contains(charTry)) {
                    string tempWord = string.Empty;
                    for (int i = 0; i < guessTest.secretWord.Length; i++) {
                        if (guessTest.secretWord[i] == charTry[0]) {
                            tempWord += guessTest.secretWord[i];
                        } else {
                            tempWord += guessTest.shownWord[i];
                        }
                    }
                    guessTest.shownWord = tempWord;
                }
            }

            Console.Clear();
            Console.WriteLine("Your secret word is " + guessTest.shownWord);
        }


    }
}