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
            Server.Get.Events.Round.RoundStartEvent += onStart;
            Server.Get.Events.Round.RoundEndEvent += onRoundEnd;
            Server.Get.Events.Round.RoundRestartEvent += onRoundRestart;
        }


        public void onStart()
        {
            _start = Timing.RunCoroutine(doSupplyDrop());
        }

        public void onRoundEnd() => Timing.KillCoroutines(_start);

        public void onRoundRestart() => Timing.KillCoroutines(_start);


        public IEnumerator<float> doSupplyDrop()
        {
            while (true)
            {
                yield return Timing.WaitForSeconds(Plugin.Config.supplyIntervall);

                if (Server.Get.Players.Count >= Plugin.Config.minPlayersForSupply)
                {
                    if (Plugin.Config.doCassieAnnouncement)
                        Map.Get.GlitchedCassie(Plugin.Config.cassieAnnouncement);

                    if (!Plugin.Config.isOnlyHelicopter)
                    {
                        int i = r.Next(1, 101);
                        if (i <= Plugin.Config.ciCarChance)
                        {

                            RespawnEffectsController.ExecuteAllEffects(RespawnEffectsController.EffectType.Selection, SpawnableTeamType.ChaosInsurgency);

                            if (Plugin.Config.doBroadcast)
                                Map.Get.SendBroadcast(Plugin.Config.broadcastDuration, Plugin.Config.broadcastMessageCI);

                            yield return Timing.WaitForSeconds(15f);


                            foreach (var items in Plugin.Config.items)
                                items.Parse().Drop(ciSpawn);

                        }
                        else
                        {
                            RespawnEffectsController.ExecuteAllEffects(RespawnEffectsController.EffectType.Selection, SpawnableTeamType.NineTailedFox);

                            if (Plugin.Config.doBroadcast)
                                Map.Get.SendBroadcast(Plugin.Config.broadcastDuration, Plugin.Config.broadcastMessageMTF);

                            yield return Timing.WaitForSeconds(15f);

                            foreach (var items in Plugin.Config.items)
                                items.Parse().Drop(mtfSpawn);

                        }
                    }
                    else
                    {
                        RespawnEffectsController.ExecuteAllEffects(RespawnEffectsController.EffectType.Selection, SpawnableTeamType.NineTailedFox);

                        if (Plugin.Config.doBroadcast)
                            Map.Get.SendBroadcast(Plugin.Config.broadcastDuration, Plugin.Config.broadcastMessageMTF);

                        yield return Timing.WaitForSeconds(15f);

                        foreach (var items in Plugin.Config.items)
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
