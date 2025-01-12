namespace GameLib
{
    public enum EnemyType
    {
        Grunt,
        Tank,
        Runner
    }

    public class Enemy : GameObject
    {
        private int _health;
        private int _maxHealth;
        private int _speed;
        private EnemyType _enemyType;
        private int _reward;

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
            set => _speed = value;
        }

        public EnemyType Type => _enemyType;

        public int Reward => _reward;

        public bool HasReachedEnd
        {
            get => _hasReachedEnd;
            private set => _hasReachedEnd = value;
        }

        public Enemy(int x, int y, int health, int speed, EnemyType type)
        {
            X = x;
            Y = y;
            Health = health;
            MaxHealth = health;
            Speed = speed;
            _enemyType = type;

            _reward = type switch
            {
                EnemyType.Grunt => 5,
                EnemyType.Tank => 15,
                EnemyType.Runner => 10,
                _ => 5
            };
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
                    gameManager.RewardForEnemyKill(this);
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
