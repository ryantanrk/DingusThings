using DingusThings.Behaviours;
using HarmonyLib;

namespace DingusThings.Patches
{
    internal class SeedPatch
    {
        [HarmonyPatch(typeof(StartOfRound), nameof(StartOfRound.ChooseNewRandomMapSeed))]
        [HarmonyPostfix]
        public static void StartOfRound_ChooseNewRandomMapSeed(StartOfRound __instance)
        {
            // save random map seed to our instance
            DingusThings.SetRandomMapSeed(__instance.randomMapSeed);
        }
    }
}
