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
using System.Threading.Tasks;
using UnityEngine;
using Random = System.Random;

namespace SupplyDrops.Handlers
{
    class EventHandlers
    {
        Random r = new Random();
        private CoroutineHandle _start;
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
                _start = Timing.RunCoroutine(DoSupplyDrop());
            }
        }

        public void OnRoundEnd() => Timing.KillCoroutines(_start);

        public void OnRoundRestart() => Timing.KillCoroutines(_start);


        public IEnumerator<float> DoSupplyDrop()
        {
            if (Plugin.Config.IsEnabled)
            {
                Vector3 MtfSpawn = new Vector3(Plugin.Config.MTFSpawnLocation.x, Plugin.Config.MTFSpawnLocation.y, Plugin.Config.MTFSpawnLocation.z);
                Vector3 CiSpawn = new Vector3(Plugin.Config.CISpawnLocation.x, Plugin.Config.CISpawnLocation.y, Plugin.Config.CISpawnLocation.z);
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

                                RespawnEffectsController.ExecuteAllEffects(RespawnEffectsController.EffectType.Selection, SpawnableTeamType.ChaosInsurgency);
                                SupplyType supplyType = Plugin.Config.SupplyDrops[UnityEngine.Random.Range(0, Plugin.Config.SupplyDrops.Count())];

                                if (Plugin.Config.DoBroadcast)
                                    Map.Get.SendBroadcast(15, Plugin.PluginTranslation.ActiveTranslation.CISpawnBroadcast.Replace("%type%", supplyType.SupplyTypeName));

                                yield return Timing.WaitForSeconds(15f);

                                foreach(var items in supplyType.SupplyItems)
                                {
                                    int chance = UnityEngine.Random.Range(0, 100);
                                    if (chance <= items.Chance)
                                    {
                                        if(items.Amount > 1)
                                        {
                                            for (int y = 0; y < items.Amount; y++)
                                                items.Item.Parse().Drop(CiSpawn);
                                        }
                                        else
                                            items.Item.Parse().Drop(CiSpawn);
                                    }
                                }
                            }
                            else
                            {
                                RespawnEffectsController.ExecuteAllEffects(RespawnEffectsController.EffectType.Selection, SpawnableTeamType.NineTailedFox);
                                SupplyType supplyType = Plugin.Config.SupplyDrops[UnityEngine.Random.Range(0, Plugin.Config.SupplyDrops.Count())];

                                if (Plugin.Config.DoBroadcast)
                                    Map.Get.SendBroadcast(15, Plugin.PluginTranslation.ActiveTranslation.MTFSpawnBroadcast.Replace("%type%", supplyType.SupplyTypeName));

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
                        }
                        else
                        {
                            RespawnEffectsController.ExecuteAllEffects(RespawnEffectsController.EffectType.Selection, SpawnableTeamType.NineTailedFox);
                            SupplyType supplyType = Plugin.Config.SupplyDrops[UnityEngine.Random.Range(0, Plugin.Config.SupplyDrops.Count())];

                            if (Plugin.Config.DoBroadcast)
                                Map.Get.SendBroadcast(15, Plugin.PluginTranslation.ActiveTranslation.MTFSpawnBroadcast.Replace("%type%", supplyType.SupplyTypeName));

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
                    }
                    else
                        Server.Get.Logger.Info("[SupplyDrops] Not enough players for a supplydrop, skipping");
                }
            }

        }

    }
}
