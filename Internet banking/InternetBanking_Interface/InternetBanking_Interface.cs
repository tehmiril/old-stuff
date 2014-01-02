using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Messaging;
using System.Collections;


namespace InternetBanking_Interface
{
    //delegate
    public delegate void sessionEvent(object sender);

    //Login interface
    public interface i_Login
    {
        //check user log in, return -1 (no user existed) 0 (user existed)
        int checkLogin(string bankNo, string pass);
        User getUser(string accountNumber);
    }

    //register interface

    public interface I_Register
    {

        int RegisterUser(string accNumb, string username, string pass, string residence);
        int checkUsernameAvailablity(string accNumb);
    }

    public interface i_Session
    {
        event sessionEvent sEvent;
        int AddUsers(User u);
        void RemoveUsers(User u);
        int Transfer(User currUser, string accountNo, double amount); //return 0 success, -1 fail
        User UpdateDatabase(User oldUser);
        ArrayList GetUsers();
               
    }


}
