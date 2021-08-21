using Synapse.Config;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace SupplyDrops
{
    public class Config : AbstractConfigSection
    {
        [Description("Should this Plugin be enabled?")]
        public bool IsEnabled { get; set; } = true;

        [Description("How many Players need to be on the server to start the supply timer cloak?")]
        public int MinPlayersForSupply { get; set; } = 4;

        [Description("Should Supplydrops only arrive via the MTF Chopper?")]
        public bool IsOnlyHelicopter { get; set; } = true;

        [Description("If you have IsOnlyHelicopter on false, how high is the chance Supplydrops arrive via the CI car?")]
        public int CiCarChance { get; set; } = 50;

        [Description("What Items should the Supplydrop bring?")]
        public List<SerializedItem> Items { get; set; } = new List<SerializedItem>()
        {
            new SerializedItem((int) ItemType.Medkit, 0, 0, Vector3.one),
            new SerializedItem((int) ItemType.Medkit, 0, 0, Vector3.one),
            new SerializedItem((int) ItemType.Radio, 0, 0, Vector3.one)
        };

        [Description("What should the intervall be in what Supplydrops arrive (in seconds)")]
        public float SupplyIntervall { get; set; } = 300;

        [Description("Should there be a Broadcast when supply arrives?")]
        public bool DoBroadcast { get; set; } = true;

        [Description("How long should the Broadcast be?")]
        public ushort BroadcastDuration { get; set; } = 15;

        [Description("Should there be a C.A.S.S.I.E Announcement when supply arrives?")]
        public bool DoCassieAnnouncement { get; set; } = true;

        [Description("What should the C.A.S.S.I.E Announcement be?")]
        public string CassieAnnouncement { get; set; } = "Supply has entered the facility";
    }

}