using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GrimeRandomizer.ItemRepository;

namespace GrimeRandomizer
{
    public class RandomizerCore
    {
        private static RandomizerCore? _instance;
        private static readonly object _lockObject = new object();

        private List<int>? pool1;
        private List<int>? progressionPool;
        private int listOrder;
        private int progressionListOrder;
        private bool itemsRandomized;
        private int weaponItemToIgnore;
        private int progressionItemsLength;
        private int itemsToRandomize;
        private int numItemsRand;
        private int totalNumItemsRand;
        private int lastRandomized;
        private Vector3 _itemCollectedTemp;
        private Dictionary<ItemCoord, List<ItemDefinition>>? _itemCoordsPair;
        private List<int>? _coordsToRemove;
        private bool _isPullAquired;

        public Dictionary<ItemCoord, List<ItemDefinition>>? ItemCoordsPair { get { return _itemCoordsPair; } set { _itemCoordsPair = value; } }
        public Vector3 ItemCollectedTemp { get { return _itemCollectedTemp; } set { _itemCollectedTemp = value; } }
        public bool IsPullAquired { get { return _isPullAquired; } set { _isPullAquired = value; } }
        public bool ItemsRandomized { get { return itemsRandomized; } set { itemsRandomized = value; } }
        public List<int>? CoordsToRemove { get { return _coordsToRemove; } set { _coordsToRemove = value; } }
        public List<int>? Pool1 { get { return pool1; } set { pool1 = value; } }
        public List<int>? ProgressionPool { get { return progressionPool; } set { progressionPool = value; } }
        public int ListOrder { get { return listOrder; } set { listOrder = value; } }

        private RandomizerCore()
        {
            InitializeState();
        }

