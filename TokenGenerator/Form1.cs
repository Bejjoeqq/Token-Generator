using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Speech;
using System.Speech.Synthesis;

namespace TokenGenerator
{
    public partial class Form1 : Form
    {
        SpeechSynthesizer rd = new SpeechSynthesizer();
        Random x = new Random();
        INIFile ini = new INIFile(@"C:\Users\Public\Config\config.ini");
        [DllImport("wininet.dll")]
        public extern static bool InternetGetConnectedState(out int Description, int ReserverValue);
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n0 = x.Next(1000, 9999);
            int n1 = x.Next(10, 99);
            int n2 = x.Next(0, 9);
            int n3 = x.Next(100, 999);
            int n4 = x.Next(10000, 99999);
            int n5 = x.Next(10000, 99999);
            total = n0.ToString() + n1.ToString() + n2.ToString() + n3.ToString() + n4.ToString() + n5.ToString();
            label5.Text = total;
            webBrowser1.Document.GetElementById("tkn").InnerText = total;
            webBrowser1.Document.GetElementById("user").InnerText = System.Windows.Forms.SystemInformation.ComputerName;
            foreach (HtmlElement elem in webBrowser1.Document.GetElementsByTagName("input"))
            {
                if (elem.GetAttribute("value")=="Insert")
                {
                    elem.InvokeMember("Click");
                }
            }
            writeinidir("Date", daten);
            writeinidir("Token", total);
            button1.Enabled = false;
            label7.Text = "Sukses";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string path = Directory.GetCurrentDirectory();
            string target = @"C:\Users\Public\Config";
            if (!Directory.Exists(target))
            {
                Directory.CreateDirectory(target);
            }
            speech = "Hello " + System.Windows.Forms.SystemInformation.ComputerName;
            rd.Dispose();
            rd = new SpeechSynthesizer();
            rd.SpeakAsync(speech);
            timer1.Start();
            label3.Text = System.Windows.Forms.SystemInformation.ComputerName;
            reloadini();
            if (licensi=="")
            {
                licensi lc = new licensi();
                lc.ShowDialog();
            }
            else
            {
                Hello hl = new Hello();
                hl.ShowDialog();
            }
        }
        private void writeinidir(string title, string set)
        {
            ini.Write("Data", title, set);
        }
        string licensi, date,total,daten,tokn;
        private void reloadini()
        {
            licensi = ini.Read("Data", "Licensi");
            date = ini.Read("Data", "Date");
            tokn = ini.Read("Data", "Token");
        }
        private void getTime()
        {
            var client = new TcpClient("time.nist.gov", 13);
            using (var streamReader = new StreamReader(client.GetStream()))
            {
                string response = streamReader.ReadToEnd();
                string utcDateTimeString = response.Substring(7, 8);
                DateTime localDateTime = DateTime.ParseExact(utcDateTimeString, "yy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);
                daten = localDateTime.ToString();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            getTime();
        }
        string speech;
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Clipboard.SetText(label5.Text);
            MessageBox.Show("Copied", "TokenGenerator V3.0");
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Token hanya dapat digenerate sekali dalam 1 hari, reset pada jam 07:00","TokenGenerator V3.0");
            MessageBox.Show("Setiap token hanya dapat digunakan satu kali didalam website", "TokenGenerator V3.0");
            MessageBox.Show("Klik pada kotak untuk menyalin", "TokenGenerator V3.0");
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if(textBox1.Visible==false)
            {
                textBox1.Visible = true;
            }
            else
            {
                textBox1.Visible = false;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="Bejjoeqq")
            {
                webBrowser1.BringToFront();
            }
            else
            {
                System.Windows.Forms.Clipboard.SetText(label3.Text);
                MessageBox.Show("Copied", "TokenGenerator V3.0");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox2.Show();
            MessageBox.Show("Awww", "TokenGenerator V3.0");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("-_-", "TokenGenerator V3.0");
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("-_-", "TokenGenerator V3.0");
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
        }
        int ax = 0, be = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            int Dec;
            if (InternetGetConnectedState(out Dec, 0).ToString() == "False")
            {
                panel2.Show();
                ax = 0;
                be = 0;
            }
            else
            {
                panel2.Hide();
                ax = 1;
            }
            if (ax == 1)
            {
                if(be==0)
                {
                    be = 1;
                    getTime();
                    if (ini.Read("Data", "Date") != daten)
                    {
                        button1.Enabled = true;
                        label7.Text = "-";
                        label5.Text = "YourDailyToken";
                    }
                    else
                    {
                        button1.Enabled = false;
                        label7.Text = "Sukses";
                        label5.Text = tokn;
                    }
                }
            }
        }
    }
}
