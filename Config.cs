using Synapse.Config;
using System.Collections.Generic;
using UnityEngine;

namespace SupplyDrops
{
    public class Config : AbstractConfigSection
    {
        public int MinPlayersForSupply = 4;

        public bool IsOnlyHelicopter = true;

        public int CiCarChance = 50;

        public List<SerializedItem> Items = new List<SerializedItem>()
        {
            new SerializedItem((int) ItemType.Medkit, 0, 0, 0, 0, Vector3.one),
            new SerializedItem((int) ItemType.Medkit, 0, 0, 0, 0, Vector3.one),
            new SerializedItem((int) ItemType.Radio, 0, 0, 0, 0, Vector3.one)
        };

        public float SupplyIntervall = 300;

        public bool DoBroadcast = true;

        public ushort BroadcastDuration = 15;

        public bool DoCassieAnnouncement = true;

        public string BroadcastMessageCI = "<b>A Supply drop has arrived via <color=#2EB800>CI Car</color></b>";

        public string BroadcastMessageMTF = "<b>A Supply drop has arrived via <color=#1F22C7>NTF Helicopter</color>!</b>";

        public string CassieAnnouncement = "Supply has enter the facility";
    }

}