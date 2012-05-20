using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Perplexity.Component
{
    public class CameraManager : Camera
    {
        public Vector2 target;
        private float speed;

        public Matrix Transform { get { return transform; } }

        public CameraManager(Vector2 target, float speed)
            :base()
        {
            this.target = target;
            this.speed = speed;
        }

        public override void OnUpdate(GraphicsDevice graphics, GameTime gameTime)
        {
            base.OnUpdate(graphics, gameTime);

            var delta = (float)gameTime.ElapsedGameTime.TotalSeconds;

            position.X += (target.X - position.X) * speed * delta;
            position.Y += (target.Y - position.Y) * speed * delta;
        }
    }
}
