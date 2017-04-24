using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MissionPlanner.Controls
{
    public partial class Rocker : UserControl
    {
        Bitmap backgroundIMG;
        bool drawnheading = false;
        public int mode = 0;

        int _rockerin1 = 1500;
        int _rockerin2 = 1500;
        int _rockerout1 = 1500;
        int _rockerout2 = 1500;

        [System.ComponentModel.Browsable(true)]
        public int rockerin1
        {
            get { return _rockerin1; }
            set { _rockerin1 = value; this.Invalidate(); }
        }

        [System.ComponentModel.Browsable(true)]
        public int rockerin2
        {
            get { return _rockerin2; }
            set { _rockerin2 = value; }
        }

        [System.ComponentModel.Browsable(true)]
        public int rockerout1
        {
            get { return _rockerout1; }
            set { _rockerout1 = value; this.Invalidate(); }
        }

        [System.ComponentModel.Browsable(true)]
        public int rockerout2
        {
            get { return _rockerout2; }
            set { _rockerout2 = value; }
        }

        /// <summary>
        /// Override to prevent offscreen drawing the control - mono mac
        /// </summary>
        public new void Invalidate()
        {
            if (Disposing)
                return;
            if (!ThisReallyVisible())
            {
                return;
            }

            base.Invalidate();
        }

        /// <summary>
        /// this is to fix a mono off screen drawing issue
        /// </summary>
        /// <returns></returns>
        public bool ThisReallyVisible()
        {
            //Control ctl = Control.FromHandle(this.Handle);
            return this.Visible;
        } 

        public Rocker()
        {
            InitializeComponent();

            backgroundIMG = new Bitmap(this.Width, this.Height);
            checkBox1.Location = new System.Drawing.Point(0, 0);
            checkBox2.Location = new System.Drawing.Point(Width - checkBox2.Width, 0);
            checkBox3.Location = new System.Drawing.Point(0, Height - checkBox3.Height);
            checkBox4.Location = new System.Drawing.Point(Width - checkBox4.Width, Height - checkBox4.Height);


        }

        private void modechange(object sender, EventArgs e)
        {
            mode++;
            if (mode == 2)
                mode = 0;

            if(mode == 1)
              lab_mode_text.Text = "飞翼";
            if (mode == 0)
                lab_mode_text.Text = "常规";
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            
            base.OnPaint(e);

            if (drawnheading == false || this.DesignMode)
            {
                backgroundIMG = new Bitmap(Width, Height);

                Graphics g = Graphics.FromImage(backgroundIMG);

                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bicubic;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                //Graphics g = e.Graphics;

                g.TranslateTransform(this.Width / 2, this.Height / 2);

                int font = this.Width / 14;

                g.ResetTransform();

                drawnheading = true;
            }

            if (mode == 1)
            {
                e.Graphics.TranslateTransform(-(float)Width / 6f, (float)Height / 1.9f);
                e.Graphics.RotateTransform(-45);
            }
            //e.Graphics.DrawImage(backgroundIMG, new Rectangle(-Width / 2, -Height / 2, Width, Height));

            int __rockerin1 = _rockerin1;
            int __rockerin2 = _rockerin2;
            int __rockerout1 = _rockerout1;
            int __rockerout2 = _rockerout2;

            int d = 1;
            if (checkBox1.Checked) d = -1; else d = 1;
            if (__rockerin1 < 1000) __rockerin1 = 1000; if (__rockerin1 > 2000) __rockerin1 = 2000;
            float ch1inpos = (float)(Height / 2) + ((float)(__rockerin1 - 1500) / 500.0f * (float)(Height / 2)) * d;
            if (checkBox2.Checked) d = -1; else d = 1;
            if (__rockerin2 < 1000) __rockerin2 = 1000; if (__rockerin2 > 2000) __rockerin2 = 2000;
            float ch2inpos = (float)(Width / 2) + ((float)(__rockerin2 - 1500) / 500.0f * (float)(Width / 2)) * d;

            
            e.Graphics.DrawEllipse(new Pen(Color.Red, 10), ch2inpos - 5, ch1inpos - 5, 10.0f, 10.0f);

            if (checkBox3.Checked) d = -1; else d = 1;
            if (__rockerout1 < 1000) __rockerout1 = 1000; if (__rockerout1 > 2000) __rockerout1 = 2000;
            float ch1outpos = (float)(Height / 2) + ((float)(__rockerout1 - 1500) / 500.0f * (float)(Height / 2)) * d;
            if (checkBox4.Checked) d = -1; else d = 1;
            if (__rockerout2 < 1000) __rockerout2 = 1000; if (__rockerout2 > 2000) __rockerout2 = 2000;
            float ch2outpos = (float)(Width / 2) + ((float)(__rockerout2 - 1500) / 500.0f * (float)(Width / 2)) * d;

            
            e.Graphics.DrawEllipse(new Pen(Color.Green, 10), ch2outpos - 5, ch1outpos - 5, 10.0f, 10.0f);
            //e.Graphics.TranslateTransform(0, 0);
            //e.Graphics.RotateTransform(0);
            if (mode == 1)
                lab_mode_text.Text = "飞翼";
            if (mode == 0)
                lab_mode_text.Text = "常规";

            label1.Text = rockerin1.ToString("0");
            label3.Text = rockerout1.ToString("0");
            label2.Text = rockerin2.ToString("0");
            label4.Text = rockerout2.ToString("0");
        }

        protected override void OnResize(EventArgs e)
        {
            Width = Height;
            base.OnResize(e);
            this.Invalidate();
            drawnheading = false;
            checkBox1.Location = new System.Drawing.Point(0, 0);
            checkBox2.Location = new System.Drawing.Point(Width - checkBox2.Width, 0);
            checkBox3.Location = new System.Drawing.Point(0, Height - checkBox3.Height);
            checkBox4.Location = new System.Drawing.Point(Width - checkBox4.Width, Height - checkBox4.Height);
            lab_mode_text.Location = new System.Drawing.Point(Width / 2 - lab_mode_text.Width / 2, Height / 2 - lab_mode_text.Height / 2); 

        }
    }
}
