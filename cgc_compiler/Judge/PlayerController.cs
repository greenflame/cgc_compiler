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

		public PlayerController (GameWorld gameWorld, Player player)
		{
			GameWorld = gameWorld;
			Player = player;

			ManaController = new ManaController ();
			CardQueueController = new CardQueueController ();

			GameWorld.EventLogger.InventoryUpdate(this);
		}

		private void SpawnTroop(CardType card, float position)
		{
			if (!IsPositionAvailable(position))
			{
				throw new Exception ("Invalid positioin");
			}

			if (!CardQueueController.IsCardAvailable(card))
			{
				throw new Exception ("Card is not availible");
			}

			if (Player == Player.Right)
			{
				position = GameWorld.InvertPosition (position);
			}

			switch (card)
			{
			case CardType.Archer:
				ManaController.Consume (4);
				GameWorld.GameObjects.Add (new Archer (GameWorld, Player, position));
				break;
			case CardType.Crusader:
				ManaController.Consume (4);
				GameWorld.GameObjects.Add (new Crusader (GameWorld, Player, position));
				break;
			case CardType.Elemental:
				ManaController.Consume (5);
				GameWorld.GameObjects.Add (new Elemental (GameWorld, Player, position));
				break;
			case CardType.Gogs:
				ManaController.Consume (2);
				GameWorld.GameObjects.Add (new Gog (GameWorld, Player, position - Configuration.SpawnDispersion));
				GameWorld.GameObjects.Add (new Gog (GameWorld, Player, position));
				GameWorld.GameObjects.Add (new Gog (GameWorld, Player, position + Configuration.SpawnDispersion));
				break;
			case CardType.Halberdier:
				ManaController.Consume (4);
				GameWorld.GameObjects.Add (new Halberdier (GameWorld, Player, position));
				break;
			case CardType.Halfling:
				ManaController.Consume (3);
				GameWorld.GameObjects.Add (new Halfling (GameWorld, Player, position));
				break;
			case CardType.Peasant:
				ManaController.Consume (3);
				GameWorld.GameObjects.Add (new Peasant (GameWorld, Player, position));
				break;
			case CardType.Sharpshooters:
				ManaController.Consume (3);
				GameWorld.GameObjects.Add (new Sharpshooter (GameWorld, Player, position - Configuration.SpawnDispersion / 2f));
				GameWorld.GameObjects.Add (new Sharpshooter (GameWorld, Player, position + Configuration.SpawnDispersion / 2f));
				break;
			case CardType.Skeletons:
				ManaController.Consume (2);
				GameWorld.GameObjects.Add (new Skeleton (GameWorld, Player, position - Configuration.SpawnDispersion));
				GameWorld.GameObjects.Add (new Skeleton (GameWorld, Player, position));
				GameWorld.GameObjects.Add (new Skeleton (GameWorld, Player, position + Configuration.SpawnDispersion));
				break;
			}

			CardQueueController.RemoveCard (card);
		}

		private bool IsPositionAvailable(float position)
		{
			if (Metrics.Less(position, 0))
			{
				return false;
			}

			if (Metrics.LessOrEquals(position, Configuration.MaxSpawnPosFirstPhase))
			{
				return true;
			}

			bool enemyTowerExists = GameWorld.GameObjects
				.Where (o => o is Tower)
				.Where (o => o.Owner != Player)
				.Count () > 0;

			if (!enemyTowerExists && Metrics.LessOrEquals(position, Configuration.MaxSpawnPosSecondPhase))
			{
				return true;
			}

			return false;
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

			return input.ToString ();
		}

		public void ProcessOutput(string output, Action<string> executionLogger)
		{
			output
                .Replace(",", ".")
				.Split (new String[] { Environment.NewLine }, StringSplitOptions.None)
				.ToList ()
				.ForEach (command => {

					if (string.IsNullOrEmpty(command))
					{
						return;
					}

					executionLogger(string.Format("Processing command: {0}", command));

					List<string> parameters = command.Split(' ').ToList();

					if (parameters.Count < 2)
					{
						executionLogger("Invalid parameters length");
						return;
					}

					CardType card;
					try
					{
						card = (CardType)Enum.Parse(typeof(CardType), parameters[0]);
					}
					catch
					{
						executionLogger("Cann't parse card type");
						return;
					}

					float position;
					if (!float.TryParse (parameters [1], out position))
					{
						executionLogger("Cann't parse spawn position");
						return;
					}

					try 
					{
						SpawnTroop (card, position);
						executionLogger("Successfull");
					}
					catch (Exception ex)
					{
						executionLogger(ex.Message);
					}
				});

			if (CardQueueController.GenerateCardQueue())
			{
				GameWorld.EventLogger.InventoryUpdate(this);
			}
		}
	}
}
