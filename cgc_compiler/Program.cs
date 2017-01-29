using System;
using System.IO;

namespace cgc_compiler
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            using (FileStream fs = File.Open("/Users/Alexander/Desktop/log1", FileMode.Create))
            {
                using (StreamWriter tw = new StreamWriter(fs))
                {
                    GameWorld gameWorld = new GameWorld(s => {
                        Console.WriteLine(s);
                        tw.WriteLine(s);
                    });

                    gameWorld.GameObjects.Add(new Halfling(gameWorld, Player.RightPlayer, 10));
                    gameWorld.GameObjects.Add(new Peasant(gameWorld, Player.RightPlayer, 9));

					//                    gameWorld.gameObjects.Add(new Sharpshooter(gameWorld, Player.RightPlayer, 8));
                    //            gameWorld.GameObjects.Add(new Knight(gameWorld, Player.LeftPlayer, 8));

                    for (int i = 0; i < 500; i++)
                    {
                        gameWorld.Update(0.01f);
                    }

					gameWorld.GameObjects.Add(new Tower(gameWorld, Player.LeftPlayer, 0));

//                    gameWorld.GameObjects.Add(new Peasant(gameWorld, Player.LeftPlayer, 1));
//                    gameWorld.GameObjects.Add(new Peasant(gameWorld, Player.LeftPlayer, 2));

					gameWorld.GameObjects.Add (new Gog (gameWorld, Player.LeftPlayer, 0));
					gameWorld.GameObjects.Add (new Gog (gameWorld, Player.LeftPlayer, 0.5f));
					gameWorld.GameObjects.Add (new Gog (gameWorld, Player.LeftPlayer, 1));

					gameWorld.GameObjects.Add (new Skeleton (gameWorld, Player.LeftPlayer, 2));
					gameWorld.GameObjects.Add (new Skeleton (gameWorld, Player.LeftPlayer, 2.5f));

                    for (int i = 0; i < 20000; i++)
                    {
                        gameWorld.Update(0.01f);
                    } 
                }
            }


        }
    }
}
