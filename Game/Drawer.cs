using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Drawer
    {
        private Graphics g;
        private Worm worm;
        private BAZOOKA bazooka;
        public double angle { get; private set; }


        public Drawer(Graphics g, Worm worm, BAZOOKA bazooka)
        {
            this.worm = worm;
            this.bazooka = bazooka;
            this.g = g; 
        }

        public void DrawWorm(int moveX, int moveY)
        {
            g.DrawImage(worm.WormImage, new Rectangle(worm.LocalPosition.X + Map.InitialPosition.X + moveX, worm.LocalPosition.Y + Map.InitialPosition.Y + moveY, Cell.Size, Cell.Size));
        }

        public void CalculateAngle(Point localPosition, int move)
        {
            angle = Math.Atan2(localPosition.Y - Map.InitialPosition.Y - worm.LocalPosition.Y, localPosition.X - Map.InitialPosition.X - worm.LocalPosition.X - move) * 180 / Math.PI;
        }


        public bool DrawBazooka(Graphics g, int move, ref bool IsBazookaFlipped)
        {
            //var angle = CalculateAngle(worm.LocalPosition, move);
            g.TranslateTransform(worm.LocalPosition.X + Map.InitialPosition.X + Cell.Size / 2 + move, worm.LocalPosition.Y + Map.InitialPosition.Y + Cell.Size / 2);
            g.RotateTransform((float)angle);
            if (!IsBazookaFlipped && Math.Abs(angle) % 360 > 90 && Math.Abs(angle) % 360 < 180)
            {
                worm.WormImage.RotateFlip(RotateFlipType.RotateNoneFlipX);
                bazooka.Image.RotateFlip(RotateFlipType.RotateNoneFlipY);
                return IsBazookaFlipped = true;
            }
            if (IsBazookaFlipped && (Math.Abs(angle) % 360 > 270 || Math.Abs(angle) < 90))
            {
                worm.WormImage.RotateFlip(RotateFlipType.RotateNoneFlipX);
                bazooka.Image.RotateFlip(RotateFlipType.RotateNoneFlipY);
                return IsBazookaFlipped = false;
            }

            //отрисовка пушки
            if (IsBazookaFlipped) g.DrawImage(bazooka.Image, -bazooka.Image.Width / 2, -bazooka.Image.Width / 2);
            else g.DrawImage(bazooka.Image, -bazooka.Image.Width / 2, -bazooka.Image.Height / 2);

            //вспомогательный прямоугольник
            var p = new Pen(Color.Aquamarine);
            g.DrawRectangle(p, bazooka.Barrel.X, bazooka.Barrel.Y, bazooka.Image.Width, bazooka.Image.Height);

            return IsBazookaFlipped;
        }

        public void DrawMap()
        {
            for (var i = 0; i < Map.Level.GetLength(1); i++)
                for (var j = 0; j < Map.Level.GetLength(0); j++)
                {
                    switch (Map.Level[j, i])
                    {
                        case MapCell.Ground:
                            g.DrawImage(Resource.ground, j * Cell.Size, i * Cell.Size, Cell.Size, Cell.Size);
                            break;
                        default:
                            continue;

                    }
                }
        }

        public void Jump(int vX, int vY)
        {
            var x = worm.LocalPosition.X + Cell.Size / 2 + vX;
            var y = worm.LocalPosition.Y + Cell.Size / 2;
            vY -= 1;
            y -= vY;
        }

        //public void DrawAll()
        //{
        //    DrawMap();
        //    DrawWorm();
        //    DrawBazooka();
        //}
    }
}
