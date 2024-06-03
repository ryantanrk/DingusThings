using BepInEx;
using BepInEx.Logging;
using DingusThings.Behaviours;
using HarmonyLib;
using LethalLib.Modules;
using System.IO;
using System.Reflection;
using UnityEngine;

namespace DingusThings
{
    [BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
    [BepInDependency(LethalLib.Plugin.ModGUID)]
    public class DingusThings : BaseUnityPlugin
    {
        public static DingusThings Instance { get; private set; } = null!;
        internal new static ManualLogSource Logger { get; private set; } = null!;
        internal static Harmony? Harmony { get; set; }

        public static AssetBundle? Bundle;

        public static string PluginString = $"{MyPluginInfo.PLUGIN_NAME} v{MyPluginInfo.PLUGIN_VERSION}";

        private void Awake()
        {
            Logger = base.Logger;
            Instance = this;
            string sAssemblyLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            // load assets
            Bundle = AssetBundle.LoadFromFile(Path.Combine(sAssemblyLocation, "dingus"));
            if (Bundle == null)
            {
                Logger.LogError($"{PluginString}: Failed to load custom assets.");
                return;
            }

            /// My Heart
            int myHeartRarity = 30;
            Item myHeartItem = Bundle.LoadAsset<Item>("Assets/DingusThings/Items/MyHeart.asset");
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

            /// Steam Gift Card
            int steamGiftRarity = 50;
            Item steamGiftItem = Bundle.LoadAsset<Item>("Assets/DingusThings/Items/SteamGiftCard.asset");
            steamGiftItem.toolTips = ["Inspect : [ Z ]", "Redeem : [ LMB ]"];
            SteamGiftPhysicsProp steamGiftPhysicsProp = steamGiftItem.spawnPrefab.AddComponent<SteamGiftPhysicsProp>();
            steamGiftPhysicsProp.grabbable = true;
            steamGiftPhysicsProp.grabbableToEnemies = true;
            steamGiftPhysicsProp.isInFactory = true;
            steamGiftPhysicsProp.itemProperties = steamGiftItem;
            
            // register prefab
            NetworkPrefabs.RegisterNetworkPrefab(steamGiftItem.spawnPrefab);
            Utilities.FixMixerGroups(steamGiftItem.spawnPrefab);
            Items.RegisterScrap(steamGiftItem, steamGiftRarity, Levels.LevelTypes.All);

            /// Lifebuoy Bar Soap
            int lifebuoyBarSoapRarity = 60;
            Item lifebuoyBarSoapItem = Bundle.LoadAsset<Item>("Assets/DingusThings/Items/LifebuoyBarSoap.asset");
            PhysicsProp lifebuoyBarSoapItemPhysicsProp = lifebuoyBarSoapItem.spawnPrefab.AddComponent<PhysicsProp>();
            lifebuoyBarSoapItemPhysicsProp.grabbable = true;
            lifebuoyBarSoapItemPhysicsProp.grabbableToEnemies = true;
            lifebuoyBarSoapItemPhysicsProp.isInFactory = true;
            lifebuoyBarSoapItemPhysicsProp.itemProperties = lifebuoyBarSoapItem;

            // register prefab
            NetworkPrefabs.RegisterNetworkPrefab(lifebuoyBarSoapItem.spawnPrefab);
            Utilities.FixMixerGroups(lifebuoyBarSoapItem.spawnPrefab);
            Items.RegisterScrap(lifebuoyBarSoapItem, lifebuoyBarSoapRarity, Levels.LevelTypes.All);

            Logger.LogInfo($"{PluginString} has loaded!");
        }
    }
}
