using BepInEx;
using BepInEx.Logging;
using DingusThings.CustomScriptableObject;
using DingusThings.Patches;
using HarmonyLib;
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

        private static Terminal? terminalInstance;

        public static void SetTerminalInstance(Terminal terminal)
        {
            terminalInstance = terminal;
        }

        public static Terminal? GetTerminalInstance()
        {
            if (terminalInstance != null)
            {
                return terminalInstance;
            } 
            else
            {
                return null;
            }
        }

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

            // load patch
            Harmony.CreateAndPatchAll(typeof(TerminalPatch));

            // register custom scrap
            MyHeartItem.Register();
            SteamGiftCardItem.Register();
            LifebuoyBarSoapItem.Register();
            MaggiInstantNoodlePackItem.Register();
            
            Logger.LogInfo($"{PluginString} has loaded!");
        }
    }
}
