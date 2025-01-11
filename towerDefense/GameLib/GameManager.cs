namespace GameLib
{
    public class GameManager
    {
        public List<Enemy> Enemies { get; private set; } = new List<Enemy>();
        public List<Tower> Towers { get; private set; } = new List<Tower>();
        public int PlayerMoney { get; private set; } = 10;

        private const int TowerCost = 10;
        private const int EnemyReward = 5;

        public event Action<int> OnMoneyChanged;

        public GameManager()
        {
            OnMoneyChanged?.Invoke(PlayerMoney);
        }

        public bool TryPlaceTower(int x, int y)
        {
            if (PlayerMoney < TowerCost)
                return false;

            if (Towers.Exists(t => t.X == x && t.Y == y))
                return false;

            PlayerMoney -= TowerCost;
            Towers.Add(new Tower(x, y, 100, 20, 10));

            OnMoneyChanged?.Invoke(PlayerMoney);
            return true;
        }

        public void RewardForEnemyKill()
        {
            PlayerMoney += EnemyReward;
            OnMoneyChanged?.Invoke(PlayerMoney);
        }

        public void Update()
        {
            foreach (var enemy in Enemies)
            {
                enemy.Update();
            }

            foreach (var tower in Towers)
            {
                tower.Shoot(Enemies, this);
                tower.Update();
            }

            Enemies.RemoveAll(e => !e.IsActive && !e.HasReachedEnd);
        }
    }
}
