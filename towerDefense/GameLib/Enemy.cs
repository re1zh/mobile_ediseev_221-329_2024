namespace GameLib
{
    public class Enemy : GameObject
    {
        public int Health { get; set; }
        public int Speed { get; set; }
        private List<(int row, int col)> Path { get; set; } = new List<(int row, int col)>();
        private int CurrentPathIndex { get; set; } = 0;
        public bool HasReachedEnd { get; private set; } = false;

        public Enemy(int x, int y, int health, int speed)
        {
            X = x;
            Y = y;
            Health = health;
            Speed = speed;
        }

        public void SetPath(List<(int row, int col)> path)
        {
            Path = path;
            CurrentPathIndex = 0;
        }

        public override void Update()
        {
            if (CurrentPathIndex >= Path.Count)
            {
                HasReachedEnd = true;
                IsActive = false;
                return;
            }

            var targetCell = Path[CurrentPathIndex];
            int targetX = targetCell.col * 45;
            int targetY = targetCell.row * 45;

            double deltaX = targetX - X;
            double deltaY = targetY - Y;
            double distance = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);

            if (distance < Speed)
            {
                X = targetX;
                Y = targetY;
                CurrentPathIndex++;
            }
            else
            {
                X += (int)(Speed * deltaX / distance);
                Y += (int)(Speed * deltaY / distance);
            }
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health <= 0)
            {
                IsActive = false;
            }
        }
    }
}
