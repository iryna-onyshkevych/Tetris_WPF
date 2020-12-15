using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using Tetris.ViewModels;

namespace Tetris.View
{
    /// <summary>
    /// Interaction logic for GameEnd.xaml
    /// </summary>
    public partial class GameEnd : Window
    {
        public GameEnd(int s, int l)
        {

            InitializeComponent();
            Text_Block.Text = "   You Lose!\nYour score: " + s.ToString();


            Score p2 = new Score { Gamescore = s, Level = l };


            SaveAsync(p2);
            GetAsync(p2);

        }

        static async void SaveAsync(Score p2)
        {
            await Task.Run(() => SaveObjectsAsync(p2));
        }
        static async void GetAsync(Score p2)
        {
            await Task.Run(() => GetObjectsAsync(p2));
        }
        public static void  GetObjectsAsync(Score p2)
        {
            using (ScoreContext db = new ScoreContext())
            {                   
                MessageBox.Show("Your Level: "+p2.Level.ToString());
                
            }
           
        }
        public static async Task SaveObjectsAsync(Score p)
        {

            using (ScoreContext db = new ScoreContext())
            {
                db.Scores.Add(p);
                await db.SaveChangesAsync();
            }
        }
       
            //Закрити гру
            private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_Restart(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            this.Close();
            main.Show();

        }

        private void Button_Click_Results(object sender, RoutedEventArgs e)
        {
            LevelTable table_wind = new LevelTable();
            table_wind.Show();
        }
    }
}
