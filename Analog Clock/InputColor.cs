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
    public partial class InputColor : Form
    {
        private Clock clock;//reference for original clock
        private PartClock partclock;

        public enum PartClock//enum for changing color of the item
        {
            seconds_hand,
            minutes_hand,
            hours_hand,
            face
        }

        public InputColor()
        {
            InitializeComponent();
        }

        public void Show(Clock clock,PartClock partclock)
        {
            base.Show();//evocation base function
            this.clock = clock;//creating reference for base clock
            this.partclock = partclock;//setting changer color mode
        }

        private void SetBackgroundColor(object sender, EventArgs e)
        {
            //showing input color on background
            this.BackColor = Color.FromArgb((int)numericUpDownR.Value, (int)numericUpDownG.Value,(int)numericUpDownB.Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (clock != null)//if clock was add successfully 
            {
                switch (partclock)
                {
                    case PartClock.face:
                        clock.face.color = Color.FromArgb((int)numericUpDownR.Value, (int)numericUpDownG.Value, (int)numericUpDownB.Value);//changing color 
                        break;

                    case PartClock.seconds_hand:
                        clock.hands[0].Color = Color.FromArgb((int)numericUpDownR.Value, (int)numericUpDownG.Value, (int)numericUpDownB.Value);//changing color 
                        break;

                    case PartClock.minutes_hand:
                        clock.hands[1].Color = Color.FromArgb((int)numericUpDownR.Value, (int)numericUpDownG.Value, (int)numericUpDownB.Value);//changing color 
                        break;

                    case PartClock.hours_hand:
                        clock.hands[2].Color = Color.FromArgb((int)numericUpDownR.Value, (int)numericUpDownG.Value, (int)numericUpDownB.Value);//changing color 
                        break;
                }
            }
        }
    }
}
