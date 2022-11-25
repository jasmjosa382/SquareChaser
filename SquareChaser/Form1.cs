using System;
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
        Rectangle player1 = new Rectangle(10, 120, 10, 60);
        Rectangle player2 = new Rectangle(10, 250, 10, 60);
        public Form1()
        {
            InitializeComponent();
        }
    }
}
