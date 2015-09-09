using NUnit.Framework;

namespace BowlingGame_csharp
{
    [TestFixture]
    public class SimpleBowlingGameTests
    {
        private SimpleBowlingGame _game;
        [SetUp]
        public void Setup()
        {
            _game = new SimpleBowlingGame();
        }

        private void RollMany(int n, int pins)
        {
            for (int i = 0; i < n; i++)
            {
                _game.Roll(pins);
            }
        }

        private void RollSpare(int firstRoll = 5)
        {
            _game.Roll(firstRoll);
            _game.Roll(10 - firstRoll);
        }

        private void RollStrike()
        {
            _game.Roll(10);
        }

        [Test]
        public void GutterGame_Should_return0()
        {
            RollMany(20, 0);
            Assert.AreEqual(0, _game.Score());
        }


        [Test]
        public void All1_Should_return20()
        {
            RollMany(20, 1);
            Assert.AreEqual(20, _game.Score());
        }

        [Test]
        public void Spare_Should_AddNextRollPins()
        {
            RollSpare();
            _game.Roll(3);
            RollMany(17, 0);
            Assert.AreEqual(16, _game.Score());
        }

        [Test]
        public void Strike_Should_AddTwoNextRolls()
        {
            RollStrike();
            _game.Roll(3);
            _game.Roll(4);
            RollMany(16, 0);
            Assert.AreEqual(24, _game.Score());
        }

        [Test]
        public void PerfectGame_Should_ReturnScoreOf300()
        {
            RollMany(12, 10);
            Assert.AreEqual(300, _game.Score());
        }



    }
}
