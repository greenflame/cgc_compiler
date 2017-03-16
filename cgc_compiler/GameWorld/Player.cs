using System;
using System.Linq;

namespace cgc_compiler
{
    public class Player
    {
        public string Name { get; private set; }
        public GameWorld GameWorld { get; private set; }

        public ManaFlask ManaFlask { get;  private set; }
        public CardQueue CardQueue { get; private set; }

        public Player(GameWorld gameWorld, string name)
        {
            GameWorld = gameWorld;
            Name = name;

            ManaFlask = new ManaFlask();
            CardQueue = new CardQueue();

            GameWorld.EventLogger.InventoryUpdate(this);
        }

        public override string ToString() => Name;

        public float GetBuildingsHealth()
        {
            return GameWorld.GameObjects
                .Where(o => o is Turret)
                .Where(o => o.Owner == this)
                .Select(o => (o as IDamagable).GetHealth().CurrentHealth)
                .Sum();
        }

        public Player Opponent =>
            this == GameWorld.LeftPlayer ? GameWorld.RightPlayer : GameWorld.LeftPlayer;

        public void SpawnTroop(CardType card, float position)
        {
            if (!IsPositionAvailable(position))
            {
                throw new Exception("Invalid positioin");
            }

            if (!CardQueue.IsCardAvailable(card))
            {
                throw new Exception("Card is not availible");
            }

            if (this == GameWorld.RightPlayer)
            {
                position = GameWorld.InvertPosition(position);
            }

            switch (card)
            {
                case CardType.Archer:
                    ManaFlask.Consume(4);
                    GameWorld.GameObjects.Add(new Archer(GameWorld, this, position));
                    break;
                case CardType.Crusader:
                    ManaFlask.Consume(4);
                    GameWorld.GameObjects.Add(new Crusader(GameWorld, this, position));
                    break;
                case CardType.Elemental:
                    ManaFlask.Consume(5);
                    GameWorld.GameObjects.Add(new Elemental(GameWorld, this, position));
                    break;
                case CardType.Gogs:
                    ManaFlask.Consume(2);
                    GameWorld.GameObjects.Add(new Gog(GameWorld, this, position - Configuration.SpawnDispersion));
                    GameWorld.GameObjects.Add(new Gog(GameWorld, this, position));
                    GameWorld.GameObjects.Add(new Gog(GameWorld, this, position + Configuration.SpawnDispersion));
                    break;
                case CardType.Halberdier:
                    ManaFlask.Consume(4);
                    GameWorld.GameObjects.Add(new Halberdier(GameWorld, this, position));
                    break;
                case CardType.Halfling:
                    ManaFlask.Consume(3);
                    GameWorld.GameObjects.Add(new Halfling(GameWorld, this, position));
                    break;
                case CardType.Peasant:
                    ManaFlask.Consume(3);
                    GameWorld.GameObjects.Add(new Peasant(GameWorld, this, position));
                    break;
                case CardType.Sharpshooters:
                    ManaFlask.Consume(3);
                    GameWorld.GameObjects.Add(new Sharpshooter(GameWorld, this, position - Configuration.SpawnDispersion / 2f));
                    GameWorld.GameObjects.Add(new Sharpshooter(GameWorld, this, position + Configuration.SpawnDispersion / 2f));
                    break;
                case CardType.Skeletons:
                    ManaFlask.Consume(2);
                    GameWorld.GameObjects.Add(new Skeleton(GameWorld, this, position - Configuration.SpawnDispersion));
                    GameWorld.GameObjects.Add(new Skeleton(GameWorld, this, position));
                    GameWorld.GameObjects.Add(new Skeleton(GameWorld, this, position + Configuration.SpawnDispersion));
                    break;
            }

            CardQueue.RemoveCard(card);
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
                .Where(o => o is Tower)
                .Where(o => o.Owner != this)
                .Count() > 0;

            if (!enemyTowerExists && Metrics.LessOrEquals(position, Configuration.MaxSpawnPosSecondPhase))
            {
                return true;
            }

            return false;
        }

    }
}

