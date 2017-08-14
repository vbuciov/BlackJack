using System;
using Blackjack.game;
using Blackjack.imp;

namespace Blackjack
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			BlackJack21 newGame = new BlackJack21 (); 
			Player computer = new Player ("Computer");
			Player human;
			string answer = "n";
			bool print = true;

			computer.IsIA = true;
			Console.WriteLine("What's your name?");
			do
			{
				answer = Console.ReadLine ().Trim();
				if (answer.Length < 1)
					Console.WriteLine("You should write 1 character at least, what's your name?");
			} while (answer.Length < 1);

			human = new Player (answer.Trim());
			newGame.AddPlayer (computer);
			newGame.AddPlayer (human);

			newGame.Start (new UnlimitedDeck());
			newGame.ShowTitle ();
		
			do
			{
				if (!newGame.isOver())
				{
					newGame.ShowPlayersHand ();
					do
					{
						newGame.AskHitOrStay ();
					} while (!newGame.isOver());
				}

				if (print)
				{
					newGame.ShowIAActions();
					Console.WriteLine("-------------------------------");
					Console.WriteLine(newGame.getTheWinner ());
					newGame.ShowPlayersHand(true);
					Console.WriteLine("Would you like to play again? (Y) or (N)");
				}

				answer = Console.ReadLine().Trim().ToLower();

				if (answer == "y")
				{
					Console.Clear();
					newGame.playAgain();
					print = true;
				}

				else if (answer != "n")
				{
					Console.WriteLine("Please answer only with Y or N");
					print = false;
				}
			}while(answer != "n");
		}
	}
}