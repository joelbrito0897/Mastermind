using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mastermind.Resources.Enums;
using NUnit.Framework;

namespace Mastermind.Test.Resources
{
    public class MastermindTest
    {
        [TestCaseSource(nameof(ResulPeg))]
        [TestCase(null)]
        public void TestMastermindHints(List<ResultPeg> param)
        {
            var list = new List<CodePeg> {CodePeg.Black, CodePeg.Black, CodePeg.Black, CodePeg.Black};

            var mastermind = new Mastermind.Resources.Mastermind();

            var result = mastermind.GetHints(list);

            Assert.AreEqual(param, result);
        }

        private static readonly List<ResultPeg> ResulPeg =
            new() {ResultPeg.Black, ResultPeg.Black, ResultPeg.Black, ResultPeg.Black};

    }
}
