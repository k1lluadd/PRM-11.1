using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _11._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void обувьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new Form2();
            f.Show();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void категорииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new Form3();
            f.Show();
        }

        private void производителиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new Form4();
            f.Show();
        }

        private void покупателиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new Form5();
            f.Show();
        }

        private void продажиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new Form6();
            f.Show();
        }
    }
}
