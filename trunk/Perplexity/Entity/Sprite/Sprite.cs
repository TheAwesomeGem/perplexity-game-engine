using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Perplexity.Entity
{
    public class Sprite
    {
        #region Enum

        #endregion


        #region Field

        //Protected
        protected Texture2D texture;
        protected Vector2 position;
        protected Rectangle rectangle;
        protected Rectangle sourceRectangle;
        protected Vector2 origin;
        protected float rotation;

        #endregion


        #region Property

        #endregion


        public Sprite(Texture2D texture, Vector2 position, float rotation = 0f)
        {
            this.texture = texture;
            this.position = position;
            this.rotation = rotation;
            this.rectangle = new Rectangle((int)position.X, (int)position.Y, (int)texture.Width, (int)texture.Height);
            this.origin = new Vector2(texture.Width / 2, texture.Height / 2);
            
            SpriteManager.sprites.Add(this);
        }


        #region Method

        #endregion


        #region Event

        public virtual void OnDraw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, sourceRectangle, Color.White, rotation, origin, 1f, SpriteEffects.None, 0);
        }

        public virtual void OnUpdate(GameTime gameTime)
        {
            this.rectangle = new Rectangle((int)position.X, (int)position.Y, (int)texture.Width, (int)texture.Height);
            this.origin = new Vector2(texture.Width / 2, texture.Height / 2);
        }

        #endregion
    }
}
