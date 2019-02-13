using System;
using System.Collections.Generic;
using System.Text;

namespace Navico.Test.SnakeAndLadder.Common
{
    /// <summary>
    /// Class to represent a player in the game .
    /// </summary>
    public class GamePlayer
    {
        private Token _token { get;}
        public virtual int Id { get; set; }
      
        public bool IsWinner => _token.Position == 100;

        /// <summary>
        /// constructor
        /// </summary>
        public GamePlayer()
        {
            _token = new Token();
        }

        /// <summary>
        /// template for rolling a die and moving a token when it is this players turn 
        /// </summary>
        public void PlayNextMove()
        {
            int value = RollDie();
            MoveToken(value);
        }

        public int GetCurrentTokenPosition()
        {
            return _token.Position;
        }

        public  virtual int RollDie()
        {
            Random random = new Random();
            return random.Next(1,6);
        }

        protected void MoveToken(int value)
        {
           if(_token.Position + value <= 100)
            _token.Position += value;
        }

    }
}
