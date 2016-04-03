using System;

namespace Trivia_csharp.Completed
{
    public class Player
    {
        private int _place;
        private bool _isGettingOutOfPenaltyBox;
        private bool _inPenaltyBox;
        private int _purse;
        private readonly string _playerName;
        public event Action<Player> PlaceChanged;
        public event Action<Player> PurseChanged;
        public event Action<Player> InPenaltyChanged;
        public event Action<Player> IsGettingOutOfPenaltyChanged;
        
        public int Place
        {
            get { return _place; }
            private set
            {
                this.SetField(ref _place, value,PlaceChanged);
            }
        }

        public int Purse
        {
            get { return _purse; }
            set { this.SetField(ref _purse, value, PurseChanged); }
        }

        public bool InPenaltyBox
        {
            get { return _inPenaltyBox; }
            set { this.SetField(ref _inPenaltyBox, value, InPenaltyChanged); }
        }

        public bool IsGettingOutOfPenaltyBox
        {
            get { return _isGettingOutOfPenaltyBox; }
            set { this.SetField(ref _isGettingOutOfPenaltyBox, value, IsGettingOutOfPenaltyChanged); }
        }

        public Player(string playerName, IGameRenderer renderer = null)
        {
            _playerName = playerName;

            if (renderer == null) return;
            PurseChanged += renderer.ShowPlayerPurses;
            InPenaltyChanged += renderer.ShowSentPlayerToPenality;
            IsGettingOutOfPenaltyChanged += renderer.ShowGettingOut;
            PlaceChanged += renderer.ShowNewPlace;
        }

        public override string ToString()
        {
            return _playerName;
        }

        public void MoveOf(int roll)
        {
            Place = (Place + roll) % 12;
        }
    }
}