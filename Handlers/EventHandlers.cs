using MEC;
using Respawning;
using Synapse;
using Synapse.Api;
using Synapse.Api.Items;
using Synapse.Api.Plugin;
using Synapse.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UnityEngine;
using Random = System.Random;

namespace SupplyDrops.Handlers
{
    class EventHandlers
    {
        Random r = new Random();
        private CoroutineHandle coroutine;

        Vector3 MtfSpawn    = new Vector3(Plugin.Config.MTFSpawnLocation.x, Plugin.Config.MTFSpawnLocation.y, Plugin.Config.MTFSpawnLocation.z);
        Vector3 CiSpawn     = new Vector3(Plugin.Config.CISpawnLocation.x, Plugin.Config.CISpawnLocation.y, Plugin.Config.CISpawnLocation.z);

        public EventHandlers()
        {
            //You can also use SynapseController.Server to get the Server!
            Server.Get.Events.Round.RoundStartEvent += OnStart;
            Server.Get.Events.Round.RoundEndEvent += OnRoundEnd;
            Server.Get.Events.Round.RoundRestartEvent += OnRoundRestart;
        }


        public void OnStart()
        {
            if (Plugin.Config.IsEnabled)
            {
                coroutine = Timing.RunCoroutine(DoSupplyDrop());
            }
        }

        public void OnRoundEnd() => Timing.KillCoroutines(coroutine);

        public void OnRoundRestart() => Timing.KillCoroutines(coroutine);


        public IEnumerator<float> DoSupplyDrop()
        {
            if (Plugin.Config.IsEnabled)
            {
                while (true)
                {
                    yield return Timing.WaitForSeconds(Plugin.Config.SupplyIntervall);

                    if (Server.Get.Players.Count >= Plugin.Config.MinPlayersForSupply)
                    {
                        if (Plugin.Config.DoCassieAnnouncement)
                            Map.Get.GlitchedCassie(Plugin.Config.CassieAnnouncement);

                        if (!Plugin.Config.IsOnlyHelicopter)
                        {
                            int i = r.Next(1, 101);
                            if (i <= Plugin.Config.CiCarChance)
                            {
                                Timing.RunCoroutine(DropCHI());
                            }
                            else
                            {
                                Timing.RunCoroutine(DropMTF());
                            }
                        }
                        else
                        {
                            Timing.RunCoroutine(DropMTF());
                        }
                    }
                    else
                        Server.Get.Logger.Info("Not enough players for a supplydrop, skipping");
                }
            }

        }

        public IEnumerator<float> DropMTF()
        {
            Round.Get.SpawnVehicle(false);

            SupplyType supplyType = Plugin.Config.SupplyDrops[UnityEngine.Random.Range(0, Plugin.Config.SupplyDrops.Count())];

            if (Plugin.Config.DoBroadcast)
            {
                string message = Regex.Replace(Plugin.PluginTranslation.ActiveTranslation.MTFSpawnBroadcast, "%type%", supplyType.SupplyTypeName, RegexOptions.IgnoreCase);
                Map.Get.SendBroadcast(15, message);
            }
            yield return Timing.WaitForSeconds(15f);

            foreach (var items in supplyType.SupplyItems)
            {
                int chance = UnityEngine.Random.Range(0, 100);
                if (chance <= items.Chance)
                {
                    if (items.Amount > 1)
                    {
                        for (int y = 0; y < items.Amount; y++)
                            items.Item.Parse().Drop(MtfSpawn);
                    }
                    else
                        items.Item.Parse().Drop(MtfSpawn);
                }
            }
        }

        public IEnumerator<float> DropCHI()
        {
            Round.Get.SpawnVehicle(true);

            SupplyType supplyType = Plugin.Config.SupplyDrops[UnityEngine.Random.Range(0, Plugin.Config.SupplyDrops.Count())];

            if (Plugin.Config.DoBroadcast)
                Map.Get.SendBroadcast(15, Plugin.PluginTranslation.ActiveTranslation.CISpawnBroadcast.Replace("%type%", supplyType.SupplyTypeName));

            yield return Timing.WaitForSeconds(15f);

            foreach (var items in supplyType.SupplyItems)
            {
                int chance = UnityEngine.Random.Range(0, 100);
                if (chance <= items.Chance)
                {
                    if (items.Amount > 1)
                    {
                        for (int y = 0; y < items.Amount; y++)
                            items.Item.Parse().Drop(CiSpawn);
                    }
                    else
                        items.Item.Parse().Drop(CiSpawn);
                }
            }
        }

    }
}
