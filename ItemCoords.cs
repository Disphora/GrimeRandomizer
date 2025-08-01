using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static GrimeRandomizer.ItemPool;

namespace GrimeRandomizer
{
    public class ItemCoord
    {
        public Vector3 Coord { get; }
        public string ItemName { get; }
        public bool Assignable { get; }
        public bool Weaponless { get; }
        public int ItemsDropped { get; }
        public bool FallsDown {  get; }
        public ItemCoord(Vector3 coord, string itemName = "defaultName", bool assignable = true, bool weaponless = false, int itemsDropped = 1, bool fallsDown = false)
        {
            Coord = coord;
            ItemName = itemName;
            Assignable = assignable;
            Weaponless = weaponless;
            ItemsDropped = itemsDropped;
            FallsDown = fallsDown;
        }
    }

    internal class ItemCoords
    {
        public static bool walk = false;
        public static bool pull = false;
        public static bool itemPull = false;
        public static bool airDash = false;
        public static bool selfPull = false;
        public static bool doubleJump = false;
        public static bool hover = false;
        public static bool kilyahStone = false;
        public static bool unsealer = false;
        public static bool strandOfTheChild = false;
        public static bool sprint = false;
        public static bool _AbandonnedOpus = pull && airDash && selfPull && doubleJump && hover;
        public static bool _Gloomnest = doubleJump || pull || airDash;
        public static bool _Worldpillar = doubleJump || pull;
        public static bool _Nerveroot = pull;
        public static bool _feastersLair = pull || airDash;
        public static bool _yrDenFromFeasters = airDash || selfPull;
        public static bool _servantsPath = (pull || doubleJump) && kilyahStone;
        public static bool _carvenPalace = pull || doubleJump;
        public static bool _garden = doubleJump && hover || pull && (doubleJump || airDash);
        public static bool _childBed = pull;
        public static bool _beyondTheBarrier = (pull && selfPull || doubleJump) && kilyahStone && unsealer;
        public static bool _CenotaphCity = (pull && selfPull && kilyahStone && unsealer);

        public static List<ItemCoord> itemCoordList = new List<ItemCoord>
        {
            // Weeping Cavity
            new ItemCoord(new Vector3(646.03f, 95.92f, 0.00f), "UnformedFinger", true, true),
            new ItemCoord(new Vector3(605.06f, 105.83f, 0.00f), "LevolamDust", true, true),
            new ItemCoord(new Vector3(638.26f, 102.31f, 0.00f), "LevolamDust", true, true),
            new ItemCoord(new Vector3(657.04f, 117.29f, 0.00f), "ArdentSand", true, true),
            new ItemCoord(new Vector3(623.97f, 115.57f, 0.00f), "UnformedFinger", true, true),
            new ItemCoord(new Vector3(606.23f, 112.31f, 0.00f), "UnformedFinger", true, true),
            new ItemCoord(new Vector3(591.55f, 128.29f, 0.00f), "VolatileEye", true, true),
            new ItemCoord(new Vector3(99f, 99f, 99f), "MaulAxe", true, true),
            new ItemCoord(new Vector3(509.62f, 74.55f, 0.00f), "UnformedBody"),
            new ItemCoord(new Vector3(518.69f, 65.69f, 0.01f), "OtherwherePhloxArmor", true, false, 3),
            new ItemCoord(new Vector3(674.24f, 95.81f, 0.00f), "MaulSword", walk),
            new ItemCoord(new Vector3(591.13f, 132.59f, 0.00f), "CrimsonIchor"),
            new ItemCoord(new Vector3(696.43f, 158.32f, 0.18f), "PricklyWeeperChest"),
            new ItemCoord(new Vector3(709.11f, 153.34f, 0.18f), "PricklyWeeperHands"),
            new ItemCoord(new Vector3(702.17f, 171.86f, 0.18f), "PricklyWeeperLegs"),
            new ItemCoord(new Vector3(679.66f, 140.81f, 0.18f), "Nail"),
            new ItemCoord(new Vector3(677.91f, 140.81f, 0.18f), "Nail"),
            new ItemCoord(new Vector3(692.45f, 142.56f, 0.18f), "Nail"),
            new ItemCoord(new Vector3(752.74f, 144.35f, 0.00f), "BreathdewShard"),
            new ItemCoord(new Vector3(729.45f, 151.94f, 0.18f), "VolatileEye"),
            new ItemCoord(new Vector3(727.27f, 156.35f, 0.00f), "TwinFangs"),
            new ItemCoord(new Vector3(709.40f, 158.32f, 0.18f), "UnformedHand"),
            new ItemCoord(new Vector3(665.50f, 167.36f, 0.18f), "DebrisField"),
            new ItemCoord(new Vector3(660.72f, 151.84f, 0.34f), "UnformedHand"),
            new ItemCoord(new Vector3(639.40f, 185.19f, 0.18f), "Nail"),
            new ItemCoord(new Vector3(682.02f, 212.37f, 0.00f), "BellowMace"),
            new ItemCoord(new Vector3(667.08f, 207.33f, 0.18f), "ArdentSand"),
            new ItemCoord(new Vector3(677.00f, 202.36f, 0.18f), "MotleyPearl"),
            new ItemCoord(new Vector3(680.00f, 197.32f, 0.18f), "MotleyPearl"),
            new ItemCoord(new Vector3(69f, 69f, 69f), "ImpostorArmorFollows"),
            new ItemCoord(new Vector3(778.97f, 190.27f, 0.00f), "FriendlyImpostorArmor", itemPull, false, 3),
            new ItemCoord(new Vector3(767.18f, 195.47f, 0.00f), "Nail"),
            new ItemCoord(new Vector3(746.06f, 203.97f, 0.00f), "UnformedBody", airDash && selfPull && doubleJump),
            new ItemCoord(new Vector3(746.31f, 237.35f, 0.18f), "LivingFlesh", airDash && selfPull && doubleJump),
            new ItemCoord(new Vector3(721.54f, 254.72f, 0.18f), "Bownails", airDash && selfPull && doubleJump)
        };
    }
}
