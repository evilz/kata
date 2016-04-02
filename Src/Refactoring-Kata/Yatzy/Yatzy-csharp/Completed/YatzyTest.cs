using NUnit.Framework;

namespace Yatzy_csharp.Completed
{
    [TestFixture]
    public class YatzyTests
    {

        [TestCase(15, 2, 3, 4, 5, 1)]
        [TestCase(16, 3, 3, 4, 5, 1)]
        public void Chance_should_sum_of_all_dice(int expected, params int[] dices)
        {
            Assert.That(new YatzyDice(dices).Chance(), Is.EqualTo(expected));
        }

        [TestCase(50, 4, 4, 4, 4, 4)]
        [TestCase(50, 6, 6, 6, 6, 6)]
        [TestCase(0, 6, 6, 6, 6, 3)]
        public void Yatzy_should_return_50_or_0(int expected, params int[] dices)
        {
            Assert.That(new YatzyDice(dices).Yatzy(), Is.EqualTo(expected));
        }

        [TestCase(1, 1, 2, 3, 4, 5)]
        [TestCase(2, 1, 2, 1, 4, 5)]
        [TestCase(0, 6, 2, 2, 4, 5)]
        [TestCase(4, 1, 2, 1, 1, 1)]
        public void Ones_should_Sum_1(int expected, params int[] dices)
        {
            Assert.That(new YatzyDice(dices).Ones(), Is.EqualTo(expected));
        }

        [TestCase(4, 1, 2, 3, 2, 6)]
        [TestCase(10, 2, 2, 2, 2, 2)]
        public void Twos_should_Sum_2(int expected, params int[] dices)
        {
            Assert.That(new YatzyDice(dices).Twos(), Is.EqualTo(expected));
        }

        [TestCase(6, 1, 2, 3, 2, 3)]
        [TestCase(12, 2, 3, 3, 3, 3)]
        public void Threes_should_Sum_3(int expected, params int[] dices)
        {
            Assert.That(new YatzyDice(dices).Threes(), Is.EqualTo(expected));
        }

        [TestCase(12, 4, 4, 4, 5, 5)]
        [TestCase(8, 4, 4, 5, 5, 5)]
        [TestCase(4, 4, 5, 5, 5, 5)]
        public void Fours_should_Sum_4(int expected, params int[] dices)
        {
            Assert.That(new YatzyDice(dices).Fours(), Is.EqualTo(expected));
        }

        [TestCase(10, 4, 4, 4, 5, 5)]
        [TestCase(15, 4, 4, 5, 5, 5)]
        [TestCase(20, 4, 5, 5, 5, 5)]
        public void Fives_should_Sum_5(int expected, params int[] dices)
        {
            Assert.That(new YatzyDice(dices).Fives(), Is.EqualTo(expected));
        }


        [TestCase(0, 4, 4, 4, 5, 5)]
        [TestCase(6, 4, 4, 6, 5, 5)]
        [TestCase(18, 6, 5, 6, 6, 5)]
        public void Sixes_should_Sum_6(int expected, params int[] dices)
        {
            Assert.That(new YatzyDice(dices).Sixes(), Is.EqualTo(expected));
        }

        [TestCase(6, 3, 4, 3, 5, 6)]
        [TestCase(10, 5, 3, 3, 3, 5)]
        [TestCase(12, 5, 3, 6, 6, 5)]
        public void OnePair_should_Sum_biggest_pair(int expected, params int[] dices)
        {
            Assert.That(new YatzyDice(dices).OnePair(), Is.EqualTo(expected));
        }

        [TestCase(16, 3, 3, 5, 4, 5)]
        [TestCase(16, 3, 3, 5, 5, 5)]
        public void OnePair_should_Sum_two_pairs(int expected, params int[] dices)
        {
            Assert.That(new YatzyDice(dices).TwoPair(), Is.EqualTo(expected));
        }

        [TestCase(9, 3, 3, 3, 4, 5)]
        [TestCase(15, 5, 3, 5, 4, 5)]
        [TestCase(9, 3, 3, 3, 3, 5)]
        public void ThreeOfAKind_should_Sum_dice_that_are_three_times(int expected, params int[] dices)
        {
            Assert.That(new YatzyDice(dices).ThreeOfAKind(), Is.EqualTo(expected));
        }

        [TestCase(12, 3, 3, 3, 3, 5)]
        [TestCase(20, 5, 5, 5, 4, 5)]
        [TestCase(12, 3, 3, 3, 3, 3)]
        public void FourOfAKind_should_Sum_dice_that_are_four_times(int expected, params int[] dices)
        {
            Assert.That(new YatzyDice(dices).FourOfAKind(), Is.EqualTo(expected));
        }

        [TestCase(15, 1, 2, 3, 4, 5)]
        [TestCase(15, 2, 3, 4, 5, 1)]
        [TestCase(0, 1, 2, 2, 4, 5)]
        public void SmallStraight_should_return_15_if_all_different(int expected, params int[] dices)
        {
            Assert.That(new YatzyDice(dices).SmallStraight(), Is.EqualTo(expected));
        }


        [TestCase(20, 6, 2, 3, 4, 5)]
        [TestCase(20, 2, 3, 4, 5, 6)]
        [TestCase(0, 1, 2, 2, 4, 5)]
        public void LargeStraight_should_return_20_if_all_different_and_there_is_a_6(int expected, params int[] dices)
        {
            Assert.That(new YatzyDice(dices).LargeStraight(), Is.EqualTo(expected));
        }


        [TestCase(18, 6, 2, 2, 2, 6)]
        [TestCase(0, 2, 3, 4, 5, 6)]
        public void FullHouse_should_return_sum_all_dice_if_there_is_two_of_a_kind_and_three_of_a_kind(int expected, params int[] dices)
        {
            Assert.That(new YatzyDice(dices).FullHouse(), Is.EqualTo(expected));
        }

    }
}