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
        private Clock clock = new Clock();

        public Form1()
        {
            InitializeComponent();
            ////////////////creating clock/////////////////////////
            clock.hands.Add(new Clock.Hand(new Vector.vector2(165, 150), Color.Red, 2, 100));//seconds lead
            clock.hands.Add(new Clock.Hand(new Vector.vector2(165, 150), Color.Black, 3, 100));//minutes lead
            clock.hands.Add(new Clock.Hand(new Vector.vector2(165, 150), Color.Black, 3, 70));//hour lead
            MoveClock();
            ////////////////creating clock/////////////////////////

            timer1.Start();
        }

        private void Display(object sender, PaintEventArgs e)
        {
            //clock.RecentryOnWindow(this.Size);
            clock.Draw(e);//drawing clock
        }

        private void MoveClock()
        {
            clock.hands[0].rotation = DateTime.Now.Second * 6;//360 : 60 = 6
            clock.hands[1].rotation = DateTime.Now.Minute * 6;//6 * x = angel
            clock.hands[2].rotation = DateTime.Now.Hour * 30;//360 : 12 = 30 30 * x = angel
            this.Refresh();//redrawing a clock
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            MoveClock();
        }
    }
}
