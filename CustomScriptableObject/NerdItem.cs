using DingusThings.Behaviours;
using LethalLib.Modules;
using UnityEngine;

namespace DingusThings.CustomScriptableObject
{
    internal class NerdItem
    {
        public static void Register()
        {
            string itemName = "Nerd";
            AssetBundle? bundle = DingusThings.Bundle;
            if (bundle == null)
            {
                DingusThings.Logger.LogError(itemName + " failed to load.");
                return;
            }
            /// Nerd
            int rarity = 40;
            Item item = bundle.LoadAsset<Item>("Assets/DingusThings/Items/Nerd.asset");
            item.toolTips = ["Ackchually: [LMB]"];
            NerdPhysicsProp nerdPhysicsProp = item.spawnPrefab.AddComponent<NerdPhysicsProp>();
            nerdPhysicsProp.grabbable = true;
            nerdPhysicsProp.grabbableToEnemies = true;
            nerdPhysicsProp.isInFactory = true;
            nerdPhysicsProp.itemProperties = item;

            // register prefab
            NetworkPrefabs.RegisterNetworkPrefab(item.spawnPrefab);
            Utilities.FixMixerGroups(item.spawnPrefab);
            Items.RegisterScrap(item, rarity, Levels.LevelTypes.All);
        }
    }
}
