namespace GameLib
{
    public abstract class GameObject
    {
        private int _x;
        private int _y;
        private bool _isActive = true;

        public int X
        {
            get => _x;
            protected set => _x = value;
        }

        public int Y
        {
            get => _y;
            protected set => _y = value;
        }

        public bool IsActive
        {
            get => _isActive;
            protected set => _isActive = value;
        }

        public virtual void Update() { }
    }
}
