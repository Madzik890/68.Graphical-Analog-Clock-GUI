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
        private Clock clock;//

        public InputColor()
        {
            InitializeComponent();
        }

        public void Show(Clock clock)
        {
            base.Show();//evocation base function
            this.clock = clock;//creating reference for base clock
        }

        private void SetBackgroundColor()
        {
            this.BackColor = Color.FromArgb((int)numericUpDownR.Value, (int)numericUpDownR.Value, (int)numericUpDownR.Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(clock !=null)
            clock.face.color = Color.Red;
        }

        private void numericUpDownR_ValueChanged(object sender, EventArgs e)
        {
            SetBackgroundColor();
        }

        private void numericUpDownG_ValueChanged(object sender, EventArgs e)
        {
            SetBackgroundColor();
        }

        private void numericUpDownB_ValueChanged(object sender, EventArgs e)
        {
            SetBackgroundColor();
        }

    }
}
