using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Collections;
using System.Security.Cryptography;
using System.Runtime.Serialization.Formatters;

using InternetBanking_Interface;

namespace Client_Account
{
    public partial class Login_form : Form
    {
        i_Login         clientLogin;
        i_Session       bank_session;
        Session_client  currentSession;
        bool isLoggedIn;

        public Login_form()
        {
            InitializeComponent();
            textBox2.MaxLength = 8;

            //set up BINARY and TCP channel
            BinaryServerFormatterSinkProvider srvFormatter = new BinaryServerFormatterSinkProvider();
            srvFormatter.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;

            BinaryClientFormatterSinkProvider clntFormatter = new BinaryClientFormatterSinkProvider();

            IDictionary props = new Hashtable();
            props["name"] = "ClientChannel";
            props["port"] = 0;

            TcpChannel chan = new TcpChannel(props, clntFormatter, srvFormatter);
            ChannelServices.RegisterChannel(chan, false);
        }

        //create login channel
        public void setupLoginRemote()
        {
            clientLogin = (i_Login)Activator.GetObject(
                              typeof(i_Login),
                              "tcp://localhost:9999/Login");

        }

        //create session channel
        public void setupSessionRemote()
        {
            bank_session = (i_Session)Activator.GetObject(
                              typeof(i_Session),
                              "tcp://localhost:9999/Session");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //creating login channel
            setupLoginRemote();
            
            //checking the input
            if (textBox1.Text.ToString() == "" || textBox2.Text.ToString() == "")
            {
                label3.Text = "Invalid input";
            }
            else
            {
                int checkUser = clientLogin.checkLogin(textBox1.Text.ToString(), textBox2.Text.ToString());

                if (checkUser == 0)
                {
                    setupSessionRemote();

                    //check if user already logged in
                    foreach (User u in bank_session.GetUsers())
                    {
                        if ((textBox1.Text.ToString()).ToUpper() == u.AccountNumber.ToUpper())
                        {
                            isLoggedIn = true;
                        }
                    }

                    if (isLoggedIn == true)
                    {
                        label3.Text = "User already logged in";
                        isLoggedIn = false;
                    }
                    else
                    {
                        User currentUser = clientLogin.getUser(textBox1.Text.ToString());
                        //form a new session for current user
                        currentSession = new Session_client(this, currentUser);
                        //close the login form
                        //this.Hide();
                        //show the session
                        currentSession.Show();
                        label3.Text = "";
                        textBox2.Text = "";
                    }

                }
                else
                    label3.Text = "Incorrect password or account number";
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            Registration_form registerform = new Registration_form();
            registerform.Show();

           
        }
    }
}
