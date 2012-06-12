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
        public Scene1(Game game)
        {
            Actor guy = new Actor(this, game.Content.Load<Texture2D>("player"), new Vector2(10, 0), 1);
            EntityManager.AddEntity("Guy", guy);
            Show();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            Actor guy = EntityManager.GetEntity<Actor>("Guy");

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                guy.Translate(new Vector2(-2f, 0));

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
