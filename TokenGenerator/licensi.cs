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
    public partial class licensi : Form
    {
        INIFile ini = new INIFile(@"C:\Users\Public\Config\config.ini");
        Random x = new Random();
        public licensi()
        {
            InitializeComponent();
        }
        private string randomm(int final)
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";
            var stringChars = new char[final];
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[x.Next(chars.Length)];
            }
            return new String(stringChars);
        }
        string total;
        private void licensi_Load(object sender, EventArgs e)
        {
            string a = randomm(5);
            string b = randomm(5);
            string c = randomm(5);
            string d = randomm(5);
            total = a+"-"+b+"-"+c+"-"+d;
            label1.Text = total;
        }

        private void licensi_DoubleClick(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = true;
            System.Windows.Forms.Clipboard.SetText(label1.Text);
            MessageBox.Show("Copied", "TokenGenerator V3.0");
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }
        int xx = 0;
        private void button1_Click_1(object sender, EventArgs e)
        {
            xx = 1;
            ini.Write("Data", "Licensi", total);
            MessageBox.Show("Lisensi disalin, silahkan simpan", "TokenGenerator V3.0");
            this.Close();
        }

        private void licensi_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(xx==0)
            {
                Application.Exit();
            }
        }

        private void licensi_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (xx == 0)
            {
                Application.Exit();
            }
        }
    }
}
