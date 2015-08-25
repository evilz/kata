using NUnit.Framework;

namespace BowlingGame_csharp.Tests
{
    [TestFixture]
    public class BowlingGameTests
    {
        private BowlingGame _bowlingGame;
        [SetUp]
        public void Setup()
        {
            _bowlingGame = new BowlingGame();
        }
        
        private void RollMany(int times, int pinsDown)
        {
            for (int i = 0; i < times; i++)
            {
                _bowlingGame.Roll(pinsDown);
            }
        }

        private void RollSpare(int firstRoll = 5)
        {
            _bowlingGame.Roll(firstRoll);
            _bowlingGame.Roll(10 - firstRoll);
        }

        private void RollStrike()
        {
            _bowlingGame.Roll(10);
        }

        [Test]
        public void GutterGame_Should_return0()
        {
            RollMany(20, 0);
            Assert.AreEqual(0, _bowlingGame.Score);
        }


        [Test]
        public void Should_sum_all_pins_down_when_there_is_no_bonus()
        {
            RollMany(20, 1);
            Assert.AreEqual(20, _bowlingGame.Score);
        }

        [Test]
        public void Should_add_next_roll_after_a_spare()
        {
            RollSpare();
            _bowlingGame.Roll(3);
            Assert.AreEqual(16, _bowlingGame.Score);
        }

        [Test]
        public void Should_add_two_next_rolls_after_a_strike()
        {
            RollStrike();
            _bowlingGame.Roll(3);
            _bowlingGame.Roll(4);
            Assert.AreEqual(24, _bowlingGame.Score);
        }

        [Test]
        public void PerfectGame_Should_ReturnScoreOf300()
        {
            RollMany(12, 10);
            Assert.AreEqual(300, _bowlingGame.Score);
        }

        [Test]
        public void Should_be_inprogress_when_starting_game()
        {
            Assert.AreEqual(BowlingGameState.InProgress, _bowlingGame.State);
        }
        
        [Test]
        public void Should_be_finished_when_20_rolls_have_be_done_without_bonus()
        {
            RollMany(20,1);
            Assert.AreEqual(BowlingGameState.Finished, _bowlingGame.State);
        }
    }
}
