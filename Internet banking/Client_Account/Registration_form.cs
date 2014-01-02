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

//TO DO

namespace Client_Account
{
    public partial class Registration_form : Form
    {
       
        I_Register clientRegister;
      

        public Registration_form()
        {

            InitializeComponent();
           


       
            
        }
        public void Bank_session_pEvent(object sender)
        {
            

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Registration_GUI_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        //create register channel 
        public void setupRegisterRemote()
        {
            clientRegister = (I_Register)Activator.GetObject(
                              typeof(I_Register),
                             "tcp://localhost:9999/Register");
        }

        private void button_registration_Click(object sender, EventArgs e)
        {

            label1.Text = "";

            //when button register is clicked, do the register remote
            setupRegisterRemote();

            // check the input validity
            if (textBox_accNo.Text.ToString() == "" || textBox_password.Text.ToString() == "" || (textBox_accNo.Text.ToString() == "" && textBox_password.Text.ToString() == "") || textBox_username.Text.ToString() == "")
            {

                label1.Text = "Invalid input!";
            }
            //do the register
            else
            {
                int check = clientRegister.RegisterUser(textBox_accNo.Text.ToString(), textBox_username.Text.ToString(), textBox_password.Text.ToString(), textBox_residence.Text.ToString());

                if (check == 0)
                {
                    label1.Text = "Registration successful!";
                }

                if (check == 1)
                {

                    label1.Text = "Useraccount already taken! Please try again!";
                }
            }

        }
    }
}
