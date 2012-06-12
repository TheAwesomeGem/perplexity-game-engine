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

            SceneManager.AddScene("Scene1", new Scene1(this));
        }
        protected override void LoadContent()
        {
            base.LoadContent();
        }
    }
}
