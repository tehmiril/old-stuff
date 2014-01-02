using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Remoting;
using System.Net;
using System.IO;

using InternetBanking_Interface;

namespace Client_Account
{
    public partial class Session_client : Form
    {
        i_Session bank_session;
        //Login_form loginform;
        User thisUser = new User();
        string receiver;
        double amount;

        //for check the log in in order to do the logout
        ArrayList allOnlineUsers = new ArrayList();
        
        public Session_client(Form parent, User u)
        {
            InitializeComponent();

            thisUser = u;

            //get instance of the bank session
            bank_session = (i_Session)Activator.GetObject(typeof(i_Session), "tcp://localhost:9999/Session");

            thisUser.loginPosition = bank_session.AddUsers(thisUser);

            //raise Event
            bank_session.sEvent += new sessionEvent(Bank_session_pEvent);

            listBox1.Items.Add(thisUser.Name + " has logged in");

            //initialize datas after logged in
            textBox1.Text = thisUser.AccountNumber;
            textBox2.Text = thisUser.Balance.ToString();
            textBox3.Text = thisUser.Name + " --- " + thisUser.Address;
            listBox1.Items.Add(thisUser.Transaction.ToString());          
            //UpdateData();

            //loginform = (Login_form)parent;
        }

        public void UpdateData()
        {
            User clone = thisUser;
            
            thisUser = bank_session.UpdateDatabase(thisUser);

            if (clone.Balance == thisUser.Balance)
            {
                return;
            }
            //update the GUI
            textBox1.Text = thisUser.AccountNumber;
            textBox2.Text = thisUser.Balance.ToString();
            textBox3.Text = thisUser.Name + " --- " + thisUser.Address;
            listBox1.Items.Add(thisUser.Transaction.ToString());
        }

        public void Bank_session_pEvent(object sender)
        {
            if (listBox1.InvokeRequired)
            {
                listBox1.BeginInvoke(new MethodInvoker(this.UpdateData));
            }
            else
            UpdateData();    

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "" || textBox5.Text == "" || Convert.ToDouble(textBox5.Text.ToString()) < 0)
            {
                return;
            }
            receiver = textBox4.Text.ToString();
            amount = Convert.ToDouble(textBox5.Text.ToString());
            
            if (bank_session.Transfer(thisUser, receiver, amount) != 0)
            {
                textBox6.Text = textBox6.Text + Environment.NewLine + "Failed to transfer";
            }
                
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bank_session.RemoveUsers(thisUser);
            this.Close();
        }
    }
}
