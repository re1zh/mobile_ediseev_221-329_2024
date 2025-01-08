namespace GameLib
{
    public class GameManager
    {
        public List<Enemy> Enemies { get; private set; } = new List<Enemy>();
        public List<Tower> Towers { get; private set; } = new List<Tower>();

        public void Update()
        {
            foreach (var enemy in Enemies)
            {
                enemy.Update();
            }

            foreach (var tower in Towers)
            {
                var target = tower.FindTarget(Enemies);
                if (target != null)
                {
                    target.TakeDamage(tower.Damage);
                }
            }

            Enemies.RemoveAll(e => !e.IsActive);
        }
    }
}
