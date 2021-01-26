using Synapse.Config;
using System.Collections.Generic;
using UnityEngine;

namespace SupplyDrops
{
    public class Config : AbstractConfigSection
    {
        public int minPlayersForSupply = 4;

        public bool isOnlyHelicopter = true;

        public int ciCarChance = 50;

        public List<SerializedItem> items = new List<SerializedItem>()
        {
            new SerializedItem((int) ItemType.Medkit, 0, 0, 0, 0, Vector3.one),
            new SerializedItem((int) ItemType.Medkit, 0, 0, 0, 0, Vector3.one),
            new SerializedItem((int) ItemType.Radio, 0, 0, 0, 0, Vector3.one)
        };

        public float supplyIntervall = 300;

        public bool doBroadcast = true;

        public ushort broadcastDuration = 15;

        public bool doCassieAnnouncement = true;

        public string broadcastMessageCI = "<b>A Supply drop has arrived via <color=#2EB800>CI Car</color></b>";

        public string broadcastMessageMTF = "<b>A Supply drop has arrived via <color=#1F22C7>NTF Helicopter</color>!</b>";

        public string cassieAnnouncement = "Supply has enter the facility";
    }

}