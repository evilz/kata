using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Yatzy_csharp.Completed
{
    public class YatzyDice : IEnumerable<int>
    {
        public int[] Dice { get; }

        public YatzyDice(int d1, int d2, int d3, int d4, int d5)
        {
            Dice = new[] { d1, d2, d3, d4, d5 };
        }

        public YatzyDice(params int[] dices)
        {
            Dice = dices.Take(5).ToArray();
        }

        public IEnumerator<int> GetEnumerator()
        {
            return Dice.Cast<int>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}