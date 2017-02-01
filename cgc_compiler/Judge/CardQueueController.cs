﻿using System;
using System.Collections.Generic;

namespace cgc_compiler
{
	public class CardQueueController
	{
		public List<CardType> Queue { get; private set; }

		public CardQueueController ()
		{
			Queue = new List<CardType> ();
			GenerateCardQueue ();
		}

		public void GenerateCardQueue()
		{
			Random r = new Random ();

			for (int i = Queue.Count; i < Configuration.AvailableCards; i++)
			{
				Array values = Enum.GetValues (typeof(CardType));
				CardType card = (CardType)values.GetValue(r.Next (values.Length));
				Queue.Add (card);
			}
		}

		public bool IsCardAvailable(CardType card)
		{
			return Queue.Contains (card);
		}

		public void RemoveCard(CardType card)
		{
			if (!IsCardAvailable (card))
			{
				throw new Exception ("No such card to remove");
			}
			else
			{
				Queue.Remove (card);
			}
		}
	}
}