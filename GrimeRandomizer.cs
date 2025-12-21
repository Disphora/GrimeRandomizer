using BepInEx;
using BepInEx.Logging;
using Dreamteck;
using HarmonyLib;
using Rewired;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static GrimeRandomizer.ItemPool;

namespace GrimeRandomizer
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class GrimeRandomizer : BaseUnityPlugin
    {
        internal static new ManualLogSource Log;

        private void Awake()
        {
            Log = base.Logger;

            Harmony harmony = new Harmony(PluginInfo.PLUGIN_GUID);

            MethodInfo original2 = AccessTools.Method(typeof(GameHandler), "Start");
            MethodInfo patch2 = AccessTools.Method(typeof(Patches), "RandoPatch");
            harmony.Patch(original2, new HarmonyMethod(patch2));

            MethodInfo original5 = AccessTools.Method(typeof(PlayerData_Inventory), "GiveItem");
            MethodInfo patch5 = AccessTools.Method(typeof(Patches), "GiveRandom");
            harmony.Patch(original5, new HarmonyMethod(patch5));

            MethodInfo original = AccessTools.Method(typeof(PickableItemHandler), "UpdateFrame");
            MethodInfo patch = AccessTools.Method(typeof(Patches), "GetCoord");
            harmony.Patch(original, new HarmonyMethod(patch));

            MethodInfo original3 = AccessTools.Method(typeof(PickableItemHandler), "OnAbsorb");
            MethodInfo patch3 = AccessTools.Method(typeof(Patches), "GetCoord2");
            harmony.Patch(original3, new HarmonyMethod(patch3));

            MethodInfo testor = AccessTools.Method(typeof(SyncHandler), "_SetGlobalFlagValue");
            MethodInfo testpa = AccessTools.Method(typeof(Patches), "flagSet");
            harmony.Patch(testor, new HarmonyMethod(testpa));

            MethodInfo bloodmetal = AccessTools.Method(typeof(InteractableMine), "PickUp");
            MethodInfo bmpatch = AccessTools.Method(typeof(Patches), "GetBloodmetalCoord");
            harmony.Patch(bloodmetal, new HarmonyMethod(bmpatch));

            MethodInfo original4 = AccessTools.Method(typeof(MainMenuHandler), "Start");
            MethodInfo patch4 = AccessTools.Method(typeof(Patches), "SetRandoText");
            harmony.Patch(original4, new HarmonyMethod(patch4));

            MethodInfo original6 = AccessTools.Method(typeof(PlayerData_Talents), "SetTalentRank");
            MethodInfo patch6 = AccessTools.Method(typeof(Patches), "GiveRandomFromRank");
            harmony.Patch(original6, new HarmonyMethod(patch6));

            MethodInfo original7 = AccessTools.Method(typeof(PlayerData_Talents), "IsTalentAquired");
            MethodInfo patch7 = AccessTools.Method(typeof(Patches), "TalentAquiredHijack");
            harmony.Patch(original7, new HarmonyMethod(patch7));

            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} has loaded!");


        }

        public class Patches
        {
            public static List<int> pool1 = new List<int>();
            public static List<int> progressionPool = new List<int>();
            public static List<int> progressionPool2 = new List<int>();
            public static int listOrder = 0;
            public static int progressionListOrder = 0;
            public static int progressionListOrder2 = 0;
            public static bool pickedItem = false;
            public static bool pickedItem2 = false;
            public static Vector3 lastPos = Vector3.zero;
            static AccessTools.FieldRef<PickableItemHandler, bool> didPick = AccessTools.FieldRefAccess<PickableItemHandler, bool>("didPick");
            public static bool customFlagSet = false;
            public static bool customTalentSet = false;
            public static bool customGiveItem = false;
            public static Vector3 itemCollectedTemp = Vector3.zero;
            static Dictionary<ItemCoord, ItemDefinition> itemCoordsPair = new Dictionary<ItemCoord, ItemDefinition>();
            public static int persistentAssignNum = 0;
            public static bool itemsRandomized = false;
            public static bool kilyahStoneCollected;
            public static bool StrandCollected;
            public static List<int> coordsToRemove = new List<int>();
            public static int weaponItemToIgnore = 0;
            public static int progressionItemsLength = 9;
            public static int itemsToRandomize;
            public static int numItemsRand = 0;
            public static int totalNumItemsRand = 0;
            public static int lastRandomized = 0;

            public static bool isPullAquired = false;
            public static bool isSelfPullAquired = false;

            public static bool RandoPatch(GameHandler __instance)
            {
                PlayerData_Inventory playerData_Inventory = PlayerData_Inventory.instance;
                ItemPool.AddItems();

                for (int i = 0; i < progressionItemsLength; i++)
                {
                    if (i < 4)
                    {
                        progressionPool.Add(i);
                    }
                    else
                    {
                        progressionPool2.Add(i);
                    }
                }
                progressionPool.Shuffle();
                progressionPool2.Shuffle();

                for (int i = 0; i < ItemPool.itemPool.Count; i++)
                {
                    pool1.Add(i);
                }

                pool1.Shuffle();

                itemCoordsPair = SaveRandomState.Load("RandomizedState");

                if (!itemsRandomized)
                {
                    ItemCoords.RefreshICList();
                    itemsToRandomize = ItemCoords.itemCoordList.Count;
                    RandomlyAssignItems();
                }

                return true;
            }

            public static void RandomlyAssignItems()
            {
                Log.LogInfo("Randomizing Items");

                //Pick a weaponless ItemCoord
                int randomWeaponless = UnityEngine.Random.Range(0, 7);
                if (ItemCoords.itemCoordList[randomWeaponless].Weaponless)
                {
                    //Assign a weapon to this Item Coord
                    int num = 0;
                    ItemPool.itemPool.TryGetValue(pool1[num], out ItemPool.ItemDefinition tempItem);
                    ItemDefinition getWeapon = tempItem;
                    while (!getWeapon.IsWeapon)
                    {
                        num++;
                        ItemPool.itemPool.TryGetValue(pool1[num], out ItemPool.ItemDefinition itemDef);
                        getWeapon = itemDef;
                    }

                    itemCoordsPair.Add(ItemCoords.itemCoordList[randomWeaponless], getWeapon);
                    weaponItemToIgnore = num;

                    //Remove this Item Coord from itemCoordList
                    ItemCoords.itemCoordList.Remove(ItemCoords.itemCoordList[randomWeaponless]);
                    coordsToRemove.Add(randomWeaponless);

                    //Remove assigned weapon from ItemPool
                    //Item is ignored by checking weaponItemToIgnore
                }
                else
                {
                    Log.LogInfo("Weapon logic failed: Failed to randomize starting weapon.");
                }

                //Randomly assign progression items

                for (int l = 0; l < progressionItemsLength; l++)
                {
                    bool assignedProg = false;
                    int randomProgressionItem;
                    if (l < 4)
                    {
                        randomProgressionItem = progressionPool[progressionListOrder];
                    }
                    else
                    {
                        randomProgressionItem = progressionPool2[progressionListOrder2];
                    }
                    int whileloopsafety = 0;

                    while (!assignedProg)
                    {
                        int randomProgCoord = UnityEngine.Random.Range(0, ItemCoords.itemCoordList.Count);

                        if (whileloopsafety > 2000)
                        {
                            Log.LogInfo("Safety: Getting Last Coord");
                            itemCoordsPair.Remove(ItemCoords.itemCoordList[lastRandomized]);
                            randomProgCoord = lastRandomized;
                            coordsToRemove.RemoveAt(coordsToRemove.Count - 1);
                            RefreshList();
                            listOrder--;
                        }

                        if (ItemCoords.itemCoordList[randomProgCoord].Assignable)
                        {
                            ItemPool.itemPool.TryGetValue(randomProgressionItem, out ItemPool.ItemDefinition itemDefProg);
                            itemCoordsPair.Add(ItemCoords.itemCoordList[randomProgCoord], itemDefProg);

                            if (ItemCoords.itemCoordList[randomProgCoord].ItemsDropped > 1)
                            {
                                ItemCoords.itemCoordList[randomProgCoord].ItemsDropped--;
                            }

                            Log.LogInfo("Randomized " + ItemCoords.itemCoordList[randomProgCoord].Coord + " to " + itemDefProg.Guid);
                            ItemCoords.itemCoordList.Remove(ItemCoords.itemCoordList[randomProgCoord]);
                            coordsToRemove.Add(randomProgCoord);

                            switch (itemDefProg.Guid)
                            {
                                case "36df0fa1-a266-4973-85b8-702ac10c2f6f":
                                    RandomizeNonProgression();
                                    ItemCoords.kilyahStone = true;
                                    RefreshList();
                                    break;
                                case "e497b557-1320-4df5-a844-3985e80b6d25":
                                    RandomizeNonProgression();
                                    ItemCoords.strandOfTheChild = true;
                                    RefreshList();
                                    break;
                                case "walk":
                                    RandomizeNonProgression();
                                    ItemCoords.walk = true;
                                    RefreshList();
                                    break;
                                case "pull":
                                    RandomizeNonProgression();
                                    ItemCoords.pull = true;
                                    RefreshList();
                                    break;
                                case "itemPull":
                                    RandomizeNonProgression();
                                    ItemCoords.itemPull = true;
                                    RefreshList();
                                    break;
                                case "airDash":
                                    RandomizeNonProgression();
                                    ItemCoords.airDash = true;
                                    RefreshList();
                                    break;
                                case "selfPull":
                                    RandomizeNonProgression();
                                    ItemCoords.selfPull = true;
                                    RefreshList();
                                    break;
                                case "doubleJump":
                                    RandomizeNonProgression();
                                    ItemCoords.doubleJump = true;
                                    RefreshList();
                                    break;
                                case "hover":
                                    RandomizeNonProgression();
                                    ItemCoords.hover = true;
                                    RefreshList();
                                    break;
                                case "sprint":
                                    RandomizeNonProgression();
                                    ItemCoords.sprint = true;
                                    RefreshList();
                                    break;
                                default:
                                    break;
                            }

                            if (l < 4)
                            {
                                progressionListOrder++;
                            }
                            else
                            {
                                progressionListOrder2++;
                            }

                            totalNumItemsRand = totalNumItemsRand + numItemsRand;
                            assignedProg = true;
                        }
                        whileloopsafety++;
                    }
                }

                ItemCoords.unsealer = true;
                ItemCoords.walk = true;
                RefreshList();

                RandomizeNonProgression();

                itemsRandomized = true;
                SaveRandomState.Save(itemCoordsPair, "RandomizedState");
                totalNumItemsRand = totalNumItemsRand + progressionItemsLength;
                Log.LogInfo("Randomized " + totalNumItemsRand + " items out of " + ItemPool.itemPool.Count);
            }

            public static void RandomizeNonProgression()
            {
                itemsToRandomize = ItemCoords.itemCoordList.Count;
                for (int j = 0, noAssignablesFailsafe = 0; j <= itemsToRandomize && noAssignablesFailsafe < 2000;)
                {
                    if (listOrder == weaponItemToIgnore || pool1[listOrder] <= progressionItemsLength)
                    {
                        listOrder++;
                    }
                    int randomCoord = UnityEngine.Random.Range(0, ItemCoords.itemCoordList.Count);
                    if (ItemCoords.itemCoordList[randomCoord].Assignable)
                    {
                        int persistentItemsDropped = ItemCoords.itemCoordList[randomCoord].ItemsDropped;
                        for (int i = 1; i <= persistentItemsDropped; i++)
                        {
                            //Log.LogInfo("Random Coord Num: " + randomCoord + " Item based on coord: " + ItemCoords.itemCoordList[randomCoord].ItemName);
                            //Assign ItemCoords.itemCoordList[randomCoord].ItemsDropped items to this Item Coord
                            ItemPool.itemPool.TryGetValue(pool1[listOrder], out ItemPool.ItemDefinition itemDef);

                            if (i > 1)
                            {
                                ItemCoord multipleSameKeys = new ItemCoord(ItemCoords.itemCoordList[randomCoord].Coord, ItemCoords.itemCoordList[randomCoord].ItemName, ItemCoords.itemCoordList[randomCoord].Assignable);
                                itemCoordsPair.Add(multipleSameKeys, itemDef);
                            }
                            else
                            {
                                itemCoordsPair.Add(ItemCoords.itemCoordList[randomCoord], itemDef);
                            }

                            //Remove this Item Coord from itemCoordList
                            Log.LogInfo("Randomized " + ItemCoords.itemCoordList[randomCoord].Coord + " to " + itemDef.Guid);

                            if (i == ItemCoords.itemCoordList[randomCoord].ItemsDropped)
                            {
                                ItemCoords.itemCoordList.Remove(ItemCoords.itemCoordList[randomCoord]);
                                coordsToRemove.Add(randomCoord);
                                lastRandomized = randomCoord;
                            }

                            //Remove assigned items from ItemPool
                            //No need, no repeating items because external pool

                            listOrder++;
                        }
                        j++;
                        numItemsRand = j;
                        noAssignablesFailsafe = 0;
                    }
                    noAssignablesFailsafe++;
                }
            }

            public static void RefreshList()
            {
                ItemCoords.RefreshICList();

                foreach (int toRemove in coordsToRemove)
                {
                    ItemCoords.itemCoordList.Remove(ItemCoords.itemCoordList[toRemove]);
                }
            }

            public static bool GetCoord(PickableItemHandler __instance)
            {
                if (didPick(__instance) && !pickedItem)
                {
                    pickedItem = true;
                    AccessTools.FieldRef<PickableItemHandler, Vector3> itemLocation = AccessTools.FieldRefAccess<PickableItemHandler, Vector3>("prePickupLocation");
                    GrimeRandomizer.Log.LogInfo("prePickupLocation: " + itemLocation(__instance) + " transform.position " + __instance.transform.position);
                    __instance.StartCoroutine(resetGetCoord());
                    didPick(__instance) = false;

                    itemCollectedTemp = __instance.transform.position;
                }
                return true;
            }

            public static bool GetCoord2(PickableItemHandler __instance)
            {
                AccessTools.FieldRef<PickableItemHandler, Vector3> itemLocation = AccessTools.FieldRefAccess<PickableItemHandler, Vector3>("prePickupLocation");
                GrimeRandomizer.Log.LogInfo("prePickupLocation: " + itemLocation(__instance) + " transform.position " + __instance.transform.position);

                itemCollectedTemp = __instance.transform.position;
                return true;
            }

            public static bool GetBloodmetalCoord(InteractableMine __instance)
            {
                GrimeRandomizer.Log.LogInfo("Bloodmetal transform.position " + __instance.transform.position);

                itemCollectedTemp = __instance.transform.position;
                return true;
            }

            public static IEnumerator resetGetCoord()
            {
                yield return new WaitForSeconds(0.9f);
                pickedItem = false;
            }

            public static bool flagSet(string flagName, int flagValue)
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

            public static bool GiveRandom(ref Data_Item item, ref int amount)
            {
                if (customGiveItem)
                {
                    return true;
                }

                AccessTools.FieldRef<GameHandler, Data_Talent[]> unlockSkillsBase = AccessTools.FieldRefAccess<GameHandler, Data_Talent[]>("unlockSkillsBase");
                AccessTools.FieldRef<GameHandler, Data_Talent[]> unlockSkillsDLC = AccessTools.FieldRefAccess<GameHandler, Data_Talent[]>("unlockSkillsDLC");
                int assignedItemsQuantity = 0;
                ItemCoord kvpToRemove = new ItemCoord(Vector3.zero);

                if (itemCollectedTemp == Vector3.zero)
                {
                    if (Hashtable_Items.getHashtable.GetIdByItem(item) == "a54651d7-e14c-4b7d-ac19-7f64cb916d7a")
                    {
                        foreach (KeyValuePair<ItemCoord, ItemDefinition> keyValuePair in itemCoordsPair)
                        {
                            if (keyValuePair.Key.ItemName == "MaulAxe")
                            {
                                switch (keyValuePair.Value.Guid)
                                {
                                    case "ardor":
                                        customTalentSet = true;
                                        PlayerData_Talents.instance.SetTalentRank(Hashtable_Talents.getHashtable.getTable[7].talentReference, Hashtable_Talents.getHashtable.getTable[7].talentReference.getRanksData.Length - 1);
                                        customTalentSet = false;
                                        amount = 0;
                                        item = null;
                                        break;
                                    case "pull":
                                        customTalentSet = true;
                                        PlayerData_Talents.instance.SetTalentRank(unlockSkillsBase(GameHandler.instance)[1], unlockSkillsBase(GameHandler.instance)[1].getRanksData.Length - 1);
                                        isPullAquired = true;
                                        customTalentSet = false;
                                        amount = 0;
                                        item = null;
                                        break;
                                    case "itemPull":
                                        customTalentSet = true;
                                        PlayerData_Talents.instance.SetTalentRank(unlockSkillsBase(GameHandler.instance)[5], unlockSkillsBase(GameHandler.instance)[5].getRanksData.Length - 1);
                                        customTalentSet = false;
                                        amount = 0;
                                        item = null;
                                        break;
                                    case "airDash":
                                        customTalentSet = true;
                                        PlayerData_Talents.instance.SetTalentRank(unlockSkillsBase(GameHandler.instance)[2], unlockSkillsBase(GameHandler.instance)[2].getRanksData.Length - 1);
                                        customTalentSet = false;
                                        amount = 0;
                                        item = null;
                                        break;
                                    case "selfPull":
                                        customTalentSet = true;
                                        PlayerData_Talents.instance.SetTalentRank(unlockSkillsBase(GameHandler.instance)[3], unlockSkillsBase(GameHandler.instance)[3].getRanksData.Length - 1);
                                        customTalentSet = false;
                                        amount = 0;
                                        item = null;
                                        break;
                                    case "doubleJump":
                                        customTalentSet = true;
                                        PlayerData_Talents.instance.SetTalentRank(unlockSkillsBase(GameHandler.instance)[4], unlockSkillsBase(GameHandler.instance)[4].getRanksData.Length - 1);
                                        customTalentSet = false;
                                        amount = 0;
                                        item = null;
                                        break;
                                    case "hover":
                                        customTalentSet = true;
                                        PlayerData_Talents.instance.SetTalentRank(unlockSkillsDLC(GameHandler.instance)[1], unlockSkillsDLC(GameHandler.instance)[0].getRanksData.Length - 1);
                                        customTalentSet = false;
                                        amount = 0;
                                        item = null;
                                        break;
                                    case "sprint":
                                        customTalentSet = true;
                                        PlayerData_Talents.instance.SetTalentRank(unlockSkillsDLC(GameHandler.instance)[0], unlockSkillsDLC(GameHandler.instance)[0].getRanksData.Length - 1);
                                        customTalentSet = false;
                                        amount = 0;
                                        item = null;
                                        break;
                                    default:
                                        Log.LogInfo("Changing out item to randomized item " + Hashtable_Items.getHashtable.GetItemByID(keyValuePair.Value.Guid));
                                        item = Hashtable_Items.getHashtable.GetItemByID(keyValuePair.Value.Guid);
                                        amount = keyValuePair.Value.Quantity;
                                        kvpToRemove = keyValuePair.Key;

                                        if (keyValuePair.Value.Guid == "36df0fa1-a266-4973-85b8-702ac10c2f6f") //KiliahStone
                                        {
                                            kilyahStoneCollected = true;
                                            if (StrandCollected)
                                            {
                                                customFlagSet = true;
                                                SyncHandler.SetGlobalFlagValue("GSF_Shidra", 2);
                                            }
                                            else
                                            {
                                                customFlagSet = true;
                                                SyncHandler.SetGlobalFlagValue("GSF_Shidra", 1);
                                            }
                                        }

                                        if (keyValuePair.Value.Guid == "e497b557-1320-4df5-a844-3985e80b6d25") //StrandOfTheChild
                                        {
                                            StrandCollected = true;
                                            if (kilyahStoneCollected)
                                            {
                                                customFlagSet = true;
                                                SyncHandler.SetGlobalFlagValue("GSF_Shidra", 2);
                                            }
                                        }
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        item = null;
                        amount = 0;
                    }
                }
                else
                {
                    foreach (KeyValuePair<ItemCoord, ItemDefinition> keyValuePair in itemCoordsPair)
                    {
                        if (itemCollectedTemp.x > keyValuePair.Key.Coord.x - 0.3 && itemCollectedTemp.x < keyValuePair.Key.Coord.x + 0.3 && itemCollectedTemp.y > keyValuePair.Key.Coord.y - 0.3 && itemCollectedTemp.y < keyValuePair.Key.Coord.y + 0.3)
                        {
                            Log.LogInfo("Matching: " + keyValuePair.Key.Coord);
                            assignedItemsQuantity++;

                            switch (keyValuePair.Value.Guid)
                            {
                                case "ardor":
                                    customTalentSet = true;
                                    PlayerData_Talents.instance.SetTalentRank(Hashtable_Talents.getHashtable.getTable[7].talentReference, Hashtable_Talents.getHashtable.getTable[7].talentReference.getRanksData.Length - 1);
                                    customTalentSet = false;
                                    amount = 0;
                                    item = null;
                                    break;
                                case "pull":
                                    customTalentSet = true;
                                    PlayerData_Talents.instance.SetTalentRank(Hashtable_Talents.getHashtable.getTable[6].talentReference, Hashtable_Talents.getHashtable.getTable[6].talentReference.getRanksData.Length - 1);
                                    customTalentSet = false;
                                    amount = 0;
                                    item = null;

                                    isPullAquired = true;
                                    break;
                                case "itemPull":
                                    customTalentSet = true;
                                    PlayerData_Talents.instance.SetTalentRank(unlockSkillsBase(GameHandler.instance)[5], unlockSkillsBase(GameHandler.instance)[5].getRanksData.Length - 1);
                                    customTalentSet = false;
                                    amount = 0;
                                    item = null;
                                    break;
                                case "airDash":
                                    customTalentSet = true;
                                    PlayerData_Talents.instance.SetTalentRank(unlockSkillsBase(GameHandler.instance)[2], unlockSkillsBase(GameHandler.instance)[2].getRanksData.Length - 1);
                                    customTalentSet = false;
                                    amount = 0;
                                    item = null;
                                    break;
                                case "selfPull":
                                    customTalentSet = true;
                                    PlayerData_Talents.instance.SetTalentRank(unlockSkillsBase(GameHandler.instance)[3], unlockSkillsBase(GameHandler.instance)[3].getRanksData.Length - 1);
                                    customTalentSet = false;
                                    amount = 0;
                                    item = null;
                                    break;
                                case "doubleJump":
                                    customTalentSet = true;
                                    PlayerData_Talents.instance.SetTalentRank(unlockSkillsBase(GameHandler.instance)[4], unlockSkillsBase(GameHandler.instance)[4].getRanksData.Length - 1);
                                    customTalentSet = false;
                                    amount = 0;
                                    item = null;
                                    break;
                                case "hover":
                                    customTalentSet = true;
                                    PlayerData_Talents.instance.SetTalentRank(unlockSkillsDLC(GameHandler.instance)[1], unlockSkillsDLC(GameHandler.instance)[0].getRanksData.Length - 1);
                                    customTalentSet = false;
                                    amount = 0;
                                    item = null;
                                    break;
                                case "sprint":
                                    customTalentSet = true;
                                    PlayerData_Talents.instance.SetTalentRank(unlockSkillsDLC(GameHandler.instance)[0], unlockSkillsDLC(GameHandler.instance)[0].getRanksData.Length - 1);
                                    customTalentSet = false;
                                    amount = 0;
                                    item = null;
                                    break;
                                default:
                                    if (assignedItemsQuantity == 1)
                                    {
                                        Log.LogInfo("Changing out item to randomized item " + Hashtable_Items.getHashtable.GetItemByID(keyValuePair.Value.Guid));
                                        item = Hashtable_Items.getHashtable.GetItemByID(keyValuePair.Value.Guid);
                                        amount = keyValuePair.Value.Quantity;
                                        kvpToRemove = keyValuePair.Key;

                                        if (keyValuePair.Value.Guid == "e497b557-1320-4df5-a844-3985e80b6d25")
                                        {
                                            customFlagSet = true;
                                            SyncHandler.SetGlobalFlagValue("GSF_Shidra", 2);
                                        }
                                    }
                                    persistentAssignNum = assignedItemsQuantity;
                                    break;
                            }
                        }
                    }
                    itemCoordsPair.Remove(kvpToRemove);

                    if (persistentAssignNum == 1 || persistentAssignNum == 0)
                    {
                        itemCollectedTemp = Vector3.zero;
                    }
                }

                return true;
            }

            public static bool GiveRandomFromRank(ref Data_Talent talent, int rank)
            {
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
                        switch (keyValuePair.Value.Guid)
                        {
                            case "ardor":
                                customTalentSet = true;
                                PlayerData_Talents.instance.SetTalentRank(Hashtable_Talents.getHashtable.getTable[7].talentReference, Hashtable_Talents.getHashtable.getTable[7].talentReference.getRanksData.Length - 1);
                                customTalentSet = false;
                                break;
                            case "pull":
                                customTalentSet = true;
                                PlayerData_Talents.instance.SetTalentRank(unlockSkillsBase(GameHandler.instance)[1], unlockSkillsBase(GameHandler.instance)[1].getRanksData.Length - 1);
                                isPullAquired = true;
                                customTalentSet = false;
                                break;
                            case "itemPull":
                                customTalentSet = true;
                                PlayerData_Talents.instance.SetTalentRank(unlockSkillsBase(GameHandler.instance)[5], unlockSkillsBase(GameHandler.instance)[5].getRanksData.Length - 1);
                                customTalentSet = false;
                                break;
                            case "airDash":
                                customTalentSet = true;
                                PlayerData_Talents.instance.SetTalentRank(unlockSkillsBase(GameHandler.instance)[2], unlockSkillsBase(GameHandler.instance)[2].getRanksData.Length - 1);
                                customTalentSet = false;
                                break;
                            case "selfPull":
                                customTalentSet = true;
                                PlayerData_Talents.instance.SetTalentRank(unlockSkillsBase(GameHandler.instance)[3], unlockSkillsBase(GameHandler.instance)[3].getRanksData.Length - 1);
                                customTalentSet = false;
                                break;
                            case "doubleJump":
                                customTalentSet = true;
                                PlayerData_Talents.instance.SetTalentRank(unlockSkillsBase(GameHandler.instance)[4], unlockSkillsBase(GameHandler.instance)[4].getRanksData.Length - 1);
                                customTalentSet = false;
                                break;
                            case "hover":
                                customTalentSet = true;
                                PlayerData_Talents.instance.SetTalentRank(unlockSkillsDLC(GameHandler.instance)[1], unlockSkillsDLC(GameHandler.instance)[0].getRanksData.Length - 1);
                                customTalentSet = false;
                                break;
                            case "sprint":
                                customTalentSet = true;
                                PlayerData_Talents.instance.SetTalentRank(unlockSkillsDLC(GameHandler.instance)[0], unlockSkillsDLC(GameHandler.instance)[0].getRanksData.Length - 1);
                                customTalentSet = false;
                                break;
                            default:
                                Log.LogInfo("Giving randomized item " + Hashtable_Items.getHashtable.GetItemByID(keyValuePair.Value.Guid));
                                customGiveItem = true;
                                playerData_Inventory.GiveItem(Hashtable_Items.getHashtable.GetItemByID(keyValuePair.Value.Guid), keyValuePair.Value.Quantity);
                                customGiveItem = false;
                                kvpToRemove = keyValuePair.Key;

                                if (keyValuePair.Value.Guid == "e497b557-1320-4df5-a844-3985e80b6d25")
                                {
                                    customFlagSet = true;
                                    SyncHandler.SetGlobalFlagValue("GSF_Shidra", 2);
                                }
                            break;
                        }
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

            public static bool SetRandoText(MainMenuHandler __instance)
            {
                AccessTools.FieldRef<MainMenuHandler, TextMeshProUGUI> gvText = AccessTools.FieldRefAccess<MainMenuHandler, TextMeshProUGUI>("gameVersionText");
                gvText(__instance).text = "Randomizer " + PluginInfo.PLUGIN_VERSION;
                gvText(__instance).autoSizeTextContainer = true;

                AccessTools.FieldRef<MainMenuHandler, GameObject> exButton = AccessTools.FieldRefAccess<MainMenuHandler, GameObject>("exitButton");
                AccessTools.FieldRef<MainMenuHandler, GameObject[]> buttonCarriers = AccessTools.FieldRefAccess<MainMenuHandler, GameObject[]>("buttonCarriers");
                AccessTools.FieldRef<MainMenuHandler, GameObject[]> mainMenuStyles = AccessTools.FieldRefAccess<MainMenuHandler, GameObject[]>("mainMenuStyles");
                AccessTools.FieldRef<MainMenuHandler, UnityEngine.UI.Button[]> panelButtons = AccessTools.FieldRefAccess<MainMenuHandler, UnityEngine.UI.Button[]>("panelButtons");
                GameObject randoSettingsButton = GameObject.Instantiate(exButton(__instance));
                randoSettingsButton.transform.SetParent(buttonCarriers(__instance)[0].transform);
                randoSettingsButton.transform.position = new Vector3(960f, 385f, 0.00f);
                randoSettingsButton.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
                UnityEngine.UI.Button rsButton = randoSettingsButton.GetComponentInChildren<UnityEngine.UI.Button>();
                rsButton.onClick.SetPersistentListenerState(0, UnityEventCallState.Off);
                rsButton.onClick.AddListener(() => SaveRandomState.Delete("RandomizedState"));
                rsButton.name = "MainMenu_Button_RSettings";
                panelButtons(__instance).AddItem(rsButton);
                TextMeshProUGUI randoSettingsButtonText = randoSettingsButton.GetComponentInChildren<TextMeshProUGUI>();
                randoSettingsButtonText.text = "Randomize Again";
                randoSettingsButtonText.autoSizeTextContainer = true;

                return true;
            }

            //Type Converter to Serialize and Deserialize itemCoordPair Dictionary
            public class ItemCoordTypeConverter : TypeConverter
            {
                public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
                    => sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);

                public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
                    => destinationType == typeof(string) || base.CanConvertTo(context, destinationType);

                //string to ItemCoord (DESERIALIZATION)
                public override object ConvertFrom(
                    ITypeDescriptorContext context,
                    CultureInfo culture,
                    object value)
                {
                    if (value is not string s)
                        throw new ArgumentException("Invalid ItemCoord key");

                    // Expected: x,y,z|ItemName
                    var parts = s.Split('|');
                    if (parts.Length != 2)
                        throw new FormatException($"Invalid ItemCoord format: {s}");

                    var vec = parts[0].Split(',');
                    if (vec.Length != 3)
                        throw new FormatException($"Invalid Vector3 format: {parts[0]}");

                    var coord = new Vector3(
                        float.Parse(vec[0], CultureInfo.InvariantCulture),
                        float.Parse(vec[1], CultureInfo.InvariantCulture),
                        float.Parse(vec[2], CultureInfo.InvariantCulture));

                    return new ItemCoord(coord, parts[1]);
                }

                //ItemCoord to string (SERIALIZATION)
                public override object ConvertTo(
                    ITypeDescriptorContext context,
                    CultureInfo culture,
                    object value,
                    Type destinationType)
                {
                    if (destinationType != typeof(string))
                        throw new NotSupportedException();

                    if (value is not ItemCoord ic)
                        throw new ArgumentException("Invalid ItemCoord");

                    return $"{ic.Coord.x:F3},{ic.Coord.y:F3},{ic.Coord.z:F3}|{ic.ItemName}";
                }
            }

        }
    }
}