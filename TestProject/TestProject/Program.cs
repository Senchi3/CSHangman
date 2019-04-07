using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject {
    class Program {
        static void Main(string[] args) {

            HangGame game = new HangGame();

            while (!(game.guessTest.shownWord == game.guessTest.secretWord)) {
                game.Run();
            }

            Console.WriteLine("Game finished. Press any key to continue.");
            Console.ReadKey();
        }
    }
}