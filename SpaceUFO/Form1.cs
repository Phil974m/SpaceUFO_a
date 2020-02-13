using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceUFO
{
    public partial class SpaceUFO : Form

    { 
        PictureBox[] stars;
        PictureBox[] munitions;

        int backgroundspeed;
        int PlayerSpeed;
        int MunitionsSpeed;

        Random rnd;

        public SpaceUFO()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            backgroundspeed = 6;
            stars = new PictureBox[15];
            rnd = new Random();
            PlayerSpeed = 4;
            MunitionsSpeed = 20;
            munitions = new PictureBox[3];

            //Loads image of the flare getting out the spaceship when press fire
            Image munition = Image.FromFile(@"pics\fire.png");
            for (int i = 0; i < munitions.Length; i++)
            {
                munitions[i] = new PictureBox();
                munitions[i].Size = new Size(15,15);
                munitions[i].Image = munition;
                munitions[i].SizeMode = PictureBoxSizeMode.Zoom;
                munitions[i].BorderStyle = BorderStyle.None;
                this.Controls.Add(munitions[i]);
            }

            for ( int i = 0; i <stars.Length; i++)
            {
                stars[i] = new PictureBox();
                stars[i].BorderStyle = BorderStyle.None;
                stars[i].Location = new Point(rnd.Next(20, 800), rnd.Next(-10, 400));

                if (i%2 == 1)
                {
                    stars[i].Size = new Size(2, 2);
                    stars[i].BackColor = Color.Wheat;
                }
                else
                {
                    stars[i].Size = new Size(3, 3);
                    stars[i].BackColor = Color.DarkGray;
                }
                this.Controls.Add(stars[i]);
            }
        }

        private void Move_Bg_Timer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i<stars.Length/2; i++)
            {

                stars[i].Top += backgroundspeed;
                if  (stars[i].Top > this.Height)
                {
                    stars[i].Top = -stars[i].Height;
                }
            }

            for (int i = stars.Length /2; i <stars.Length ; i++)
            {
                stars[i].Top += backgroundspeed-2;
                if (stars[i].Top > this.Height)
                {
                    stars[i].Top = -stars[i].Height;
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        private void UpdateMoveTimer_Tick(object sender, EventArgs e)
        {

        }

        private void RightMoveTimer_Tick(object sender, EventArgs e)
        {
            if (Player.Right < 780)
            {
                Player.Left += PlayerSpeed;
            }
        }

        private void LeftMoveTimer_Tick(object sender, EventArgs e)
        {
            if (Player.Left > 10)
            {
                Player.Left -= PlayerSpeed;
            }
        }

        private void DownMoveTimer_Tick(object sender, EventArgs e)
        {
            if (Player.Top < 500)
            {
                Player.Top += PlayerSpeed;
            }
        }

        private void UpMoveTimer_Tick(object sender, EventArgs e)
        {
            if (Player.Top > 10)
            {
                Player.Top -= PlayerSpeed;
            }
        }

        private void SpaceUFO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                RightMoveTimer.Start();
            }

            if (e.KeyCode == Keys.Left)
            {
                LeftMoveTimer.Start();
            }

            if (e.KeyCode == Keys.Down)
            {
                DownMoveTimer.Start();
            }

            if (e.KeyCode == Keys.Up)
            {
                UpMoveTimer.Start();
            }


        }

        private void SpaceUFO_KeyUp(object sender, KeyEventArgs e)
        {
            RightMoveTimer.Stop();
            LeftMoveTimer.Stop();
            DownMoveTimer.Stop();
            UpMoveTimer.Stop();
        }

        private void MoveMunitionTimer_Tick(object sender, EventArgs e)
        {
            for (int i=0; i < munitions.Length; i++)
            {
                if (munitions[i].Top > 0)
                {
                    munitions[i].Visible = true;
                    munitions[i].Top  -= MunitionsSpeed;
                }
                else
                {
                    munitions[i].Visible = false;
                    munitions[i].Location = new Point(Player.Location.X + 20, Player.Location.Y - i * 30);
                }
            }
        }
    }
}
