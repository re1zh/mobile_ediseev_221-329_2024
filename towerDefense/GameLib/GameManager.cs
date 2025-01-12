using System.Windows;
using System.Windows.Threading;

namespace GameLib
{
    public class GameManager
    {
        private List<Enemy> _enemies = new List<Enemy>();
        private List<Tower> _towers = new List<Tower>();

        private int _playerMoney = 40;

        public event Action<int> OnMoneyChanged;
        public event Action<int> OnTowerCountChanged;

        public IReadOnlyList<Enemy> Enemies => _enemies.AsReadOnly();
        public IReadOnlyList<Tower> Towers => _towers.AsReadOnly();
        public int PlayerMoney => _playerMoney;

        public GameManager()
        {
            OnMoneyChanged?.Invoke(_playerMoney);
        }

        public void SpendMoney(int amount)
        {
            _playerMoney -= amount;
            OnMoneyChanged?.Invoke(_playerMoney);
        }

        public void AddEnemy(Enemy enemy)
        {
            _enemies.Add(enemy);
        }

        public bool TryPlaceTower(int x, int y, TowerType type)
        {
            int cost = GetTowerCost(type);

            if (_playerMoney < cost)
                return false;

            if (_towers.Exists(t => t.X == x && t.Y == y))
                return false;

            _playerMoney -= cost;
            _towers.Add(new Tower(x, y, type));

            OnMoneyChanged?.Invoke(_playerMoney);
            OnTowerCountChanged?.Invoke(_towers.Count);
            return true;
        }

        private int GetTowerCost(TowerType type)
        {
            return type switch
            {
                TowerType.Archer => 10,
                TowerType.Cannon => 20,
                TowerType.Frost => 15,
                _ => 10
            };
        }

        public void RewardForEnemyKill(Enemy enemy)
        {
            _playerMoney += enemy.Reward;
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