namespace GameLib
{
    public class Projectile : GameObject
    {
        private int _speed;
        private int _damage;
        private Enemy _target;
        private GameManager _gameManager;

        public int Speed
        {
            get => _speed;
            private set => _speed = value;
        }

        public int Damage
        {
            get => _damage;
            private set => _damage = value;
        }

        public Enemy Target
        {
            get => _target;
            private set => _target = value;
        }

        public Projectile(int x, int y, int speed, int damage, Enemy target, GameManager gameManager)
        {
            X = x;
            Y = y;
            Speed = speed;
            Damage = damage;
            Target = target;
            _gameManager = gameManager;
        }

        public override void Update()
        {
            if (Target == null || !Target.IsActive)
            {
                IsActive = false;
                return;
            }

            int enemyWidth = 45;
            int enemyHeight = 45;

            double targetX = Target.X + enemyWidth / 2.0;
            double targetY = Target.Y + enemyHeight / 2.0;

            double deltaX = targetX - X;
            double deltaY = targetY - Y;
            double distance = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);

            if (distance < Speed)
            {
                X = Target.X;
                Y = Target.Y;

                Target.TakeDamage(Damage, _gameManager);

                IsActive = false;
            }
            else
            {
                X += (int)(Speed * deltaX / distance);
                Y += (int)(Speed * deltaY / distance);
            }
        }
    }
}
