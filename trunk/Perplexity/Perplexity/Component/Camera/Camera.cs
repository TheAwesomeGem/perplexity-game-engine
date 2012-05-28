using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Perplexity.Component
{
    public class Camera
    {
        protected Vector2 position;
        protected float speed;
        protected float rotation;
        protected Vector2 origin;
        protected float scale;
        protected Vector2 centerScreen;
        protected Matrix transform;

        public Matrix Transform { get { return transform; } }

        public Camera()
        {
            centerScreen = new Vector2(Engine.ScreenWidth / 2, Engine.ScreenHeight / 2);
            scale = 1;
            speed = 1.25f;
        }

        public virtual void Update(GameTime gameTime)
        {
            transform = Matrix.Identity *
                    Matrix.CreateTranslation(-position.X, -position.Y, 0) *
                    Matrix.CreateRotationZ(rotation) *
                    Matrix.CreateTranslation(origin.X, origin.Y, 0) *
                    Matrix.CreateScale(scale);

            origin = centerScreen / scale;
        }

        public bool IsInView(Vector2 position, Texture2D texture)
        {
            if ((position.X + texture.Width) < (position.X - origin.X) || (position.X) > (position.X + origin.X))
                return false;

            if ((position.Y + texture.Height) < (position.Y - origin.Y) || (position.Y) > (position.Y + origin.Y))
                return false;

            return true;
        }
    }
}
