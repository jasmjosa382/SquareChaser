﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Square Chaser Game
//November 2022
//Jasmine Josan
namespace SquareChaser
{
    public partial class Form1 : Form
    {
        Rectangle player1 = new Rectangle(100, 120, 20, 20);
        Rectangle player2 = new Rectangle(100, 250, 20, 20);
        Rectangle boundaries = new Rectangle(50, 40, 350, 330);
        Rectangle point = new Rectangle(200, 210, 10, 10);
        Rectangle speedUp = new Rectangle(210, 230, 10, 10);


        Pen cyanPen = new Pen(Color.Cyan, 8);
        SolidBrush blueBrush = new SolidBrush(Color.DodgerBlue);
        SolidBrush pinkBrush = new SolidBrush(Color.Pink);
        SolidBrush yellowBrush = new SolidBrush(Color.Yellow);
        SolidBrush limeBrush = new SolidBrush(Color.LightGreen);

        bool wDown = false;
        bool sDown = false;
        bool upArrowDown = false;
        bool downArrowDown = false;

        bool aDown = false;
        bool dDown = false;
        bool leftDown = false;
        bool rightDown = false;

        int playerTurn = 1;
        int player1Score = 0;
        int player2Score = 0;
        int playerSpeed = 4;
        int location;
        int x, y;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
                case Keys.A:
                    aDown = true;
                    break;
                case Keys.D:
                    dDown = true;
                    break;
                case Keys.Left:
                    leftDown = true;
                    break;
                case Keys.Right:
                    rightDown = true;
                    break;
            }

            }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
                case Keys.A:
                    aDown = false;
                    break;
                case Keys.D:
                    dDown = false;
                    break;
                case Keys.Left:
                    leftDown = false;
                    break;
                case Keys.Right:
                    rightDown = false;
                    break;
            }

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(blueBrush, player1);
            e.Graphics.FillRectangle(pinkBrush, player2);
            e.Graphics.DrawRectangle(cyanPen, boundaries);
            e.Graphics.FillRectangle(yellowBrush, point);
            e.Graphics.FillRectangle(limeBrush, speedUp);


        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            Random randGen = new Random();

            //move player 1
            if (wDown == true && player1.Y > 0)
            {
                player1.Y -= playerSpeed;
            }

            if (sDown == true && player1.Y < this.Height - player1.Height)
            {
                player1.Y += playerSpeed;
            }

            if (dDown == true && player1.X < this.Width - player1.Width)
            {
                player1.X += playerSpeed;
            }
            if (aDown == true && player1.X < this.Width - player1.Width)
            {
                player1.X -= playerSpeed;
            }

            //move player 2
            if (upArrowDown == true && player2.Y > 0)
            {
                player2.Y -= playerSpeed;
            }

            if (downArrowDown == true && player2.Y < this.Height - player2.Height)
            {
                player2.Y += playerSpeed; 
            }
            if (rightDown == true && player2.X < this.Width - player1.Width)
            {
                player2.X += playerSpeed;
            }
            if (leftDown == true && player2.X < this.Width - player2.Width) 
            {
                player2.X -= playerSpeed;
            }
            

            //Check if point was interacted with and move it
            if (player1.Y < 40 || player1.Y > this.Height - player1.Height)
            {
                player1.Y *= -1;
            }

            if (player1.X < 50 || player1.X > this.Width - player1.Width)
            {
                player1.X *= -1;
            }


            //player 1 intersects with point add 1 to player 1 points if so
            if (player1.IntersectsWith(point))
            {
                player1Score++;
                p2ScoreLabel.Text = $"{player1Score}";

                point.X = randGen.Next(x,y);
                point.Y = randGen.Next(x, y);
            }



            Refresh();
        }
    }
}
