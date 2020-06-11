using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Rander._3D
{
    public class Object3D
    {
        public string ObjectName;
        public Vector3 Position;
        public Vector3 Rotation;
        public Vector3 Size;
        public List<Component3D> Components = new List<Component3D>();

        public Object3D(string objectName, Vector3 position, Vector3 size)
        {
            ObjectName = objectName;
            Position = position;
            Size = size;
            Game.Objects3D.Add(objectName, this);
        }

        public Object3D(string objectName, Vector3 position, Vector3 size, Component3D[] components)
        {
            ObjectName = objectName;
            Position = position;
            Size = size;

            foreach (Component3D com in components)
            {
                AddComponent(com);
            }

            Game.Objects3D.Add(objectName, this);
        }

        public virtual void Update()
        {
            foreach (Component3D Com in Components)
            {
                Com.Update();
            }
        }

        public virtual void Draw()
        {
            foreach (Component3D Com in Components)
            {
                Com.Draw();
            }
        }

        public Component3D AddComponent(Component3D component)
        {
            component.Parent = this;
            Components.Add(component);
            component.Start();
            return component;
        }

        public virtual T GetObjectType<T>()
        {
            return (T)Convert.ChangeType(this, typeof(T));
        }

        public virtual T GetComponent<T>()
        {
            Component3D Com = Components.Find(x => x is T);

            return (T)Convert.ChangeType(Com, typeof(T));
        }

        public virtual void RemoveComponent<T>()
        {
            Component3D Com = Components.Find(x => x is T);

            Components.Remove(Com);
        }
    }
}
