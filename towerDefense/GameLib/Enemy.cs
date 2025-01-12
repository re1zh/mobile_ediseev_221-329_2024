namespace GameLib
{
    public class Enemy : GameObject
    {
        private int _health;
        private int _maxHealth;
        private int _speed;
        private List<(int row, int col)> _path = new List<(int row, int col)>();
        private int _currentPathIndex = 0;
        private bool _hasReachedEnd = false;

        public int Health
        {
            get => _health;
            private set => _health = value;
        }

        public int MaxHealth
        {
            get => _maxHealth;
            private set => _maxHealth = value;
        }

        public int Speed
        {
            get => _speed;
            private set => _speed = value;
        }

        public bool HasReachedEnd
        {
            get => _hasReachedEnd;
            private set => _hasReachedEnd = value;
        }

        public Enemy(int x, int y, int health, int speed)
        {
            X = x;
            Y = y;
            Health = health;
            MaxHealth = health;
            Speed = speed;
        }

        public void SetPath(List<(int row, int col)> path)
        {
            _path = path;
            _currentPathIndex = 0;
        }

        public override void Update()
        {
            if (_currentPathIndex >= _path.Count)
            {
                HasReachedEnd = true;
                IsActive = false;
                return;
            }

            var targetCell = _path[_currentPathIndex];
            int targetX = targetCell.col * 45;
            int targetY = targetCell.row * 45;

            double deltaX = targetX - X;
            double deltaY = targetY - Y;
            double distance = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);

            if (distance < Speed)
            {
                X = targetX;
                Y = targetY;
                _currentPathIndex++;
            }
            else
            {
                X += (int)(Speed * deltaX / distance);
                Y += (int)(Speed * deltaY / distance);
            }
        }

        public void TakeDamage(int damage, GameManager gameManager)
        {
            Health -= damage;
            if (Health <= 0 && IsActive)
            {
                IsActive = false;
                try
                {
                    gameManager.RewardForEnemyKill();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Ошибка: {e.Message}");
                }
            }
        }

        public void IncreaseStats(int healthIncrement, int speedIncrement)
        {
            Health += healthIncrement;
            MaxHealth += healthIncrement;
            Speed += speedIncrement;
        }
    }
}
