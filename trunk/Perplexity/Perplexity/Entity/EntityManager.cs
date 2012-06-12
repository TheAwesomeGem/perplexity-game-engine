using System.Collections.Generic;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Perplexity.Entity
{
    public static class EntityManager
    {
        private static Dictionary<string, Entity> entities = new Dictionary<string, Entity>();

        public static Dictionary<string, Entity> Entities { get { return entities; } }

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
    }
}
