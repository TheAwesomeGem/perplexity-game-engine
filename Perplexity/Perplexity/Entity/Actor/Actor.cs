using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Perplexity.Entity
{
    public class Actor : Entity
    {
        public enum State
        {
            Alive,
            Hidden,
            Dead
        }

        public Vector2 Velocity;
        public State CurrentState { get; set; }

        public Actor(Texture2D texture, Vector2 position)
            : base(texture, position)
        {
            Velocity = Vector2.Zero;
            CurrentState = State.Alive;
        }

        public override void Update()
        {
            if (CurrentState == State.Alive || CurrentState == State.Hidden)
            {
                position += Velocity;

                Velocity = Vector2.Zero;

                base.Update();
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (CurrentState == State.Alive)
            {
                base.Draw(spriteBatch);
            }
        }
    }
}
