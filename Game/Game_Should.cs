using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    [TestFixture]
    class Game_Should
    {
        [Test]
        public void Test1()
        {
            var _map = new Map();
            _map.FillMap();
            Assert.AreEqual(Map.Level[0, 0], MapCell.Ground);
        }

        [Test]
        public void Test2()
        { 
            var _worm = new Worm("test");
            var drawer = new Drawer(default(Graphics), _worm, default(BAZOOKA));
            drawer.CalculateAngle(new Point(_worm.LocalPosition.X + Map.InitialPosition.X, _worm.LocalPosition.Y + Map.InitialPosition.Y), 0);
            Assert.AreEqual(drawer.angle, 0);
        }
    }
}
