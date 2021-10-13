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
    public partial class LogIn : Form
    {
        private object lblLogInFeedBack;

        public LogIn()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();

        }

        private void buttonNDH_Click(object sender, EventArgs e)
        {
            DataHandlerForm dhf = new DataHandlerForm();
            dhf.Show();
            this.Hide();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string inputUsername = textBox1.Text;
            string inputPassword = textBox2.Text;
            //Global Variables is a class created to store global variables
            if (GlobalVariables.userList.Count != 0)
            {
                try//ensuring same player doesnt log in twice
                {
                    if (inputUsername != GlobalVariables.userList[0].Username)
                    {
                        checkLogIn(inputUsername, inputPassword);//method to chech login details
                    }
                    else
                    {
                        throw new LogInException("User Already Logged in");
                    }

                }
                catch (LogInException m)
                {
                    lbl.ForeColor = Color.Maroon;
                    lbl.Text = m.Message;
                }

            }
            else
            {
                checkLogIn(inputUsername, inputPassword);
            }


            
        }
        

        private void checkLogIn(string inputUsername, string inputPassword)
        {
            UserAccountInfo users = new UserAccountInfo();
            Dictionary<string, string> userInfo = new Dictionary<string, string>();
            userInfo = users.Accounts;  // Initializes usernames and passwords

            if (userInfo.ContainsKey(inputUsername))
            {
                // Gets Password associated with key
                string value = "";
                userInfo.TryGetValue(inputUsername, out value);

                if (inputPassword == value)
                {
                    BCview bcv = new BCview();
                    bcv.Show();
                    this.Hide();
                }
                else
                {
                    
                    lbl.Text = "Incorrect username or password";
                }
            }
            else
            {
                lbl.ForeColor = Color.Maroon;
                lbl.Text = "Incorrect username or password";
            }
        }

        
    }
}
