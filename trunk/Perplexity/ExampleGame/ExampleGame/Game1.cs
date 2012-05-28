using Perplexity;
using Perplexity.Entity;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ExampleGame
{
    public class Game1 : Engine
    {
        private KeyboardState n;
        private KeyboardState o;

        protected override void Initialize()
        {
            ScreenTitle = "Example Game";

            base.Initialize();
        }
        protected override void LoadContent()
        {
            base.LoadContent();

            EntityManager.AddEntity("Background", new Image(Content.Load<Texture2D>("background"), new Vector2(300,300)));
            EntityManager.AddEntity("Player", new Actor(Content.Load<Texture2D>("player"), new Vector2(300, 300)));
        }

        protected override void Update(GameTime gameTime)
        {
            n = Keyboard.GetState();

            if (n.IsKeyDown(Keys.Left))
                EntityManager.GetEntity<Actor>("Player").Velocity.X = -3;

            if (n.IsKeyDown(Keys.Right))
                EntityManager.GetEntity<Actor>("Player").Velocity.X = 3;

            if (n.IsKeyDown(Keys.A))
                EntityManager.GetEntity<Actor>("Player").Velocity.X = 50;

            o = n;

            base.Update(gameTime);
        }
    }
}
