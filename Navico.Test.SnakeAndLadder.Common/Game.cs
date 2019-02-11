using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Navico.Test.SnakeAndLadder.Common
{
    public class Game
    {       
        private GameStatus gameStatus;
        protected  List<GamePlayer> _players;
        public Game()
        {
          
            _players = new List<GamePlayer>();
        }     
       

        public void AddPlayer(int id, string name)
        {
            _players.Add(new GamePlayer() { Id= id, Name = name });
        }

        protected virtual int RollDie()
        {
           return  _players[0].RollDie();
        }
        
        public void MoveToken()
        {
            GamePlayer player = _players[0];
            // _board.GetNextNumber(player.PlayerToken.Position,incrementValue);
            player.MoveToken(RollDie());            
                   
        }

        public int GetPlayerTokenPostion(int Id)
        {
            return _players.FirstOrDefault(p=>p.Id==Id).GetCurrentTokenPosition();
        }

        public void Start()
        {           
            gameStatus = GameStatus.Start;           
        }

        public void  RollDie(int playerId, int PlayerToken)
        {
           // _board.MoveToken(player.PlayerToken, incrementValue);
           
        }
    }
}
