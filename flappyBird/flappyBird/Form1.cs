using System;  
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace flappyBird
{
    public partial class Form1 : Form
    {

        int pipeSpeed = 8;
        int gravity = 15;
        int score = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            flappyBird.Top += gravity;
            pipeBottom.Left -= pipeSpeed;
            pipeBottom1.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            pipeTop1.Left -= pipeSpeed;
            ScoreText.Text = "Score: " + score;
            if (pipeBottom.Left < -150)
            {
                pipeBottom.Left = 800;
                score++;
            }
            if(pipeTop.Left < -180)
            {
                pipeTop.Left = 950;
                score++;
            }
            if (pipeBottom1.Left < -150)
            {
                pipeBottom1.Left = 800;
                score++;
            }
            if (pipeTop1.Left < -180)
            {
                pipeTop1.Left = 950;
                score++;
            }

            if (flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) ||
                flappyBird.Bounds.IntersectsWith(pipeBottom1.Bounds) ||
                flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                flappyBird.Bounds.IntersectsWith(pipeTop1.Bounds) ||
                flappyBird.Bounds.IntersectsWith(ground.Bounds)
                )
            {
                endGame();
            }

        }

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {

            if(e.KeyCode == Keys.Space)
            {
                gravity = -15;
            }

        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 15;
            }

        }

        private void pipeTop_Click(object sender, EventArgs e)
        {

        }

        private void endGame()
        {
            gameTimer.Stop();
            ScoreText.Text += "Game over!!!";
        }
    }
}
