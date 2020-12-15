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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Entity;
using Tetris.View;
using Tetris.ViewModels;

namespace Tetris.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {

            InitializeComponent();
            
            
        }
        // закриває вікно GameStart і відкриває  вікно main game 
        private void Button_Click_Yes(object sender, RoutedEventArgs e)
        {
            Gamestart main = new Gamestart();
            //App.Current.Gamestart = main;
            this.Close();
            main.Show();
        }

        // Виходить з гри
        private void Button_Click_No(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_Help(object sender, RoutedEventArgs e)
        {
            Help window = new Help();
            //App.Current.Gamestart = main;
            window.Show();
        }
        
    }
}
