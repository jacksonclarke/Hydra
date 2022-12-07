using System;
using System.Collections.Generic;
using System.Data;
using Unit05.Game.Casting;
using Unit05.Game.Services;


namespace Unit05.Game.Scripting
{
    /// <summary>
    /// <para>An update action that handles interactions between the actors.</para>
    /// <para>
    /// The responsibility of HandleCollisionsAction is to handle the situation when the snake 
    /// collides with the food, or the snake collides with its segments, or the game is over.
    /// </para>
    /// </summary>
    public class HandleCollisionsAction : Action
    {
        private bool _isGameOver = false;

        /// <summary>
        /// Constructs a new instance of HandleCollisionsAction.
        /// </summary>
        public HandleCollisionsAction()
        {
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            if (_isGameOver == false)
            {
                HandleFoodCollisions(cast);
                HandleSegmentCollisions(cast);
                HandleGameOver(cast);
            }
        }

        /// <summary>
        /// Updates the score nd moves the food if the snake collides with it.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        private void HandleFoodCollisions(Cast cast)
        {
            Snake snake = (Snake)cast.GetFirstActor("snake");
            Score score = (Score)cast.GetFirstActor("score");
            List<Actor> foods = cast.GetActors("food");
            Point snakeHead = snake.GetHead().GetPosition();
            Point snakeRadi = snake.GetHead().GetPosition().Add(new Point(5,5));

            foreach(Food food in foods){
                if (DistanceFormula(snakeHead, food.GetPosition()) < DistanceFormula(snakeRadi, snakeHead))
                {
                    int points = food.GetPoints();
                    snake.GrowTail(points);
                    score.AddPoints(points);
                    // food.RemoveActor();
                }
            }
            
        }

        private double DistanceFormula(Point point1, Point point2){
            double dis = System.Math.Sqrt((point2.GetX() - point1.GetX())^2 + (point2.GetY()-point1.GetY())^2);
            return dis;
        }

        /// <summary>
        /// Sets the game over flag if the snake collides with one of its segments.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        private void HandleSegmentCollisions(Cast cast)
        {
            Snake snake = (Snake)cast.GetFirstActor("snake");
            Actor head = snake.GetHead();
            List<Actor> body = snake.GetBody();
            List<Actor> snakebots = cast.GetActors("snakebots");
            List<Actor> food = cast.GetActors("food");
            
            foreach (Snake snakebot in snakebots){
                List<Actor> botBody = snakebot.GetBody();
                foreach(Actor seg in body){
                    if(snakebot.GetHead().GetPosition().Equals(seg.GetPosition())){
                        cast.RemoveActor("snakebots", snakebot);
                        foreach(Actor botSeg in botBody){
                            cast.AddActor("food", new Food(botSeg.GetPosition()));
                            // botSeg.SetColor(Constants.WHITE);
                        }
                    }
                foreach(Actor botSeg in botBody){
                    if(head.GetPosition().Equals(botSeg.GetPosition())){
                        _isGameOver = true;
                    }
                }
                }
            }

            // foreach (Actor segment in body)
            // {
            //     if (segment.GetPosition().Equals(head.GetPosition()))
            //     {
            //     }
            // }
        }

        private void HandleGameOver(Cast cast)
        {
            if (_isGameOver == true)
            {
                Snake snake = (Snake)cast.GetFirstActor("snake");
                List<Actor> segments = snake.GetSegments();
                Food food = (Food)cast.GetFirstActor("food");

                // create a "game over" message
                int x = Constants.MAX_X / 2;
                int y = Constants.MAX_Y / 2;
                Point position = new Point(x, y);

                Actor message = new Actor();
                message.SetText("Game Over!");
                message.SetPosition(position);
                cast.AddActor("messages", message);

                // make everything white
                foreach (Actor segment in segments)
                {
                    segment.SetColor(Constants.WHITE);
                }
                
            }
        }

    }
}