using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace GrimeRandomizer
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class GrimeRandomizer : BaseUnityPlugin
    {
        internal static new ManualLogSource Log;

        private void Awake()
        {
            // Initialize logger
            Log = base.Logger;

            // Create and patch all harmony patches using auto-discovery
            Harmony harmony = new Harmony(PluginInfo.PLUGIN_GUID);
            harmony.PatchAll();

            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} has loaded!");
        }
    }
}
