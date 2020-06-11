using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Rander._2D
{
    public class Object2D
    {
        public string ObjectName;
        public Vector2 Position;
        public Vector2 Size;
        public Color Color;
        float Rot;
        public float Rotation { get { return Rot; } set { foreach (Component2D com in Components) { com.SetAlign(com.Align); Rot = value; } } }
        public List<Component2D> Components = new List<Component2D>();
        public float Layer = 0;

        public Object2D(string objectName, Vector2 position, Vector2 size, float rotation, Color color)
        {
            Size = size;
            Color = color;
            Position = position;
            Rot = rotation;
            ObjectName = objectName;

            AfterCreate();
        }

        public Object2D(string objectName, Vector2 position, Vector2 size, float rotation, Color color, float layer)
        {
            Size = size;
            Color = color;
            Position = position;
            Rot = rotation;
            Layer = layer;
            ObjectName = objectName;

            AfterCreate();
        }

        public Object2D(string objectName, Vector2 position, Vector2 size, float rotation, Color color, Component2D[] components)
        {
            Size = size;
            Color = color;
            Position = position;
            Rot = rotation;

            foreach (Component2D com in components)
            {
                AddComponent(com);
            }

            ObjectName = objectName;

            AfterCreate();
        }

        public Object2D(string objectName, Vector2 position, Vector2 size, float rotation, Color color, float layer, Component2D[] components)
        {
            Size = size;
            Color = color;
            Position = position;
            Rot = rotation;

            foreach (Component2D com in components)
            {
                AddComponent(com);
            }

            Layer = layer;

            ObjectName = objectName;

            AfterCreate();
        }

        void AfterCreate()
        {
            if (ObjectName == "")
            {
                Debug.LogError("Object name can't be blank!", true, 3);
            }
            else if (Game.Objects2D.ContainsKey(ObjectName))
            {
                Debug.LogError("The 2DObject \"" + ObjectName + "\" already exists!", true, 3);
            }
            else
            {
                Game.Objects2D.Add(ObjectName, this);
            }
        }

        public virtual void Draw()
        {
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
            T Com = (T)Convert.ChangeType(Components.Find(x => x is T), typeof(T));

            if (Com != null)
            {
                return Com;
            }
            else
            {
                StackTrace stk = new StackTrace();
                Debug.LogError("2DObject \"" + ObjectName + "\" does not contain the component \"" + typeof(T).Name + "\"", true);
                return (T)Convert.ChangeType(null, typeof(T));
            }
        }

        public void RemoveComponent<T>()
        {
            Component2D Com = Components.Find(x => x is T);

            if (Com != null)
            {
                Components.Remove(Com);
            }
            else
            {
                Debug.LogError("2DObject \"" + ObjectName + "\" does not already contain the component \"" + typeof(T).Name + "\"");
            }
        }

        public void Destroy()
        {
            Game.Objects2D.Remove(ObjectName);
        }
    }
}