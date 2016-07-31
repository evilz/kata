using System.Collections.Generic;
using System.Linq;

namespace Yatzy_csharp.Completed
{
    public static class YatzyComputer {

        public static int Chance(this YatzyDice dice)
        {
            return dice.Sum();
        }
        
        public static int Yatzy(this YatzyDice dice)
        {
            return dice.GroupDice().Count == 1
                ? 50
                : 0;
        }

        public static int Ones(this YatzyDice dice) {

            return dice.FilteredSumBy(1);
        }

        public static int Twos(this YatzyDice dice) {
            return dice.FilteredSumBy(2);
        }

        public static int Threes(this YatzyDice dice)
        {
            return dice.FilteredSumBy(3);
        }
        
        public static int Fours(this YatzyDice dice)
        {
            return dice.FilteredSumBy(4);
        }

        public static int Fives(this YatzyDice dice)
        {
            return dice.FilteredSumBy(5);
        }

        public static int Sixes(this YatzyDice dice)
        {
            return dice.FilteredSumBy(6);
        }

        public static int OnePair(this YatzyDice dice)
        {
            var pairs = dice.GroupDice().WhereCountIsAtLeast(2);

           return pairs.Any()
                ? pairs.First().Key * 2
                : 0;           
        }

        public static int TwoPair(this YatzyDice dice)
        {
            var pairs = dice.GroupDice().WhereCountIsAtLeast(2);

            return pairs.Length == 2 
                ? pairs[0].Key * 2 + pairs[1].Key * 2 
                : 0;
        }

        public static int FourOfAKind(this YatzyDice dice)
        {
            var threeOfAKind = dice.GroupDice().WhereCountIsAtLeast(4);

            return threeOfAKind.Any()
                ? threeOfAKind[0].Key * 4
                : 0;
        }

        public static int ThreeOfAKind(this YatzyDice dice)
        {
            var threeOfAKind = dice.GroupDice().WhereCountIsAtLeast(3);

            return threeOfAKind.Any() 
                ? threeOfAKind[0].Key*3 
                : 0;
        }

        public static int SmallStraight(this YatzyDice dice)
        {
            return dice.GroupDice().Count == 5 
                ? 15
                 : 0;
        }

        public static int LargeStraight(this YatzyDice dice)
        {
            var groupDice = dice.GroupDice();
            return groupDice.Count == 5 && groupDice.First().Key == 6 
                ? 20
                : 0;
        }

        public static int FullHouse(this YatzyDice dice)
        {
            var groups = dice.GroupDice();

            return groups.Count == 2 
                ? groups.Sum(g => g.Key*g.Value) 
                : 0;
        }

        private static int FilteredSumBy(this YatzyDice dice, int by)
        {
            return dice.Where(i => i == by).Sum();
        }

        private static KeyValuePair<int, int>[] WhereCountIsAtLeast(this IDictionary<int, int> group, int count)
        {
            return group.Where(x => x.Value >= count).ToArray();
        }

        private static IDictionary<int, int> GroupDice(this YatzyDice dice)
        {
            return dice.GroupBy(i => i).OrderByDescending(pair => pair.Key).ToDictionary(g => g.Key, g => g.Count());
        }
    }
}
