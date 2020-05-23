using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class BAZOOKA
    {
        //private readonly Graphics g;

        public string Name { get; private set; }
        public Bitmap Image { get; set; }
        public Point Barrel;
        private Bitmap worm;
        private double angle;

        public BAZOOKA(string name, Bitmap image, Bitmap wormBase)
        {
            Name = name;
            Image = image;
            worm = wormBase;
            //g = Form1.g;
            Barrel = new Point(Image.Width, 5);
        }

        //public void CalculateAngle(Point localPosition, int move)
        //{
        //    angle = Math.Atan2(localPosition.Y - Worm.LocalPosition.Y, localPosition.X - Worm.LocalPosition.X - move) * 180 / Math.PI;
        //}


        //public bool DrawBazooka(Graphics g, int move, ref bool IsBazookaFlipped)
        //{
        //    g.TranslateTransform(Worm.LocalPosition.X + Cell.Size / 2 + move, Worm.LocalPosition.Y + Cell.Size / 2);
        //    g.RotateTransform((float)angle);
        //    if (!IsBazookaFlipped && Math.Abs(angle) % 360 > 90 && Math.Abs(angle) % 360 < 180)
        //    {
        //        worm.RotateFlip(RotateFlipType.RotateNoneFlipX);
        //        Image.RotateFlip(RotateFlipType.RotateNoneFlipY);
        //        return IsBazookaFlipped = true;
        //    }
        //    if (IsBazookaFlipped && (Math.Abs(angle) % 360 > 270 || Math.Abs(angle) < 90))
        //    {
        //        worm.RotateFlip(RotateFlipType.RotateNoneFlipX);
        //        Image.RotateFlip(RotateFlipType.RotateNoneFlipY);
        //        return IsBazookaFlipped = false;
        //    }

        //    //отрисовка пушки
        //    if (IsBazookaFlipped) g.DrawImage(Image, -Image.Width / 2, -Image.Width / 2);
        //    else g.DrawImage(Image, -Image.Width / 2, -Image.Height / 2);

        //    //вспомогательный прямоугольник
        //    var p = new Pen(Color.Aquamarine);
        //    g.DrawRectangle(p, Barrel.X, Barrel.Y, Image.Width, Image.Height);

        //    return IsBazookaFlipped;
        //}
    }
}
