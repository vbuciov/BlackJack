using System;
using Blackjack.imp;
using System.Collections.Generic;
using Blackjack.api;
using System.Text;

namespace Blackjack.game
{
	public class Player
	{
		private IList<ICard> hand;
		private int points;
		private string name;
		private Boolean isIA, stay;

		public Player(string theName)
		{
			name = theName;
			hand = new List<ICard>();
			points = 0;
			isIA = false;
			stay = false;
		}

		public int CardsCount {
			get
			{
				return hand.Count;
			}
		}

		public int Points {
			get
			{
				return this.points;
			}
		}

		public string Name {
			get
			{
				return this.name;
			}
			set
			{
				name = value;
			}
		}

		public bool IsIA {
			get
			{
				return this.isIA;
			}
			set
			{
				isIA = value;
			}
		}

		public bool Stay {
			get
			{
				return this.stay;
			}
			set
			{
				stay = value;
			}
		}

		public void AddCard(ICard theNewCard)
		{
			hand.Add (theNewCard);
			this.points += theNewCard.getValue();
		}

		public string GetHand()
		{
			StringBuilder elements = new StringBuilder ();

			foreach (ICard element in hand)
			{
				if (elements.Length > 0)
					elements.Append(", ");
				elements.Append (element.getValue ());
			}

			return elements.ToString ();
		}

		public void releaseHand ()
		{
			hand.Clear ();
			points = 0;
			stay = false;
		}
	}
}