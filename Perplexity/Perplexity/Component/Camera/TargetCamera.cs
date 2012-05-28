using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Perplexity.Component
{
    public class TargetCamera : Camera
    {
        public Vector2 target;
        
        public TargetCamera(Vector2 target)
            : base()
        {
            this.target = target;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            float delta = (float)gameTime.ElapsedGameTime.TotalSeconds;

            position.X += (target.X - position.X) * speed * delta;
            position.Y += (target.Y - position.Y) * speed * delta;
        }
    }
}
