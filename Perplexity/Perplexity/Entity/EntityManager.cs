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
        }
        public static void RemoveEntity(string name)
        {
            if (entities.ContainsKey(name))
                entities.Remove(name);
        }
        public static T GetEntity<T>(string name)
        {
            Entity value = null;

            if (entities.ContainsKey(name))
                entities.TryGetValue(name, out value);

            return (T)(object)value;
        }

        public static void Update()
        {
            foreach (KeyValuePair<string, Entity> entity in entities)
            {
                Entity curEntity = entity.Value;
                curEntity.Update();
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
