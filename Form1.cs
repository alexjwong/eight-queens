using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace eight_queens
{
    public partial class Form1 : Form
    {
        private ArrayList Queens = new ArrayList();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            const int CELLHEIGHT = 50;
            const int CELLWIDTH = 50;

            Graphics g = e.Graphics;



        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            this.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Queens.Clear();
            this.Invalidate();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
