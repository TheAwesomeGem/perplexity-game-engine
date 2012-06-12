using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Perplexity.Helper;

namespace Perplexity.Entity
{
    public abstract class Entity : Sprite 
    {
        public Scene Scene { get; set; }

        public enum State
        {
            Active,
            Hidden,
            Destroyed
        }
        public State CurrentState { get; set; }

        public Entity(Scene scene, Texture2D texture, Vector2 position, float layer)
            : base(texture, position, 0f, 1f, layer)
        {
            Scene = scene;
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
