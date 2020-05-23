using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Worm
    {
        //Graphics g;

        public string Name { get; private set; }
        public Bitmap WormImage { get; private set; }
        public Point LocalPosition;

        public Worm(string name)
        {
            Name = name;
            WormImage = Resource.worm1;
            //g = Form1.g;
            LocalPosition = Map.InitialPosition;
        }

        //public void DrawWorm()
        //{
        //    g.DrawImage(WormImage, new Rectangle(LocalPosition.X, LocalPosition.Y, Cell.Size, Cell.Size));
        //}

        //public void DrawWorm(int moveX, int moveY)
        //{
        //    g.DrawImage(WormImage, new Rectangle(LocalPosition.X + moveX, LocalPosition.Y + moveY, Cell.Size, Cell.Size));
        //}
    }
}
