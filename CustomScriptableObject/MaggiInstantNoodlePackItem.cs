using LethalLib.Modules;
using UnityEngine;

namespace DingusThings.CustomScriptableObject
{
    internal class MaggiInstantNoodlePackItem
    {
        public static void Register()
        {
            string itemName = "Maggi Instant Noodle pack";
            AssetBundle? bundle = DingusThings.Bundle;
            if (bundle == null)
            {
                DingusThings.Logger.LogError(itemName + " failed to load.");
                return;
            }

            int rarity = 70;
            Item item = bundle.LoadAsset<Item>("Assets/DingusThings/Items/MaggiInstantNoodlePack.asset");
            PhysicsProp physicsProp = item.spawnPrefab.AddComponent<PhysicsProp>();
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
