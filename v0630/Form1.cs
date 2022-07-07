using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace v0630
{
    public partial class Form1 : Form
    {
        static int charmax => 100;
        int[] vx = new int[charmax];
        int[] vy = new int[charmax];
        Label[] labels = new Label[charmax];
        //清的=最初に決めておく <> 動的=実行時に変更可能
        static Random rand = new Random();

        public Form1()
        {
            InitializeComponent();
            /*for (int ii = 0; ii < 3; ii++)
                MessageBox.Show($"{ii}");*/
            for(int i=0;i< charmax; i++)
            {
                vx[i] = rand.Next(-10, 11);
                vy[i] = rand.Next(-10, 11);
            
                labels[i] = new Label();
                labels[i].AutoSize = true;
                labels[i].Text = "★";
                Controls.Add(labels[i]);

                labels[i].Left = rand.Next(ClientSize.Width - labels[i].Width);
                labels[i].Top = rand.Next(ClientSize.Height - labels[i].Height);
            }

            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i< charmax; i++)
            {
                labels[i].Left += vx[i];
                labels[i].Top += vy[i];
                if (labels[i].Left < 0)
                    vx[i] = Math.Abs(vx[i]);
                if (labels[i].Top < 0)
                    vy[i] = Math.Abs(vy[i]);
                if (labels[i].Right > ClientSize.Width)
                    vx[i] = -Math.Abs(vx[i]);
                if (labels[i].Bottom > ClientSize.Height)
                    vy[i] = -Math.Abs(vy[i]);
            }
            

            Point spos = MousePosition;
            Point fpos = PointToClient(spos);
            label2.Left = fpos.X - label2.Width / 2;
            label2.Top = fpos.Y - label2.Height / 2;

            for(int i=0;i< charmax; i++)
            {
                if ((labels[i].Left <= fpos.X)
                    && (labels[i].Top <= fpos.Y)
                    && (labels[i].Right >= fpos.X)
                    && (labels[i].Bottom >= fpos.Y))
                    labels[i].Visible = false;
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            checkBox1.Text = "kawaii!!!";
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
