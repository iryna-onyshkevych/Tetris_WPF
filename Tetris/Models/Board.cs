using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Tetris.Models
{
    class Board
    {
        private int Rows;
        private int Columns;
        private int Score;
        private int Level;
        private bool gameEnd;
        private Tetrimino currTetrimino; 
        private Label[,] BlockControls; 
        static private Brush NoBrush = Brushes.Transparent; 
        static private Brush SilverBrush = Brushes.Gray; 

       
        public Board(Grid TetrisGrid)
        {
            Rows = TetrisGrid.RowDefinitions.Count;
            Columns = TetrisGrid.ColumnDefinitions.Count;
            Score = 0;
            Level = 1;
            gameEnd = false;

            BlockControls = new Label[Columns, Rows];
            for (int i = 0; i < Columns; i++)
            {
                for (int j = 0; j < Rows; j++)
                {
                    BlockControls[i, j] = new Label();
                    BlockControls[i, j].Background = NoBrush;
                    BlockControls[i, j].BorderBrush = SilverBrush;
                    BlockControls[i, j].BorderThickness = new Thickness(1, 1, 1, 1);
                    Grid.SetRow(BlockControls[i, j], j);
                    Grid.SetColumn(BlockControls[i, j], i);
                    TetrisGrid.Children.Add(BlockControls[i, j]);
                }
            }
            currTetrimino = new Tetrimino();
            currTetriminoDraw();
        }

      
        public int getScore()
        {
            return Score;
        }
        public int getLevel()
        {
            return Level;
        }
        public bool getGameEnd()
        {
            return gameEnd;
        }

        private void currTetriminoDraw()
        {
            Point Position = currTetrimino.getCurrPosition();
            Point[] Shape = currTetrimino.getCurrShape();
            Brush Color = currTetrimino.getCurrColor();
            foreach (Point S in Shape)
            {
                BlockControls[(int)(S.X + Position.X) + ((Columns / 2) - 1), (int)(S.Y + Position.Y) + 2].Background = Color;
            }
        }

        private void currTetriminoErase()
        {
            Point Position = currTetrimino.getCurrPosition();
            Point[] Shape = currTetrimino.getCurrShape();
            foreach (Point S in Shape)
            {
                BlockControls[(int)(S.X + Position.X) + ((Columns / 2) - 1), (int)(S.Y + Position.Y) + 2].Background = NoBrush;
            }
        }

        private void CheckRows()
        {
            bool full;
            for (int i = Rows - 1; i > 0; i--)
            {
                full = true;
                for (int j = 0; j < Columns; j++)
                {
                    if (BlockControls[j, i].Background == NoBrush)
                    {
                        full = false;
                    }
                }
                if (full)
                {
                    RemoveRow(i);
                    Score += 100;
                    if (Score % 100 == 0)
                    {
                        Level++;
                    }
                    CheckRows();
                }
            }
        }

      
        private void RemoveRow(int row)
        {
            for (int i = row; i > 0; i--)
            {
                for (int j = 0; j < Columns; j++)
                {
                    BlockControls[j, i].Background = BlockControls[j, i - 1].Background;
                }
            }
        }

        public void CurrTetriminoMoveLeft()
        {
            Point Position = currTetrimino.getCurrPosition();
            Point[] Shape = currTetrimino.getCurrShape();
            bool move = true;
            currTetriminoErase();
            foreach (Point S in Shape)
            {
                if (((int)(S.X + Position.X) + ((Columns / 2) - 1) - 1) < 0)
                {
                    move = false;
                }
                else if (BlockControls[((int)(S.X + Position.X) + ((Columns / 2) - 1) - 1), (int)(S.Y + Position.Y) + 2].Background != NoBrush)
                {
                    move = false;
                }
            }
            if (move)
            {
                currTetrimino.moveLeft();
                currTetriminoDraw();
            }
            else
            {
                currTetriminoDraw();
            }
        }

        public void CurrTetriminoMoveRight()
        {
            Point Position = currTetrimino.getCurrPosition();
            Point[] Shape = currTetrimino.getCurrShape();
            bool move = true;
            currTetriminoErase();
            foreach (Point S in Shape)
            {
                if (((int)(S.X + Position.X) + ((Columns / 2) - 1) + 1) >= Columns)
                {
                    move = false;
                }
                else if (BlockControls[((int)(S.X + Position.X) + ((Columns / 2) - 1) + 1), (int)(S.Y + Position.Y) + 2].Background != NoBrush)
                {
                    move = false;
                }
            }
            if (move)
            {
                currTetrimino.moveRight();
                currTetriminoDraw();
            }
            else
            {
                currTetriminoDraw();
            }
        }

     
        public void CurrTetriminoMoveDown()
        {
            Point Position = currTetrimino.getCurrPosition();
            Point[] Shape = currTetrimino.getCurrShape();
            bool move = true;
            currTetriminoErase();
            foreach (Point S in Shape)
            {
                Point x = new Point(0, 0);
                //Point y = new Point(0, 1);
                Point y = new Point(0, -1);


                if (((int)(S.Y + Position.Y) + 2 + 1) >= Rows)
                {
                    move = false;
                }
                else if (BlockControls[((int)(S.X + Position.X) + ((Columns / 2) - 1)), (int)(S.Y + Position.Y) + 2 + 1].Background != NoBrush && currTetrimino.getCurrPosition() == x)
                {
                    gameEnd = true;
                }
                else if (BlockControls[((int)(S.X + Position.X) + ((Columns / 2) - 1)), (int)(S.Y + Position.Y) + 3].Background != NoBrush && (currTetrimino.getCurrPosition() == y))
                {
                    gameEnd = true;
                }
                else if (BlockControls[((int)(S.X + Position.X) + ((Columns / 2) - 1)), (int)(S.Y + Position.Y) + 2 + 1].Background != NoBrush)
                {
                    move = false;
                }
            }
            if (move)
            {
                currTetrimino.moveDown();
                currTetriminoDraw();
            }
            else
            {
                currTetriminoDraw();
                CheckRows();
                currTetrimino = new Tetrimino();
            }
        }

        public void CurrTetriminoMoveRotate()
        {
            Point Position = currTetrimino.getCurrPosition();
            Point[] S = new Point[4];
            Point[] Shape = currTetrimino.getCurrShape();
            bool move = true;
            Shape.CopyTo(S, 0);
            currTetriminoErase();
            for (int i = 0; i < S.Length; i++)
            {
                double x = S[i].X;
                S[i].X = S[i].Y * -1;
                S[i].Y = x;
                if (((int)((S[i].Y + Position.Y) + 2)) >= Rows)
                {
                    move = false;
                }
                else if (((int)(S[i].X + Position.X) + ((Columns / 2) - 1)) < 0)
                {
                    move = false;
                }
                else if (((int)(S[i].X + Position.X) + ((Columns / 2) - 1)) >= Columns)
                {
                    move = false;
                }
                else if (BlockControls[((int)(S[i].X + Position.X) + ((Columns / 2) - 1)), (int)(S[i].Y + Position.Y) + 2].Background != NoBrush)
                {
                    move = false;
                }
            }
            if (move)
            {
                currTetrimino.moveRotate();
                currTetriminoDraw();
            }
            else
            {
                currTetriminoDraw();
            }
        }
    }
}

