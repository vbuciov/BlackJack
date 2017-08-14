using System;

namespace Blackjack.api
{
	public interface IDeck
	{
		ICard getNextCard ();
		void Shuffle();
	}
}

