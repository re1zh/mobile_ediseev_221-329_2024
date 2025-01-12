using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;
using GameLib;

namespace towerDefense
{
    public partial class MainWindow : Window
    {
        private const int CellSize = 45;
        private const int GridWidth = 16;
        private const int GridHeight = 9;
        private Rectangle[,] gridCells = new Rectangle[GridHeight, GridWidth];

        private List<(int row, int col)> staticPath = new List<(int row, int col)> { };

        private GameManager gameManager = new GameManager();

        private DispatcherTimer gameLoopTimer = new DispatcherTimer();
        private DispatcherTimer enemySpawnTimer = new DispatcherTimer();
        private DispatcherTimer gameTimer = new DispatcherTimer();
        private DispatcherTimer countdownTimer = new DispatcherTimer();

        private int countdownValue = 5;

        private int gameDuration = 60;
        private int elapsedSeconds = 0;

        private bool isGameOver = false;

        public MainWindow(int level)
        {
            InitializeComponent();

            gameManager = new GameManager();
            gameManager.OnMoneyChanged += UpdateMoneyDisplay;

            switch (level)
            {
                case 1:
                    staticPath = new List<(int row, int col)>
                    {
                        (0, 0), (0, 1), (0, 2), (0, 3), (1, 3), (2, 3), (2, 2), (2, 1),
                        (2, 0), (3, 0), (4, 0), (4, 1), (4, 2), (4, 3), (5, 3), (6, 3),
                        (6, 2), (6, 1), (6, 0), (7, 0), (8, 0), (8, 1), (8, 2), (8, 3),
                        (7, 3), (7, 4), (7, 5), (6, 5), (5, 5), (5, 6), (5, 7), (6, 7),
                        (7, 7), (7, 8), (6, 8), (5, 8), (4, 8), (3, 8), (2, 8), (1, 8),
                        (0, 8), (0, 9), (0, 10), (1, 10), (2, 10), (3, 10), (4, 10),
                        (4, 11), (4, 12), (3, 12), (2, 12), (1, 12), (0, 12), (0, 13),
                        (0, 14), (0, 15)
                    };
                    break;
                case 2:
                    staticPath = new List<(int row, int col)>
                    {
                        (0, 0), (0, 1), (0, 2), (0, 3), (1, 3), (2, 3), (3, 3), (3, 2),
                        (3, 1), (3, 0), (4, 0), (5, 0), (5, 1), (5, 2), (4, 2), (4, 3),
                        (4, 4), (3, 4), (2, 4), (1, 4), (1, 5), (1, 6), (2, 6), (3, 6),
                        (4, 6), (5, 6), (5, 7), (4, 7), (3, 7), (2, 7), (1, 7), (0, 7),
                        (0, 8), (0, 9), (0, 10), (1, 10), (2, 10), (3, 10), (4, 10),
                        (5, 10), (6, 10), (7, 10), (8, 10), (8, 11), (8, 12), (8, 13),
                        (8, 14), (8, 15)
                    };
                    break;
                case 3:
                    staticPath = new List<(int row, int col)>
                    {
                        (0, 0), (1, 0), (2, 0), (3, 0), (4, 0), (4, 1), (4, 2), (3, 2),
                        (2, 2), (2, 3), (2, 4), (3, 4), (4, 4), (4, 5), (4, 6), (3, 6),
                        (2, 6), (2, 7), (2, 8), (3, 8), (4, 8), (4, 9), (4, 10), (3, 10),
                        (2, 10), (2, 11), (2, 12), (3, 12), (4, 12), (4, 13), (4, 14),
                        (4, 15)
                    };
                    break;
                default:
                    staticPath = new List<(int row, int col)>
                    {
                        (0, 0), (0, 1), (0, 2), (0, 3), (1, 3), (2, 3), (2, 2), (2, 1),
                        (2, 0), (3, 0), (4, 0), (4, 1), (4, 2), (4, 3), (5, 3), (6, 3),
                        (6, 2), (6, 1), (6, 0), (7, 0), (8, 0), (8, 1), (8, 2), (8, 3),
                        (7, 3), (7, 4), (7, 5), (6, 5), (5, 5), (5, 6), (5, 7), (6, 7),
                        (7, 7), (7, 8), (6, 8), (5, 8), (4, 8), (3, 8), (2, 8), (1, 8),
                        (0, 8), (0, 9), (0, 10), (1, 10), (2, 10), (3, 10), (4, 10),
                        (4, 11), (4, 12), (3, 12), (2, 12), (1, 12), (0, 12), (0, 13),
                        (0, 14), (0, 15)
                    };
                    break;
            }

            DrawGrid();

            countdownTimer.Interval = TimeSpan.FromSeconds(1);
            countdownTimer.Tick += CountdownTimer_Tick;

            ShowCountdown();
        }

