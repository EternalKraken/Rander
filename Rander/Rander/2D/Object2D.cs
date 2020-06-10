using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Rander._2D
{
    public class Object2D
    {
        public Vector2 Position;
        public Vector2 Size;
        public Color Color;
        public float Rotation;
        public List<Component2D> Components = new List<Component2D>();

        public Object2D(string objectName, Vector2 position, Vector2 size, float rotation, Color color)
        {
            Size = size;
            Color = color;
            Position = position;
            Rotation = rotation;
            MyGame.Objects2D.Add(objectName, this);
        }

        public Object2D(string objectName, Vector2 position, Vector2 size, float rotation, Color color, Component2D[] components)
        {
            Size = size;
            Color = color;
            Position = position;
            Rotation = rotation;

            foreach (Component2D com in components)
            {
                AddComponent(com);
            }

            MyGame.Objects2D.Add(objectName, this);
        }

        public virtual void Draw() {
            foreach (Component2D Com in Components)
            {
                Com.Draw();
            }
        }

        public Component2D AddComponent(Component2D component)
        {
            component.Parent = this;
            Components.Add(component);
            component.Start();
            return component;
        }

        public T GetComponent<T>()
        {
            Component2D Com = Components.Find(x => x is T);
            return (T)Convert.ChangeType(Com, typeof(T));
        }

        public void RemoveComponent<T>()
        {
            Component2D Com = Components.Find(x => x is T);
            Components.Remove(Com);
        }
    }
}