﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using FinkiManEscape.Properties;


namespace FinkiManEscape
{
    public partial class Form1 : Form
    {
        Image slika;
        Game game;
        int dX, dY;
        bool moving;
        public Form1()
        {
            InitializeComponent();
            Figura f1 = new Figura(2, 2, 0, Figura.PORTRAIT);
            Figura f2 = new Figura(2, 0, 1, Figura.LANDSCAPE);
            Figura f3 = new Figura(2, 0, 2, Figura.PORTRAIT);
            Figura f4 = new Figura(2, 1, 2, Figura.LANDSCAPE);
            Figura f5 = new Figura(2, 1, 3, Figura.PORTRAIT);
            Figura f6 = new Figura(2, 2, 4, Figura.LANDSCAPE);
            Figura f7 = new Figura(2, 3, 1, Figura.PORTRAIT);
            Figura f8 = new Figura(3, 3, 0, Figura.LANDSCAPE);
            Figura f9 = new Figura(3, 4, 2, Figura.PORTRAIT);
            Figura f10 = new Figura(2, 3, 5, Figura.LANDSCAPE);
            Figura f11 = new Figura(2, 5, 1, Figura.PORTRAIT);
            Figura f12 = new Figura(2, 5, 3, Figura.PORTRAIT);
            Student s = new Student(1, 0, 0, Figura.LANDSCAPE, true);
            Figura[] f = new Figura[13];
            f[0] = f1;
            f[1] = f2;
            f[2] = f3;
            f[3] = f4;
            f[4] = f5;
            f[5] = f6;
            f[6] = f7;
            f[7] = f8;
            f[8] = f9;
            f[9] = f10;
            f[10] = f11;
            f[11] = f12;
            f[12] = s;
            game = new Game(f);
            
            dX = dY = 0;
            moving = false;
          
            DoubleBuffered = true;
            
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (!game.prepareMove(e.X, e.Y))
            {
                return;
            }
            dX = e.X;
            dY = e.Y;
            moving = true;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (moving)
            {
                int dy, dx;
                dx = e.X - dX;
                dy = (e.Y - dY);
                dX = e.X;
                dY = e.Y;
                if (game.moveCurrent(dx, dy))
                {
                    Invalidate();
                }
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (moving)
            {
                while (game.adjust())
                {
                    Invalidate();
                }
                game.finishMove();
               // Invalidate();
                moving = false;
            }
            dX = dY = 0;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            game.draw(e.Graphics);
            e.Graphics.DrawRectangle(new Pen(Color.Black), new Rectangle(0, 0, 605, 605));
        }
        

    }
}
