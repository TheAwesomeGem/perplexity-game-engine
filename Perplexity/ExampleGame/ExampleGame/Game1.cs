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
        protected override void Initialize()
        {
            ScreenTitle = "Example Game";

            base.Initialize();
        }
        protected override void LoadContent()
        {
            base.LoadContent();

            SceneManager.AddScene("Scene1", new Scene1(this));
            SceneManager.AddScene("Scene2", new Scene2(this));
        }
    }
}
