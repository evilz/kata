using System;
using System.IO;
using System.Text;
using ApprovalTests;
using ApprovalTests.Reporters;
using NUnit.Framework;

namespace Trivia_csharp.Completed
{
    public class TriviaTests
    {
        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void RefactoringTests()
        {
            var output = new StringBuilder();
            Console.SetOut(new StringWriter(output));

            Game aGame = new Game();
            Console.WriteLine(aGame.IsPlayable);
            aGame.Add("Chet");


            aGame.Roll(1);
            aGame.Roll(1);
            aGame.Roll(1);
            aGame.Roll(1);
            aGame.Roll(1);
            aGame.Roll(1);
            aGame.Roll(1);
            aGame.Roll(1);
            aGame.Roll(1);
            aGame.Roll(1);
            aGame.Roll(1);
            aGame.Roll(1);
            aGame.Roll(1);
            aGame.Roll(1);

            aGame.WasCorrectlyAnswered();
            aGame.WrongAnswer();

            aGame.Roll(2);

            aGame.Roll(11);

            aGame.WrongAnswer();

            aGame.Roll(2);

            aGame.Roll(2);


            aGame.WrongAnswer();

            aGame.WasCorrectlyAnswered();
            aGame.Roll(1);
            aGame.WasCorrectlyAnswered();

            Console.WriteLine(aGame.IsPlayable);
            aGame.Add("Pat");
            Console.WriteLine(aGame.IsPlayable);
            aGame.Add("Sue");
            Approvals.Verify(output.ToString());
        }
    }
}
