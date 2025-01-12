namespace GameLib
{
    public class GameManager
    {
        private List<Enemy> _enemies = new List<Enemy>();
        private List<Tower> _towers = new List<Tower>();

        private int _playerMoney = 15;

        private const int TowerCost = 10;
        private const int EnemyReward = 5;

        public event Action<int> OnMoneyChanged;

        public IReadOnlyList<Enemy> Enemies => _enemies.AsReadOnly();
        public IReadOnlyList<Tower> Towers => _towers.AsReadOnly();
        public int PlayerMoney => _playerMoney;

        public GameManager()
        {
            OnMoneyChanged?.Invoke(_playerMoney);
        }

        public void AddEnemy(Enemy enemy)
        {
            _enemies.Add(enemy);
        }

        public bool TryPlaceTower(int x, int y)
        {
            if (_playerMoney < TowerCost)
                return false;

            if (_towers.Exists(t => t.X == x && t.Y == y))
                return false;

            _playerMoney -= TowerCost;
            _towers.Add(new Tower(x, y, 100, 20, 10));

            OnMoneyChanged?.Invoke(_playerMoney);
            return true;
        }

        public void RewardForEnemyKill()
        {
            _playerMoney += EnemyReward;
            OnMoneyChanged?.Invoke(_playerMoney);
        }

        public void Update()
        {
            foreach (var enemy in _enemies)
            {
                enemy.Update();
            }

            foreach (var tower in _towers)
            {
                tower.Shoot(_enemies, this);
                tower.Update();
            }

            _enemies.RemoveAll(e => !e.IsActive && !e.HasReachedEnd);
        }
    }
}
