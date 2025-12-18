using HarmonyLib;
using System;
using System.Collections.Generic;
using UnityEngine;
using static GrimeRandomizer.ItemRepository;
using static PlayerDataPreset.Inventory;

namespace GrimeRandomizer.Patches
{
    public class InventoryPatches
    {
        [HarmonyPatch(typeof(PlayerData_Inventory), "GiveItem")]
        [HarmonyPrefix]
        public static bool GiveRandom(ref Data_Item item, ref int amount)
        {
            var core = RandomizerCore.Instance;

            if (core.ItemCoordsPair == null)
                return true;

            AccessTools.FieldRef<GameHandler, Data_Talent[]> unlockSkillsBase = AccessTools.FieldRefAccess<GameHandler, Data_Talent[]>("unlockSkillsBase");
            AccessTools.FieldRef<GameHandler, Data_Talent[]> unlockSkillsDLC = AccessTools.FieldRefAccess<GameHandler, Data_Talent[]>("unlockSkillsDLC");
            int assignedItemsQuantity = 0;
            ItemCoord kvpToRemove = new ItemCoord(Vector3.zero);

            if (core.ItemCollectedTemp == Vector3.zero)
            {
                if (Hashtable_Items.getHashtable.GetIdByItem(item) == ItemRepository.MaulAxe)
                {
                    foreach (KeyValuePair<ItemCoord, List<ItemDefinition>> keyValuePair in core.ItemCoordsPair)
                    {
                        if (keyValuePair.Key.ItemName == "MaulAxe" && keyValuePair.Value.Count > 0)
                        {
                            ProcessItemDefinition(ref item, ref amount, keyValuePair.Value[0], unlockSkillsBase, unlockSkillsDLC, ref kvpToRemove, core);
                        }
                    }
                }
                else
                {
                    // Item is null reference type, skip processing
                    amount = 0;
                }
            }
            else
            {
                foreach (KeyValuePair<ItemCoord, List<ItemDefinition>> keyValuePair in core.ItemCoordsPair)
                {
                    if (core.ItemCollectedTemp.x > keyValuePair.Key.Coord.x - 0.3 && core.ItemCollectedTemp.x < keyValuePair.Key.Coord.x + 0.3 && 
                        core.ItemCollectedTemp.y > keyValuePair.Key.Coord.y - 0.3 && core.ItemCollectedTemp.y < keyValuePair.Key.Coord.y + 0.3)
                    {
                        GrimeRandomizer.Log.LogInfo("Matching: " + keyValuePair.Key.Coord);
                        assignedItemsQuantity++;

                        if (keyValuePair.Value.Count > 0)
                        {
                            ProcessItemDefinition(ref item, ref amount, keyValuePair.Value[0], unlockSkillsBase, unlockSkillsDLC, ref kvpToRemove, core, assignedItemsQuantity);
                        }
                    }
                }
                core.ItemCoordsPair.Remove(kvpToRemove);

                if (core.ItemCoordsPair.Count == 0 || assignedItemsQuantity == 0)
                {
                    core.ItemCollectedTemp = Vector3.zero;
                }
            }

            return true;
        }

        private static void ProcessItemDefinition(ref Data_Item item, ref int amount, ItemDefinition itemDef, 
            AccessTools.FieldRef<GameHandler, Data_Talent[]> unlockSkillsBase, 
            AccessTools.FieldRef<GameHandler, Data_Talent[]> unlockSkillsDLC,
            ref ItemCoord kvpToRemove, RandomizerCore core, int assignedItemsQuantity = 1)
        {
            switch (itemDef.Guid)
            {
                case "ardor":
                    PlayerData_Talents.instance.SetTalentRank(Hashtable_Talents.getHashtable.getTable[7].talentReference, 
                        Hashtable_Talents.getHashtable.getTable[7].talentReference.getRanksData.Length - 1);
                    amount = 0;
                    break;
                case "pull":
                    PlayerData_Talents.instance.SetTalentRank(Hashtable_Talents.getHashtable.getTable[6].talentReference, 
                        Hashtable_Talents.getHashtable.getTable[6].talentReference.getRanksData.Length - 1);
                    core.IsPullAquired = true;
                    amount = 0;
                    break;
                case "itemPull":
                    PlayerData_Talents.instance.SetTalentRank(unlockSkillsBase(GameHandler.instance)[5], 
                        unlockSkillsBase(GameHandler.instance)[5].getRanksData.Length - 1);
                    amount = 0;
                    break;
                case "airDash":
                    PlayerData_Talents.instance.SetTalentRank(unlockSkillsBase(GameHandler.instance)[2], 
                        unlockSkillsBase(GameHandler.instance)[2].getRanksData.Length - 1);
                    amount = 0;
                    break;
                case "selfPull":
                    PlayerData_Talents.instance.SetTalentRank(unlockSkillsBase(GameHandler.instance)[3], 
                        unlockSkillsBase(GameHandler.instance)[3].getRanksData.Length - 1);
                    amount = 0;
                    break;
                case "doubleJump":
                    PlayerData_Talents.instance.SetTalentRank(unlockSkillsBase(GameHandler.instance)[4], 
                        unlockSkillsBase(GameHandler.instance)[4].getRanksData.Length - 1);
                    amount = 0;
                    break;
                case "hover":
                    PlayerData_Talents.instance.SetTalentRank(unlockSkillsDLC(GameHandler.instance)[1], 
                        unlockSkillsDLC(GameHandler.instance)[0].getRanksData.Length - 1);
                    amount = 0;
                    break;
                case "sprint":
                    PlayerData_Talents.instance.SetTalentRank(unlockSkillsDLC(GameHandler.instance)[0], 
                        unlockSkillsDLC(GameHandler.instance)[0].getRanksData.Length - 1);
                    amount = 0;
                    break;
                default:
                    if (assignedItemsQuantity == 1)
                    {
                        GrimeRandomizer.Log.LogInfo("Changing out item to randomized item " + Hashtable_Items.getHashtable.GetItemByID(itemDef.Guid));
                        item = Hashtable_Items.getHashtable.GetItemByID(itemDef.Guid);
                        amount = itemDef.Quantity;
                        kvpToRemove = new ItemCoord(Vector3.zero);

                        if (itemDef.Guid == ItemRepository.KilyahStone)
                        {
                            // Handle KilyahStone state
                            SyncHandler.SetGlobalFlagValue("GSF_Shidra", 1);
                        }

                        if (itemDef.Guid == ItemRepository.StrandOfTheChild)
                        {
                            // Handle StrandOfTheChild state
                            SyncHandler.SetGlobalFlagValue("GSF_Shidra", 2);
                        }
                    }
                    break;
            }
        }
    }
}
