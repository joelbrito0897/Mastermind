using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mastermind.Resources.Enums;
using Mastermind.Resources.Models;

namespace Mastermind.Resources.Logic
{
    public class MastermindGame
    {
        private static readonly Random _random = new();
        private readonly GuessAnalyzer _analyzer;
        private readonly List<Turn> _turns = new();

        private readonly List<int> _code;

        public bool IsFinished { get; private set; }
        public MastermindGame() : this(GenerateCode()) { }

        public MastermindGame(List<int> code)
        {
            _code = code;
            _analyzer = new GuessAnalyzer(code);
        }

        private static List<int> GenerateCode(int length = 4)
        {
            var codePeg = new List<int>();
            var list = Enum.GetValues(typeof(CodePeg));
            while (codePeg.Count != 4)
            {
                codePeg.Add((int)list.GetValue(_random.Next(length)));
            }
            return codePeg;
        }

        public string GetHints(List<int> guess)
        {
            // Implement your code here.
            var turn = new Turn
            {
                Number = _turns.Count + 1,
               // Response = _analyzer.Analyze(guess)
            };

            _turns.Add(turn);

            if (turn.Response.Equals(string.Concat(Enumerable.Repeat($"{(int)ResultPeg.Black}", 4))))
            {
                IsFinished = true;
                return $"Congratulations, you won!\n(in only {turn.Number} turns)";
            }
            if (turn.Number > 4)
            {
                IsFinished = true;
                return $@"Sorry, you lose.(The code was $'{_code}')";
            }

            return turn.Response;
        }
    }
}
