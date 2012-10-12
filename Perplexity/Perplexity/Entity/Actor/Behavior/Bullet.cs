using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Perplexity.Entity
{
    public class Bullet
    {
        private static int i = 0;

        public static void AddBehavior(Actor actor)
        {
            actor.Behavior = "Bullet";
        }
        public static void Update(GameTime gameTime)
        {
            foreach (KeyValuePair<string, Entity> entity in EntityManager.Entities)
            {
                Actor curEntity = (Actor)entity.Value;

                if (curEntity.Behavior == "Bullet")
                {
                    i+=5;
                    curEntity.Translate(new Vector2(i, 0));
                }
            }
        }
    }
}
