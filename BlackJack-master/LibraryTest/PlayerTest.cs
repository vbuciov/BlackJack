using System;
using Blackjack.game;
using Blackjack.api;
using Blackjack.imp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.game
{
	[TestClass()]
	public class PlayerTest
	{
		[TestMethod()]
		public void pointsIncreasesAcordingToHand()
		{
			Player myPlayer = new Player ("Test");
			ICard random = new Card (10, 1);

			myPlayer.AddCard (random);

			Assert.AreEqual (random.getValue (), myPlayer.Points);
		}

		[TestMethod()]
		public void realeseHand()
		{
			Player myPlayer = new Player ("Test");
			ICard random = new Card (10, 1);

			myPlayer.AddCard (random);

			Assert.IsTrue (myPlayer.CardsCount > 0 && myPlayer.Points > 0);
			myPlayer.releaseHand ();

			Assert.IsTrue (myPlayer.CardsCount == 0 && myPlayer.Points == 0);
		}
	}
}

