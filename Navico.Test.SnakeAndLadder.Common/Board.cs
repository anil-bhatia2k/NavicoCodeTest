using System;
using System.Collections.Generic;

namespace Navico.Test.SnakeAndLadder.Common
{
    public class Board
    {
        public List<Token> Tokens { get; set; }                

        public int GetNextNumber(int  currentPosition, int incrementValue)
        {
            return incrementValue + currentPosition ;          
        }
    }
}
