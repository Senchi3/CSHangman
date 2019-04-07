using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject {
    class GuessTest {
        const string symbol = "*";
        const char emptySpace = ' ';
        public string secretWord;
        public string shownWord;

        public GuessTest(string secretWord) {

            this.secretWord = secretWord;

            if (string.IsNullOrWhiteSpace(secretWord)) {
                Console.WriteLine("WARNING YOU MADE A GAME WITH EMPTY SECRETWORD");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            for (int i = 0; i < secretWord.Length; i++) {
                if (!(secretWord[i] == emptySpace)) {
                    shownWord += symbol;
                } else {
                    shownWord += emptySpace;
                }
            }
            Console.WriteLine("Your secret word is " + shownWord);
        }
    }
}