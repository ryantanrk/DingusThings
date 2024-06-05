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
            Harmony.CreateAndPatchAll(typeof(LifebuoyBarSoapPatch));
            int lifebuoyBarSoapRarity = 60;
            Item lifebuoyBarSoapItem = bundle.LoadAsset<Item>("Assets/DingusThings/Items/LifebuoyBarSoap.asset");
            PhysicsProp lifebuoyBarSoapItemPhysicsProp = lifebuoyBarSoapItem.spawnPrefab.AddComponent<PhysicsProp>();
            lifebuoyBarSoapItemPhysicsProp.grabbable = true;
            lifebuoyBarSoapItemPhysicsProp.grabbableToEnemies = true;
            lifebuoyBarSoapItemPhysicsProp.isInFactory = true;
            lifebuoyBarSoapItemPhysicsProp.itemProperties = lifebuoyBarSoapItem;

            // register prefab
            NetworkPrefabs.RegisterNetworkPrefab(lifebuoyBarSoapItem.spawnPrefab);
            Utilities.FixMixerGroups(lifebuoyBarSoapItem.spawnPrefab);
            Items.RegisterScrap(lifebuoyBarSoapItem, lifebuoyBarSoapRarity, Levels.LevelTypes.All);
        }
    }
}
