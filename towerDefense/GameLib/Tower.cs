namespace GameLib
{
    public class Tower : GameObject
    {
        private int _range;
        private int _damage;
        private int _fireRate;
        private int _currentCooldown = 0;
        private List<Projectile> _projectiles = new List<Projectile>();

        public int Range
        {
            get => _range;
            private set => _range = value;
        }

        public int Damage
        {
            get => _damage;
            private set => _damage = value;
        }

        public int FireRate
        {
            get => _fireRate;
            private set => _fireRate = value;
        }

        public IReadOnlyList<Projectile> Projectiles => _projectiles.AsReadOnly();

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

        public void Shoot(IEnumerable<Enemy> enemies, GameManager gameManager)
        {
            if (_currentCooldown > 0)
            {
                _currentCooldown--;
                return;
            }

            Enemy target = FindTarget(enemies);
            if (target != null)
            {
                int towerSize = 45;

                var projectile = new Projectile(
                    X + towerSize / 2,
                    Y + towerSize / 2,
                    10,
                    Damage,
                    target,
                    gameManager
                );
                _projectiles.Add(projectile);
                _currentCooldown = FireRate;
            }
        }

        public override void Update()
        {
            foreach (var projectile in _projectiles)
            {
                projectile.Update();
            }
            _projectiles.RemoveAll(p => !p.IsActive);
        }
    }
}
