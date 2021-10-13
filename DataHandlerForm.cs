using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mile_Stone_1
{
    public partial class DataHandlerForm : Form
    {
        public DataHandlerForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AllMethods all = new AllMethods();

            string naame = textBox1.Text;
            string password = textBox2.Text;

            if (naame.Length.Equals(0) || password.Length.Equals(0) )
            {
                MessageBox.Show("Don't leave anything empty");
            }
            else
            {
                all.insertUser(naame, password);
                MessageBox.Show("User enterd");

                LogIn log = new LogIn();
                log.Show();
                this.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }
    }
}
