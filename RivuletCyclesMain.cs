using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BepInEx;
using RWCustom;
using UnityEngine;
using IL;
using On;
using Debug = UnityEngine.Debug;
using System.Security.Permissions;
using System.Security;

#pragma warning disable CS0618
[module: UnverifiableCode]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]

namespace GiveSlugCatRivuletCycles
{
    
    [BepInPlugin(PLUGIN_GUID, PLUGIN_NAME, PLUGIN_VERSION)]
    public class RivuletCyclesMain : BaseUnityPlugin
    {
       

        public const string PLUGIN_GUID = "ikepike.RivuletCyclesForAllSlugcats";
        public const string PLUGIN_NAME = "\"Ever felt like the campaigns were easy? WELL WHAT IF WE GAVE YOU THE LOWEST CYCLE?? \\n \\n A mod that makes every campaign have the rivulet cycles (which is 2 minutes and 30 seconds (6000 ticks in total!!!! WOW)) \\n \\n source code: https://github.com/Ikepik3/giveSlugcatsRivuletCycles\"";
        public const string PLUGIN_VERSION = "1.0.0";


        public void Start()
        {
            On.RainCycle.Update += RainSetHook;
        }

        public void OnEnable()
        {

            On.RainCycle.Update += RainUpdateHook;
        }

        void RainSetHook(On.RainCycle.orig_Update orig, RainCycle rain)
        {
            var timeLeft = 6000; // the time of a rivulet cycle (which is 2 minutes and 30 seconds)

            rain.cycleLength = timeLeft; // Give the cycleLength the time of said cycle
        }


        void RainUpdateHook(On.RainCycle.orig_Update orig, RainCycle rain)
        {
            rain.timer += 1; // assuming the code always run per tick, add one tick to the timer, a second in rain world is 20 ticks.

            Debug.Log("test");
            Debug.Log(rain.deathRainHasHit);

            if (rain.timer == 7000)
            {
                rain.deathRainHasHit = true;
                rain.RainHit();

                

                Debug.Log("rainIsComing");
                Debug.Log(rain.deathRainHasHit);
            }
        }
    }
}
