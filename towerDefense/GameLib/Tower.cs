namespace GameLib
{
    public class Tower : GameObject
    {
        public int Range { get; set; }
        public int Damage { get; set; }

        public Tower(int x, int y, int range, int damage)
        {
            X = x;
            Y = y;
            Range = range;
            Damage = damage;
        }

        public Enemy FindTarget(IEnumerable<Enemy> enemies)
        {
            return enemies.FirstOrDefault(e => e.IsActive && DistanceTo(e) <= Range);
        }

        public int DistanceTo(GameObject obj)
        {
            return (int)Math.Sqrt(Math.Pow(X - obj.X, 2) + Math.Pow(Y - obj.Y, 2));
        }
    }
}
