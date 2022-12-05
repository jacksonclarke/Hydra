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

            Snake snake = (Snake)cast.GetFirstActor("snake");
            snake.TurnHead(_direction);
            List<Actor> snakeBots = cast.GetActors("snakebots");
            foreach(Snake snakeBot in snakeBots){
                if ((snakeBot.GetHead().GetPosition().GetX()).Equals(255)){
                    snakeBot.TurnHead(_direction);
                } else if ((snakeBot.GetHead().GetPosition().GetX()).Equals(465)){
                    snakeBot.TurnHead(_direction);
                } else if ((snakeBot.GetHead().GetPosition().GetX()).Equals(795)){
                    snakeBot.TurnHead(_direction);
                }else if ((snakeBot.GetHead().GetPosition().GetY()).Equals(255)){
                    snakeBot.TurnHead(_direction);
                } else if ((snakeBot.GetHead().GetPosition().GetY()).Equals(465)){
                    snakeBot.TurnHead(_direction);
                } else if ((snakeBot.GetHead().GetPosition().GetY()).Equals(795)){
                    snakeBot.TurnHead(_direction);
                }
            }



        }
    }
}