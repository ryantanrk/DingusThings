using DingusThings.Behaviours;
using LethalLib.Modules;
using UnityEngine;

namespace DingusThings.CustomScriptableObject
{
    internal class MyHeartItem
    {
        public static void Register()
        {
            string itemName = "My Heart";
            AssetBundle? bundle = DingusThings.Bundle;
            if (bundle == null)
            {
                DingusThings.Logger.LogError(itemName + " failed to load.");
                return;
            }
            /// My Heart
            int rarity = 40;
            Item item = bundle.LoadAsset<Item>("Assets/DingusThings/Items/MyHeart.asset");
            item.toolTips = ["What she said: [LMB]"];
            // add custom behavior
            MyHeartPhysicsProp myHeartProp = item.spawnPrefab.AddComponent<MyHeartPhysicsProp>();
            myHeartProp.grabbable = true;
            myHeartProp.grabbableToEnemies = true;
            myHeartProp.isInFactory = true;
            myHeartProp.itemProperties = item;

            // register prefab
            NetworkPrefabs.RegisterNetworkPrefab(item.spawnPrefab);
            Utilities.FixMixerGroups(item.spawnPrefab);
            Items.RegisterScrap(item, rarity, Levels.LevelTypes.All);
        }
    }
}
