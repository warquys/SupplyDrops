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
        Version = "2.1.0"
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
                CISpawnBroadcast = "<b><i><color=green>Chaos Insurgency</color> Vorratslieferung ist eingetroffen!</i></b>\n<b><i>Vorratsart: %type%</i></b>",
                MTFSpawnBroadcast = "<b><color=blue>MTF</color> Vorratslieferung ist eingetroffen!</b>\n<b><i>Vorratsart: %type%</i></b>"
            }, "GERMAN");

            PluginTranslation.AddTranslation(new PluginTranslation
            {
                CISpawnBroadcast = "<b><u>Un largage aérien de l'<color=green>Insurrection du Chaos</color> est arrivé!</i></b>\n<b><i>Type de ravitaillement: %type%</i></b>",
                MTFSpawnBroadcast = "<b><i>Un largage aérien <color=blue>MTF</color> est arrivé!</i></b>\n<b><i>Type de ravitaillement: %type%</i></b>"
            }, "FRENCH");

            new EventHandlers();
        }
    }
}
