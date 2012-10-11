using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Perplexity.Helper
{
    public abstract class Sprite
    {
        protected Texture2D texture;
        protected Vector2 position;
        protected float rotation;
        protected float scale;
        protected Vector2 origin;
        protected Rectangle bounds;
        protected Rectangle source;
        protected float layer;
        protected Color[] texDat;

        public Sprite(Texture2D texture, Vector2 position, float rotation = 0f, float scale = 1f, float layer = 0f)
        {
            this.texture = texture;
            this.position = position;
            this.rotation = rotation;
            this.scale = scale;
            this.layer = layer;

            this.origin = new Vector2(texture.Width / 2, texture.Height / 2);
            this.bounds = new Rectangle((int)position.X, (int)position.Y,
                                        (int)texture.Width, (int)texture.Height);

            this.source = new Rectangle(0, 0, (int)texture.Width, (int)texture.Height);
            this.texDat = new Color[texture.Width * texture.Height];
            texture.GetData(texDat);
        }

        public virtual void Update(GameTime gameTime)
        {
            this.bounds = new Rectangle((int)position.X, (int)position.Y,
                                        (int)texture.Width, (int)texture.Height);

        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, source, Color.White, rotation, origin, scale, SpriteEffects.None, layer);
        }
    }
}
