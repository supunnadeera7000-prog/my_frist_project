using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game.Animals
{
    public partial class frist : Form
    {
        public frist()
        {
            InitializeComponent();
        }

        private void frist_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 100;
            Form1 v= new Form1();
            v.Show();
        }
    }
}
