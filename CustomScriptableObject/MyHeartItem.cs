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
            int myHeartRarity = 30;
            Item myHeartItem = bundle.LoadAsset<Item>("Assets/DingusThings/Items/MyHeart.asset");
            myHeartItem.toolTips = ["What she said : [ LMB ]"];
            // add custom behavior
            MyHeartPhysicsProp myHeartProp = myHeartItem.spawnPrefab.AddComponent<MyHeartPhysicsProp>();
            myHeartProp.grabbable = true;
            myHeartProp.grabbableToEnemies = true;
            myHeartProp.isInFactory = true;
            myHeartProp.itemProperties = myHeartItem;

            // register prefab
            NetworkPrefabs.RegisterNetworkPrefab(myHeartItem.spawnPrefab);
            Utilities.FixMixerGroups(myHeartItem.spawnPrefab);
            Items.RegisterScrap(myHeartItem, myHeartRarity, Levels.LevelTypes.All);
        }
    }
}
