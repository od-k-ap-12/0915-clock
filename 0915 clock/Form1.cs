using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _0915_clock
{
    public partial class Form1 : Form
    {
        Pen clock;
        Pen secondarrow;
        Pen minutearrow;
        Pen hourarrow;
        Bitmap bmp;
        Bitmap bmp2;
        Graphics g;
        Graphics gr;
        Matrix mtr;
        float alpha;
        float alpha2;
        float alpha3;

        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            bmp2 = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(pictureBox1.Image = bmp);
            gr = Graphics.FromImage(pictureBox1.Image = bmp);
            mtr = new Matrix();

            float InitialArrowPlacement = -135;
            clock = new Pen(Color.Black, 10);
            secondarrow = new Pen(Color.Black, 2);
            minutearrow = new Pen(Color.Black, 4);
            hourarrow = new Pen(Color.Black, 6);
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            bmp2 = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            gr = Graphics.FromImage(pictureBox1.Image = bmp);
            gr.DrawEllipse(clock, 10, 10, 480, 480);
            gr.DrawEllipse(clock, 250, 250, 2, 2);

            pictureBox1.Image = bmp;
            alpha = InitialArrowPlacement+DateTime.Now.Second*6;
            mtr.Rotate(alpha);
            gr.Transform = mtr;
            gr.TranslateTransform(pictureBox1.Width / 2, pictureBox1.Height / 2, MatrixOrder.Append);
            gr.DrawLine(secondarrow, 0, 0, 100, 100);
            mtr.Reset();

            alpha2 = InitialArrowPlacement + DateTime.Now.Minute * 6;
            mtr.Rotate(alpha2);
            gr.Transform = mtr;
            gr.TranslateTransform(pictureBox1.Width / 2, pictureBox1.Height / 2, MatrixOrder.Append);
            gr.DrawLine(minutearrow, 0, 0, 100, 100);
            mtr.Reset();

            alpha3 = InitialArrowPlacement + DateTime.Now.Hour * 30 ;
            mtr.Rotate(alpha3);
            gr.Transform = mtr;
            gr.TranslateTransform(pictureBox1.Width / 2, pictureBox1.Height / 2, MatrixOrder.Append);
            gr.DrawLine(hourarrow, 0, 0, 100, 100);
            mtr.Reset();

            timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            label1.Text = String.Format("{0:D2}:{1:D2}:{2:D2}", dt.Hour, dt.Minute, dt.Second);
            gr.Clear(Color.White);

            clock = new Pen(Color.Black, 10);
            secondarrow = new Pen(Color.Black, 2);
            minutearrow = new Pen(Color.Black, 4);
            hourarrow = new Pen(Color.Black, 6);
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            bmp2 = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            gr = Graphics.FromImage(pictureBox1.Image = bmp);
            gr.DrawEllipse(clock, 10, 10, 480, 480);
            gr.DrawEllipse(clock, 250, 250, 2, 2);



            pictureBox1.Image = bmp;
            alpha += 6;
            mtr.Rotate(alpha);
            gr.Transform = mtr;
            gr.TranslateTransform(pictureBox1.Width / 2, pictureBox1.Height / 2, MatrixOrder.Append);
            gr.DrawLine(secondarrow, 0, 0, 100, 100);
            mtr.Reset();

            if (DateTime.Now.Second == 0)
            {
                alpha2 += 6;
            }
            mtr.Rotate(alpha2);
            gr.Transform = mtr;
            gr.TranslateTransform(pictureBox1.Width / 2, pictureBox1.Height / 2, MatrixOrder.Append);
            gr.DrawLine(minutearrow, 0, 0, 100, 100);
            mtr.Reset();

            if (DateTime.Now.Minute == 0)
            {
                alpha3 += 30;
            }
            mtr.Rotate(alpha3);
            gr.Transform = mtr;
            gr.TranslateTransform(pictureBox1.Width / 2, pictureBox1.Height / 2, MatrixOrder.Append);
            gr.DrawLine(hourarrow, 0, 0, 100, 100);
            mtr.Reset();


        }
    }
}
