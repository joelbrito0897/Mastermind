using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mastermind.Resources.Enums;
using Mastermind.Resources.Logic;
using Mastermind.Resources.Models;

namespace Mastermind.Resources
{
    public class Mastermind
    {
        private static readonly Random _random = new();
        private readonly GuessAnalyzer _analyzer;
        private readonly List<Turn> _turns = new();
        
        private readonly List<int> _code;

        public bool IsFinished { get; set; }
        public int Turn { get; set; } = 1;

        public Mastermind() : this(GenerateCode()) { }
        public Mastermind(List<int> code)
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
                codePeg.Add((int) list.GetValue(_random.Next(length)));
            }
            return codePeg;
        }

        public List<ResultPeg> GetHints(List<CodePeg> guess)
        {
            // Implement your code here.
            var response = _analyzer.Analyze(guess);

            var result = response.Select(x => x.ToString()).ToList().ConvertAll(x =>
                (ResultPeg)Enum.Parse(typeof(ResultPeg), x));

            return result;
        }
    }
}