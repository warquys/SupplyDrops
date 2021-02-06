using Synapse.Config;
using System.Collections.Generic;
using UnityEngine;

namespace SupplyDrops
{
    public class Config : AbstractConfigSection
    {
        public bool IsEnabled { get; set; } = true;

        public int MinPlayersForSupply { get; set; } = 4;

        public bool IsOnlyHelicopter { get; set; } = true;

        public int CiCarChance { get; set; } = 50;

        public List<SerializedItem> Items { get; set; } = new List<SerializedItem>()
        {
            new SerializedItem((int) ItemType.Medkit, 0, 0, 0, 0, Vector3.one),
            new SerializedItem((int) ItemType.Medkit, 0, 0, 0, 0, Vector3.one),
            new SerializedItem((int) ItemType.Radio, 0, 0, 0, 0, Vector3.one)
        };

        public float SupplyIntervall { get; set; } = 300;

        public bool DoBroadcast { get; set; } = true;

        public ushort BroadcastDuration { get; set; } = 15;

        public bool DoCassieAnnouncement { get; set; } = true;

        public string BroadcastMessageCI { get; set; } = "<b>A Supply drop has arrived via <color{ get; set; } =#2EB800>CI Car</color></b>";

        public string BroadcastMessageMTF { get; set; } = "<b>A Supply drop has arrived via <color{ get; set; } =#1F22C7>NTF Helicopter</color>!</b>";

        public string CassieAnnouncement { get; set; } = "Supply has entered the facility";
    }

}