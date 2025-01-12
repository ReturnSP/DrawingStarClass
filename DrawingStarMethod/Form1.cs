﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DrawingStarMethod
{
    public partial class Form1 : Form
    {

        List<Star> starList = new List<Star>();
        Random randGen = new Random();

        public Form1()
        {
            InitializeComponent();

        }

        private void starTimer_Tick(object sender, EventArgs e)
        {
            foreach (Star s in starList)
            {
                s.Move();
                //s.rotateStar();
                //s.Move();
                //s.rotateStar();

            }

            for (int i = 0; i < 20; i++)
            {
                int funnyMultiplier = 1500; 
                float size = randGen.Next(10, 60);
                float x = randGen.Next(0, funnyMultiplier  * Convert.ToInt16(size));
                float y = randGen.Next(0, funnyMultiplier * Convert.ToInt16(size));
                float speed = randGen.Next(1, 5);

                //Color Change
                for (int j = 0; j < 25; j++)
                {
                    int val1 = randGen.Next(0, 255);
                    val1++;
                    int val2 = randGen.Next(0, 255);
                    val2++;
                    int val3 = randGen.Next(0, 255);
                    val3++;
                    int val4 = randGen.Next(0, 255);
                    val4++;
                    int val5 = randGen.Next(0, 255);
                    val5++;
                    int val6 = randGen.Next(0, 255);
                    val6++;
                    int val7 = randGen.Next(0, 255);
                    val7++;
                    int val8 = randGen.Next(0, 255);
                    val8++;

                    Color.FromArgb(val1, val2, val3, val4);
                    Pen rainbowPen = new Pen(Color.FromArgb(val1, val2, val3, val4));
                    Brush rainbowBrush = new SolidBrush(Color.FromArgb(val5, val6, val7, val8));


                    Star newStar = new Star(rainbowPen, rainbowBrush, x, y, size, speed);
                    starList.Add(newStar);
                }
            }
            Refresh();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Star s in starList)
            {
                e.Graphics.DrawPolygon(s.starPen, s.starPoints);
                e.Graphics.FillPolygon(s.starBrush, s.starPoints);
                
                e.Graphics.RotateTransform(50);
            }
        }
    }
}
