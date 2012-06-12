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
            Actor guy = new Actor(this, game.Content.Load<Texture2D>("player"), new Vector2(300, 300), 0);
            EntityManager.AddEntity("Guy", guy);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
