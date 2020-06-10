using System;
using System.Collections.Generic;

namespace Rander
{
    public class GameObject
    {
        public List<Component> Components = new List<Component>();

        public virtual void Update()
        {
            foreach (Component Com in Components)
            {
                Com.Update();
            }
        }

        public Component AddComponent(Component component)
        {
            component.Parent = this;
            Components.Add(component);
            return component;
        }

        public virtual T GetObjectType<T>()
        {
            return (T)Convert.ChangeType(this, typeof(T));
        }

        public virtual T GetComponent<T>()
        {
            Component Com = Components.Find(x => x is T);

            return (T)Convert.ChangeType(Com, typeof(T));
        }

        public virtual void RemoveComponent<T>()
        {
            Component Com = Components.Find(x => x is T);

            Components.Remove(Com);
        }
    }
}
