using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Collections;

using System.Data.OleDb; //for databases

using InternetBanking_Interface;

namespace Server_Central_Bank
{
    public class Login : MarshalByRefObject, i_Login
    {
        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source= Bank_Account_Data.mdb ");
        //find the database in Server_Central_Bank\Bin\Debug

        string bankAccNumber;  //account number for login
        string userPass;    //user password for login
        
        ArrayList allUser = new ArrayList();
        
        public Login()
        {
            bankAccNumber = "";
            userPass = "";
        }

        public Login(string bankNo, string pass)
        {
            bankAccNumber = bankNo;
            userPass = pass;
        }

        public int checkLogin(string bankNo, string pass)
        {
            //make connection
            conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Bank_Account_Data.mdb");

            OleDbDataReader rdr = null;
            if (conn.State == System.Data.ConnectionState.Closed)
            {
               conn.Open();
            }

            OleDbCommand cmd = new OleDbCommand("select * from Bank_account where Bank_no = '" + bankNo + "'and User_password = '" + pass + "' ", conn);
            rdr = cmd.ExecuteReader();
                
            if (rdr.Read()) //user exist
            {
                allUser.Clear();
                //add data to the user list
                User u = new User(rdr[0].ToString(), rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString(), (double)rdr[4], rdr[5].ToString());
                allUser.Add(u);
                if (rdr != null) rdr.Close();
                if (conn != null) conn.Close();
                return 0;
            }
            if (rdr != null) rdr.Close();
            if (conn != null) conn.Close();
            return -1;
        }

        public ArrayList AllUser
        {
            get { return allUser; }
        }

        public User getUser(string accountNumber)
        {
            for (int i = 0; i < allUser.Count; i++)
            {
                User u = (User)allUser[i];
                if (u.AccountNumber == accountNumber)
                {
                    return u;
                }
            }
            return new User();




        }

        //register class
    class Register : MarshalByRefObject,I_Register
    {
        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source= Bank_Account_Data.mdb ");

        string rAccountNumb; //register account
        string rUsername;//register username
        string rPass; //register pass
        string rResidence;//register residence

        public Register()
        {
            rAccountNumb = "";
            rUsername = "";
            rPass = "";
            rResidence = "";
            
        }
        public Register(string accNumb,string username, string pass,string residence)
        {
            rAccountNumb = accNumb;
            rUsername = username;
            rPass = pass;
            rResidence = residence;
            

        }
        public int RegisterUser(string accNumb, string username, string pass, string residence)
        {

            int result = checkUsernameAvailablity(accNumb);

            if (result == 1)//'1' is failed
            {
                return 1;
            }
            else if (result == 0) //'0' is successful
            {
                //open data
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }
                //int score = 0;
                string insertString = @"insert into Bank_account (Bank_no,User_name,User_password,User_Address) values ('" + accNumb + "', '" + username + "', '" + pass + "','" + residence + "' )";
                OleDbCommand cmd = new OleDbCommand(insertString, conn);
                cmd.ExecuteNonQuery();

                return 0;
            }
            else
                return 3;
        }

        public int checkUsernameAvailablity(string name)
        {
            OleDbDataReader rdr = null;

            try
            {
                //open data
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }
                OleDbCommand cmd = new OleDbCommand("select * from Bank_account where Bank_no = '" + name + "'", conn);

                rdr = cmd.ExecuteReader();

                if (rdr.Read() != false) //username already exists
                    return 1;
                else
                    return 0;
            }
            finally
            {
                if (rdr != null) rdr.Close();
                if (conn != null) conn.Close();
            }


        }
    }
    }

}
