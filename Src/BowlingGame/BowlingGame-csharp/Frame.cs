using System.Collections.Generic;
using System.Linq;

namespace BowlingGame_csharp
{
    public class Frame
    {
        public void KnockDown(int pins)
        {
            Rolls.First(roll => roll.State == RollState.UnPlayed).KnockDown(pins);
        }

        private IEnumerable<Roll> Rolls
        {
            get
            {
                yield return Roll1;
                yield return Roll2;
            }
        }

        public Roll Roll1 { get; } = new Roll();
        public Roll Roll2 { get; } = new Roll();
        private bool IsRoll1Played { get { return Roll1.State == RollState.Played; } }
        private bool IsRoll2Played { get { return Roll2.State == RollState.Played; } }

        public bool IsStrike
        {
            get { return IsRoll1Played && Roll1.Pins == 10; }
        }

        public int FrameScore
        {
            get
            {
                return Roll1.Pins + Roll2.Pins;
            }
        }

        public int GetStrikeBonus(LinkedListNode<Frame> frameInList)
        {
            var bonus = 0;
            var nextFrame = frameInList.Next;
            if (nextFrame != null)
            {
                bonus += nextFrame.Value.FrameScore;
                if (nextFrame.IsStrike() && nextFrame.Next != null)
                {
                    bonus += nextFrame.Next.Value.Roll1.Pins;
                }
            }
            return bonus;
        }
        
        public bool IsSpare
        {
            get { return FrameScore == 10 && !IsStrike; }
        }

        public bool IsCompleted => IsRoll1Played && IsRoll2Played || IsStrike;

        public virtual int GetSpareBonus(LinkedListNode<Frame> frame)
        {
            return frame.Next.Value.Roll1.Pins;
        }
    }
}