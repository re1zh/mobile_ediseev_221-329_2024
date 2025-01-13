using System;
using System.Collections.Generic;
using System.Linq;
using GameLib;

namespace MinimalConsoleTD
{
    public enum EnemyType
    {
        Grunt,
        Tank,
        Runner
    }

    public enum TowerType
    {
        Archer,
        Cannon,
        Frost
    }

    public class Enemy
    {
        public EnemyType Type { get; }
        public int Health { get; private set; }
        public bool IsActive { get; private set; } = true;

        public int Row { get; private set; }
        public int Col { get; private set; }

        private readonly List<(int row, int col)> _path;
        private int _currentPathIndex = 0;

        public Enemy(EnemyType type, int health, List<(int, int)> path)
        {
            Type = type;
            Health = health;
            _path = path;

            if (path.Count > 0)
            {
                (Row, Col) = path[0];
            }
        }

        public void MoveNext()
        {
            if (!IsActive) return;

            _currentPathIndex++;
            if (_currentPathIndex < _path.Count)
            {
                (Row, Col) = _path[_currentPathIndex];
            }
            else
            {
                IsActive = false;
            }
        }

        public void TakeDamage(int damage)
        {
            if (!IsActive) return;
            Health -= damage;
            if (Health <= 0)
            {
                IsActive = false;
            }
        }
    }
    public class Tower
    {
        public TowerType Type { get; }
        public int Damage { get; private set; }
        public int Range { get; private set; }
        public int Row { get; }
        public int Col { get; }

        public Tower(TowerType type, int row, int col)
        {
            Type = type;
            Row = row;
            Col = col;

            switch (type)
            {
                case TowerType.Archer:
                    Damage = 15;
                    Range = 2;
                    break;
                case TowerType.Cannon:
                    Damage = 30;
                    Range = 2;
                    break;
                case TowerType.Frost:
                    Damage = 10;
                    Range = 3;
                    break;
            }
        }

        public void AttackEnemies(IEnumerable<Enemy> enemies)
        {
            foreach (var enemy in enemies)
            {
                if (!enemy.IsActive) continue;

                int distance = (int)Math.Sqrt(Math.Pow(enemy.Row - Row, 2) + Math.Pow(enemy.Col - Col, 2));
                if (distance <= Range)
                {
                    enemy.TakeDamage(Damage);
                }
            }
        }
    }

    public class Game
    {
        private const int MapRows = 5;
        private const int MapCols = 5;

        private List<(int row, int col)> _path = new()
        {
            (0, 0),
            (0, 1),
            (0, 2),
            (1, 2),
            (2, 2),
            (3, 2),
            (4, 2)
        };

        public int PlayerMoney { get; private set; } = 50;

        public List<Enemy> Enemies { get; private set; } = new List<Enemy>();
        public List<Tower> Towers { get; private set; } = new List<Tower>();

        public bool IsGameOver { get; set; }

        public void SetupGame()
        {
            Enemies.Add(new Enemy(EnemyType.Grunt, 40, _path));
        }

        public void NextTurn()
        {
            foreach (var tower in Towers)
            {
                tower.AttackEnemies(Enemies);
            }

            foreach (var enemy in Enemies)
            {
                enemy.MoveNext();
            }

            if (Enemies.Any(e => !e.IsActive && e.Health > 0))
            {
                Console.WriteLine("Враг достиг конца пути. Вы проиграли!");
                IsGameOver = true;
            }

            if (Enemies.All(e => !e.IsActive || e.Health <= 0))
            {
                Console.WriteLine("Все враги побеждены! Вы выиграли!");
                IsGameOver = true;
            }
        }

        public bool BuyTower(int row, int col, TowerType type)
        {
            if (!CheckInBounds(row, col)) return false;
            if (Towers.Any(t => t.Row == row && t.Col == col)) return false;

            int cost = type switch
            {
                TowerType.Archer => 10,
                TowerType.Cannon => 20,
                TowerType.Frost => 15,
                _ => 10
            };
            if (PlayerMoney < cost) return false;

            PlayerMoney -= cost;
            Towers.Add(new Tower(type, row, col));
            return true;
        }

        private bool CheckInBounds(int row, int col)
        {
            return (row >= 0 && row < MapRows && col >= 0 && col < MapCols);
        }
        public void PrintMap()
        {
            char[,] map = new char[MapRows, MapCols];
            for (int r = 0; r < MapRows; r++)
            {
                for (int c = 0; c < MapCols; c++)
                {
                    map[r, c] = '.';
                }
            }

            foreach (var (pr, pc) in _path)
            {
                if (pr >= 0 && pr < MapRows && pc >= 0 && pc < MapCols)
                    map[pr, pc] = '*';
            }

            foreach (var tower in Towers)
            {
                map[tower.Row, tower.Col] = 'T';
            }

            foreach (var enemy in Enemies)
            {
                if (enemy.IsActive && enemy.Health > 0)
                {
                    map[enemy.Row, enemy.Col] = 'E';
                }
            }

            Console.WriteLine("==== Карта ====");
            for (int r = 0; r < MapRows; r++)
            {
                for (int c = 0; c < MapCols; c++)
                {
                    Console.Write(map[r, c]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("===============");
        }
    }

    class Program
    {
        static void Main()
        {
            var game = new Game();
            game.SetupGame();

            while (!game.IsGameOver)
            {
                Console.Clear();
                Console.WriteLine($"Деньги: {game.PlayerMoney}");
                game.PrintMap();

                if (game.IsGameOver) break;

                Console.WriteLine("[1] Установить башню");
                Console.WriteLine("[2] Сделать ход (движение врагов и атака башен)");
                Console.WriteLine("[Q] Выйти");
                Console.Write("Ваш выбор: ");
                char choice = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (choice)
                {
                    case '1':
                        PlaceTower(game);
                        break;
                    case '2':
                        game.NextTurn();
                        break;
                    case 'Q':
                    case 'q':
                        Console.WriteLine("Выход...");
                        game.IsGameOver = true;
                        break;
                    default:
                        Console.WriteLine("Неизвестная команда.");
                        break;
                }
            }

            Console.WriteLine("Игра завершена. Нажмите любую клавишу...");
            Console.ReadKey();
        }

        static void PlaceTower(Game game)
        {
            Console.WriteLine("Выберите тип башни: (1)Archer (2)Cannon (3)Frost");
            char choice = Console.ReadKey().KeyChar;
            Console.WriteLine();
            TowerType type = TowerType.Archer;
            switch (choice)
            {
                case '1': type = TowerType.Archer; break;
                case '2': type = TowerType.Cannon; break;
                case '3': type = TowerType.Frost; break;
                default:
                    Console.WriteLine("Неверный ввод.");
                    return;
            }

            Console.Write("Введите row: ");
            if (!int.TryParse(Console.ReadLine(), out int row))
            {
                Console.WriteLine("Некорректный ввод.");
                return;
            }
            Console.Write("Введите col: ");
            if (!int.TryParse(Console.ReadLine(), out int col))
            {
                Console.WriteLine("Некорректный ввод.");
                return;
            }

            bool success = game.BuyTower(row, col, type);
            if (success)
                Console.WriteLine("Башня установлена успешно!");
            else
                Console.WriteLine("Не удалось установить башню (нехватка денег, выход за границы или место занято).");
        }
    }
}
