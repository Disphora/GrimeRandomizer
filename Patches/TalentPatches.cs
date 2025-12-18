using HarmonyLib;
using System;
using System.Collections.Generic;
using UnityEngine;
using static GrimeRandomizer.ItemRepository;
using static PlayerDataPreset.Inventory;

namespace GrimeRandomizer.Patches
{
    public class TalentPatches
    {
        internal static Dictionary<ItemCoord, List<ItemDefinition>>? itemCoordsPair;
        internal static bool customTalentSet = false;
        internal static bool customGiveItem = false;
        internal static bool customFlagSet = false;
        internal static bool isPullAquired = false;

        [HarmonyPatch(typeof(PlayerData_Talents), "SetTalentRank")]
        [HarmonyPrefix]
        public static bool GiveRandomFromRank(ref Data_Talent talent, int rank)
        {
            if (itemCoordsPair == null)
                return true;

            AccessTools.FieldRef<GameHandler, Data_Talent[]> unlockSkillsBase = AccessTools.FieldRefAccess<GameHandler, Data_Talent[]>("unlockSkillsBase");
            AccessTools.FieldRef<GameHandler, Data_Talent[]> unlockSkillsDLC = AccessTools.FieldRefAccess<GameHandler, Data_Talent[]>("unlockSkillsDLC");
            PlayerData_Inventory playerData_Inventory = PlayerData_Inventory.instance;
            ItemCoord kvpToRemove = new ItemCoord(Vector3.zero);

            string[] talentNameSplit = talent.name.Split(' ');
            string talrep1 = talentNameSplit[talentNameSplit.Length - 1].Replace("(", string.Empty);
            string talrep2 = talrep1.Replace(")", string.Empty);

            bool isRandomizableSkill = false;
            if (talrep2 == "Pull" || talrep2 == "Grow" || talrep2 == "Air Dash" || talrep2 == "Self Pull" || talrep2 == "Pull Items")
            {
                isRandomizableSkill = true;
            }

            foreach (KeyValuePair<ItemCoord, ItemDefinition> keyValuePair in itemCoordsPair)
            {
                if (talrep2 == keyValuePair.Key.ItemName && !customTalentSet)
                {
                    ProcessTalentItem(keyValuePair.Value, unlockSkillsBase, unlockSkillsDLC, playerData_Inventory, ref kvpToRemove);
                }
            }
            itemCoordsPair.Remove(kvpToRemove);

            if (!customTalentSet && isRandomizableSkill)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        [HarmonyPatch(typeof(PlayerData_Talents), "IsTalentAquired")]
        [HarmonyPrefix]
        public static bool TalentAquiredHijack(Data_Talent talent)
        {
            string[] talentNameSplit = talent.name.Split(' ');
            string talrep1 = talentNameSplit[talentNameSplit.Length - 1].Replace("(", string.Empty);
            string talrep2 = talrep1.Replace(")", string.Empty);

            if (talrep2 == "Pull" && !isPullAquired)
            {
                return false;
            }

            return true;
        }

        private static void ProcessTalentItem(ItemDefinition itemDef, 
            AccessTools.FieldRef<GameHandler, Data_Talent[]> unlockSkillsBase,
            AccessTools.FieldRef<GameHandler, Data_Talent[]> unlockSkillsDLC,
            PlayerData_Inventory playerData_Inventory,
            ref ItemCoord kvpToRemove)
        {
            switch (itemDef.Guid)
            {
                case "ardor":
                    customTalentSet = true;
                    PlayerData_Talents.instance.SetTalentRank(Hashtable_Talents.getHashtable.getTable[7].talentReference, 
                        Hashtable_Talents.getHashtable.getTable[7].talentReference.getRanksData.Length - 1);
                    customTalentSet = false;
                    break;
                case "pull":
                    customTalentSet = true;
                    PlayerData_Talents.instance.SetTalentRank(unlockSkillsBase(GameHandler.instance)[1], 
                        unlockSkillsBase(GameHandler.instance)[1].getRanksData.Length - 1);
                    isPullAquired = true;
                    customTalentSet = false;
                    break;
                case "itemPull":
                    customTalentSet = true;
                    PlayerData_Talents.instance.SetTalentRank(unlockSkillsBase(GameHandler.instance)[5], 
                        unlockSkillsBase(GameHandler.instance)[5].getRanksData.Length - 1);
                    customTalentSet = false;
                    break;
                case "airDash":
                    customTalentSet = true;
                    PlayerData_Talents.instance.SetTalentRank(unlockSkillsBase(GameHandler.instance)[2], 
                        unlockSkillsBase(GameHandler.instance)[2].getRanksData.Length - 1);
                    customTalentSet = false;
                    break;
                case "selfPull":
                    customTalentSet = true;
                    PlayerData_Talents.instance.SetTalentRank(unlockSkillsBase(GameHandler.instance)[3], 
                        unlockSkillsBase(GameHandler.instance)[3].getRanksData.Length - 1);
                    customTalentSet = false;
                    break;
                case "doubleJump":
                    customTalentSet = true;
                    PlayerData_Talents.instance.SetTalentRank(unlockSkillsBase(GameHandler.instance)[4], 
                        unlockSkillsBase(GameHandler.instance)[4].getRanksData.Length - 1);
                    customTalentSet = false;
                    break;
                case "hover":
                    customTalentSet = true;
                    PlayerData_Talents.instance.SetTalentRank(unlockSkillsDLC(GameHandler.instance)[1], 
                        unlockSkillsDLC(GameHandler.instance)[0].getRanksData.Length - 1);
                    customTalentSet = false;
                    break;
                case "sprint":
                    customTalentSet = true;
                    PlayerData_Talents.instance.SetTalentRank(unlockSkillsDLC(GameHandler.instance)[0], 
                        unlockSkillsDLC(GameHandler.instance)[0].getRanksData.Length - 1);
                    customTalentSet = false;
                    break;
                default:
                    GrimeRandomizer.Log.LogInfo("Giving randomized item " + Hashtable_Items.getHashtable.GetItemByID(itemDef.Guid));
                    customGiveItem = true;
                    playerData_Inventory.GiveItem(Hashtable_Items.getHashtable.GetItemByID(itemDef.Guid), itemDef.Quantity);
                    customGiveItem = false;

                    if (itemDef.Guid == ItemRepository.StrandOfTheChild)
                    {
                        customFlagSet = true;
                        SyncHandler.SetGlobalFlagValue("GSF_Shidra", 2);
                    }
                    break;
            }
        }
    }
}
