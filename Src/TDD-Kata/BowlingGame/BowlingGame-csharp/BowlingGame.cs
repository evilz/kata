using System.Collections.Generic;
using System.Linq;
using BowlingGame_csharp.Tests;

namespace BowlingGame_csharp
{
    public class BowlingGame
    {
        private readonly LinkedList<Frame> _frames = new LinkedList<Frame>();
        private LinkedListNode<Frame> _currentFrame;

        public BowlingGame()
        {
            _currentFrame = _frames.AddFirst(new Frame());
        }

        public void Roll(int pins)
        {
            if (State == BowlingGameState.Finished)
                return;

            if (_currentFrame.IsCompleted())
            {
                _currentFrame = _frames.AddLast(new Frame());
            }
            _currentFrame.Value.KnockDown(pins);
        }

        public int Score
        {
            get
            {
                var score = 0;
                var node = _frames.First;
                while (node != null)
                {
                    score += node.GetScore();
                    node = node.Next;
                }
                return score;
            }
        }

        public BowlingGameState State
        {
            get
            {
                return _frames.Count == 10 && _frames.All(f => f.IsCompleted) && !_frames.Last().IsStrike && !_frames.Last().IsSpare
                    || _frames.Count == 11 && _frames.All(f => f.IsCompleted)
                    || _frames.Count == 12 && _frames.All(f => f.IsCompleted)
                  ? BowlingGameState.Finished
                  : BowlingGameState.InProgress;
            }
        }
    }
}
