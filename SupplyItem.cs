using Synapse.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyDrops
{
    public class SupplyItem
    {
        public int Chance { get; set; }
        public int Amount { get; set; }
        public SerializedItem Item { get; set; }

    }
}
