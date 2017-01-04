using System;

namespace cgc_compiler
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            GameWorld gameWorld = new GameWorld();

            gameWorld.GameObjects.Add(new Knight(gameWorld, Player.RightPlayer, 10));
//            gameWorld.GameObjects.Add(new Knight(gameWorld, Player.RightPlayer, 9));
//            gameWorld.GameObjects.Add(new Knight(gameWorld, Player.LeftPlayer, 8));

            for (int i = 0; i < 200; i++)
            {
                gameWorld.Update(0.1f);
            }

            gameWorld.GameObjects.Add(new Forge(gameWorld, Player.LeftPlayer, 0));

            for (int i = 0; i < 200; i++)
            {
                gameWorld.Update(0.1f);
            }
        }
    }
}
