using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using Tetris.Models;
using Tetris.View;
using Tetris.ViewModels;

namespace Tetris.ViewModels
{
    /// <summary>
    /// Interaction logic for Gamestart.xaml
    /// </summary>
    public partial class Gamestart : Window
    {
        DispatcherTimer Timer; // Таймер для руху
        Board myBoard; // гральна дошка
        public Gamestart()
        {
            InitializeComponent();


        }
        void MainWindow_Initialized(object sender, EventArgs e)
        {
            Timer = new DispatcherTimer();
            Timer.Tick += new EventHandler(GameTick);
            Timer.Interval = new TimeSpan(0, 0, 0, 0, 400);

            GameStart();
        }

        // Створює нову гральну дошку і встановлює таймер
        private void GameStart()
        {
            MainGrid.Children.Clear();
            myBoard = new Board(MainGrid);
            Timer.Start();

            //GamePause();
        }

        
        void GameTick(object sender, EventArgs e)
        {
            int s, l, n;
            s = myBoard.getScore();
            l = myBoard.getLevel();
            n = 410 - (l * 30);
            Timer.Interval = new TimeSpan(0, 0, 0, 0, n);

            Score.Content = "Score=" + myBoard.getScore().ToString("0000");
            Lines.Content = "Level=" + myBoard.getLevel().ToString("0000");

            myBoard.CurrTetriminoMoveDown();
            if (myBoard.getGameEnd())
            {
                GameEnd main = new GameEnd(s, l);
                App.Current.MainWindow = main;
                this.Close();
                main.Show();
                Timer.Stop();
            }

        }

        // Пауза і продовження гри
        private void GamePause()
        {
            if (Timer.IsEnabled) Timer.Stop();
            else Timer.Start();
        }

        //Події кнопок клавіатури
        private void HandleKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Left:
                    if (Timer.IsEnabled) myBoard.CurrTetriminoMoveLeft();
                    break;
                case Key.Right:
                    if (Timer.IsEnabled) myBoard.CurrTetriminoMoveRight();
                    break;
                case Key.Down:
                    if (Timer.IsEnabled) myBoard.CurrTetriminoMoveDown();
                    break;
                case Key.Up:
                    if (Timer.IsEnabled) myBoard.CurrTetriminoMoveRotate();
                    break;
                case Key.Space:
                    GameStart();
                    break;
                case Key.P:
                    GamePause();
                    break;
                default:
                    break;
            }
        }
    }
}