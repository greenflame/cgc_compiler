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

		public ManaController ManaController { get; private set; }
		public CardQueueController CardQueueController { get; private set; }

		private int CurrentAvailableCards { get; set; }

		public PlayerController (GameWorld gameWorld, Player player)
		{
			GameWorld = gameWorld;
			Player = player;

			ManaController = new ManaController ();
			CardQueueController = new CardQueueController ();
		}

		private void SpawnTroop(Card card, float position)
		{
			if (!Metrics.LessOrEquals(position, GameWorld.Length / 2))
			{
				throw new Exception ("Invalid positioin. You can spawn troops only in your half of game world.");
			}

			if (!CardQueueController.IsCardAvailable (card))
			{
				throw new Exception ("Card is not availible");
			}

			if (Player == Player.Right)
			{
				position = GameWorld.InvertPosition (position);
			}

			switch (card)
			{
			case Card.Archer:
				ManaController.Consume (4);
				GameWorld.GameObjects.Add (new Archer (GameWorld, Player, position));
				break;
			case Card.Crusader:
				ManaController.Consume (4);
				GameWorld.GameObjects.Add (new Crusader (GameWorld, Player, position));
				break;
			case Card.Elemental:
				ManaController.Consume (5);
				GameWorld.GameObjects.Add (new Elemental (GameWorld, Player, position));
				break;
			case Card.Gogs:
				ManaController.Consume (2);
				GameWorld.GameObjects.Add (new Gog (GameWorld, Player, position - 0.2f));
				GameWorld.GameObjects.Add (new Gog (GameWorld, Player, position));
				GameWorld.GameObjects.Add (new Gog (GameWorld, Player, position + 0.2f));
				break;
			case Card.Halebardier:
				ManaController.Consume (4);
				GameWorld.GameObjects.Add (new Halebardier (GameWorld, Player, position));
				break;
			case Card.Halfling:
				ManaController.Consume (3);
				GameWorld.GameObjects.Add (new Halfling (GameWorld, Player, position));
				break;
			case Card.Peasant:
				ManaController.Consume (3);
				GameWorld.GameObjects.Add (new Peasant (GameWorld, Player, position));
				break;
			case Card.Sharpshooters:
				ManaController.Consume (3);
				GameWorld.GameObjects.Add (new Sharpshooter (GameWorld, Player, position - 0.1f));
				GameWorld.GameObjects.Add (new Sharpshooter (GameWorld, Player, position + 0.1f));
				break;
			case Card.Skeletons:
				ManaController.Consume (2);
				GameWorld.GameObjects.Add (new Skeleton (GameWorld, Player, position - 0.2f));
				GameWorld.GameObjects.Add (new Skeleton (GameWorld, Player, position));
				GameWorld.GameObjects.Add (new Skeleton (GameWorld, Player, position + 0.2f));
				break;
			}

			CardQueueController.RemoveCard (card);
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

			input.AppendLine (ManaController.CurrentMana.ToString());

			// Todo next card
			CardQueueController.Queue
				.ForEach(i => input.AppendLine(i.ToString()));

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

//			Console.WriteLine (input.ToString());
			return input.ToString ();
		}

		public void ProcessOutput(string output, Action<string> executionLogger)
		{
			output
				.Split (new String[] { Environment.NewLine }, StringSplitOptions.None)
				.ToList ()
				.ForEach (l => {
					executionLogger(l);
					List<string> arguments = l.Split(' ').ToList();

					if (arguments.Count != 2)
					{
						executionLogger("Invalid arguments count (!= 2)");
						return;
					}

					Card card;
					try
					{
						card = (Card)Enum.Parse(typeof(Card), arguments[0]);
					}
					catch
					{
						executionLogger("Cann't parse first argument - card type");
						return;
					}

					float position;
					if (!float.TryParse (arguments [1], out position))
					{
						executionLogger("Cann't parse second argument - float position");
						return;
					}

					executionLogger(string.Format("tr: {0} cm: {1}", card, ManaController.CurrentMana));

					try 
					{
						SpawnTroop (card, position);
					}
					catch (Exception ex)
					{
						executionLogger(ex.Message);
					}
				});

			CardQueueController.GenerateCardQueue ();
		}
	}
}
