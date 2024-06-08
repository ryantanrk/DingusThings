using LethalLib.Modules;
using UnityEngine;

namespace DingusThings.CustomScriptableObject
{
    internal class InstantNoodlePackItem
    {
        public static void Register()
        {
            AssetBundle? bundle = DingusThings.Bundle;
            if (bundle == null)
            {
                DingusThings.Logger.LogError("Instant noodle packs failed to load.");
                return;
            }

            int rarity = 70;
            Item maggiItem = bundle.LoadAsset<Item>("Assets/DingusThings/Items/MaggiInstantNoodlePack.asset");
            PhysicsProp maggiPhysicsProp = maggiItem.spawnPrefab.AddComponent<PhysicsProp>();
            maggiPhysicsProp.grabbable = true;
            maggiPhysicsProp.grabbableToEnemies = true;
            maggiPhysicsProp.isInFactory = true;
            maggiPhysicsProp.itemProperties = maggiItem;

            // register scrap
            NetworkPrefabs.RegisterNetworkPrefab(maggiItem.spawnPrefab);
            Utilities.FixMixerGroups(maggiItem.spawnPrefab);
            Items.RegisterScrap(maggiItem, rarity, Levels.LevelTypes.All);

            Item indomieItem = bundle.LoadAsset<Item>("Assets/DingusThings/Items/IndomieInstantNoodlePack.asset");
            PhysicsProp indomiePhysicsProp = indomieItem.spawnPrefab.AddComponent<PhysicsProp>();
            indomiePhysicsProp.grabbable = true;
            indomiePhysicsProp.grabbableToEnemies = true;
            indomiePhysicsProp.isInFactory = true;
            indomiePhysicsProp.itemProperties = maggiItem;

            // register scrap
            NetworkPrefabs.RegisterNetworkPrefab(indomieItem.spawnPrefab);
            Utilities.FixMixerGroups(indomieItem.spawnPrefab);
            Items.RegisterScrap(indomieItem, rarity, Levels.LevelTypes.All);
        }
    }
}
