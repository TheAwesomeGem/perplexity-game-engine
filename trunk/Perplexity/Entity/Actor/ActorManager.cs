using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Perplexity.Entity
{
    public static class ActorManager
    {
        #region Enum

        #endregion


        #region Field

        //Public
        public static List<Actor> actors = new List<Actor>();

        #endregion


        #region Property

        #endregion


        #region Method

        public static void Remove(Actor actor)
        {
            actors.Remove(actor);
        }

        #endregion


        #region Event

        public static void OnUpdate(GameTime gameTime)
        {
            foreach (Actor actor in actors)
                actor.OnUpdate(gameTime);
        }

        public static void OnDraw(SpriteBatch spriteBatch)
        {
            foreach (Actor actor in actors)
                actor.OnDraw(spriteBatch);
        }

        #endregion
    }
}
