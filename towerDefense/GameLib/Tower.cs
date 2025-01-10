namespace GameLib
{
    public class Tower : GameObject
    {
        public int Range { get; set; }
        public int Damage { get; set; }
        public int FireRate { get; set; }
        private int currentCooldown = 0;
        public List<Projectile> Projectiles { get; private set; } = new List<Projectile>();

        public Tower(int x, int y, int range, int damage, int fireRate)
        {
            X = x;
            Y = y;
            Range = range;
            Damage = damage;
            FireRate = fireRate;
        }

        public Enemy FindTarget(IEnumerable<Enemy> enemies)
        {
            return enemies.FirstOrDefault(e => e.IsActive && DistanceTo(e) <= Range);
        }

        public int DistanceTo(GameObject obj)
        {
            return (int)Math.Sqrt(Math.Pow(X - obj.X, 2) + Math.Pow(Y - obj.Y, 2));
        }

        public void Shoot(IEnumerable<Enemy> enemies)
        {
            if (currentCooldown > 0)
            {
                currentCooldown--;
                return;
            }

            Enemy target = FindTarget(enemies);
            if (target != null)
            {
                var projectile = new Projectile(X, Y, 10, Damage, target);
                Projectiles.Add(projectile);
                currentCooldown = FireRate;
            }
        }

        public override void Update()
        {
            foreach (var projectile in Projectiles)
            {
                projectile.Update();
            }

            Projectiles.RemoveAll(p => !p.IsActive);
        }
    }
}
