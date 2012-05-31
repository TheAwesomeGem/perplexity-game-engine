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
        private Actor background;

        protected override void Initialize()
        {
            ScreenTitle = "Example Game";

            base.Initialize();
        }
        protected override void LoadContent()
        {
            base.LoadContent();

            EntityManager.AddEntity("Background", new Actor(Content.Load<Texture2D>("background"), new Vector2(0, 0), 0.1f));
            background = EntityManager.GetEntity<Actor>("Background");

            EntityManager.AddEntity("Player", new Actor(Content.Load<Texture2D>("playersheet"), new Vector2(0, 150), 0.0f)); // 25 x 35
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
                player.Translate(new Vector2(-3, 0));
                playerAnim.currentFrame.X = 9;
            }
            if (n.IsKeyDown(Keys.Right))
            {
                player.Translate(new Vector2(3, 0));
                playerAnim.currentFrame.X = 5;
            }
 
            o = n;

            Camera.Transform(new Vector2(player.Position.X, player.Position.Y - 120));

            base.Update(gameTime);
        }
    }
}
