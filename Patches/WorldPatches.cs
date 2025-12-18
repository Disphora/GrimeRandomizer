using HarmonyLib;
using System.Collections;
using UnityEngine;

namespace GrimeRandomizer.Patches
{
    public class WorldPatches
    {
        internal static bool pickedItem = false;
        internal static bool pickedItem2 = false;
        internal static Vector3 itemCollectedTemp = Vector3.zero;
        internal static Vector3 lastPos = Vector3.zero;

        [HarmonyPatch(typeof(PickableItemHandler), "UpdateFrame")]
        [HarmonyPrefix]
        public static bool GetCoord(PickableItemHandler __instance)
        {
            AccessTools.FieldRef<PickableItemHandler, bool> didPick = AccessTools.FieldRefAccess<PickableItemHandler, bool>("didPick");
            
            if (didPick(__instance) && !pickedItem)
            {
                pickedItem = true;
                AccessTools.FieldRef<PickableItemHandler, Vector3> itemLocation = AccessTools.FieldRefAccess<PickableItemHandler, Vector3>("prePickupLocation");
                GrimeRandomizer.Log.LogInfo("prePickupLocation: " + itemLocation(__instance) + " transform.position " + __instance.transform.position);
                __instance.StartCoroutine(ResetGetCoord());
                didPick(__instance) = false;

                itemCollectedTemp = __instance.transform.position;
            }
            return true;
        }

        [HarmonyPatch(typeof(PickableItemHandler), "OnAbsorb")]
        [HarmonyPrefix]
        public static bool GetCoord2(PickableItemHandler __instance)
        {
            AccessTools.FieldRef<PickableItemHandler, Vector3> itemLocation = AccessTools.FieldRefAccess<PickableItemHandler, Vector3>("prePickupLocation");
            GrimeRandomizer.Log.LogInfo("prePickupLocation: " + itemLocation(__instance) + " transform.position " + __instance.transform.position);

            itemCollectedTemp = __instance.transform.position;
            return true;
        }

        [HarmonyPatch(typeof(InteractableMine), "PickUp")]
        [HarmonyPrefix]
        public static bool GetBloodmetalCoord(InteractableMine __instance)
        {
            GrimeRandomizer.Log.LogInfo("Bloodmetal transform.position " + __instance.transform.position);
            itemCollectedTemp = __instance.transform.position;
            return true;
        }

        private static IEnumerator ResetGetCoord()
        {
            yield return new WaitForSeconds(0.9f);
            pickedItem = false;
        }
    }
}
