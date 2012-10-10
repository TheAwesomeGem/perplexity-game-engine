using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Perplexity.Component;

namespace Perplexity.Entity
{
    public class Actor : Entity
    {
        public Rectangle Source { get { return source; } set { source = value; } }
        public Vector2 Position { get { return position; } }

        public event NotifyHandler PositionChange;

        public Actor(Scene scene, Texture2D texture, Vector2 position, float layer)
            : base(scene, texture, position, layer)
        {
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        public void Transform(Vector2 position)
        {
            if(CurrentState == State.Active || CurrentState == State.Hidden)
                this.position = position;

            if (PositionChange != null) PositionChange(this);
        }
        public void Translate(Vector2 newPosition)
        {
            if (CurrentState == State.Active || CurrentState == State.Hidden)
                this.position += newPosition;

            if (PositionChange != null) PositionChange(this);
        }
    }
}
