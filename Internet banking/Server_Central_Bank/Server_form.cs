using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Serialization.Formatters;


namespace Server_Central_Bank
{
    public partial class Server_form : Form
    {
        public Server_form()
        {
            InitializeComponent();
            
            //setup for BINARY and TCP
            BinaryServerFormatterSinkProvider srvFormatter = new BinaryServerFormatterSinkProvider();
            srvFormatter.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;

            BinaryClientFormatterSinkProvider clntFormatter = new BinaryClientFormatterSinkProvider();

            IDictionary props = new Hashtable();
            props["name"] = "ServerChannel";
            props["port"] = 9999;

            TcpChannel chan = new TcpChannel(props, clntFormatter, srvFormatter);
            ChannelServices.RegisterChannel(chan, false);

            //setup the Login
            setupLoginRemote();
            //setup the Session
            setupSessionRemote();
        }

        //setup Login remote
        public void setupLoginRemote()
        {
            RemotingConfiguration.RegisterWellKnownServiceType(
            typeof(Login), // The type to register
            "Login",                   // The well known name
            WellKnownObjectMode.Singleton   // SingleCall or Singleton
            );
        }

        public void setupRegisterRemote()
        {
            RemotingConfiguration.RegisterWellKnownServiceType(
            typeof(Register), // The type to register
            "Login",                   // The well known name
            WellKnownObjectMode.Singleton   // SingleCall or Singleton
            );
        }

        public void setupSessionRemote()
        {
            RemotingConfiguration.RegisterWellKnownServiceType(
                typeof(Session),
                "Session",
                WellKnownObjectMode.Singleton
            );
        }

        //make the life time of server infinite
        public override Object InitializeLifetimeService()
        {
            return null;
        }
    }
}
