using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Perplexity.Entity
{
    public abstract class Sprite
    {
        protected Texture2D texture;
        public Vector2 position;
        protected float rotation;
        protected Rectangle rectangle;
        protected Vector2 origin;
        protected Rectangle sourceRectangle;

        public Sprite(Texture2D texture, Vector2 position, float rotation = 0.0f)
        {
            this.texture = texture;
            this.position = position;
            this.rotation = rotation;

            rectangle = new Rectangle((int)position.X, (int)position.Y, (int)texture.Width, (int)texture.Height);
            origin = new Vector2(texture.Width * 0.5f, texture.Height * 0.5f);
        }

        public virtual void OnUpdate(GameTime gameTime)
        {
            rectangle = new Rectangle((int)position.X, (int)position.Y, (int)texture.Width, (int)texture.Height);
        }
        public virtual void OnDraw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, null, Color.White, rotation, origin, 1f, SpriteEffects.None, 0);
        }
    }
}