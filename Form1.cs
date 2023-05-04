using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace MD5Hash
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Text = myalgorithm(textBox1.Text);
        }
        public string myalgorithm(string password)
        {
            string hashedvalue = "";
            MD5 algorithm = MD5.Create();
            byte [] passwordbytes = Encoding.ASCII.GetBytes(password);
            byte[] hashedbytes =algorithm.ComputeHash(passwordbytes);
            for (int i = 0; i < hashedbytes.Length; i++)
            {
                hashedvalue += hashedbytes [i].ToString("x2");
            }
            return hashedvalue;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string loginhash = myalgorithm(textBox2.Text);
            string registerhash = myalgorithm(textBox1.Text);
            int result = string.Compare(registerhash, loginhash);
            if (result == 0)
            {
                label2.Text = "Password is correct";
                label4.Text = registerhash;
                label5.Text = loginhash;
            }
            else
            {
                label2.Text = "password invalid";
                label4.Text = registerhash;
                label5.Text = loginhash;
            }
        }
    }
}
