using System;
using System.Collections;
using System.Linq;
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

		public bool GenerateCardQueue()
		{
			Random r = new Random ();
			bool queueChanged = false;

			for (int i = Queue.Count; i < Configuration.AvailableCards; i++)
			{
				List<CardType> values = Enum.GetValues (typeof(CardType))
					.Cast<CardType>()
					.Where(c => !Queue.Contains(c))
					.ToList();
				
				CardType card = values[r.Next (values.Count)];
				Queue.Add (card);
				queueChanged = true;
			}

			return queueChanged;
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
