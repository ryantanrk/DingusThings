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
            int steamGiftRarity = 50;
            Item steamGiftItem = bundle.LoadAsset<Item>("Assets/DingusThings/Items/SteamGiftCard.asset");
            steamGiftItem.toolTips = ["Inspect : [ Z ]"];
            SteamGiftPhysicsProp steamGiftPhysicsProp = steamGiftItem.spawnPrefab.AddComponent<SteamGiftPhysicsProp>();
            steamGiftPhysicsProp.grabbable = true;
            steamGiftPhysicsProp.grabbableToEnemies = true;
            steamGiftPhysicsProp.isInFactory = true;
            steamGiftPhysicsProp.itemProperties = steamGiftItem;

            // register prefab
            NetworkPrefabs.RegisterNetworkPrefab(steamGiftItem.spawnPrefab);
            Utilities.FixMixerGroups(steamGiftItem.spawnPrefab);
            Items.RegisterScrap(steamGiftItem, steamGiftRarity, Levels.LevelTypes.All);
        }
    }
}
