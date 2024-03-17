using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Location_DVD
{
    public class Client
    {
        public int ClientID { get; set; }
        public string Firstname { get; internal set; }
        public string Lastname { get; set; }
        public string Adresse { get; set; }
        public string Phonenumber { get; set; }

    }
}

