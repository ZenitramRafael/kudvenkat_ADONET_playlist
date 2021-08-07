using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kudvenkat_ADONET_playlist.Model
{
    public class Product
    {
        public int productID { get; set; }
        public string name { get; set; }
        public int unitPrice { get; set; }
        public int qtyAvailable { get; set; }
    }
}
