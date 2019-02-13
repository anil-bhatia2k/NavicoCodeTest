using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Navico.Test.SnakeAndLadder.Common
{
    public class Game
    {
        private GameStatus gameStatus { get; set; }
        protected  List<GamePlayer> _players;

        /// <summary>
        /// constructor
        /// </summary>
        public Game()
        {
            _players = new List<GamePlayer>();
        }

        /// <summary>
        /// method to add a player to the player list . This follows the aggregate root pattern to avoid exposing the list of players to outside world
        /// </summary>
        /// <param name="player"></param>
        public void AddPlayer(GamePlayer player)
        {
            _players.Add(player);
        }

        /// <summary>
        ///   method to move the token. This will decide the player whose turn it is to roll
        ///a die and call a method on the player to roll a die and move token
        /// </summary>
        public void MoveToken()
        {
            _players[0].PlayNextMove();
            if (_players.Any(x => x.IsWinner))
            {
                gameStatus = GameStatus.EndWithWinner;
            }
        }

        /// <summary>
        /// method to return the status of the game
        /// </summary>
        /// <returns></returns>
        public GameStatus GetGameStatus()
        {
            return gameStatus;
        }

        /// <summary>
        /// method to get the token position of the player
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public int GetPlayerTokenPostion(int id)
        {
            return _players.FirstOrDefault(p=>p.Id==id).GetCurrentTokenPosition();
        }

        /// <summary>
        /// method to start the game
        /// </summary>
        public void Start()
        {
            gameStatus = GameStatus.Start;           
        }

      
    }
}
