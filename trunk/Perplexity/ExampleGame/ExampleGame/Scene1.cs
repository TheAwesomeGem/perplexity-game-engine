using Perplexity;
using Perplexity.Entity;
using Perplexity.Component;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ExampleGame
{
    public class Scene1 : Scene
    {
        Timer TestTimer;

        public Scene1(Game game)
        {
            TestTimer = new Timer();
            TestTimer.Fire += new NotifyHandler(TestTimer_Fire);

            Actor guy = new Actor(this, game.Content.Load<Texture2D>("player"), new Vector2(10, 0), 1);
            EntityManager.AddEntity("Guy", guy);
            Show();
        }

        void TestTimer_Fire()
        {
            EntityManager.GetEntity<Actor>("Guy").Translate(new Vector2(30, 0));
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            Actor guy = EntityManager.GetEntity<Actor>("Guy");

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                TestTimer.Start(5);

            if (guy.Position.X < 0)
            {
                this.Hide();
                SceneManager.GetScene("Scene2").Show();
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
