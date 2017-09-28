using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SSHFrom.BO
{
    [Serializable]
    public class PublishBO
    {
        private ServerBO server;
        //private bool isCompile;
        //private string compileSor;
        //private string compileTarget;

        private string source;
        private string white;
        private bool isInc;
        private DateTime datetimeInc;
        private string remotePath;
        private string reg;
        private string startBefor;
        private string startup;

        public PublishBO(ServerBO server,string source, string white, bool isInc, DateTime datetimeInc, string remotePath, string reg, string startBefor ,string startup)
        {
            this.server = server; 
            this.source = source;
            this.white = white;
            this.isInc = isInc;
            this.datetimeInc = datetimeInc;
            this.remotePath = remotePath;
            this.reg = reg;
            this.startBefor = startBefor;
            this.startup = startup;
        }
        public ServerBO Server { get => server; set => server = value; }
        //public bool IsCompile { get => isCompile; set => isCompile = value; }
        //public string CompileSor { get => compileSor; set => compileSor = value; }
        //public string CompileTarget { get => compileTarget; set => compileTarget = value; }
        public string Source { get => source; set => source = value; }
        public string White { get => white; set => white = value; }
        public bool IsInc { get => isInc; set => isInc = value; }
        public DateTime DatetimeInc { get => datetimeInc; set => datetimeInc = value; }
        public string RemotePath { get => remotePath; set => remotePath = value; }
        public string Reg { get => reg; set => reg = value; }
        public string StartBefor { get => startBefor; set => startBefor = value; }
        public string Startup { get => startup; set => startup = value; }
    }
}
