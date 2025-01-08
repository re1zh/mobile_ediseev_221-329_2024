namespace GameLib
{
    public class Enemy : GameObject
    {
        public int Health { get; set; }
        public int Speed { get; set; }

        public Enemy(int x, int y, int health, int speed)
        {
            X = x;
            Y = y;
            Health = health;
            Speed = speed;
        }

        public override void Update()
        {
            X += Speed;
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
