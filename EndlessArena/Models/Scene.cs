using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndlessArena.Models
{
    class Scene
    {
        public static Scene Current { get; set; }

        static Scene()
        {
            Current = new Scene();
            Add(new Player());
        }
        public HashSet<GameObject> Objects { get; } = new HashSet<GameObject>();

        public static void Add(GameObject gameObject)
        {
            Current.AddInternal(gameObject);
        }

        public static void Destroy(GameObject gameObject)
        {
            Current.DestroyInternal(gameObject);
        }

        void AddInternal(GameObject gameObject)
        {
            Objects.Add(gameObject);
        }

        void DestroyInternal(GameObject gameObject)
        {
            Objects.Remove(gameObject);
        }
    }
}
