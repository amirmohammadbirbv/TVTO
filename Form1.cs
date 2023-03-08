using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace tvto
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            new addPerson().ShowDialog();
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            new car().ShowDialog();
        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            new entesab().ShowDialog();
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
