using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Perplexity.Helper;

namespace Perplexity.Entity
{
    public abstract class Entity : Sprite 
    {
        public enum State
        {
            Active,
            Hidden,
            Destroyed
        }
        public State CurrentState { get; set; }

        public Entity(Texture2D texture, Vector2 position)
            : base(texture, position)
        {
            CurrentState = State.Active;
        }

        public override void Update(GameTime gameTime)
        {
            if (CurrentState == State.Active || CurrentState == State.Hidden)
                base.Update(gameTime);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (CurrentState == State.Active)
                base.Draw(spriteBatch);
        }

    }
}
