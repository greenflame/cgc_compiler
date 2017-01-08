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

//                    gameWorld.gameObjects.Add(new Sharpshooter(gameWorld, Player.RightPlayer, 10));
                    gameWorld.gameObjects.Add(new Peasant(gameWorld, Player.RightPlayer, 9));
//                    gameWorld.gameObjects.Add(new Sharpshooter(gameWorld, Player.RightPlayer, 8));
                    //            gameWorld.GameObjects.Add(new Knight(gameWorld, Player.LeftPlayer, 8));

                    for (int i = 0; i < 50; i++)
                    {
                        gameWorld.Update(0.1f);
                    }
                    gameWorld.gameObjects.Add(new Peasant(gameWorld, Player.LeftPlayer, 1));
//                    gameWorld.gameObjects.Add(new Peasant(gameWorld, Player.LeftPlayer, 2));

                    //            gameWorld.GameObjects.Add(new Forge(gameWorld, Player.LeftPlayer, 0));

                    for (int i = 0; i < 2000; i++)
                    {
                        gameWorld.Update(0.1f);
                    } 
                }
            }


        }
    }
}
