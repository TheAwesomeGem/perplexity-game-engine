using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Perplexity;
using Perplexity.Entity;

namespace ExampleGame
{
    public class Primary : Base
    {
        private Actor ball1;
        private Actor ball2;

        public Primary()
        {
            ScreenColor = Color.Black;  
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            ball1 = new Actor(Content.Load<Texture2D>(@"Images\ball"), new Vector2(0, 0), false);
            ball1.Position = new Vector2(ScreenWidth / 2, ScreenHeight - ball1.Size.Y);

            ball2 = new Actor(Content.Load<Texture2D>(@"Images\ball"), new Vector2(0, 0), false);
            ball2.Position = new Vector2((ScreenWidth / 2)+250, ScreenHeight - ball2.Size.Y);
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            InputManager.Start();

            if (InputManager.KeyHolding(Keys.Left))
                ball1.Position = new Vector2(ball1.Position.X - 5, ball1.Position.Y);

            if (InputManager.KeyHolding(Keys.Right))
                ball1.Position = new Vector2(ball1.Position.X + 5, ball1.Position.Y);

            if (InputManager.KeyHolding(Keys.A))
                ball2.Position = new Vector2(ball2.Position.X - 5, ball2.Position.Y);

            if (InputManager.KeyHolding(Keys.D))
                ball2.Position = new Vector2(ball2.Position.X + 5, ball2.Position.Y);

            InputManager.End();

            if(ball1.ColidingWith(ball2))
                ball1.Position = new Vector2(ScreenWidth / 2, ScreenHeight - ball1.Size.Y);
        }
    }
}
