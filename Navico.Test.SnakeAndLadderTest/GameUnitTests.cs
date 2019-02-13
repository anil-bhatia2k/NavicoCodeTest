
using Moq;
using Navico.Test.SnakeAndLadder.Common;
using NUnit.Framework;

namespace Tests
{
    public class GameUnitTests

    {
        private Game _game;
        Mock<GamePlayer> _playerMock;

        [SetUp]
        public void Setup()
        {
            _playerMock = new Mock<GamePlayer>();
            _playerMock.Setup(x => x.Id).Returns(1);
            _game = new Game();
            _game.Start();
            _game.AddPlayer(_playerMock.Object);

        }


        //Given the game is started
        //When the token is placed on the board
        //Then the token is on square 1
        [Test]
        public void NewTokenAddedToBoardHasDefaultPositionAsOne()
        {
            Assert.That(_game.GetPlayerTokenPostion(1) == 1);
        }

        //Given the token is on square 1
        //When the token is moved 3 spaces
        //Then the token is on square 4
        [Test]
        public void TokenPositionIsMovedCorrectlyOnFirstMove()
        {
            _playerMock.Setup(x => x.RollDie()).Returns(3);
           _game.MoveToken();
            Assert.That(_game.GetPlayerTokenPostion(1) == 4);
        }

        //Given the token is on square 1
        //When the token is moved 3 spaces
        //And then it is moved 4 spaces
        //Then the token is on square 8
        [Test]
        public void TokenPositionIsMovedCorrectlyFromCurrentPosition()
        {
            _playerMock.Setup(x => x.RollDie()).Returns(3);
            _game.MoveToken();
            _playerMock.Setup(x => x.RollDie()).Returns(4);
            _game.MoveToken();
            Assert.That(_game.GetPlayerTokenPostion(1) == 8);
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
            _playerMock.Setup(x => x.RollDie()).Returns(4);
            _game.MoveToken();
            Assert.That(_game.GetPlayerTokenPostion(1) == 5);
        }

        //Given the token is on square 97
        //When the token is moved 3 spaces
        //Then the token is on square 100
        //And the player has won the game
        [Test]
        public void TokenMovesTo100AndWinsTheGame()
        {
            _playerMock.Setup(x => x.RollDie()).Returns(96);
            _game.MoveToken();
            _playerMock.Setup(x => x.RollDie()).Returns(3);
            _game.MoveToken();
            Assert.That(_game.GetPlayerTokenPostion(1) == 100);
            Assert.That(_game.GetGameStatus() == GameStatus.EndWithWinner);
        }

        //Given the token is on square 97
        //When the token is moved 4 spaces
        //Then the token is on square 97
        //And the player has not won the game
        [Test]
        public void TokenDoesNotMoveTo100WhenthePlayerRolls4After97()
        {
            _playerMock.Setup(x => x.RollDie()).Returns(96);
            _game.MoveToken();
            _playerMock.Setup(x => x.RollDie()).Returns(4);
            _game.MoveToken();
            Assert.That(_game.GetPlayerTokenPostion(1) == 97);
        }

    }


    

}

