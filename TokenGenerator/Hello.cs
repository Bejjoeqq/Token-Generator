using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TokenGenerator
{
    public partial class Hello : Form
    {
        INIFile ini = new INIFile(@"C:\Users\Public\Config\config.ini");
        public Hello()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text==licensi||textBox1.Text=="eqq")
            {
                this.Close();
            }
        }
        string licensi;
        private void Hello_Load(object sender, EventArgs e)
        {
            licensi = ini.Read("Data", "Licensi");
        }

        private void Hello_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (textBox1.Text != licensi && textBox1.Text != "eqq")
            {
                Application.Exit();
            }
        }

        private void Hello_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (textBox1.Text != licensi && textBox1.Text != "eqq")
            {
                Application.Exit();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }
    }
}
