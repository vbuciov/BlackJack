using System;
using Blackjack.game;
using Blackjack.api;
using Blackjack.imp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.game
{
	[TestClass()]
	public class BlackJack21Test
	{
		BlackJack21 game;
		IDeck testDeck;
		Player myPlayer;
		Player myComputer;

		public BlackJack21Test ()
		{
			game = new BlackJack21 ();
			testDeck = new UnlimitedDeck ();
			myPlayer = new Player ("TestPlayer");
			myComputer = new Player ("TestComputer");
			game.AddPlayer (myPlayer);
			game.AddPlayer (myComputer);
		}

		[TestMethod()]
		public void eachPlayerStartWith2Cards()
		{
			game.Start (testDeck);
			Assert.IsTrue (myPlayer.CardsCount == 2);
			Assert.IsTrue (myComputer.CardsCount == 2);
			game.resetGame ();
		}

		[TestMethod()]
		public void computerWinsTheGameWithMorePointsThanPlayer()
		{
			AssignTestCards (myPlayer, 10, 17);
			AssignTestCards (myComputer, 10, 10, 1);

			game.PerfomEvaluation ();
			Assert.IsTrue (myPlayer.Stay && myComputer.Stay);
			Assert.IsTrue (game.getTheWinner().Contains(myComputer.Name));
			game.resetGame ();
		}

		[TestMethod()]
		public void computerWinsTheGameWith21PointsButPlayerExceed()
		{
			AssignTestCards (myPlayer, 10, 10, 10);
			AssignTestCards (myComputer, 10, 10, 1);

			game.PerfomEvaluation ();
			Assert.IsTrue (myPlayer.Stay && myComputer.Stay);
			Assert.IsTrue (game.getTheWinner().Contains(myComputer.Name));
			game.resetGame ();
		}

		[TestMethod()]
		public void computerWinsTheGameWith10Points()
		{
			AssignTestCards (myPlayer, 1, 2);
			AssignTestCards (myComputer, 9, 1);

			game.PerfomEvaluation ();
			Assert.IsTrue (myPlayer.Stay && myComputer.Stay);
			Assert.IsTrue (game.getTheWinner().Contains(myComputer.Name));
			game.resetGame ();
		}

		[TestMethod()]
		public void playerWinsGameWithMorePointsThanComputer()
		{
			AssignTestCards (myPlayer, 10, 10, 1);
			AssignTestCards (myComputer, 10, 7);

			game.PerfomEvaluation ();
			Assert.IsTrue (myPlayer.Stay && myComputer.Stay);
			Assert.IsTrue (game.getTheWinner().Contains(myPlayer.Name));
			game.resetGame ();
		}

		[TestMethod()]
		public void playerWinsGameWith21PointsButComputerExceed()
		{
			AssignTestCards (myPlayer, 10, 10, 1);
			AssignTestCards (myComputer, 10, 10, 10);

			game.PerfomEvaluation ();
			Assert.IsTrue (myPlayer.Stay && myComputer.Stay);
			Assert.IsTrue (game.getTheWinner().Contains(myPlayer.Name));
			game.resetGame ();
		}


		[TestMethod()]
		public void playerWinsTheGameWith10Points()
		{
			AssignTestCards (myPlayer, 1, 9);
			AssignTestCards (myComputer, 1, 1);

			game.PerfomEvaluation ();
			Assert.IsTrue (myPlayer.Stay && myComputer.Stay);
			Assert.IsTrue (game.getTheWinner().Contains(myPlayer.Name));
			game.resetGame ();
		}

		[TestMethod()]
		public void drawGameWith21Points()
		{
			AssignTestCards (myPlayer, 10, 10, 1);
			AssignTestCards (myComputer, 10, 10, 1);

			game.PerfomEvaluation ();
			Assert.IsTrue (myPlayer.Stay && myComputer.Stay);
			Assert.IsTrue (game.getTheWinner().Contains("draw game"));
			game.resetGame ();
		}

		[TestMethod()]
		public void drawGameWith17Points()
		{
			AssignTestCards (myPlayer, 10, 7);
			AssignTestCards (myComputer, 10, 7);

			game.PerfomEvaluation ();
			Assert.IsTrue (myPlayer.Stay && myComputer.Stay);
			Assert.IsTrue (game.getTheWinner().Contains("draw game"));
			game.resetGame ();
		}

		[TestMethod()]
		public void bothLosesTheGame()
		{
			AssignTestCards (myPlayer, 10, 10, 10);
			AssignTestCards (myComputer, 10, 10, 10);

			game.PerfomEvaluation ();
			Assert.IsTrue (myPlayer.Stay && myComputer.Stay);
			Assert.IsTrue (game.getTheWinner().Contains("no winner"));
			game.resetGame ();
		}


		/// <summary>
		/// Assigns cards to an existing player
		/// </summary>
		/// <param name="player">Player</param>
		/// <param name="cards">Card values</param>
		private void AssignTestCards(Player testPlayer, params int[] cards) {
			ICard theNewCard;
			foreach (int cardValue in cards) {
				theNewCard = new Card (cardValue, 1);
				testPlayer.AddCard(theNewCard);
			}

			//Simulates that he ask for stay or he already exceeded 21
			testPlayer.Stay = true;
		}
	}
}