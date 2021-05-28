using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mastermind.Resources.Enums;

namespace Mastermind.Resources.Logic
{
    public class GuessAnalyzer
    {
        private readonly List<int> _code;

        public GuessAnalyzer(List<int> code)
        {
            _code = code;
        }
        public string Analyze(List<CodePeg> param)
        {
            var winner = param.Cast<int>().ToList();
                //Select(x => x.ToString()).ToList().ConvertAll(Convert.ToInt32);

            var builder = new StringBuilder();
            
            for (var i = 0; i < winner.Count; i++)
            {
                var digit = winner[i];
                var response = (int)ResultPeg.Gray;
                if (_code.Contains(digit))
                    response = _code[i] == digit
                         ? (int)ResultPeg.Black
                        : (int)ResultPeg.White;
                builder.Append(response);
            }
            
            return builder.ToString();
        }
    }
}
