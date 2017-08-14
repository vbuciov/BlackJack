using System;
using Blackjack.api;

namespace Blackjack.imp
{
	public class UnlimitedDeck : IDeck
	{
		Random allCards;

		public UnlimitedDeck ()
		{
			allCards = new Random ();
		}


		public ICard getNextCard ()
		{
			return new Card (allCards.Next (10) + 1, allCards.Next (4));
		}

		public void Shuffle ()
		{
			System.Console.WriteLine("Deck was shuffling");
		}
	}
}

