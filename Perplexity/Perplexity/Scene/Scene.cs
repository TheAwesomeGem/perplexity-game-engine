using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Perplexity
{
    public abstract class Scene
    {
        protected bool shown;

        public Scene()
        {
            shown = false;
        }

        public void Show()
        {
            shown = true;
        }
        public void Hide()
        {
            shown = false;
        }

        public virtual void Update(GameTime gameTime)
        {
            foreach (KeyValuePair<string, Entity.Entity> entity in Entity.EntityManager.Entities)
            {
                Entity.Entity curEntity = entity.Value;

                if (curEntity.Scene == this)
                {
                    if(shown)
                        curEntity.Update(gameTime);
                }
            }
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            foreach (KeyValuePair<string, Entity.Entity> entity in Entity.EntityManager.Entities)
            {
                Entity.Entity curEntity = entity.Value;

                if (curEntity.Scene == this)
                {
                    if(shown)
                        curEntity.Draw(spriteBatch);
                }
            }
        }
    } 
}
