using Perplexity;
using Perplexity.Entity;
using Perplexity.Component;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ExampleGame
{
    public class Game1 : Engine
    {
        private KeyboardState n;
        private KeyboardState o;

        private AnimationFrame playerAnim;
        private Actor player;

        protected override void Initialize()
        {
            ScreenTitle = "Example Game";

            base.Initialize();
        }
        protected override void LoadContent()
        {
            base.LoadContent();

            EntityManager.AddEntity("Player", new Actor(Content.Load<Texture2D>("playersheet"), new Vector2(300,300))); // 25 x 35
            player = EntityManager.GetEntity<Actor>("Player");


            playerAnim = new AnimationFrame(new Point(4, 0), 25, 35);
        }

        protected override void Update(GameTime gameTime)
        {
            playerAnim.Update(gameTime);
            EntityManager.GetEntity<Actor>("Player").Source = playerAnim.Source;

            n = Keyboard.GetState();

            if (n.IsKeyDown(Keys.Left))
            {
                player.Velocity.X = -3;
                playerAnim.currentFrame.X = 9;
            }
            if (n.IsKeyDown(Keys.Right))
            {
                player.Velocity.X = 3;
                playerAnim.currentFrame.X = 5;
            }
 
            o = n;

            base.Update(gameTime);
        }
    }
}
