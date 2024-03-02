using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingStarMethod
{
    internal class Star
    {
        public Pen starPen;
        public Brush starBrush;

        public float x;
        public float y;
        public float speed;
        public double rotation = 0;

        public float size;
        public float scale;
        public PointF objectAxis = new PointF(0,0);
        public static List<Star> starList = new List<Star>();

        public PointF[] starPoints = new PointF[10];
        public PointF[] pointList = new PointF[10];

        //Constructor Method
        public Star(Pen _starPen, Brush _starBrush, float _x, float _y, float _size, float _speed)
        {
            starPen = _starPen;
            x = _x;
            y = _y;
            size = _size;
            speed = _speed;
            starBrush = _starBrush;


            //FindStarPoints();
            //GeneratePoints(15, 25);
            //Rotation();

            SetPoints();
        }
        public void FindStarPoints()
        {
            for (int i = 0; i < pointList.Length; i++)
            {

                float scale = size / 206;
                pointList[i] = GeneratePoints(((2 * Math.PI / pointList.Length) * (i)) + rotation, scale);
            }
        }
        PointF GeneratePoints(double theta, double radius)
        {
            float pointX = (float)((radius * Math.Cos(theta) + objectAxis.X));
            float pointY = (float)((radius * Math.Sin(theta) + objectAxis.Y));
        return (new PointF(pointX, pointY));
        }
        public void Rotation()
        {
            rotation += 0.01;
        }



        private void SetPoints()
        {

            float scale = size / 206;

            starPoints[0] = new PointF(0 * scale + x * speed, 74 * scale + y * speed);
            starPoints[1] = new PointF(79 * scale + x * speed, 74 * scale + y * speed);
            starPoints[2] = new PointF(103 * scale + x * speed, 0 * scale + y * speed);
            starPoints[3] = new PointF(127 * scale + x * speed, 74 * scale + y * speed);
            starPoints[4] = new PointF(206 * scale + x * speed, 74 * scale + y * speed);
            starPoints[5] = new PointF(142 * scale + x * speed, 122 * scale + y * speed);
            starPoints[6] = new PointF(166 * scale + x * speed, 196 * scale + y * speed);
            starPoints[7] = new PointF(103 * scale + x * speed, 150 * scale + y * speed);
            starPoints[8] = new PointF(39 * scale + x * speed, 196 * scale + y * speed);
            starPoints[9] = new PointF(64 * scale + x * speed, 122 * scale + y * speed);
        }
        private void Scatter()
        {
            x *= -6;
            x*= -2;
        }
        public void Move()
        {
            x += 6;
            y += 2;

            if (x > 800)
            {
                x = -50;
                //Scatter();
            }
            if (y > 800)
            {
                y = -50;
                //Scatter();
            }
            SetPoints();
        }
        public void starBlink()
        {
            //try and get most things into the class
        }
    }
}
