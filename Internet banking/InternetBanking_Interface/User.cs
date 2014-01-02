using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;

namespace InternetBanking_Interface
{
    //compatible with .NET remoting
    [Serializable]
    public class User
    {
        private string accountNo;
        private string name;
        private string address;
        private string pass;
        private double balance;
        private string transactionHistory;
        public int     loginPosition;
        
        public User()
        {
            accountNo = "";
            name = "";
            address = "";
            pass = "";
            balance = 0;
            transactionHistory = "";
        }

        public User(string accNo, string accName, string accPass, string accAdd, double accBalance, string transH)
        {
            this.accountNo  = accNo;
            this.name = accName;
            this.address = accAdd;
            this.pass = accPass;
            this.balance = accBalance;
            this.transactionHistory = transH;
        }

        public string AccountNumber
        {
            get
            {
                return accountNo;
            }
            set
            {
                accountNo = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }

        public string Password
        {
            get
            {
                return pass;
            }
            set
            {
                pass = value;
            }
        }

        public double Balance
        {
            get
            {
                return balance;
            }
            set
            {
                balance = value;
            }
        }

        public string Transaction
        {
            get
            {
                return transactionHistory;
            }
            set
            {
                transactionHistory = value;
            }
        }
        


    }
}
