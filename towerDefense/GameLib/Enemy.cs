namespace GameLib
{
    public class Enemy : GameObject
    {
        public int Health { get; set; }
        public int Speed { get; set; }
        private List<(int row, int col)> Path { get; set; } = new List<(int row, int col)>();
        private int CurrentPathIndex { get; set; } = 0;

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
            CurrentPathIndex = 0; // Сбрасываем индекс в начало пути
        }

        public override void Update()
        {
            if (CurrentPathIndex >= Path.Count)
            {
                IsActive = false; // Враг завершил путь
                return;
            }

            // Целевая клетка на пути
            var targetCell = Path[CurrentPathIndex];
            int targetX = targetCell.col * 45; // 45 — размер клетки
            int targetY = targetCell.row * 45;

            // Вычисляем расстояние до цели
            double deltaX = targetX - X;
            double deltaY = targetY - Y;
            double distance = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);

            // Если достигли цели, переключаемся на следующую точку
            if (distance < Speed)
            {
                X = targetX;
                Y = targetY;
                CurrentPathIndex++;
            }
            else
            {
                // Движение в направлении цели
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
