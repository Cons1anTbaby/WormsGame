using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class Form1 : Form
    {
        Bitmap worm = Resource.worm1, ground = Resource.ground, bazooka = Resource.bazooka1;
        private bool IsBazookaFlipped = false;
        public static bool IsWormRotate = false;
        private int moveX;
        private int moveY;
        private Worm _worm = new Worm("mainWorm");
        private Drawer drawer;
        private bool IsJumped;
        private int JumpSpeed;
        private int v0 = -20;
        private int acl = 1;
        public static Graphics g { get; private set; }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public Form1()
        {
            InitializeComponent();

            SetStyle(ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.AllPaintingInWmPaint
                | ControlStyles.UserPaint, true);

            UpdateStyles();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
        }

        private void paint_form1(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            var _bazooka = new BAZOOKA("mainGun", bazooka, worm);
            var _map = new Map();
            drawer = new Drawer(g, _worm, _bazooka);

            _map.FillMap();
            drawer.DrawMap();
            drawer.DrawWorm(moveX, moveY);



            drawer.CalculateAngle(PointToClient(Cursor.Position), moveX);
            IsBazookaFlipped = drawer.DrawBazooka(g, moveX, ref IsBazookaFlipped);

            if (!IsWormRotate)
            {
                _worm.WormImage.RotateFlip(RotateFlipType.RotateNoneFlipX);
                IsWormRotate = true;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                moveX += 10;
            }
            if (e.KeyCode == Keys.Left)
            {
                moveX -= 10;
            }
            if (e.KeyCode == Keys.Up)
            {
                v0 += acl;
                _worm.LocalPosition.Y += v0;

                if (Map.Level[(_worm.LocalPosition.X + Map.InitialPosition.X) / Cell.Size, (_worm.LocalPosition.Y + Map.InitialPosition.Y + 1) / Cell.Size + 1] == MapCell.Ground) { v0 = 0; acl = 0; }
                //else _worm.LocalPosition.Y -= 10;
            }
            if (e.KeyCode == Keys.Down)
            {
                v0 = -20;
                acl = 1;
            }
        }
    }
}
