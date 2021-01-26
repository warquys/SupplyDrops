using MEC;
using SupplyDrops.Handlers;
using Synapse.Api;
using Synapse.Api.Plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyDrops
{
    [PluginInformation(
        Author = "TheVoidNebula",
        Description = "Brings Supplies via MTF helicopter and CI truck.",
        LoadPriority = 0,
        Name = "SupplyDrops",
        SynapseMajor = 2,
        SynapseMinor = 4,
        SynapsePatch = 2,
        Version = "b1.0"
        )]
    public class Plugin : AbstractPlugin
    {
        [Synapse.Api.Plugin.Config(section = "SupplyDrops")]
        public static Config Config;
        public override void Load()
        {
            SynapseController.Server.Logger.Info("SupplyDrops loaded!");

            new EventHandlers();
        }

        public override void ReloadConfigs()
        {

        }
    }
}
