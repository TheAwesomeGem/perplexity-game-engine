using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Perplexity.Entity
{
    public static class ActorManager
    {
        private static List<Actor> actors = new List<Actor>(50);

        public static void AddActor(Actor actor)
        {
            actors.Add(actor);
        }
        public static void RemoveActor(Actor actor)
        {
            actors.Remove(actor);
        }
        public static int CountActor()
        {
            return actors.Count;
        }

        public static void OnUpdate(GameTime gameTime)
        {
            for (int i = actors.Count - 1; i >= 0; i--)
                actors[i].OnUpdate(gameTime);
        }
        public static void OnDraw(SpriteBatch spriteBatch)
        {
            for (int i = actors.Count - 1; i >= 0; i--)
                actors[i].OnDraw(spriteBatch);
        }
    }
}
