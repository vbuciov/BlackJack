using System;
using Blackjack.api;
using Blackjack.imp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.imp
{
	[TestClass()]
	public class UnlimitedDeckTest
	{
		[TestMethod()]
		public void GetRandomCard()
		{
			UnlimitedDeck myDeck = new UnlimitedDeck ();
			ICard random = myDeck.getNextCard ();

			Assert.IsTrue (random.getValue () > 0);
		}
	}
}

