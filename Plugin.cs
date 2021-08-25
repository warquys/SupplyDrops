using MEC;
using SupplyDrops.Handlers;
using Synapse.Api;
using Synapse.Api.Plugin;
using Synapse.Translation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyDrops
{
    [PluginInformation(
        Author = "TheVoidNebula",
        Description = "Help from the skies!",
        LoadPriority = 0,
        Name = "SupplyDrops",
        SynapseMajor = 2,
        SynapseMinor = 7,
        SynapsePatch = 0,
        Version = "2.0.1"
        )]
    public class Plugin : AbstractPlugin
    {
        [Synapse.Api.Plugin.Config(section = "SupplyDrops")]
        public static Config Config;

        [SynapseTranslation]
        public static SynapseTranslation<PluginTranslation> PluginTranslation;
        public override void Load()
        {
            SynapseController.Server.Logger.Info("SupplyDrops loaded!");
            PluginTranslation.AddTranslation(new PluginTranslation());

            PluginTranslation.AddTranslation(new PluginTranslation
            {
                CISpawnBroadcast = "<b><color=green>Chaos Insurgency</color> Vorratslieferung ist eingetroffen!</b>",
                MTFSpawnBroadcast = "<b><color=blue>MTF</color> Vorratslieferung ist eingetroffen!</b>"
            }, "GERMAN");

            new EventHandlers();
        }
    }
}
