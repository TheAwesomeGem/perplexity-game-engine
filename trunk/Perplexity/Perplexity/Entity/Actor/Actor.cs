using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Perplexity.Component;

namespace Perplexity.Entity
{
    public class Actor : Entity
    {
        public Vector2 Velocity;

        private TargetCamera camera;

        public Actor(Texture2D texture, Vector2 position)
            : base(texture, position)
        {
            Velocity = Vector2.Zero;

            camera = new TargetCamera(position);
        }

        public override void Update(GameTime gameTime)
        {
            camera.target = position;
            camera.Update(gameTime);

            position += Velocity;

            Velocity = Vector2.Zero;

            base.Update(gameTime);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, null, null, null, null, camera.Transform);

            base.Draw(spriteBatch);

            spriteBatch.End();
        }
    }
}
