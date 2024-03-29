﻿using Unit05.Game.Casting;
using Unit05.Game.Directing;
using Unit05.Game.Scripting;
using Unit05.Game.Services;
using System;


namespace Unit05
{
    /// <summary>
    /// The program's entry point.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Starts the program using the given arguments.
        /// </summary>
        /// <param name="args">The given arguments.</param>
        static void Main(string[] args)
        {
            // create the cast
            Cast cast = new Cast();
            cast.AddActor("snake", new PlaySnake(new Point(150,135)));
            cast.AddActor("score", new Score());
            for (int i = 0; i < 20; i++){
                for (int x = 0; x <= 2; x++){
                    Random rand = new Random();
                    int randomNum = rand.Next(1,10);
                    cast.AddActor("food", new Food(new Point(i*45,i*randomNum*15)));
                    cast.AddActor("food", new Food(new Point(i*randomNum*30,i*15)));
                }
            }
            for (int i = 0; i <= 1; i++){
                Random rand = new Random();
                int randomNum = rand.Next(1,10);
                cast.AddActor("snakebots", new Snake(new Point(randomNum*i*45,i*30)));
                cast.AddActor("snakebots", new Snake(new Point(randomNum*30,randomNum*i*60)));
            }
            

            // create the services
            KeyboardService keyboardService = new KeyboardService();
            VideoService videoService = new VideoService(false);
           
            // create the script
            Script script = new Script();
            script.AddAction("input", new ControlActorsAction(keyboardService));
            script.AddAction("update", new MoveActorsAction());
            script.AddAction("update", new HandleCollisionsAction());
            script.AddAction("output", new DrawActorsAction(videoService));

            // start the game
            Director director = new Director(videoService);
            director.StartGame(cast, script);
        }
    }
}