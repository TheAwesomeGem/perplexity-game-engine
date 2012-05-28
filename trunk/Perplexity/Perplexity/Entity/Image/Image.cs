using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Perplexity.Entity
{
    public class Image : Entity
    {
        public Image(Texture2D texture, Vector2 position)
            : base(texture, position)
        {
 
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            
            base.Draw(spriteBatch);

            spriteBatch.End();
        }
    }
}
