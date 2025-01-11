using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace towerDefense
{
    /// <summary>
    /// Логика взаимодействия для LevelSelection.xaml
    /// </summary>
    public partial class LevelSelection : Window
    {
        public LevelSelection()
        {
            InitializeComponent();
        }
        private void Level1Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow gameWindow = new MainWindow(1);
            gameWindow.Show();
            this.Close();
        }

        private void Level2Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow gameWindow = new MainWindow(2);
            gameWindow.Show();
            this.Close();
        }

        private void Level3Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow gameWindow = new MainWindow(3);
            gameWindow.Show();
            this.Close();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
            this.Close();
        }
    }
}
