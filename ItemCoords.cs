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
            new ItemCoord(new Vector3(778.97f, 190.27f, 0.00f), "FriendlyImpostorArmor", itemPull, false, 3),
            new ItemCoord(new Vector3(767.18f, 195.47f, 0.00f), "Nail"),
            new ItemCoord(new Vector3(746.06f, 203.97f, 0.00f), "UnformedBody", airDash && selfPull && doubleJump),
            new ItemCoord(new Vector3(746.31f, 237.35f, 0.18f), "LivingFlesh", airDash && selfPull && doubleJump),
            new ItemCoord(new Vector3(721.54f, 254.72f, 0.18f), "Bownails", airDash && selfPull && doubleJump),
            new ItemCoord(new Vector3(638.26f, 169.01f, 0.45f), "Bloodmetal Splinter"),
            new ItemCoord(new Vector3(647.44f, 194.87f, 0.00f), "Bloodmetal Splinter"),
            new ItemCoord(new Vector3(503.64f, 80.42f, 0.00f), "Bloodmetal Shard"),
            new ItemCoord(new Vector3(708.71f, 210.51f, 0.00f), "Bloodmetal Splinter"),

            //Unformed Desert
            new ItemCoord(new Vector3(858.24f, 183.46f, 0.00f), "Fossil Fist"),
            new ItemCoord(new Vector3(879.40f, 181.57f, 0.00f), "Volatile Blob"),
            new ItemCoord(new Vector3(908.12f, 179.31f, 0.00f), "Ardent Sand"),
            new ItemCoord(new Vector3(888.01f, 182.33f, 0.00f), "Ardent Sand"),
            new ItemCoord(new Vector3(921.83f, 184.65f, 0.00f), "Ardent Sand"),
            new ItemCoord(new Vector3(931.40f, 175.11f, 0.00f), "Ardent Sand"),
            new ItemCoord(new Vector3(919.73f, 177.75f, 0.00f), "Boulderplate Chest"),
            new ItemCoord(new Vector3(939.96f, 175.03f, 0.00f), "Boulderplate Hands"),
            new ItemCoord(new Vector3(910.46f, 176.35f, 0.00f), "Boulderplate Legs"),
            new ItemCoord(new Vector3(977.42f, 176.56f, 0.00f), "Unformed Hand"),
            new ItemCoord(new Vector3(997.08f, 183.33f, 0.00f), "Volatile Blob"),
            new ItemCoord(new Vector3(974.18f, 185.84f, 0.00f), "Volatile Blob"),
            new ItemCoord(new Vector3(957.18f, 190.43f, 0.00f), "Volatile Eye"),
            new ItemCoord(new Vector3(996.32f, 199.22f, 0.00f), "Motley Pearl", pull || doubleJump),
            new ItemCoord(new Vector3(1020.88f, 195.86f, 0.00f), "Unformed Slab"),
            new ItemCoord(new Vector3(1006.95f, 199.18f, 0.00f), "Unformed Hand"),
            new ItemCoord(new Vector3(951.16f, 201.07f, 0.00f), "Thirsting Sand", pull || doubleJump || itemPull),
            new ItemCoord(new Vector3(944.17f, 214.06f, 0.00f), "Nail", doubleJump || pull),
            new ItemCoord(new Vector3(976.15f, 209.22f, 0.00f), "Levolam Dust", doubleJump || pull),
            new ItemCoord(new Vector3(956.07f, 205.39f, 0.00f), "Unformed Body", doubleJump || pull && airDash),
            new ItemCoord(new Vector3(938.71f, 232.44f, 0.00f), "Fully Formed Husk", pull && selfPull && (airDash || doubleJump)),
            new ItemCoord(new Vector3(938.15f, 225.45f, 0.00f), "Fully Formed Husk", (pull && selfPull && (airDash || doubleJump)) || ((airDash || doubleJump) && itemPull)),
            new ItemCoord(new Vector3(1010.90f, 213.74f, 0.00f), "Crimson Ichor", walk && pull || doubleJump),
            new ItemCoord(new Vector3(1032.25f, 195.31f, 0.00f), "Fully Formed Husk", itemPull || doubleJump || airDash),
            new ItemCoord(new Vector3(934.33f, 191.22f, 0.00f), "Bloodmetal Splinter"),
            new ItemCoord(new Vector3(995.30f, 193.84f, 0.00f), "Bloodmetal Splinter"),
            new ItemCoord(new Vector3(1028.55f, 209.06f, 0.00f), "Bloodmetal Chunk", walk && (pull && airDash && hover || doubleJump && (airDash || hover))),

            //Lithic
            new ItemCoord(new Vector3(1066.50f, 195.28f, 0.00f), "Nail"),
            new ItemCoord(new Vector3(1103.74f, 188.94f, 0.00f), "Unformed Hand"),
            new ItemCoord(new Vector3(1162.29f, 195.35f, 0.62f), "Living Rock"),
            new ItemCoord(new Vector3(1229.86f, 246.99f, 0.00f), "Pillar Slab"),
            new ItemCoord(new Vector3(1239.25f, 246.99f, 0.00f), "Levolam Dust"),
            new ItemCoord(new Vector3(1248.08f, 190.91f, 0.00f), "Living Rock"),
            new ItemCoord(new Vector3(1270.06f, 192.44f, 0.00f), "Bloodmetal Splinter"),
            new ItemCoord(new Vector3(1304.86f, 181.20f, 0.00f), "Broken Husk"),
            new ItemCoord(new Vector3(1269.86f, 176.93f, 0.00f), "Bloodmetal Shard"),
            new ItemCoord(new Vector3(1232.24f, 173.49f, 0.00f), "Broken Husk"),
            new ItemCoord(new Vector3(1295.62f, 172.18f, 0.00f), "Debris Field"),
            new ItemCoord(new Vector3(1296.10f, 160.18f, 0.00f), "Bloodmetal Splinter"),
            new ItemCoord(new Vector3(1287.06f, 160.18f, 0.00f), "Bloodmetal Splinter"),
            new ItemCoord(new Vector3(1252.43f, 156.64f, 0.00f), "Lithic Effigy"),
            new ItemCoord(new Vector3(1179.05f, 182.42f, 0.00f), "Lithic Portrait"),
            new ItemCoord(new Vector3(1202.22f, 186.09f, 0.00f), "Living Rock"),
            new ItemCoord(new Vector3(1148.62f, 183.85f, 0.00f), "Ardent Sand"),
            new ItemCoord(new Vector3(1155.50f, 183.85f, 0.00f), "Ardent Sand"),
            new ItemCoord(new Vector3(1170.22f, 174.51f, 0.00f), "Debris Field"),
            new ItemCoord(new Vector3(1189.01f, 167.52f, 0.00f), "Unformed Head"),
            new ItemCoord(new Vector3(1193.53f, 155.64f, 0.00f), "Motley Pearl"),
            new ItemCoord(new Vector3(1095.59f, 131.89f, 0.00f), "Bloodmetal Splinter"),
            new ItemCoord(new Vector3(1090.00f, 106.97f, -0.01f), "Obelisk Fist"),
            new ItemCoord(new Vector3(1175.34f, 110.40f, -0.20f), "Motley Pearl"),
            new ItemCoord(new Vector3(1125.83f, 124.91f, 0.00f), "Bloodmetal Splinter"),
            new ItemCoord(new Vector3(1181.22f, 128.87f, 0.00f), "Crimson Ichor"),
            new ItemCoord(new Vector3(1148.83f, 130.35f, 0.00f), "Debris Field"),
            new ItemCoord(new Vector3(1139.75f, 130.40f, 0.00f), "Petalstone Chest"),
            new ItemCoord(new Vector3(1129.56f, 108.98f, -0.20f), "Petalstone Hands"),
            new ItemCoord(new Vector3(1113.34f, 117.30f, -0.01f), "Petalstone Legs"),
            new ItemCoord(new Vector3(1175.85f, 114.38f, -0.20f), "Nail"),
            new ItemCoord(new Vector3(1194.08f, 113.88f, 0.00f), "Bloodmetal Splinter"),
            new ItemCoord(new Vector3(1192.47f, 104.20f, -0.20f), "Thirsting Sand"),
            new ItemCoord(new Vector3(1210.46f, 99.69f, -0.20f), "Unformed Hand"),
            new ItemCoord(new Vector3(1227.37f, 99.53f, -0.20f), "Lithic Poem"),
            new ItemCoord(new Vector3(1231.84f, 99.52f, -0.20f), "Living Rock"),
            new ItemCoord(new Vector3(1227.00f, 96.25f, 0.00f), "Bloodmetal Shard"),
            new ItemCoord(new Vector3(1247.26f, 104.52f, -0.20f), "Motley Pearl"),
            new ItemCoord(new Vector3(1218.78f, 130.35f, -0.20f), "Shard Field"),
            new ItemCoord(new Vector3(1292.17f, 140.03f, 0.00f), "Unformed Torso", doubleJump || pull),
            new ItemCoord(new Vector3(1316.59f, 126.86f, 0.00f), "Bloodmetal Splinter", doubleJump || pull),
            new ItemCoord(new Vector3(1319.55f, 143.29f, 0.00f), "Breathdew Fragment", pull),
            new ItemCoord(new Vector3(1201.14f, 272.06f, 0.00f), "Lithichusk Chest", doubleJump && airDash),
            new ItemCoord(new Vector3(1206.12f, 252.84f, 0.00f), "Breathdew Droplet", doubleJump && airDash),
            new ItemCoord(new Vector3(1197.28f, 232.02f, 0.00f), "Lithichusk Hands", (doubleJump || hover) && airDash),
            new ItemCoord(new Vector3(1202.74f, 232.02f, 0.00f), "Lithichusk Legs", (doubleJump || hover) && airDash),
            new ItemCoord(new Vector3(1280.90f, 231.80f, 0.00f), "Breathdew Droplet", doubleJump && airDash && hover),
            new ItemCoord(new Vector3(1291.20f, 224.52f, 0.00f), "Fully Formed Husk", doubleJump && airDash && hover && itemPull),
            new ItemCoord(new Vector3(1320.74f, 214.04f, 0.00f), "Pointed Traveler Legs", doubleJump && airDash && hover && pull),
            new ItemCoord(new Vector3(1302.10f, 195.27f, 0.00f), "Pointed Traveler Chest", doubleJump && airDash && hover && pull),
            new ItemCoord(new Vector3(1306.40f, 185.98f, 0.00f), "Pointed Traveler Hands", doubleJump),
            new ItemCoord(new Vector3(1286.93f, 209.13f, 0.00f), "Breathdew Droplet", airDash),
            new ItemCoord(new Vector3(69f, 69f, 69f), "Pull"),

            //Gloomnest
            new ItemCoord(new Vector3(1020.28f, 167.51f, 0.00f), "Burst Lantern"),
            new ItemCoord(new Vector3(989.47f, 156.28f, 0.00f), "Bloodmetal Splinter", _Gloomnest),
            new ItemCoord(new Vector3(981.54f, 160.03f, 0.00f), "Bloodmetal Splinter", _Gloomnest),
            new ItemCoord(new Vector3(947.84f, 167.46f, 0.00f), "Volatile Eye", _Gloomnest),
            new ItemCoord(new Vector3(884.29f, 106.99f, 0.00f), "Volatile Eye", _Gloomnest),
            new ItemCoord(new Vector3(933.51f, 156.03f, 0.00f), "Whole Husk", _Gloomnest),
            new ItemCoord(new Vector3(959.37f, 146.41f, 0.00f), "Crimson Ichor", _Gloomnest && itemPull),
            new ItemCoord(new Vector3(933.72f, 148.77f, 0.00f), "Urn Of Volatile Eyes", _Gloomnest && itemPull),
            new ItemCoord(new Vector3(1018.98f, 154.25f, 0.00f), "Motley Pearl", _Gloomnest),
            new ItemCoord(new Vector3(994.68f, 143.47f, 0.00f), "Volatile Blob", _Gloomnest),
            new ItemCoord(new Vector3(1004.83f, 135.47f, 0.00f), "Bloodmetal Shard", _Gloomnest),
            new ItemCoord(new Vector3(977.57f, 135.46f, 0.00f), "Face Slasher", _Gloomnest),
            new ItemCoord(new Vector3(916.76f, 133.85f, 0.00f), "Bloodmetal Shard", airDash),
            new ItemCoord(new Vector3(909.31f, 128.62f, 0.00f), "Bloodmetal Chunk", airDash),
            new ItemCoord(new Vector3(907.00f, 134.18f, 0.00f), "Thirsting Sand", airDash),
            new ItemCoord(new Vector3(913.08f, 106.99f, 0.00f), "Awakening Gasp", airDash),
            new ItemCoord(new Vector3(904.01f, 106.99f, 0.00f), "Broken Husk", airDash),
            new ItemCoord(new Vector3(893.71f, 106.99f, 0.00f), "Broken Husk", airDash),
            new ItemCoord(new Vector3(884.29f, 106.99f, 0.00f), "Volatile Eye", airDash),
            new ItemCoord(new Vector3(882.82f, 131.83f, 0.00f), "Breathdew Shard", airDash),
            new ItemCoord(new Vector3(1019.96f, 120.53f, 0.00f), "Bloodmetal Shard", _Gloomnest),
            new ItemCoord(new Vector3(1031.43f, 138.01f, 0.00f), "Drained Shell Chest", _Gloomnest),
            new ItemCoord(new Vector3(1005.78f, 122.97f, 0.00f), "Drained Shell Hands", _Gloomnest),
            new ItemCoord(new Vector3(1030.71f, 140.46f, 0.00f), "Drained Shell Legs", _Gloomnest),
            new ItemCoord(new Vector3(1010.06f, 138.96f, 0.00f), "Urn Of Volatile Eyes", _Gloomnest),
            new ItemCoord(new Vector3(1029.08f, 144.18f, 0.00f), "Bowdaggers", _Gloomnest),
            new ItemCoord(new Vector3(1040.14f, 140.97f, 0.00f), "Bloodmetal Shard", _Gloomnest),
            new ItemCoord(new Vector3(1042.31f, 157.22f, 0.00f), "Ardent Sand", doubleJump || pull),
            new ItemCoord(new Vector3(1070.70f, 158.57f, 0.00f), "Thirsting Sand", doubleJump || pull),
            new ItemCoord(new Vector3(1092.71f, 154.62f, 0.00f), "Breathdew Shard", doubleJump || airDash && pull),

            //Yr Den

            //Worldpillar
            new ItemCoord(new Vector3(1594.98f, 188.52f, 0.00f), "Pillar Fragment", _Worldpillar),
            new ItemCoord(new Vector3(1554.96f, 196.91f, 0.00f), "Pillar Fragment", _Worldpillar),
            new ItemCoord(new Vector3(1567.94f, 198.63f, 0.00f), "Bone Grinder", (doubleJump || airDash) && itemPull && _Worldpillar),
            new ItemCoord(new Vector3(1573.13f, 198.63f, 0.00f), "Unformed Body", (doubleJump || airDash) && itemPull && _Worldpillar),
            new ItemCoord(new Vector3(1544.09f, 202.33f, 0.00f), "Bloodmetal Chunk", airDash && _Worldpillar),
            new ItemCoord(new Vector3(1597.73f, 163.10f, 0.00f), "Pillar Fragment", ((doubleJump || airDash && pull) && selfPull) || hover && _Worldpillar),
            new ItemCoord(new Vector3(1588.23f, 132.30f, 0.00f), "Levolam Dust", (selfPull || hover) && _Worldpillar),
            new ItemCoord(new Vector3(1587.57f, 102.15f, 0.00f), "Motley Pearl", ((doubleJump || airDash && pull) && selfPull) || hover && _Worldpillar),
            new ItemCoord(new Vector3(1649.63f, 139.98f, 0.00f), "Bloodmetal Splinter", airDash && selfPull && pull),
            new ItemCoord(new Vector3(1655.88f, 139.98f, 0.00f), "Bloodmetal Splinter", airDash && selfPull && pull),
            new ItemCoord(new Vector3(1652.60f, 139.98f, 0.00f), "Bloodmetal Chunk", airDash && selfPull && pull),
            new ItemCoord(new Vector3(1661.17f, 145.98f, 2.13f), "Crimson Ichor", airDash && selfPull && pull),
            new ItemCoord(new Vector3(1559.05f, 246.06f, 0.00f), "Pillar Fragment", _Worldpillar),
            new ItemCoord(new Vector3(1567.38f, 241.74f, 0.00f), "Pillar Fragment", _Worldpillar),
            new ItemCoord(new Vector3(1551.31f, 245.12f, 0.00f), "Levolam Dust", _Worldpillar),
            new ItemCoord(new Vector3(1497.56f, 243.25f, 0.00f), "Levolam Dust", pull),
            new ItemCoord(new Vector3(1475.92f, 286.18f, 0.00f), "Motley Pearl", pull),
            new ItemCoord(new Vector3(1486.46f, 261.08f, 0.00f), "Wakebone Armor", pull, false, 3),
            new ItemCoord(new Vector3(1535.58f, 275.43f, 0.00f), "Shaper", pull),
            new ItemCoord(new Vector3(1552.66f, 278.24f, 0.00f), "Bloodmetal Chunk", pull),
            new ItemCoord(new Vector3(1573.59f, 272.95f, 0.00f), "Levolam Dust", pull),
            new ItemCoord(new Vector3(1535.04f, 252.64f, 0.00f), "Bloodmetal Chunk", _Worldpillar && selfPull),
            new ItemCoord(new Vector3(1536.25f, 262.51f, 0.00f), "Breathdew Shard", _Worldpillar && selfPull),
            new ItemCoord(new Vector3(1567.85f, 259.23f, 0.00f), "Pillar Fragment", _Worldpillar),
            new ItemCoord(new Vector3(1560.05f, 252.55f, 0.00f), "Clutching Root", _Worldpillar),
            new ItemCoord(new Vector3(1552.49f, 249.20f, 0.00f), "Bloodmetal Shard", _Worldpillar),
            new ItemCoord(new Vector3(1574.05f, 247.54f, 0.00f), "Pillar Fragment", _Worldpillar),
            new ItemCoord(new Vector3(1608.57f, 257.25f, 0.00f), "Pillar Fragment", pull && airDash),
            new ItemCoord(new Vector3(1584.29f, 247.91f, 0.00f), "Pillar Fragment", _Worldpillar),
            new ItemCoord(new Vector3(1588.66f, 260.00f, 0.00f), "Fully Formed Husk", ((doubleJump || (airDash && selfPull && pull)) && itemPull) || doubleJump && airDash),
            new ItemCoord(new Vector3(1621.18f, 252.10f, 0.00f), "Fully Formed Husk", pull && itemPull || doubleJump),
            new ItemCoord(new Vector3(1621.35f, 230.88f, 0.00f), "Bloodmetal Shard", _Worldpillar),
            new ItemCoord(new Vector3(1624.08f, 45.75f, 0.00f), "Pillar Fragment", (doubleJump || pull) && hover || pull && (doubleJump || airDash)),

            //Nerveroot
            new ItemCoord(new Vector3(1515.20f, 198.78f, 0.00f), "Bloodmetal Splinter", _Nerveroot),
            new ItemCoord(new Vector3(1504.56f, 181.82f, 0.00f), "Charcoal Root", _Nerveroot),
            new ItemCoord(new Vector3(1509.11f, 172.72f, 0.00f), "Charcoal Root", _Nerveroot),
            new ItemCoord(new Vector3(1538.65f, 167.30f, 0.00f), "Breathdew Fragment", _Nerveroot),
            new ItemCoord(new Vector3(1544.18f, 167.21f, 0.00f), "Volatile Blob", _Nerveroot),
            new ItemCoord(new Vector3(1527.45f, 179.56f, 0.00f), "Pillar Fragment", _Nerveroot),
            new ItemCoord(new Vector3(1485.65f, 151.76f, 0.00f), "Bloodmetal Shard", _Nerveroot),
            new ItemCoord(new Vector3(1468.68f, 145.37f, 0.00f), "Hollowroot Chest", _Nerveroot, false, 1, true),
            new ItemCoord(new Vector3(1431.18f, 138.35f, 0.00f), "Hollowroot Hands", _Nerveroot),
            new ItemCoord(new Vector3(1452.89f, 136.31f, 0.00f), "Hollowroot Legs", _Nerveroot),
            new ItemCoord(new Vector3(1451.47f, 129.06f, 0.00f), "Unformed Body", (doubleJump || airDash || hover) && _Nerveroot),
            new ItemCoord(new Vector3(1480.56f, 126.31f, 0.00f), "Motley Pearl", doubleJump && _Nerveroot),
            new ItemCoord(new Vector3(1516.58f, 140.07f, 0.00f), "Bloodmetal Chunk", _Nerveroot),
            new ItemCoord(new Vector3(1505.77f, 152.23f, 0.00f), "Rawblade", _Nerveroot),
            new ItemCoord(new Vector3(1500.56f, 137.31f, 0.00f), "Charcoal Root", _Nerveroot),
            new ItemCoord(new Vector3(1472.47f, 130.21f, 0.00f), "Breathdew Shard", _Nerveroot),
            new ItemCoord(new Vector3(1511.09f, 105.60f, 0.00f), "Carven Greatsword", _Nerveroot, false, 1, true),
            new ItemCoord(new Vector3(1492.94f, 96.82f, 0.00f), "Bloodmetal Splinter", _Nerveroot),
            new ItemCoord(new Vector3(1511.93f, 110.84f, 0.00f), "Pillar Fragment", _Nerveroot),
            new ItemCoord(new Vector3(1537.28f, 108.84f, 0.00f), "Bloodmetal Shard", doubleJump && airDash && _Nerveroot),
            new ItemCoord(new Vector3(1487.75f, 88.80f, 0.00f), "Levolam Dust", _Nerveroot),
            new ItemCoord(new Vector3(1508.60f, 87.27f, 0.00f), "Breathdew Fragment", _Nerveroot, false, 1, true),
            new ItemCoord(new Vector3(1518.70f, 75.20f, 0.00f), "Motley Pearl", _Nerveroot),
            new ItemCoord(new Vector3(1485.72f, 67.27f, 0.00f), "Pillar Fragment", _Nerveroot),
            new ItemCoord(new Vector3(1387.01f, 102.07f, 0.00f), "Bloodmetal Splinter", _Nerveroot),
            new ItemCoord(new Vector3(1392.60f, 86.82f, 0.00f), "Bloodmetal Splinter"),
            new ItemCoord(new Vector3(1359.67f, 95.28f, 0.00f), "Clutching Root", _Nerveroot),
            new ItemCoord(new Vector3(1349.32f, 84.52f, 0.00f), "Motley Pearl", _Nerveroot),
            new ItemCoord(new Vector3(1277.19f, 82.04f, 0.00f), "Charcoal Root", _Nerveroot),
            new ItemCoord(new Vector3(1272.06f, 91.42f, 0.00f), "Wisp Lantern", _Nerveroot, false, 1, true),
            new ItemCoord(new Vector3(1255.76f, 80.57f, 0.00f), "Bloodmetal Shard", _Nerveroot && airDash),
            new ItemCoord(new Vector3(1486.39f, 49.31f, 0.00f), "Motley Pearl", _Nerveroot && airDash),
            new ItemCoord(new Vector3(1433.58f, 49.44f, 0.00f), "Bloodmetal Chunk", _Nerveroot && airDash && selfPull),
            new ItemCoord(new Vector3(1450.47f, 49.98f, 0.00f), "Breathdew Fragment", _Nerveroot && airDash && selfPull),
            new ItemCoord(new Vector3(1444.81f, 49.98f, 0.00f), "Breathdew Fragment", _Nerveroot && airDash && selfPull),
            new ItemCoord(new Vector3(1440.10f, 49.98f, 0.00f), "Breathdew Fragment", _Nerveroot && airDash && selfPull),
            new ItemCoord(new Vector3(1431.27f, 68.29f, 0.00f), "Clutching Root", _Nerveroot && airDash),
            new ItemCoord(new Vector3(1392.51f, 65.07f, 0.00f), "Bloodmetal Shard", _Nerveroot && airDash),
            new ItemCoord(new Vector3(1406.71f, 73.70f, 0.00f), "Bloodetal Shard", _Nerveroot && airDash),
            new ItemCoord(new Vector3(1313.25f, 72.77f, 0.00f), "Charcoal Root", _Nerveroot && airDash),
            new ItemCoord(new Vector3(1303.19f, 56.04f, 0.00f), "Charcoal Root", _Nerveroot && airDash),
            new ItemCoord(new Vector3(1441.46f, 80.80f, 0.00f), "Levolam Dust", _Nerveroot && airDash),
            new ItemCoord(new Vector3(1442.33f, 74.31f, 0.00f), "Unformed Hand", _Nerveroot && airDash),
            new ItemCoord(new Vector3(1426.34f, 74.31f, 0.00f), "Unformed Hand", _Nerveroot && airDash),
            new ItemCoord(new Vector3(1442.33f, 74.31f, 0.00f), "Breathdew Fragment", _Nerveroot && airDash),
            new ItemCoord(new Vector3(1421.06f, 74.31f, 0.00f), "Breathdew Fragment", _Nerveroot && airDash),
            new ItemCoord(new Vector3(1437.40f, 74.31f, 0.00f), "Levolam Dust", _Nerveroot && airDash),
            new ItemCoord(new Vector3(1414.89f, 74.31f, 0.00f), "Clutching Root", _Nerveroot && airDash),

            //Feaster's Lair
            new ItemCoord(new Vector3(1170.80f, 75.00f, 0.00f), "Rib", pull && doubleJump || airDash),
            new ItemCoord(new Vector3(1189.75f, 56.23f, 0.00f), "Bloodmetal Shard", _feastersLair),
            new ItemCoord(new Vector3(1053.38f, 118.99f, 0.00f), "Ardent Sand", airDash || doubleJump),
            new ItemCoord(new Vector3(1066.28f, 98.94f, 0.00f), "Ardent Sand", airDash || doubleJump),
            new ItemCoord(new Vector3(1064.55f, 88.31f, 0.00f), "Pillar Fragment", airDash || doubleJump),
            new ItemCoord(new Vector3(1069.64f, 87.95f, 0.00f), "Pillar Fragment", airDash || doubleJump),
            new ItemCoord(new Vector3(1039.83f, 90.59f, 0.00f), "Bloodmetal Shard", airDash || doubleJump),
            new ItemCoord(new Vector3(1040.75f, 60.97f, 0.00f), "Tarbile Tooth", _feastersLair),
            new ItemCoord(new Vector3(1127.33f, 21.98f, 0.00f), "Rib", _feastersLair),
            new ItemCoord(new Vector3(1162.43f, 34.50f, 0.00f), "Bloodmetal Splinter", pull || doubleJump && airDash),
            new ItemCoord(new Vector3(1115.26f, 38.16f, 0.00f), "Tarbile Tooth", pull || doubleJump && airDash),
            new ItemCoord(new Vector3(1140.59f, 40.11f, 0.00f), "Bloodmetal Shard", airDash && pull),
            new ItemCoord(new Vector3(1280.58f, 14.44f, 0.00f), "Bloodmetal Chunk", pull && airDash && selfPull),
            new ItemCoord(new Vector3(1296.05f, 13.75f, 0.00f), "Tooth Fists", pull && airDash && selfPull),
            new ItemCoord(new Vector3(1107.51f, 31.00f, 0.00f), "Shard Field", pull || doubleJump && airDash),
            new ItemCoord(new Vector3(1096.42f, 16.75f, 0.00f), "Bloodmetal Shard", _feastersLair),
            new ItemCoord(new Vector3(1099.85f, 32.05f, 0.00f), "Thirsting Sand", _feastersLair),

            //Servant's Path
            //Carven Palace
            //Garden
            //Childbed
            //Beyond The Barrier
            //Cenotaph City
        };
    }
}
