using System;
using System.Linq;
using System.Reflection.Metadata;
using Mastermind.Resources.Enums;

namespace Mastermind
{
    class Program
    {
        public int _Turn { get; set; }
        static void Main(string[] args)
        {
            Console.WriteLine("Greetings!");
            Console.WriteLine("I have generated a random code:");
            Console.WriteLine("There are only 4 digits, That represent a color");
            Console.WriteLine("Each digit falls between 0 and 5, inclusive.");

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("You have up to 5 tries to guess my secret code.");

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine($"- Black = {(int)CodePeg.Black}");
            Console.WriteLine($"- Blue = {(int)CodePeg.Blue}");
            Console.WriteLine($"- Green = {(int)CodePeg.Green}");
            Console.WriteLine($"- Red = {(int)CodePeg.Red}");
            Console.WriteLine($"- White = {(int)CodePeg.White}");
            Console.WriteLine($"- Yellow = {(int)CodePeg.Yellow}");

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("After each guess, I will give you a 4-digit response:");
            Console.WriteLine($" - Black = '{(int)ResultPeg.Black}' character means your guess was correct in that position.");
            Console.WriteLine($" - White = '{(int)ResultPeg.White}' character means that digit is in the code, but not in that position.");
            Console.WriteLine($" - Gray = '{(int)ResultPeg.Gray}' means that digit is not in the code at all.");
            Console.WriteLine("\nPlease enter your first guess now.");

            var mastermind = new Resources.Mastermind();
            
            do
            {
                Console.Write("\n> ");
                var pressed = Console.ReadLine();
                if (pressed.Length>4)
                {
                    Console.WriteLine($"You can write 4 character, you inputed {pressed.Length}, Bye");
                    mastermind.IsFinished = true;
                    break;
                }
                if (pressed.Length<4)
                {
                    Console.WriteLine($"The min is 4, Bye");
                    mastermind.IsFinished = true;
                    break;
                }
                var listOfColor = (pressed ?? string.Empty).Select(c => c.ToString()).ToList().ConvertAll(x =>
                    (CodePeg) Enum.Parse(typeof(CodePeg), x));

                var result = mastermind.GetHints(listOfColor);

                var dataToPrint = string.Empty;
                result.ForEach(c =>
                {
                    dataToPrint += (int) c;
                });
                if (dataToPrint.Equals(string.Concat(Enumerable.Repeat($"{(int)ResultPeg.Black}", 4))))
                {
                    mastermind.IsFinished = true;
                    Console.WriteLine($"Congratulations, you won!\n(The code was {dataToPrint})");
                }
                else
                {
                    mastermind.Turn++;
                    mastermind.IsFinished = false;
                    Console.WriteLine("Try again");
                    Console.WriteLine($"Turn #{mastermind.Turn}");
                }

                if (mastermind.Turn>4)
                {
                    mastermind.IsFinished = true;
                    Console.WriteLine($@"Sorry, you lose.");
                }
                Console.WriteLine($"Result: {dataToPrint}");
                

            } while (!mastermind.IsFinished);

            Console.ReadKey();
        }
    }
}
