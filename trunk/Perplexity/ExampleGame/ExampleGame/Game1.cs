using Perplexity;
using Perplexity.Entity;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ExampleGame
{
    public class Game1 : Engine
    {
        protected override void LoadContent()
        {
            base.LoadContent();

            EntityManager.AddEntity("Player", new Actor(Content.Load<Texture2D>("player"), new Vector2(300, 300)));
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                Actor player = EntityManager.GetEntity<Actor>("Player");
                player.Velocity.X = 3;
            }

            base.Update(gameTime);
        }
    }
}
