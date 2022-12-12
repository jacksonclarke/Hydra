using Unit05.Game.Casting;
using Unit05.Game.Services;
using System;
using System.Collections.Generic;


namespace Unit05.Game.Scripting
{
    /// <summary>
    /// <para>An input action that controls the snake.</para>
    /// <para>
    /// The responsibility of ControlActorsAction is to get the direction and move the snake's head.
    /// </para>
    /// </summary>
    public class ControlActorsAction : Action
    {
        private KeyboardService _keyboardService;
        private Point _direction = new Point(Constants.CELL_SIZE, 0);

        /// <summary>
        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        /// </summary>
        public ControlActorsAction(KeyboardService keyboardService)
        {
            this._keyboardService = keyboardService;
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            // left
            if (_keyboardService.IsKeyDown("a"))
            {
                _direction = new Point(-Constants.CELL_SIZE, 0);
            }

            // right
            if (_keyboardService.IsKeyDown("d"))
            {
                _direction = new Point(Constants.CELL_SIZE, 0);
            }

            // up
            if (_keyboardService.IsKeyDown("w"))
            {
                _direction = new Point(0, -Constants.CELL_SIZE);
            }

            // down
            if (_keyboardService.IsKeyDown("s"))
            {
                _direction = new Point(0, Constants.CELL_SIZE);
            }

            PlaySnake snake = (PlaySnake)cast.GetFirstActor("snake");
            snake.TurnHead(_direction);
            List<Actor> snakeBots = cast.GetActors("snakebots");
            foreach(Snake snakeBot in snakeBots){
                Random rand = new Random();
                int randDir = rand.Next(1,4);
                if ((snakeBot.GetHead().GetPosition().GetX()).Equals(255)){
                    if (randDir == 2){
                        snakeBot.TurnHead(new Point(Constants.CELL_SIZE,0));
                    }else if (randDir == 1){
                        snakeBot.TurnHead(new Point(Constants.CELL_SIZE,-Constants.CELL_SIZE));
                    }else{
                        snakeBot.TurnHead(_direction);
                    }
                } else if ((snakeBot.GetHead().GetPosition().GetX()).Equals(450)){
                    if (randDir == 1){
                        snakeBot.TurnHead(_direction);
                    }else if (randDir == 4){
                        snakeBot.TurnHead(new Point(Constants.CELL_SIZE,-Constants.CELL_SIZE));
                    }else{
                        snakeBot.TurnHead(new Point(Constants.CELL_SIZE,Constants.CELL_SIZE));
                    }
                } else if ((snakeBot.GetHead().GetPosition().GetX()).Equals(795)){
                    if (randDir == 2){
                        snakeBot.TurnHead(new Point(0, -Constants.CELL_SIZE));
                    }else if (randDir == 3){
                        snakeBot.TurnHead(_direction);
                    }else{
                        snakeBot.TurnHead(new Point(Constants.CELL_SIZE, -Constants.CELL_SIZE));
                    }
                }
            }
        }
    }
}