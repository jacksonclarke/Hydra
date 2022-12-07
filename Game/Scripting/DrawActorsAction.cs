using System.Collections.Generic;
using Unit05.Game.Casting;
using Unit05.Game.Services;


namespace Unit05.Game.Scripting
{
    /// <summary>
    /// <para>An output action that draws all the actors.</para>
    /// <para>The responsibility of DrawActorsAction is to draw each of the actors.</para>
    /// </summary>
    public class DrawActorsAction : Action
    {
        private VideoService _videoService;

        /// <summary>
        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        /// </summary>
        public DrawActorsAction(VideoService videoService)
        {
            this._videoService = videoService;
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            Snake snake = (Snake)cast.GetFirstActor("snake");
            List<Actor> segments = snake.GetSegments();
            List<Actor> snakeBots = cast.GetActors("snakebots");
            Actor score = cast.GetFirstActor("score");
            List<Actor> food = cast.GetActors("food");
            List<Actor> messages = cast.GetActors("messages");
            
            _videoService.ClearBuffer();
            foreach(Snake snakeBot in snakeBots){
                List<Actor> botSeg = snakeBot.GetSegments();
                _videoService.DrawActors(botSeg);
            }
            _videoService.DrawActors(segments);
            _videoService.DrawActor(score);
            foreach(Actor fItem in food ){
                _videoService.DrawActor(fItem);
            }
            _videoService.DrawActors(messages);
            _videoService.FlushBuffer();
        }
    }
}