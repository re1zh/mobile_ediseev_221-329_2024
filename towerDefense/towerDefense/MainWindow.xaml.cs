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

        private List<(int row, int col)> staticPath = new List<(int row, int col)>
        {
            (0, 0), (1, 0), (2, 0), (3, 0), (3, 1), (3, 2), (3, 3), (2, 3),
            (1, 3), (1, 4), (1, 5), (2, 5), (3, 5), (3, 6), (3, 7), (2, 7),
            (1, 7), (0, 7), (0, 8), (0, 9), (0, 10), (1, 10), (2, 10), (3, 10),
            (4, 10), (5, 10), (6, 10), (6, 11), (6, 12), (6, 13), (6, 14), (6, 15)
        };

        private GameManager gameManager = new GameManager();

        private DispatcherTimer gameLoopTimer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();

            gameLoopTimer.Interval = TimeSpan.FromMilliseconds(16);
            gameLoopTimer.Tick += GameLoop;
            gameLoopTimer.Start();

            DrawGrid();
            InitializeEnemies();
        }

        private void GameLoop(object sender, EventArgs e)
        {
            gameManager.Update();
            RenderGame();
        }

        private void DrawGrid()
        {
            for (int row = 0; row < GridHeight; row++)
            {
                for (int col = 0; col < GridWidth; col++)
                {
                    var cell = new Rectangle
                    {
                        Width = CellSize,
                        Height = CellSize,
                        Stroke = Brushes.Black,
                        StrokeThickness = 1,
                        Fill = Brushes.LightGray
                    };

                    Canvas.SetLeft(cell, col * CellSize);
                    Canvas.SetTop(cell, row * CellSize);  
                    
                    // Проверяем, является ли клетка частью пути
                    if (staticPath.Contains((row, col)))
                    {
                        cell.Fill = Brushes.Green; // Клетка пути
                    }

                    cell.MouseLeftButtonDown += (s, e) =>
                    {
                        var mousePosition = e.GetPosition(GameCanvas);
                        int clickedRow = (int)(mousePosition.Y / CellSize);
                        int clickedCol = (int)(mousePosition.X / CellSize);

                        CreateTower(clickedCol, clickedRow);
                    };

                    gridCells[row, col] = cell;

                    GameCanvas.Children.Add(cell);
                }
            }
        }

        private void CreateTower(int col, int row)
        {
            if (row < 0 || row >= GridHeight || col < 0 || col >= GridWidth)
            {
                MessageBox.Show($"Invalid cell coordinates: row={row}, col={col}");
                return;
            }

            try
            {
                if (gameManager.Towers.Exists(t => t.X == col * CellSize && t.Y == row * CellSize))
                {
                    MessageBox.Show("Башня уже существует в этой клетке!");
                    return;
                }

                var newTower = new Tower(col * CellSize, row * CellSize, 150, 20);
                gameManager.Towers.Add(newTower);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"CreateTower Exception: {ex.Message}");
            }
        }

        private void InitializeEnemies()
        {
            var startCell = staticPath[0]; // Начальная точка пути
            int startX = startCell.col * CellSize;
            int startY = startCell.row * CellSize;

            var enemy = new Enemy(startX, startY, 100, 2); // 2 — скорость врага
            enemy.SetPath(staticPath); // Задаем путь
            gameManager.Enemies.Add(enemy);
        }

        private void RenderGame()
        {
            var elementsToRemove = new List<UIElement>();

            foreach (var child in GameCanvas.Children)
            {
                if (child is Rectangle rect && rect.Fill != Brushes.LightGray)
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
                var enemyRect = new Rectangle
                {
                    Width = 20,
                    Height = 20,
                    Fill = Brushes.Red
                };
                Canvas.SetLeft(enemyRect, enemy.X);
                Canvas.SetTop(enemyRect, enemy.Y);
                GameCanvas.Children.Add(enemyRect);
            }

            foreach (var tower in gameManager.Towers)
            {
                var towerRect = new Rectangle
                {
                    Width = 45,
                    Height = 45,
                    Fill = Brushes.Blue
                };
                Canvas.SetLeft(towerRect, tower.X);
                Canvas.SetTop(towerRect, tower.Y);
                GameCanvas.Children.Add(towerRect);
            }
        }
    }
}
