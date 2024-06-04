using HarmonyLib;

namespace DingusThings.Patches
{
    internal class TerminalPatch
    {
        // tell Harmony which class method is being targeted
        [HarmonyPatch(typeof(Terminal), nameof(Terminal.Start))]
        // run after original method
        [HarmonyPostfix]
        public static void Terminal_Start(Terminal __instance)
        {
            DingusThings.SetTerminalInstance(__instance);
        }
    }
}
