using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Perplexity.Helper;

namespace Perplexity.Entity
{
    public class Entity : Sprite 
    {
        public Entity(Texture2D texture, Vector2 position)
            : base(texture, position)
        {
        }

        public override void Update()
        {
            base.Update();
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

    }
}
