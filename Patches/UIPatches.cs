using HarmonyLib;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GrimeRandomizer.Patches
{
    public class UIPatches
    {
        internal static bool customFlagSet = false;

        [HarmonyPatch(typeof(MainMenuHandler), "Start")]
        [HarmonyPrefix]
        public static bool SetRandoText(MainMenuHandler __instance)
        {
            AccessTools.FieldRef<MainMenuHandler, TextMeshProUGUI> gvText = AccessTools.FieldRefAccess<MainMenuHandler, TextMeshProUGUI>("gameVersionText");
            gvText(__instance).text = "Randomizer " + PluginInfo.PLUGIN_VERSION;
            gvText(__instance).autoSizeTextContainer = true;

            AccessTools.FieldRef<MainMenuHandler, GameObject> exButton = AccessTools.FieldRefAccess<MainMenuHandler, GameObject>("exitButton");
            AccessTools.FieldRef<MainMenuHandler, GameObject[]> buttonCarriers = AccessTools.FieldRefAccess<MainMenuHandler, GameObject[]>("buttonCarriers");
            AccessTools.FieldRef<MainMenuHandler, GameObject[]> mainMenuStyles = AccessTools.FieldRefAccess<MainMenuHandler, GameObject[]>("mainMenuStyles");
            AccessTools.FieldRef<MainMenuHandler, Button[]> panelButtons = AccessTools.FieldRefAccess<MainMenuHandler, Button[]>("panelButtons");
            
            GameObject randoSettingsButton = GameObject.Instantiate(exButton(__instance));
            randoSettingsButton.transform.SetParent(buttonCarriers(__instance)[0].transform);
            randoSettingsButton.transform.position = new Vector3(960f, 385f, 0.00f);
            randoSettingsButton.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
            
            Button rsButton = randoSettingsButton.GetComponentInChildren<Button>();
            rsButton.onClick.SetPersistentListenerState(0, UnityEventCallState.Off);
            rsButton.onClick.AddListener(() => SaveRandomState.Delete("RandomizedState"));
            rsButton.name = "MainMenu_Button_RSettings";
            panelButtons(__instance).AddItem(rsButton);
            
            TextMeshProUGUI randoSettingsButtonText = randoSettingsButton.GetComponentInChildren<TextMeshProUGUI>();
            randoSettingsButtonText.text = "Randomize Again";
            randoSettingsButtonText.autoSizeTextContainer = true;

            return true;
        }

        [HarmonyPatch(typeof(SyncHandler), "_SetGlobalFlagValue")]
        [HarmonyPrefix]
        public static bool FlagSet(string flagName, int flagValue)
        {
            if (flagName == "GSF_Shidra" && !customFlagSet)
            {
                return false;
            }
            else if (customFlagSet)
            {
                customFlagSet = false;
                return true;
            }
            else
            {
                return true;
            }
        }
    }
}
