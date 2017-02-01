using System;

namespace cgc_compiler
{
	public class ManaController
	{
		public float CurrentMana { get; private set; }

		public ManaController ()
		{
			CurrentMana = Configuration.InitialMana;
		}

		public void Produce(float deltaTime)
		{
			CurrentMana = Math.Min(Configuration.MaxMana, CurrentMana + Configuration.ManaProductionSpeed * deltaTime);
		}

		public bool HaveEnouth(float mana)
		{
			return CurrentMana >= mana;
		}

		public void Consume(float mana)
		{
			if (HaveEnouth (mana))
			{
				CurrentMana -= mana;
			}
			else
			{
				throw new Exception ("Not enouth mana");
			}
		}
	}
}

