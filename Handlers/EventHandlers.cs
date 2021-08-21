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
        Vector3 mtfSpawn = new Vector3(180, 993, -58);
        Vector3 ciSpawn = new Vector3(5, 988, -58);
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

                                if (Plugin.Config.DoBroadcast)
                                    Map.Get.SendBroadcast(Plugin.Config.BroadcastDuration, Plugin.PluginTranslation.ActiveTranslation.CISpawnBroadcast);

                                yield return Timing.WaitForSeconds(15f);


                                foreach (var items in Plugin.Config.Items)
                                    items.Parse().Drop(ciSpawn);

                            }
                            else
                            {
                                RespawnEffectsController.ExecuteAllEffects(RespawnEffectsController.EffectType.Selection, SpawnableTeamType.NineTailedFox);

                                if (Plugin.Config.DoBroadcast)
                                    Map.Get.SendBroadcast(Plugin.Config.BroadcastDuration, Plugin.PluginTranslation.ActiveTranslation.MTFSpawnBroadcast);

                                yield return Timing.WaitForSeconds(15f);

                                foreach (var items in Plugin.Config.Items)
                                    items.Parse().Drop(mtfSpawn);

                            }
                        }
                        else
                        {
                            RespawnEffectsController.ExecuteAllEffects(RespawnEffectsController.EffectType.Selection, SpawnableTeamType.NineTailedFox);

                            if (Plugin.Config.DoBroadcast)
                                Map.Get.SendBroadcast(Plugin.Config.BroadcastDuration, Plugin.PluginTranslation.ActiveTranslation.MTFSpawnBroadcast);

                            yield return Timing.WaitForSeconds(15f);

                            foreach (var items in Plugin.Config.Items)
                                items.Parse().Drop(mtfSpawn);
                        }

                        yield return Timing.WaitForOneFrame;
                    }
                    else
                        Server.Get.Logger.Info("Not enough players for a supplydrop, skipping");
                }
            }

        }

    }
}
