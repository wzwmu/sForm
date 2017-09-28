using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSHFrom.BO
{
    [Serializable]
    public class ServerBO
    {
        private string host;
        private string user;
        private string pass;

        public ServerBO(string host, string user, string pass)
        {
            this.host = host;
            this.user = user;
            this.pass = pass;
        }

        public string Host { get => host; set => host = value; }
        public string User { get => user; set => user = value; }
        public string Pass { get => pass; set => pass = value; }
    }
}
