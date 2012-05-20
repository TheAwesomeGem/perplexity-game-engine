using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Perplexity.Entity
{
    public class Actor : Sprite
    {
        public Actor(Texture2D texture, Vector2 position)
            : base(texture, position)
        {
 
        }

        public bool IsColidingWith(Actor actor)
        {
            return rectangle.Intersects(actor.rectangle);
        }
    }
}
