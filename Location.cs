using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Location_DVD
{
    // Classe Location : représente une location de DVD effectuée par un client
    public class Location
    {
        public int LocationId { get; set; }
        public string LeClient { get; set; }
        public string LeDVD { get; set; }
        public string DateRented { get; set; }
        public string DateReturned { get; set; }
    }
}
