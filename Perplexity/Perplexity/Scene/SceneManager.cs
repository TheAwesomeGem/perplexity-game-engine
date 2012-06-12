using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;

namespace Perplexity
{
    public static class SceneManager
    {
        private static Dictionary<string, Scene> scenes = new Dictionary<string, Scene>();

        public static void AddScene(string name, Scene scene)
        {
            if (!scenes.ContainsKey(name))
                scenes.Add(name, scene);
            else
                throw new Exception("The scene " + name + " already exist on the memory.");
        }
        public static void RemoveScene(string name)
        {
            if (scenes.ContainsKey(name))
                scenes.Remove(name);
            else
                throw new Exception("Invalid scene name.");
        }
        public static T GetScene<T>(string name)
        {
            Scene value = null;

            if (scenes.ContainsKey(name))
                scenes.TryGetValue(name, out value);
            else
                throw new Exception("Invalid scene name.");

            return (T)(object)value;
        }
        public static void Update(GameTime gameTime)
        {
            foreach (KeyValuePair<string, Scene> scene in scenes)
            {
                Scene curScene = scene.Value;
                curScene.Update(gameTime);
            }
        }
        public static void Draw(SpriteBatch spriteBatch)
        {
            foreach (KeyValuePair<string, Scene> scene in scenes)
            {
                Scene curScene = scene.Value;
                curScene.Draw(spriteBatch);
            }
        }
    }
}
