using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Map
    {
        //Graphics g;
        readonly Bitmap ground = Resource.ground;
        public static Image Background { get; private set; }
        public static MapCell[,] Level { get; private set; }
        public static Point InitialPosition { get; private set; }

        string pattern = @"
XXXXXXXXXXXXXXXXXXXXX
XXXXXXXXXXXXXXXXXXXXX
                    |
                    |
             XXXXX  |
         XX         X
XXXXXXX             X
                    X
XXXXXXXXXXXXXXXXXXXXX
XXXXXXXXXXXXXXXXXXXXX
XXXXXXXXXXXXXXXXXXXXX";

        public Map()
        {
            Background = Resource.background;
            //g = Form1.g;
            InitialPosition = new Point(500, Background.Height / 2 - 30);
        }

        public void FillMap()
        {
            var lines = pattern.Split(new[] { "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            Level = new MapCell[lines[0].Length, lines.Length];
            for (var i = 0; i < lines.Length; i++)
                for (var j = 0; j < lines[0].Length; j++)
                {
                    switch (lines[i][j])
                    {
                        case 'X':
                            Level[j, i] = MapCell.Ground;
                            break;
                        default:
                            Level[j, i] = MapCell.Empty;
                            break;
                    }
                }
        }

        public static bool IsEmpty(int x, int y)
        {
            return Level[x / 76, y / 76] == MapCell.Empty;
        }

        //public void DrawMap()
        //{
        //    for (var i = 0; i < Level.GetLength(1); i++)
        //        for (var j = 0; j < Level.GetLength(0); j++)
        //        {
        //            switch (Level[j, i])
        //            {
        //                case MapCell.Ground:
        //                    g.DrawImage(ground, j * Cell.Size, i * Cell.Size, Cell.Size, Cell.Size);
        //                    break;
        //                default:
        //                    continue;
                            
        //            }
        //        }
        //}
    }
}

