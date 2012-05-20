using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Perplexity.Component
{
    public abstract class Camera
    {
        protected Matrix transform;
        public Vector2 position;
        protected float rotation;
        protected float zoom;

        public Camera()
        {
            position = Vector2.Zero;
            rotation = 0.0f;
            zoom = 1.0f;
        }

        public void Move(Vector2 translate)
        {
            position += translate;
        }

        public virtual void OnUpdate(GraphicsDevice graphics, GameTime gameTime)
        {
            Vector2 ScreenCenter = new Vector2(graphics.Viewport.Width / 2, graphics.Viewport.Height / 2);

            transform = Matrix.CreateTranslation(new Vector3(-position.X, -position.Y, 0)) *
                        Matrix.CreateRotationZ(rotation) *
                        Matrix.CreateScale(new Vector3(zoom, zoom, zoom)) *
                        Matrix.CreateTranslation(new Vector3(ScreenCenter.X / zoom, ScreenCenter.Y / zoom, 0))
            ;

        }
    }
}
