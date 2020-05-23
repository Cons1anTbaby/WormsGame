using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Game
{
    class Trajectory
    {
        public Vector Direction { get; private set; }
        private double angle;

        public Trajectory(Vector vector, double angle)
        {
            Direction = vector;
            this.angle = angle;
        }

        public static PointF[] GetTraectory(double angle)
        {
            var quality = 10;
            var g = -9.8;
            var velocity = 200;
            var yVel = -velocity * Math.Sin(angle) / quality;
            var xVel = velocity * Math.Cos(angle) / quality;
            var list = new List<PointF>();
            var x = 0.0;
            var y = 0.0;
            while(y <= 0)
            {
                y += yVel;
                x += xVel;
                yVel -= g / quality;
                list.Add(new PointF((float)x + 1, (float)y + 1));
            } 
            return list.ToArray();
        }
    }
}
