using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

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
        SolidBrush coralBrush = new SolidBrush(Color.Coral);
        SolidBrush limeBrush = new SolidBrush(Color.LightGreen);

        bool wDown = false;
        bool sDown = false;
        bool upArrowDown = false;
        bool downArrowDown = false;

        bool aDown = false;
        bool dDown = false;
        bool leftDown = false;
        bool rightDown = false;

        int player1Score = 0;
        int player2Score = 0;
        int player1Speed = 4;
        int player2Speed = 4;
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
            e.Graphics.FillRectangle(limeBrush, point);
            e.Graphics.FillRectangle(coralBrush, speedUp);


        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            Random randGen = new Random();

            //move player 1
            if (wDown == true && player1.Y > 47)
            {
                player1.Y -= player1Speed;
            }

            if (sDown == true && player1.Y < 345)
            {
                player1.Y += player1Speed;
            }

            if (dDown == true && player1.X < 375)
            {
                player1.X += player1Speed;
            }
            if (aDown == true && player1.X > 55)
            {
                player1.X -= player1Speed;
            }

            //move player 2
            if (upArrowDown == true && player2.Y > 45)
            {
                player2.Y -= player2Speed;
            }

            if (downArrowDown == true && player2.Y < 345)
            {
                player2.Y += player2Speed; 
            }
            if (rightDown == true && player2.X < 375)
            {
                player2.X += player2Speed;
            }
            if (leftDown == true && player2.X > 55)  
            {
                player2.X -= player2Speed;
            }


            //if either player intersects with point add 1 to player points 
            if (player1.IntersectsWith(point))
            {
                player1Score++;
                p2ScoreLabel.Text = $"{player1Score}";

                point.X = randGen.Next(60, 365);
                point.Y = randGen.Next(60, 365);
                SoundPlayer pointUp = new SoundPlayer(Properties.Resources.pointUp);
                pointUp.Play();
            }

            if (player2.IntersectsWith(point))
            {
                player2Score++;
                p2ScoreLabel.Text = $"{player2Score}";

                point.X = randGen.Next(60, 365);
                point.Y = randGen.Next(60, 365);
                SoundPlayer pointUp = new SoundPlayer(Properties.Resources.pointUp);
                pointUp.Play();
            }

            //if either player intersects with speed up increase speed by 1
            if (player1.IntersectsWith(speedUp))
            {
                player1Speed++;

                speedUp.X = randGen.Next(60, 365);
                speedUp.Y = randGen.Next(60, 365);
                SoundPlayer speed = new SoundPlayer(Properties.Resources.speed);
                speed.Play();
            }

            if (player2.IntersectsWith(speedUp))
            {
                player2Speed++;

                speedUp.X = randGen.Next(60, 365);
                speedUp.Y = randGen.Next(60, 365);
                SoundPlayer speed = new SoundPlayer(Properties.Resources.speed);
                speed.Play();
            }

            // check score and stop game if either player is at 5 points
            if (player1Score == 5)
            {
                gameTimer.Enabled = false;
                winLabel.Visible = true;
                winLabel.Text = "Player 1 Wins!!";
                SoundPlayer win = new SoundPlayer(Properties.Resources.win);
                win.Play();
            }
            else if (player2Score == 5)
            {
                gameTimer.Enabled = false;
                winLabel.Visible = true;
                winLabel.Text = "Player 2 Wins!!";
                SoundPlayer win = new SoundPlayer(Properties.Resources.win);
                win.Play();
            }



            Refresh();
        }
    }
}
