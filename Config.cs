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

        [Description("Decide what loot will spawn via the Supplydrops?")]
        public List<SupplyType> SupplyDrops = new List<SupplyType>()
        {
            new SupplyType()
            {
                SupplyTypeName = "<color=#00FF12>Medicial Items</color>",
                SupplyItems = new List<SupplyItem>()
                {
                    new SupplyItem()
                    {
                        Chance = 100,
                        Amount = 4,
                        Item = new SerializedItem()
                        {
                            ID = (int) ItemType.Medkit,
                            WeaponAttachments = 0,
                            Durabillity = 0,
                            XSize = 1,
                            YSize = 1,
                            ZSize = 1
                        }
                    },

                    new SupplyItem()
                    {
                        Chance = 75,
                        Amount = 4,
                        Item = new SerializedItem()
                        {
                            ID = (int) ItemType.Adrenaline,
                            WeaponAttachments = 0,
                            Durabillity = 0,
                            XSize = 1,
                            YSize = 1,
                            ZSize = 1
                        }
                    },

                    new SupplyItem()
                    {
                        Chance = 50,
                        Amount = 2,
                        Item = new SerializedItem()
                        {
                            ID = (int) ItemType.SCP500,
                            WeaponAttachments = 0,
                            Durabillity = 0,
                            XSize = 1,
                            YSize = 1,
                            ZSize = 1
                        }
                    }
                }
            },

            new SupplyType()
            {
                SupplyTypeName = "<color=#140BFF>Weapons</color>",
                SupplyItems = new List<SupplyItem>()
                {
                    new SupplyItem()
                    {
                        Chance = 100,
                        Amount = 1,
                        Item = new SerializedItem()
                        {
                            ID = (int) ItemType.GunRevolver,
                            WeaponAttachments = 0,
                            Durabillity = 0,
                            XSize = 1,
                            YSize = 1,
                            ZSize = 1
                        }
                    },

                    new SupplyItem()
                    {
                        Chance = 100,
                        Amount = 2,
                        Item = new SerializedItem()
                        {
                            ID = (int) ItemType.GunShotgun,
                            WeaponAttachments = 0,
                            Durabillity = 0,
                            XSize = 1,
                            YSize = 1,
                            ZSize = 1
                        }
                    },
                }
            }
        };

        [Description("What should the intervall be in what Supplydrops arrive (in seconds)")]
        public float SupplyIntervall { get; set; } = 300;


        [Description("Where should Items from the MTF Chopper spawn?")]
        public Location MTFSpawnLocation { get; set; } = new Location()
        {
           x = 180,
           y = 993,
           z = -58
        };

        [Description("Where should Items from the CI Car spawn?")]
        public Location CISpawnLocation { get; set; } = new Location()
        {
            x = 5,
            y = 998,
            z = -58
        };

        [Description("Should there be a Broadcast when supply arrives?")]
        public bool DoBroadcast { get; set; } = true;

        [Description("Should there be a C.A.S.S.I.E Announcement when supply arrives?")]
        public bool DoCassieAnnouncement { get; set; } = true;

        [Description("What should the C.A.S.S.I.E Announcement be?")]
        public string CassieAnnouncement { get; set; } = "Supply has entered the facility";
    }

}