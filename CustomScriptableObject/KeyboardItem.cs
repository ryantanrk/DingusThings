﻿using DingusThings.Behaviours;
using LethalLib.Modules;
using UnityEngine;

namespace DingusThings.CustomScriptableObject
{
    internal class KeyboardItem
    {
        public static void Register()
        {
            AssetBundle? bundle = DingusThings.Bundle;
            if (bundle == null)
            {
                DingusThings.Logger.LogError("Instant noodle packs failed to load.");
                return;
            }

            int rarity = 30;
            Item item = bundle.LoadAsset<Item>("Assets/DingusThings/Items/Keyboard.asset");
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