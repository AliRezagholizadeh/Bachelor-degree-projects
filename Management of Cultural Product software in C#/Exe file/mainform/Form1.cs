using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mainform
{
    public partial class Form1 : Form
    {   
        public String PassWord = "1234" ;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == PassWord)
            {
                mainSystemForm mainSys = new mainSystemForm();
                mainSys.Show();
                Program.f1.Visible = false;
            }
            else
                MessageBox.Show("رمز عبور اشتباه است. لطفا دوباره امتحان کنید");

        }
    }
}