        public static RandomizerCore Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lockObject)
                    {
                        if (_instance == null)
                        {
                            _instance = new RandomizerCore();
                        }
                    }
                }
                return _instance;
            }
        }

        private void InitializeState()
        {
            pool1 = new List<int>();
            progressionPool = new List<int>();
            listOrder = 0;
            progressionListOrder = 0;
            itemsRandomized = false;
            weaponItemToIgnore = 0;
            progressionItemsLength = 9;
            itemsToRandomize = 0;
            numItemsRand = 0;
            totalNumItemsRand = 0;
            lastRandomized = 0;
            _itemCollectedTemp = Vector3.zero;
            _itemCoordsPair = new Dictionary<ItemCoord, List<ItemDefinition>>();
            _coordsToRemove = new List<int>();
            _isPullAquired = false;
        }

        public void Randomize()
        {
            if (itemsRandomized)
                return;

            ItemRepository.AddItems();
            InitializeProgressionPool();
            InitializeItemPool();
            LoadRandomState();
            RandomlyAssignItems();
        }

        private void InitializeProgressionPool()
        {
            for (int i = 0; i < progressionItemsLength; i++)
            {
                progressionPool?.Add(i);
            }
            ShuffleList(progressionPool);
        }

        private void InitializeItemPool()
        {
            for (int i = 0; i < ItemRepository.itemPool.Count; i++)
            {
                pool1?.Add(i);
            }
            ShuffleList(pool1);
        }

        private void ShuffleList(List<int>? list)
        {
            if (list == null) return;
            for (int i = list.Count - 1; i > 0; i--)
            {
                int randomIndex = UnityEngine.Random.Range(0, i + 1);
                int temp = list[i];
                list[i] = list[randomIndex];
                list[randomIndex] = temp;
            }
        }

        private void LoadRandomState()
        {
            _itemCoordsPair = SaveRandomState.Load("RandomizedState");
        }

        private void RandomlyAssignItems()
        {
            GrimeRandomizer.Log.LogInfo("Randomizing Items");

            int randomWeaponless = UnityEngine.Random.Range(0, 7);
            if (ItemCoords.itemCoordList[randomWeaponless].Weaponless)
            {
                AssignStartingWeapon(randomWeaponless);
            }
            else
            {
                GrimeRandomizer.Log.LogInfo("Weapon logic failed: Failed to randomize starting weapon.");
            }

            AssignProgressionItems();

            ItemCoords.unsealer = true;
            ItemCoords.walk = true;
            RefreshList();

            RandomizeNonProgression();

            itemsRandomized = true;
            if (_itemCoordsPair != null)
            {
                SaveRandomState.Save(_itemCoordsPair, "RandomizedState");
            }
            totalNumItemsRand = totalNumItemsRand + progressionItemsLength;
            GrimeRandomizer.Log.LogInfo("Randomized " + totalNumItemsRand + " items out of " + ItemRepository.itemPool.Count);
        }

        private void AssignStartingWeapon(int randomWeaponless)
        {
            int num = 0;
            ItemRepository.itemPool.TryGetValue(pool1![num], out ItemRepository.ItemDefinition tempItem);
            ItemDefinition getWeapon = tempItem;

            while (!getWeapon.IsWeapon)
            {
                num++;
                ItemRepository.itemPool.TryGetValue(pool1![num], out ItemRepository.ItemDefinition itemDef);
                getWeapon = itemDef;
            }

            List<ItemDefinition> getWeaponList = new List<ItemDefinition> { getWeapon };
            _itemCoordsPair?.Add(ItemCoords.itemCoordList[randomWeaponless], getWeaponList);
            weaponItemToIgnore = num;

            ItemCoords.itemCoordList.Remove(ItemCoords.itemCoordList[randomWeaponless]);
            _coordsToRemove?.Add(randomWeaponless);
        }

        private void AssignProgressionItems()
        {
            for (int l = 0; l < progressionItemsLength; l++)
            {
                bool assignedProg = false;
                int randomProgressionItem = progressionPool![progressionListOrder];
                int whileloopsafety = 0;

                while (!assignedProg)
                {
                    int randomProgCoord = UnityEngine.Random.Range(0, ItemCoords.itemCoordList.Count);

                    if (whileloopsafety > 2000)
                    {
                        randomProgCoord = lastRandomized;
                        _coordsToRemove?.RemoveAt(_coordsToRemove.Count - 1);
                        RefreshList();
                        listOrder--;
                    }

                    if (ItemCoords.itemCoordList[randomProgCoord].Assignable)
                    {
                        ItemRepository.itemPool.TryGetValue(randomProgressionItem, out ItemRepository.ItemDefinition itemDefProg);
                        List<ItemDefinition> itemDefProgList = new List<ItemDefinition> { itemDefProg };
                        _itemCoordsPair?.Add(ItemCoords.itemCoordList[randomProgCoord], itemDefProgList);

                        if (ItemCoords.itemCoordList[randomProgCoord].ItemsDropped > 1)
                        {
                            ItemCoords.itemCoordList[randomProgCoord].ItemsDropped--;
                        }

                        GrimeRandomizer.Log.LogInfo("Randomized " + ItemCoords.itemCoordList[randomProgCoord].Coord + " to " + itemDefProg.Guid);
                        ItemCoords.itemCoordList.Remove(ItemCoords.itemCoordList[randomProgCoord]);
                        _coordsToRemove?.Add(randomProgCoord);

                        HandleProgressionItemEffect(itemDefProg.Guid);

                        progressionListOrder++;
                        totalNumItemsRand = totalNumItemsRand + numItemsRand;
                        assignedProg = true;
                    }
                    whileloopsafety++;
                }
            }
        }

        private void HandleProgressionItemEffect(string guid)
        {
            switch (guid)
            {
                case ItemRepository.KilyahStone:
                    RandomizeNonProgression();
                    ItemCoords.kilyahStone = true;
                    RefreshList();
                    break;
                case ItemRepository.StrandOfTheChild:
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
            }
        }

        private void RandomizeNonProgression()
        {
            itemsToRandomize = ItemCoords.itemCoordList.Count;
            for (int j = 0, noAssignablesFailsafe = 0; j <= itemsToRandomize && noAssignablesFailsafe < 2000;)
            {
                if (listOrder == weaponItemToIgnore || pool1![listOrder] <= progressionItemsLength)
                {
                    listOrder++;
                }

                int randomCoord = UnityEngine.Random.Range(0, ItemCoords.itemCoordList.Count);
                if (ItemCoords.itemCoordList[randomCoord].Assignable)
                {
                    int persistentItemsDropped = ItemCoords.itemCoordList[randomCoord].ItemsDropped;
                    for (int i = 1; i <= persistentItemsDropped; i++)
                    {
                        ItemRepository.itemPool.TryGetValue(pool1![listOrder], out ItemRepository.ItemDefinition itemDef);
                        List<ItemDefinition> itemDefList = new List<ItemDefinition> { itemDef };

                        if (i > 1)
                        {
                            ItemCoord multipleSameKeys = new ItemCoord(
                                ItemCoords.itemCoordList[randomCoord].Coord,
                                ItemCoords.itemCoordList[randomCoord].ItemName,
                                ItemCoords.itemCoordList[randomCoord].Assignable);
                            itemCoordsPair?.Add(multipleSameKeys, itemDefList);
                        }
                        else
                        {
                            itemCoordsPair?.Add(ItemCoords.itemCoordList[randomCoord], itemDefList);
                        }

                        GrimeRandomizer.Log.LogInfo("Randomized " + ItemCoords.itemCoordList[randomCoord].Coord + " to " + itemDef.Guid);

                        if (i == ItemCoords.itemCoordList[randomCoord].ItemsDropped)
                        {
                            ItemCoords.itemCoordList.Remove(ItemCoords.itemCoordList[randomCoord]);
                            coordsToRemove?.Add(randomCoord);
                            lastRandomized = randomCoord;
                        }

                        listOrder++;
                    }
                    j++;
                    numItemsRand = j;
                    noAssignablesFailsafe = 0;
                }
                noAssignablesFailsafe++;
            }
        }

        private void RefreshList()
        {
            ItemCoords.RefreshICList();

            if (coordsToRemove != null)
            {
                foreach (int toRemove in coordsToRemove)
                {
                    ItemCoords.itemCoordList.Remove(ItemCoords.itemCoordList[toRemove]);
                }
            }
        }
    }
}
