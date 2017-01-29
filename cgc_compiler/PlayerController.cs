using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace cgc_compiler
{
	public class PlayerController
	{
		public Player Player;
		public GameWorld GameWorld { get; private set; }

		public float Mana { get; private set; }
		public List<string> CardQueue { get; private set; }

		public PlayerController (GameWorld gameWorld, Player player)
		{
			GameWorld = gameWorld;
			Player = player;

			Mana = Configuration.InitialMana;
			GenerateCardQueue ();
		}

		public void ProduceMana(float deltaTime)
		{
			Mana = Math.Min(Configuration.MaxMana, Mana + Configuration.ManaProductionSpeed * deltaTime);
		}

		private void GenerateCardQueue()
		{
			for (int i = 0; i < Configuration.MaxCardQueueLength; i++)
			{
				CardQueue.Add ("Knight");
			}
		}

		private void SpawnTroop(string type, float position)
		{

		}

		public static Player InvertPlayer(Player player)
		{
			if (player == Player.Left)
			{
				return Player.Right;
			}
			else
			{
				return Player.Left;
			}
		}

		public string GenerateInput()
		{
			StringBuilder input = new StringBuilder ();

			input.AppendLine (Mana.ToString());

			CardQueue
				.Take(Configuration.VisibleCards)
				.ToList()
				.ForEach(i => input.AppendLine(i));

			bool invert = Player == Player.Right;

			List<string> gameObjects = GameWorld.GameObjects
				.Where (o => !(o is Projectile))
				.Select (o => {
					string type = o.GetType ().ToString ().Split ('.').Last ();
					Player owner = invert ? InvertPlayer (o.Owner) : o.Owner;
					float position = invert ? GameWorld.InvertPosition (o.Position) : o.Position;
					float health = (o as IDamagable).GetHealth().CurrentHealth;

					return string.Format ("{0} {1} {2} {3}", type, owner, position, health);
				})
				.ToList();

			input.AppendLine (gameObjects.Count.ToString());
			gameObjects.ForEach(i => input.AppendLine(i));

			return input.ToString ();
		}

		public void ProcessOutput(string output)
		{
			if (output == null)
			{
				throw new Exception ("Null output");
			}

			List<string> arguments = output.Split (" ").ToList ();

			if (arguments.Count != 2)
			{
				throw new Exception ("Arguments length not equals two");
			}

			string type = arguments [0];
			float position;
			if (!float.TryParse (arguments [1], out position))
			{
				throw new Exception ("Cann't parse position");
			}

			SpawnTroop (type, position);
		}
	}
}
