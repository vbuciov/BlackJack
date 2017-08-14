using System;
using System.Collections.Generic;
using Blackjack.api;
using System.Text;

namespace Blackjack.game
{
	public class BlackJack21
	{
		private const int INITIAL_HAND = 2;
		private const int MAX_POINTS = 21;
		private const int IA_MAX_VALUE = 17;

		IList<Player> players;
		IDeck deckOfGame;
		bool isRoundEnd;
		String theWinner;
		StringBuilder IAactions;

		public BlackJack21 ()
		{
			players = new List<Player> ();
			IAactions = new StringBuilder ();
			initGame ();
		}

		public void initGame (){
			isRoundEnd = false;
			theWinner = "There are no winner";
			IAactions.Clear ();
		}

		public void playAgain ()
		{
			initGame ();
			foreach (Player current in players)
			{
				current.releaseHand ();
				if (deckOfGame != null)
				{
					do
					{
						current.AddCard (deckOfGame.getNextCard ());
					} while (current.CardsCount < INITIAL_HAND);
				}
			}
		}

		public void resetGame ()
		{
			initGame ();
			foreach (Player current in players)
				current.releaseHand ();
		}

		public void AddPlayer (Player theNew)
		{
			players.Add (theNew);
		}

		public void Start (IDeck deckToUse)
		{
			deckOfGame = deckToUse;
			foreach (Player element in players)
			{
				do
				{
					element.AddCard (deckOfGame.getNextCard ());
				} while (element.CardsCount < INITIAL_HAND);
			}
		}

		public void PerfomEvaluation ()
		{
			isRoundEnd = true;
			int i = 0, bigger = 0;
			Player current;

			while (isRoundEnd && i < players.Count)
			{
				current = players [i++];
				isRoundEnd = current.Stay;

				if (isRoundEnd && current.Points > 0 && current.Points <= MAX_POINTS)
				{
					if ( current.Points == bigger)
						theWinner = "Is a draw game";
				
					else if (current.Points > bigger)
					{
						bigger = current.Points;
						theWinner = String.Format ("The Winner is {0}", current.Name);
					}
				}
			}
		}

		public bool isOver ()
		{
			return isRoundEnd;
		}

		public void AskHitOrStay ()
		{
			String answer;

			foreach (Player element in players)
			{
				if (!element.Stay)
				{
					if (element.IsIA)
					{
						
						element.Stay = element.Points >= IA_MAX_VALUE;
					} 

					else
					{
						Console.WriteLine (String.Format ("{0} Do you want another card (y/n)??", element.Name));
						do
						{
						answer = Console.ReadLine ().Trim();
							element.Stay = answer.ToLower () == "n";
							if (!element.Stay && answer.ToLower () != "y")
								Console.WriteLine("Please answer only with Y or N");

						}while (!element.Stay && answer.ToLower () != "y");
					}

					
					if (!element.Stay)
					{
						element.AddCard (deckOfGame.getNextCard ());
						element.Stay = element.Points > MAX_POINTS;
						if (!element.IsIA)
							Console.WriteLine (String.Format ("your total is: {0} and your hand {1}", element.Points, element.GetHand ()));
						else
							IAactions.Append (String.Format ("your total is: {0} and your hand {1} \n", element.Points, element.GetHand ()));
					}
				 }
			}

			PerfomEvaluation ();
		}

		public void ShowTitle ()
		{
			Console.WriteLine ("Welcome to Blackjack!");
		}

		public void ShowIAActions ()
		{
			Console.WriteLine ("--- Computer TURN");
			Console.WriteLine (IAactions.ToString ());
		}

		public void ShowPlayersHand (bool final = false)
		{
			foreach (Player current in players)
			{
				if (current.Points > MAX_POINTS)
					Console.WriteLine (String.Format ("{0} your exceed 21 due to your hand: {1} ", current.Name, current.GetHand()));
				else
					Console.WriteLine (String.Format ("{0} your {1} score is: {2} and your hand is: {3}", current.Name, final?"final":"", current.Points, current.GetHand ()));
			}
		}

		public String getTheWinner (){
			return theWinner;
		}
	}
}