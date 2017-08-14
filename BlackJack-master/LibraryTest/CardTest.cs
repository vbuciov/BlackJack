
using System;
using Blackjack.imp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.imp
{
	[TestClass()]
	public class CardTest
	{

		[TestMethod()]
		public void TheCardConstructorWorks()
		{
			Card myTest = new Card (10, 1);

			Assert.IsTrue (myTest.getValue() == 10 && myTest.getShape() == 1);
		}

	}
}

