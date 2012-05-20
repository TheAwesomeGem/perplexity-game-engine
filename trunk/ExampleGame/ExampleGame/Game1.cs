using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Perplexity;
using Perplexity.Entity;
using Perplexity.Component;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ExampleGame
{
    class Game1 : Base
    {
        Actor player;
        Actor enemy;

        protected override void LoadContent()
        {
            base.LoadContent();

            player = new Actor(Content.Load<Texture2D>(@"Images\Player"), new Vector2(200, 200));
            enemy = new Actor(Content.Load<Texture2D>(@"Images\Player"), new Vector2(250, 200));
            ActorManager.AddActor(player);
            ActorManager.AddActor(enemy);
            Camera = new CameraManager(player.position, 1.5f);
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            Camera.target = player.position;

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                if (player.IsColidingWith(enemy))
                {
                    if (enemy.position.X > player.position.X)
                        player.position.X -= 3;
                }
                else 
                {
                    player.position.X -= 3;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                if (player.IsColidingWith(enemy))
                {
                    if (enemy.position.X < player.position.X)
                        player.position.X += 3;
                }
                else
                {
                    player.position.X += 3;
                }
            }
        }
    }
}