        private void ShowCountdown()
        {
            CountdownText.Visibility = Visibility.Visible;
            CountdownText.Text = countdownValue.ToString();
            countdownTimer.Start();
        }

        private void StopAllTimers()
        {
            gameLoopTimer.Stop();
            enemySpawnTimer.Stop();
            gameTimer.Stop();
        }

        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            countdownValue--;

            if (countdownValue > 0)
            {
                CountdownText.Text = countdownValue.ToString();
            }
            else
            {
                countdownTimer.Stop();
                CountdownText.Text = "СТАРТ!";
                StartGame();

                DispatcherTimer hideTextTimer = new DispatcherTimer
                {
                    Interval = TimeSpan.FromSeconds(1)
                };
                hideTextTimer.Tick += (s, args) =>
                {
                    CountdownText.Visibility = Visibility.Hidden;
                    hideTextTimer.Stop();
                };
                hideTextTimer.Start();
            }
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (isGameOver) return;

            elapsedSeconds++;

            int remainingTime = gameDuration - elapsedSeconds;
            TimerTextBlock.Text = remainingTime.ToString();

            if (elapsedSeconds >= gameDuration)
            {
                gameTimer.Stop();
                CheckForWin();
            }
        }

        private void StartGame()
        {
            gameLoopTimer.Interval = TimeSpan.FromMilliseconds(16);
            gameLoopTimer.Tick += GameLoop;
            gameLoopTimer.Start();

            gameTimer.Interval = TimeSpan.FromSeconds(1);
            gameTimer.Tick += GameTimer_Tick;
            gameTimer.Start();

            enemySpawnTimer.Interval = TimeSpan.FromSeconds(2);
            enemySpawnTimer.Tick += SpawnEnemy;
            enemySpawnTimer.Start();

            SpawnEnemy(null, null);
        }

        private void GameLoop(object sender, EventArgs e)
        {
            gameManager.Update();

            CheckForLoss();
            RenderGame();
        }

        private void DrawGrid()
        {
            for (int row = 0; row < GridHeight; row++)
            {
                for (int col = 0; col < GridWidth; col++)
                {
                    var cell = new Rectangle {};

                    if (staticPath.Contains((row, col)))
                    {
                        cell = new Rectangle
                        {
                            Width = CellSize,
                            Height = CellSize,
                            Stroke = Brushes.Black,
                            StrokeThickness = 1,
                            Fill = Brushes.Green
                        };
                    }
                    else 
                    {
                        cell = new Rectangle
                        {
                            Width = CellSize,
                            Height = CellSize,
                            Stroke = Brushes.Black,
                            StrokeThickness = 1,
                            Fill = Brushes.LightGray
                        };
                    }     
                    
                    Canvas.SetTop(cell, row * CellSize);
                    Canvas.SetLeft(cell, col * CellSize);

                    gridCells[row, col] = cell;
                    GameCanvas.Children.Add(cell);

                    cell.MouseLeftButtonDown += (s, e) =>
                    {
                        var mousePosition = e.GetPosition(GameCanvas);
                        int clickedRow = (int)(mousePosition.Y / CellSize);
                        int clickedCol = (int)(mousePosition.X / CellSize);

                        if (!staticPath.Contains((clickedRow, clickedCol)))
                        {
                            CreateTower(clickedCol, clickedRow);
                        }
                    };
                }
            }
        }

