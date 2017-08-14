using System;
using Blackjack.api;

namespace Blackjack.imp
{
	public class Card : ICard
	{
		const int Spades = 0, Diamonds = 1, Hearts = 2, Clubs = 3;
		int value, shape;


		public Card (int theValue, int theShape)
		{
			value = theValue;
			shape = theShape;
		}

		public int getValue ()
		{
			return value;
		}

		public int getShape ()
		{
			return shape;
		}
	}
}

