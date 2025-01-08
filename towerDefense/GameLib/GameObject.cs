namespace GameLib
{
    public abstract class GameObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsActive { get; set; } = true;

        public virtual void Update() { }
    }
}
