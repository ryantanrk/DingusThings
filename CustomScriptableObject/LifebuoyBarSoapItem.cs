using DingusThings.Patches;
using HarmonyLib;
using LethalLib.Modules;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace DingusThings.CustomScriptableObject
{
    internal class LifebuoyBarSoapItem
    {
        public static void Register()
        {
            string itemName = "Lifebuoy Bar Soap";
            AssetBundle? bundle = DingusThings.Bundle;
            if (bundle == null)
            {
                DingusThings.Logger.LogError(itemName + " failed to load.");
                return;
            }
            /// Lifebuoy Bar Soap
            int rarity = 10;
            Item item = bundle.LoadAsset<Item>("Assets/DingusThings/Items/LifebuoyBarSoap.asset");
            PhysicsProp lifebuoyBarSoapItemPhysicsProp = item.spawnPrefab.AddComponent<PhysicsProp>();
            lifebuoyBarSoapItemPhysicsProp.grabbable = true;
            lifebuoyBarSoapItemPhysicsProp.grabbableToEnemies = true;
            lifebuoyBarSoapItemPhysicsProp.isInFactory = true;
            lifebuoyBarSoapItemPhysicsProp.itemProperties = item;

            // register prefab
            NetworkPrefabs.RegisterNetworkPrefab(item.spawnPrefab);
            Utilities.FixMixerGroups(item.spawnPrefab);
            Items.RegisterScrap(item, rarity, Levels.LevelTypes.All);
        }
    }
}
