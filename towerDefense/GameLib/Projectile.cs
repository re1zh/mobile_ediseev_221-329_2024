namespace GameLib
{
    public class Projectile : GameObject
    {
        public int Speed { get; set; }
        public int Damage { get; set; }
        public Enemy Target { get; private set; }
        private GameManager gameManager;

        public Projectile(int x, int y, int speed, int damage, Enemy target, GameManager gameManager)
        {
            X = x;
            Y = y;
            Speed = speed;
            Damage = damage;
            Target = target;
            this.gameManager = gameManager;
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

                Target.TakeDamage(Damage, gameManager);

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
