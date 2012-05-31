using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Perplexity.Component
{
    public class Camera
    {
        private float rotation;
        private Vector2 origin;
        private float scale;
        private Vector2 centerScreen;
        private Matrix view;   
        private Vector2 position;

        public Matrix View { get { return view; } }

        public Camera()
        {
            position = Vector2.Zero;
            centerScreen = new Vector2(Engine.ScreenWidth / 2f, Engine.ScreenHeight / 2f);
            scale = 1;
        }

        public void Update(GameTime gameTime)
        {
            view = Matrix.Identity *
                    Matrix.CreateTranslation(-position.X, -position.Y, 0) *
                    Matrix.CreateRotationZ(rotation) *
                    Matrix.CreateTranslation(origin.X, origin.Y, 0) *
                    Matrix.CreateScale(scale);

            origin = centerScreen / scale;
        }
        public void Transform(Vector2 position)
        {
            this.position = position;
        }
        public void Translate(Vector2 newPosition)
        {
            this.position += newPosition;
        }
    }
}
