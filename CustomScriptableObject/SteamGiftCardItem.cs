using DingusThings.Behaviours;
using DingusThings.Patches;
using HarmonyLib;
using LethalLib.Modules;
using UnityEngine;

namespace DingusThings.CustomScriptableObject
{
    internal class SteamGiftCardItem
    {
        public static void Register()
        {
            string itemName = "Steam Gift Card";
            AssetBundle? bundle = DingusThings.Bundle;
            if (bundle == null)
            {
                DingusThings.Logger.LogError(itemName + " failed to load.");
                return;
            }
            /// Steam Gift Card
            Harmony.CreateAndPatchAll(typeof(SteamGiftPatch));
            int rarity = 60;
            Item item = bundle.LoadAsset<Item>("Assets/DingusThings/Items/SteamGiftCard.asset");
            item.toolTips = ["Inspect: [Z]"];
            SteamGiftPhysicsProp steamGiftPhysicsProp = item.spawnPrefab.AddComponent<SteamGiftPhysicsProp>();
            steamGiftPhysicsProp.grabbable = true;
            steamGiftPhysicsProp.grabbableToEnemies = true;
            steamGiftPhysicsProp.isInFactory = true;
            steamGiftPhysicsProp.itemProperties = item;

            // register prefab
            NetworkPrefabs.RegisterNetworkPrefab(item.spawnPrefab);
            Utilities.FixMixerGroups(item.spawnPrefab);
            Items.RegisterScrap(item, rarity, Levels.LevelTypes.All);
        }
    }
}
