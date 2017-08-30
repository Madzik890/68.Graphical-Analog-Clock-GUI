using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Analog;

namespace Analog_Clock
{
    public partial class Form1 : Form
    {
        private bool stop_clock = false;//variable for turn off or on clock
        private Clock clock = new Clock();

        public Form1()
        {
            InitializeComponent();
            ////////////////creating clock/////////////////////////
            clock.hands.Add(new Clock.Hand(new Vector.vector2(155, 130), Color.Red, 2, 100));//seconds lead
            clock.hands.Add(new Clock.Hand(new Vector.vector2(155, 130), Color.Black, 3, 100));//minutes lead
            clock.hands.Add(new Clock.Hand(new Vector.vector2(155, 130), Color.Black, 3, 70));//hour lead
            MoveClockHands();
            ////////////////creating clock/////////////////////////

            timer1.Start();
        }

        private void Display(object sender, PaintEventArgs e)
        {
            label1.Location = new Point((this.Size.Width - label1.Size.Width) / 2,label1.Location.Y);
            clock.Draw(e);//drawing clock
        }

        private void MoveClockHands()//moving hands of clock
        {
            clock.hands[0].rotation = DateTime.Now.Second * 6;//360 : 60 = 6
            clock.hands[1].rotation = DateTime.Now.Minute * 6;//6 * x = angel
            clock.hands[2].rotation = DateTime.Now.Hour * 30;//360 : 12 = 30 30 * x = angel
            if (label1.Visible)
                label1.Text = DateTime.Now.ToString();
            this.Refresh();//redrawing a clock
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(!stop_clock)
                MoveClockHands();
        }

        private void showTimeToolStripMenuItem_Click(object sender, EventArgs e)//starting clock
        {
            stop_clock = false;
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)//stopping clock
        {
            stop_clock = true;
        }

        private void showTimeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (label1.Visible)
                label1.Visible = false;
            else
                label1.Visible = true;
            showTimeToolStripMenuItem1.Checked = label1.Visible;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)//closing app
        {
            this.Close();
        }
        /// <summary>
        /// changing color of
        /// </summary>
        private void watchToolStripMenuItem_Click(object sender, EventArgs e)//watch face
        {
            InputColor form = new InputColor();
            form.Show(clock,InputColor.PartClock.face);          
        }

        private void secondsToolStripMenuItem_Click(object sender, EventArgs e)//seconds clock hands
        {
            InputColor form = new InputColor();
            form.Show(clock, InputColor.PartClock.seconds_hand);
        }

        private void minuteToolStripMenuItem_Click(object sender, EventArgs e)//minutes clock hands
        {
            InputColor form = new InputColor();
            form.Show(clock, InputColor.PartClock.minutes_hand);
        }

        private void hoursToolStripMenuItem_Click(object sender, EventArgs e)//hours clock hands
        {
            InputColor form = new InputColor();
            form.Show(clock, InputColor.PartClock.hours_hand);
        }

        private void alwaysTopToolStripMenuItem_Click(object sender, EventArgs e)//setting always top for window
        {
            if (this.TopMost)
                this.TopMost = false;
            else
                this.TopMost = true;

            alwaysTopToolStripMenuItem.Checked = this.TopMost;
        }
    }
}
