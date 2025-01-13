namespace GameLib
{
    public enum TowerType
    {
        Archer,
        Cannon,
        Frost
    }

    public class Tower : GameObject
    {
        private int _range;
        private int _damage;
        private int _fireRate;
        private int _currentCooldown = 0;
        private List<Projectile> _projectiles = new List<Projectile>();
        private TowerType _towerType;

        private int _level = 1;
        private const int MaxLevel = 3;

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

        public TowerType Type => _towerType;

        public int Level => _level;

        public IReadOnlyList<Projectile> Projectiles => _projectiles.AsReadOnly();

        public Tower(int x, int y, TowerType type)
        {
            X = x;
            Y = y;
            _towerType = type;

            switch (type)
            {
                case TowerType.Archer:
                    _range = 100;
                    _damage = 20;
                    _fireRate = 30;
                    break;

                case TowerType.Cannon:
                    _range = 75;
                    _damage = 80;
                    _fireRate = 90;
                    break;

                case TowerType.Frost:
                    _range = 120;
                    _damage = 10;
                    _fireRate = 40;
                    break;
            }
        }

        public Enemy FindTarget(IEnumerable<Enemy> enemies)
        {
            return enemies.FirstOrDefault(e => e.IsActive && DistanceTo(e) <= Range);
        }

        public int DistanceTo(GameObject obj)
        {
            return (int)Math.Sqrt(Math.Pow(X - obj.X, 2) + Math.Pow(Y - obj.Y, 2));
        }

        public bool Upgrade(GameManager gameManager)
        {
            const int upgradeCost = 15;

            if (_level >= MaxLevel || gameManager.PlayerMoney < upgradeCost)
            {
                return false;
            }

            gameManager.SpendMoney(upgradeCost);

            _level++;
            _damage += 5;
            _range += 5;
            _fireRate = Math.Max(1, _fireRate - 1);

            return true;
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
                    gameManager,
                    Type
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