        private void CreateTower(int col, int row)
        {
            int x = col * CellSize;
            int y = row * CellSize;

            if (!gameManager.TryPlaceTower(x, y))
            {
                MessageBox.Show("Недостаточно денег или башня уже установлена!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            UpdateMoneyDisplay(gameManager.PlayerMoney);
        }

        private void SpawnEnemy(object sender, EventArgs e)
        {
            var startCell = staticPath[0];
            int startX = startCell.col * CellSize;
            int startY = startCell.row * CellSize;

            var enemy = new Enemy(startX, startY, 200, 3);
            enemy.SetPath(staticPath);
            gameManager.AddEnemy(enemy);
        }

        private void CheckForLoss()
        {
            if (gameManager.Enemies.Any(enemy => enemy.HasReachedEnd))
            {
                isGameOver = true;
                StopAllTimers();

                MessageBox.Show("Вы проиграли!", "Игра окончена");
                //Application.Current.Shutdown();

                LevelSelection levelSelection = new LevelSelection();
                levelSelection.Show();

                this.Close();
            }
        }

        private void CheckForWin()
        {
            if (!gameManager.Enemies.Any(enemy => enemy.HasReachedEnd))
            {
                isGameOver = true;
                StopAllTimers();
                MessageBox.Show("Вы выиграли!", "Игра окончена");
                //Application.Current.Shutdown();

                LevelSelection levelSelection = new LevelSelection();
                levelSelection.Show();

                this.Close();
            }
        }

        private void UpdateMoneyDisplay(int money)
        {
            MoneyTextBlock.Text = money.ToString();
        }

        private void RenderGame()
        {
            var elementsToRemove = new List<UIElement>();

            foreach (var child in GameCanvas.Children)
            {
                if (child is Rectangle rect && rect.Fill != Brushes.LightGray && rect.Fill != Brushes.Green)
                {
                    elementsToRemove.Add((UIElement)child);
                }
            }

            foreach (var element in elementsToRemove)
            {
                GameCanvas.Children.Remove(element);
            }

            foreach (var enemy in gameManager.Enemies)
            {
                double healthPercentage = (double)enemy.Health / enemy.MaxHealth;

                var enemyRect = new Rectangle
                {
                    Width = 45,
                    Height = 45,
                    Stroke = Brushes.Black,
                    StrokeThickness = 1,
                    Fill = Brushes.Black
                };

                Canvas.SetLeft(enemyRect, enemy.X);
                Canvas.SetTop(enemyRect, enemy.Y);

                GameCanvas.Children.Add(enemyRect);

                var healthBar = new Rectangle
                {
                    Width = 45,
                    Height = 45 * healthPercentage,
                    Fill = Brushes.Red
                };

                Canvas.SetLeft(healthBar, enemy.X);
                Canvas.SetTop(healthBar, enemy.Y + (45 * (1 - healthPercentage)));

                GameCanvas.Children.Add(healthBar);
            }

            foreach (var tower in gameManager.Towers)
            {
                var towerRect = new Rectangle
                {
                    Width = 45,
                    Height = 45,
                    Stroke = Brushes.Black,
                    StrokeThickness = 1,
                    Fill = Brushes.Blue
                };

                Canvas.SetLeft(towerRect, tower.X);
                Canvas.SetTop(towerRect, tower.Y);

                GameCanvas.Children.Add(towerRect);

                foreach (var projectile in tower.Projectiles)
                {
                    var projectileRect = new Rectangle
                    {
                        Width = 10,
                        Height = 10,
                        Fill = Brushes.Orange
                    };

                    Canvas.SetLeft(projectileRect, projectile.X - projectileRect.Width / 2);
                    Canvas.SetTop(projectileRect, projectile.Y - projectileRect.Height / 2);

                    GameCanvas.Children.Add(projectileRect);
                }
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Вы уверены, что хотите выйти?", "Выход", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                StopAllTimers();

                LevelSelection levelSelection = new LevelSelection();
                levelSelection.Show();

                this.Close();
            }
        }
    }
}
