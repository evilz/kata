using System.Collections.Generic;

namespace BowlingGame_csharp
{
    public static class FrameExt
    {
        public static int GetScore(this LinkedListNode<Frame> frame)
        {
            var score = frame.Value.FrameScore;
            if (frame.IsStrike())
            {
                score += frame.GetStrikeBonus();
            }
            if (frame.Value.IsSpare)
            {
                score += frame.GetSpareBonus();
            }
            return score;
        }

        public static bool IsStrike(this LinkedListNode<Frame> frame)
        {
            return frame.Value.IsStrike;
        }

        public static bool IsCompleted(this LinkedListNode<Frame> frame)
        {
            return frame.Value.IsCompleted;
        }

        private static int GetStrikeBonus(this LinkedListNode<Frame> frame)
        {
            return frame.Value.GetStrikeBonus(frame);
        }

        private static int GetSpareBonus(this LinkedListNode<Frame> frame)
        {
            return frame.Value.GetSpareBonus(frame);
        }

    }
}