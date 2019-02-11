using Navico.Test.SnakeAndLadder.Common;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }


        //Given the game is started
        //When the token is placed on the board
        //Then the token is on square 1
        [Test]
        public void NewTokenAddedToBoardHasDefaultPositionAsOne()
        {
            Game game = new Game();
            game.AddPlayer(1, "Player1");
            game.Start();
            Assert.That(game.GetPlayerTokenPostion(1) == 1);
        }

        //Given the token is on square 1
        //When the token is moved 3 spaces
        //Then the token is on square 4
        [Test]
        public void TokenPositionIsMovedCorrectlyOnFirstMove()
        {
            TestGame game = new TestGame();
            game.Start();
            game.AddPlayer(1, "Player1");
            game.incrementValue = 3;
            game.MoveToken();
            Assert.That(game.GetPlayerTokenPostion(1) == 4);
        }

        //Given the token is on square 1
        //When the token is moved 3 spaces
        //And then it is moved 4 spaces
        //Then the token is on square 8
        [Test]
        public void TokenPositionIsMovedCorrectlyFromCurrentPosition()
        {
            TestGame game = new TestGame();
            game.Start();
            game.AddPlayer(1, "Player1");
            game.incrementValue = 3;
            game.MoveToken();
            game.incrementValue = 4;
            game.MoveToken();
            Assert.That(game.GetPlayerTokenPostion(1) == 8);
        }


        //Given the game is started
        //When the player rolls a die
        //Then the result should be between 1-6 inclusive
        [Test]
        public void PlayerRollingADieReturnsNumbersBetween1And6()
        {
            GamePlayer player = new GamePlayer();
            int number = player.RollDie();
            Assert.That(number > 0 && number < 6);
        }

        //Given the player rolls a 4
        //When they move their token
        //Then the token should move 4 spaces
        [Test]
        public void TheTokenIsMovedCorrectlyWhenAPlayerRollsDie()
        {
            TestGame game = new TestGame();
            game.AddPlayer(1, "Player1");
            game.incrementValue = 4;
            game.Start();          
            game.MoveToken();
            Assert.That(game.GetPlayerTokenPostion(1) == 5);
        }
               
        //Given the token is on square 97
        //When the token is moved 3 spaces
        //Then the token is on square 100
        //And the player has won the game
        [Test]
        public void TokenMovesTo100AndWinsTheGame()
        {
            TestGame game = new TestGame();
            game.Start();  
            int incrementValue = 96;
            game.MoveToken();
            incrementValue = 3;
            game.MoveToken();
            Assert.That(game.GetTokenPostion(tokenNumber) == 8);
        }


    }
    public class TestGame : Game
    {
       
        public int incrementValue {get;set;}
        protected override int RollDie()
        {
            return incrementValue;
        }

    }

   
}