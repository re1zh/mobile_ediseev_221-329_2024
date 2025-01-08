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

        private GameManager gameManager = new GameManager();
        private DispatcherTimer gameLoopTimer = new DispatcherTimer();

        private Rectangle[,] gridCells = new Rectangle[GridHeight, GridWidth];

        public MainWindow()
        {
            InitializeComponent();

            gameLoopTimer.Interval = TimeSpan.FromMilliseconds(16);
            gameLoopTimer.Tick += GameLoop;
            gameLoopTimer.Start();

            DrawGrid();
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
