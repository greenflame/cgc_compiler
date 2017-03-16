using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using System.Globalization;
using System.Text.RegularExpressions;

namespace cgc_compiler
{
	public class Strategy
	{
        public string Name { get; private set; }
        public Player Player { get; private set; }
        public Executer Executer { get; private set; }
        public GameWorld GameWorld { get; private set; }

        public Strategy (Player player, string executionString)
		{
            Player = player;
            Executer = new Executer(executionString, Configuration.InputFile, Configuration.OutputFile);
            Name = ExtractStrategyName(executionString);
            GameWorld = Player.GameWorld;
        }

        private string ExtractStrategyName(string executionString)
        {
            string path = executionString.Split('|')[0];
            string name = Path.GetFileNameWithoutExtension(path);
            return name.Replace(" ", "_");
        }

        public string GenerateInput()
		{
            NumberFormatInfo numFormat = new NumberFormatInfo();
            numFormat.NumberDecimalSeparator = ".";

			StringBuilder input = new StringBuilder ();

			input.AppendLine (Player.ManaFlask.CurrentMana.ToString("0.0000", numFormat));

			Player.CardQueue.Queue
				.ForEach(i => input.AppendLine(i.ToString()));

			bool invert = Player == GameWorld.RightPlayer;

			List<string> gameObjects = GameWorld.GameObjects
				.Where (o => !(o is Projectile))
				.Select (o => {
					string type = o.GetType ().ToString ().Split ('.').Last ();
					Player owner = invert ? o.Owner.Opponent : o.Owner;
					float position = invert ? GameWorld.InvertPosition (o.Position) : o.Position;
					float health = (o as IDamagable).GetHealth().CurrentHealth;

					return string.Format ("{0} {1} {2} {3}",
                        type,
                        owner,
                        position.ToString("0.0000", numFormat),
                        (int)health);
				})
				.ToList();

			input.AppendLine (gameObjects.Count.ToString());
			gameObjects.ForEach(i => input.AppendLine(i));

			return input.ToString ();
		}

		public void ProcessOutput(string output, Action<string> executionLogger)
		{
            output = Regex.Replace(output, @"(\r|\n){2,}", "\n");   // Standartize endings

			output
				.Split ('\n')
                .Select(s => s.Trim())  // Trim
                .Select(s => Regex.Replace(s, @"[ ]{2,}", " ")) // Remove multiple spaces
                .Where(s => !string.IsNullOrEmpty(s))
				.ToList ()
				.ForEach (command =>
                {
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
                    bool parseRes = float.TryParse(
                        parameters[1].Replace(",", "."),
                        NumberStyles.Any,
                        CultureInfo.InvariantCulture,
                        out position);

                    if (!parseRes)
					{
						executionLogger("Cann't parse spawn position");
						return;
					}

					try 
					{
						Player.SpawnTroop(card, position);
						executionLogger("Successfull");
					}
					catch (Exception ex)
					{
						executionLogger(ex.Message);
					}
				});

			if (Player.CardQueue.GenerateCardQueue())
			{
				GameWorld.EventLogger.InventoryUpdate(Player);
			}
		}
	}
}
