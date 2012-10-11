using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Perplexity.Helper;
using System;

namespace Perplexity.Entity
{
    public abstract class Entity : Sprite 
    {
        public Scene Scene { get; set; }
        public event NotifyHandler Init;

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

            if (Init != null) Init(this);
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

        public void Dispose()
        {
            texture.Dispose();
        }
        public bool Intersect(Entity entity)
        {
            return this.bounds.Intersects(entity.bounds);
        }
        public bool IntersectPixels(Entity entity)
        {
            int top = Math.Max(this.bounds.Top, entity.bounds.Top);
            int bottom = Math.Min(this.bounds.Bottom, entity.bounds.Bottom);
            int left = Math.Max(this.bounds.Left, entity.bounds.Left);
            int right = Math.Min(this.bounds.Right, entity.bounds.Right);

            for (int y = top; y < bottom; y++) for (int x = left; x < right; x++)
            {
                Color col1 = this.texDat[(x - this.bounds.Left) + (y - this.bounds.Top) * this.bounds.Width];
                Color col2 = entity.texDat[(x - entity.bounds.Left) + (y - entity.bounds.Top) * entity.bounds.Width];

                if (col1.A != 0 && col2.A != 0) return true;
            }

            return false;
        }
    }
}
