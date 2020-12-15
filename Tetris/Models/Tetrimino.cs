using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Tetris.Models
{
    class Tetrimino
    {
        private Point currPosition; // поточна позиція блоку
        private Point[] currShape; // форма блоку як масив точок
        private Brush currColor; // колір тетріміно
        private bool rotate;

     
        public Tetrimino()
        {
            currPosition = new Point(0,-1);
            currColor = Brushes.Transparent;
            currShape = setRandomShape();
        }


        public Brush getCurrColor()
        {
            return currColor;
        }
        public Point getCurrPosition()
        {
            return currPosition;
        }
        public Point[] getCurrShape()
        {
            return currShape;
        }

        // Методи для зміщення тетріміно
        public void moveLeft()
        {
            currPosition.X -= 1;
        }
        public void moveRight()
        {
            currPosition.X += 1;
        }
        public void moveDown()
        {
            currPosition.Y += 1;
        }
        public void moveRotate() //повертаємо тетріміно
        {
            if (rotate)
            {
                for (int i = 0; i < currShape.Length; i++)
                {
                    double x = currShape[i].X;
                    currShape[i].X = currShape[i].Y * -1;
                    currShape[i].Y = x;
                }
            }
        }

        // 7 різних форм
        private Point[] setRandomShape()
        {
            Random rand = new Random();
            switch (rand.Next() % 7)
            {
                case 0:// I
                    rotate = true;
                    currColor = Brushes.Cyan;
                    return new Point[]
                    {
                        new Point(0,-1),
                        new Point(-1,-1),
                        new Point(1,-1),
                        new Point(2,-1)

                    };
                case 1://J
                    rotate = true;
                    currColor = Brushes.Blue;
                    return new Point[]
                    {
                        new Point(-1,-1),
                        new Point(-1,0),
                        new Point(0,0),
                        new Point(1,0)
                    };
                case 2://L
                    rotate = true;
                    currColor = Brushes.Orange;
                    return new Point[]
                    {
                        new Point(0,0),
                        new Point(-1,0),
                        new Point(1,0),
                        new Point(1,-1)
                    };
                case 3://O
                    rotate = false;
                    currColor = Brushes.Yellow;
                    return new Point[]
                    {
                        new Point(0,0),
                        new Point(0,-1),
                        new Point(1,0),
                        new Point(1,-1)

                    };
                case 4://S
                    rotate = true;
                    currColor = Brushes.Green;
                    return new Point[]
                    {
                        new Point(0,0),
                        new Point(-1,0),
                        new Point(0,-1),
                        new Point(1,0)
                    };
                case 5://T
                    rotate = true;
                    currColor = Brushes.Purple;
                    return new Point[]
                    {
                        new Point(0,0),
                        new Point(-1,0),
                        new Point(0,-1),
                        new Point(1,-1)

                    };
                case 6://Z
                    rotate = true;
                    currColor = Brushes.Red;
                    return new Point[]
                    {
                        new Point(0,-1),
                        new Point(-1,-1),
                        new Point(0,0),
                        new Point(1,0)

                    };
                default:
                    return null;
            }
        }
    }
}

