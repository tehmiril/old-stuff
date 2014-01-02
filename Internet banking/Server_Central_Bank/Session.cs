using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Collections;
using System.Data.OleDb;

using InternetBanking_Interface;

namespace Server_Central_Bank
{
    class Session : MarshalByRefObject, i_Session
    {
        ArrayList OnlineUsers = new ArrayList();
        
        public event sessionEvent sEvent; //event for update the session

        public int AddUsers(User u)
        {
            OnlineUsers.Add(u);
            return OnlineUsers.Count - 1;
        }
        public void RemoveUsers(User u)
        {
            //TO DO: still have to work on how to log out
            OnlineUsers.RemoveAt(0);
        }
        public ArrayList GetUsers()
        {
            return OnlineUsers;
        }

        public int Transfer(User currUser,string accountNo, double amount)
        {
            if (currUser.Balance < amount)
            {
                return -1;
            }

            OleDbConnection conn;
            conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Bank_Account_Data.mdb");
            OleDbDataReader rdr = null;
            OleDbDataReader rdr2 = null;

            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
            
            OleDbCommand cmd = new OleDbCommand("update Bank_account set Account_balance = Account_balance -'" + amount + "' where Bank_no = '" + currUser.AccountNumber + "'", conn);
            
            rdr = cmd.ExecuteReader();

            OleDbCommand cmd2 = new OleDbCommand("update Bank_account set Account_balance = Account_balance +'" + amount + "' where Bank_no = '" + accountNo + "'", conn);

            rdr2 = cmd2.ExecuteReader();

            string tran_msg = amount.ToString() + " Euro have been transfered to account number: " + accountNo + Environment.NewLine;
            string tran_msg2 = amount.ToString() + " Euro have been received from account number: " + currUser.AccountNumber + Environment.NewLine;

            TransactionMesssage(currUser.AccountNumber, tran_msg);
            TransactionMesssage(accountNo, tran_msg2);

            if (rdr  != null) rdr.Close();
            if (rdr2 != null) rdr2.Close();
            if (conn != null) conn.Close();

            if (sEvent != null)
                sEvent(this);

            return 0;
        }

        public void TransactionMesssage(string accNo, string msg)
        {
            OleDbConnection conn;
            OleDbDataReader rdr = null;

            conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Bank_Account_Data.mdb");
            
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }

            OleDbCommand cmd = new OleDbCommand("update Bank_account set Transaction_history ='" + msg + "' where Bank_no = '" + accNo + "'", conn);
            cmd.ExecuteReader();

            if (rdr != null) rdr.Close();
            if (conn != null) conn.Close();
        }

        public User UpdateDatabase(User oldUser)
        {
            OleDbConnection conn;
            //make connection
            conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Bank_Account_Data.mdb");

            OleDbDataReader rdr = null;
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }

            OleDbCommand cmd = new OleDbCommand("select * from Bank_account where Bank_no = '" + oldUser.AccountNumber + "' ", conn);
            rdr = cmd.ExecuteReader();

            if (!rdr.Read()) //user not exist
            {
                return oldUser;                
            }

            User updatedUser = new User(rdr[0].ToString(), rdr[1].ToString(), rdr[2].ToString(), rdr[3].ToString(), (double)rdr[4], rdr[5].ToString());
            
            if (rdr != null) rdr.Close();
            if (conn != null) conn.Close();
            
            return updatedUser;
        }

        public override Object InitializeLifetimeService()
        {
            return null;
        }
    
    }

}
