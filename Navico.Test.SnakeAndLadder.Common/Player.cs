using System;
using System.Collections.Generic;
using System.Text;

namespace Navico.Test.SnakeAndLadder.Common
{
    public class GamePlayer
    {
        private Token _token { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsWinner
        {
            get
            {
                return _token.Position == 100;
            }
            set
            {
            }
        }  
        public GamePlayer()
        {
            _token = new Token();
        }

        public void MoveToken(int newTokenPosition)
        {
            _token.Position += newTokenPosition;
        }

        public int GetCurrentTokenPosition()
        {
            return _token.Position;
        }

        public int RollDie()
        {
            Random random = new Random();
            return random.Next(1,6);
        }
    }
}
