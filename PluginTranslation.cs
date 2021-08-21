using Synapse.Translation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyDrops
{
    public class PluginTranslation : IPluginTranslation
    {
        public string MTFSpawnBroadcast = "<b>A <color=blue>MTF</color> Supply drop has arrived!</b>";

        public string CISpawnBroadcast = "<b>A <color=green>Chaos Insurgency</color> Supply drop has arrived!</b>";
    }
}
