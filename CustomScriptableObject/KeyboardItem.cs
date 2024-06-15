using DingusThings.Behaviours;
using LethalLib.Modules;
using UnityEngine;

namespace DingusThings.CustomScriptableObject
{
    internal class KeyboardItem
    {
        public static void Register()
        {
            string itemName = "Keyboard";
            AssetBundle? bundle = DingusThings.Bundle;
            if (bundle == null)
            {
                DingusThings.Logger.LogError(itemName + " failed to load.");
                return;
            }

            int rarity = 30;
            Item item = bundle.LoadAsset<Item>("Assets/DingusThings/Items/Keyboard.asset");
            item.toolTips = ["Type: [LMB]"];
            KeyboardPhysicsProp physicsProp = item.spawnPrefab.AddComponent<KeyboardPhysicsProp>();
            physicsProp.grabbable = true;
            physicsProp.grabbableToEnemies = true;
            physicsProp.isInFactory = true;
            physicsProp.itemProperties = item;

            // register scrap
            NetworkPrefabs.RegisterNetworkPrefab(item.spawnPrefab);
            Utilities.FixMixerGroups(item.spawnPrefab);
            Items.RegisterScrap(item, rarity, Levels.LevelTypes.All);
        }
    }
}
