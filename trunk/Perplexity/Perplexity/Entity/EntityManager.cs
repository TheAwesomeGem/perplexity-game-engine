using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Perplexity.Entity
{
    public static class EntityManager
    {
        private static Dictionary<string, Entity> entities = new Dictionary<string, Entity>();

        public static void AddEntity(string name, Entity entity)
        {
            if (!entities.ContainsKey(name))
                entities.Add(name, entity);
            else
                throw new Exception("The entity " + name + " already exist on the memory.");
        }
        public static void RemoveEntity(string name)
        {
            if (entities.ContainsKey(name))
                entities.Remove(name);
            else
                throw new Exception("Invalid entity name.");
        }
        public static T GetEntity<T>(string name)
        {
            Entity value = null;

            if (entities.ContainsKey(name))
                entities.TryGetValue(name, out value);
            else
                throw new Exception("Invalid entity name.");

            return (T)(object)value;
        }

        public static void Update(GameTime gameTime)
        {
            foreach (KeyValuePair<string, Entity> entity in entities)
            {
                Entity curEntity = entity.Value;
                curEntity.Update(gameTime);
            }
        }
        public static void Draw(SpriteBatch spriteBatch)
        {
            foreach (KeyValuePair<string, Entity> entity in entities)
            {
                Entity curEntity = entity.Value;
                curEntity.Draw(spriteBatch);
            }
        }
    }
}
