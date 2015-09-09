using System;

namespace TicTacToe
{
    public class TicTacToeException : Exception
    {
        public TicTacToeException(string message) : base(message)
        {
            
        }
    }

    public class TicTacToeEndGameException : Exception
    {
        public TicTacToeEndGameException(string message)
            : base(message)
        {

        }
    }
}