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
        public string MTFSpawnBroadcast = "<b><i>A <color=blue>MTF</color> Supply drop has arrived!</i></b>\n<b><i>Supply Type: %type%</i></b>";

        public string CISpawnBroadcast = "<b><u>A <color=green>Chaos Insurgency</color> Supply drop has arrived!</i></b>\n<b><i>Supply Type: %type%</i></b>";
    }
}
