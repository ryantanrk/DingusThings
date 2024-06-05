using DingusThings.Behaviours;
using HarmonyLib;

namespace DingusThings.Patches
{
    internal class SteamGiftPatch
    {
        [HarmonyPatch(typeof(GrabbableObject), nameof(GrabbableObject.GrabItem))]
        [HarmonyPrefix]
        public static void GrabbableObject_GrabItem(GrabbableObject __instance)
        {
            if (__instance.itemProperties.itemName == "Steam Gift Card")
            {
                // change tooltip on grab
                HUDManager.Instance.ChangeControlTip(2, __instance.scrapValue <= 0 ? "ALREADY REDEEMED" : "Redeem : [ LMB ]");
            }
        }
    }
}
