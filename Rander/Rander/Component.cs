namespace Rander
{
    public class Component
    {
        public GameObject Parent;

        public virtual void Start() { }
        public virtual void Update() { }
        public virtual void Draw() { }
    }
}
