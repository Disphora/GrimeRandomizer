using System;
using System.Collections.Generic;
using System.Linq;

namespace GrimeRandomizer
{
    internal class ItemPool
    {
        public static Dictionary<int, ItemDefinition> itemPool = new Dictionary<int, ItemDefinition>();
        private const string Nail = "a643f782-37c6-4509-b2ac-713072570ac2";
        private const string VolatileEye = "38aa1f6f-6936-42e4-9c02-53dc6c6c9bd0";
        private const string BreathdewShard = "beb873f2-00bc-4529-800c-f77fef11236d";
        private const string ArdentSand = "07eda760-4ed9-4667-b32f-c3324be02275";
        private const string DebrisField = "7f0a5ca9-e11a-4acc-a49a-bc7a10db8a77";
        private const string LivingFlesh = "3a5d2666-3ec6-48c7-aa9f-87d05a4a21f4";
        private const string FriendlyImposterChest = "6c813e9c-2c32-427e-be70-edce25120891";
        private const string FriendlyImposterHands = "366e313a-c796-4162-a8b7-39314e263c0d";
        private const string FriendlyImposterLegs = "ca00b8de-933e-4375-9b82-3b6f07915a58";
        private const string Bownails = "2f041e3b-e252-4aec-ac63-733f35001f55";
        private const string UnformedFinger = "6e302b98-0293-4310-bd03-ac369fa85eac";
        private const string UnformedBody = "5b9743df-c1ee-480b-8c2e-48bb0c84ae7b";
        private const string UnformedHand = "402d9bf5-adf8-4f99-9aa6-baeff18a86ff";
        private const string MotleyPearl = "b681a334-e63a-499b-8aa3-25a9e9c7e0db";
        private const string CrimsonIchor = "9be6a62e-1768-4a8c-a7c6-94bc8dab96f0";
        private const string FossilFist = "cd43fd79-fb0b-4211-a0a4-3970a453bd82";
        private const string BoulderplateChest = "07469ae9-140e-4639-bce5-5d4f699bb808";
        private const string BoulderplateHands = "794839ce-0a5c-484a-b928-a321c46fb7d6";
        private const string BoulderplateLegs = "9d77f1a0-1f21-42a3-ae39-78fc6ac1bd84";
        private const string VolatileBlob = "e2cce968-bed3-435c-bfc7-5209b0482aca";
        private const string ThirstingSand = "82063e81-b22f-4b59-9b45-a6be22831bf0";
        private const string LevolamDust = "f8fe2f67-04ef-4628-b4ec-03738e15bdf4";
        private const string FullyFormedHusk = "990d8f59-fdeb-4bed-a686-a7ba9a471b85";
        private const string HyalineChest = "f3b29ca5-fc0c-4f6d-ad8c-849b29c7e091";
        private const string HyalineHands = "47237e62-276c-46bc-a40c-ac012fe6049f";
        private const string HyalineLegs = "c522d961-6c12-4467-869b-cb3869a45b19";
        private const string PetalstoneChest = "e5ebc9eb-2e38-47b0-8cca-b6dc0652e589";
        private const string PetalstoneHands = "ec0bf67e-a972-4088-b0d9-b4b0dcd37f62";
        private const string PetalstoneLegs = "2fd05764-0ffc-43a9-b9b6-7ec1a6cdb800";
        private const string PointedTravelerChest = "4f961b8a-46cf-4bbb-98a9-d69bc86a15ab";
        private const string PointedTravelerHands = "2c74d0f0-683e-4160-b7a4-158211c82a90";
        private const string PointedTravelerLegs = "3275b6be-6198-45cc-a621-2247cc06d264";
        private const string LithichuskChest = "e14593d0-2643-4066-bcab-b5f844d1aacf";
        private const string LithichuskHands = "89ea1c97-f76e-40fa-b072-fa567f9c57e8";
        private const string LithichuskLegs = "78410a71-9a70-4c37-b787-5758c5b8d8dc";
        private const string PillarSlab = "483435de-1bf1-404c-963c-1d9b4fec588d";
        private const string ObeliskFist = "d53a7e6e-8ee4-4a98-8af7-2ebbf478763c";
        private const string LivingRock = "b611d000-69d6-4b8b-a132-4f7ca2a96dda";
        private const string BreathdewFragment = "56eb58c0-6e6c-4565-96c0-b0cce209047e";
        private const string BreathdewDroplet = "6484358b-329b-44ba-aab3-292b07ba74e8";
        private const string ShardField = "65378912-4af2-4b76-b361-2e9021e96a57";
        private const string BrokenHusk = "a95feb6f-37ad-45ec-a75d-2c07699ed8c1";
        private const string UnformedTorso = "0e871433-4a10-4739-a174-b856991274b3";
        private const string LithicPortrait = "075500f4-02ba-4ecf-b646-31e68ddb9e66";
        private const string LithicPoem = "2d7c487e-1ebf-47ae-854e-31eea88c5e26";
        private const string LithicEffigy = "f9f2d960-0f73-48a7-b0d4-00fe3ac5935b";
        private const string CurvedGlaive = "c96d3d09-1de5-4552-8745-4c8727fc7d85";
        private const string YrGlaive = "0ce793f2-6514-4f3b-a272-8af73447461c";
        private const string BrokenYrSword = "1f8880c0-b491-4cb8-a6a9-05ee5482940b";
        private const string FirstYrChest = "908e3d7f-1737-4644-b93a-776e4ee3afbb";
        private const string FirstYrHands = "0e48f2fd-37a9-4ca2-befe-bec5b84f5dc8";
        private const string FirstYrLegs = "06cbabee-85be-4391-925a-2de57afca155";
        private const string Rib = "7136086a-b489-4092-ad53-ad6c296e8a8c";
        private const string Shaper = "e53b040c-1c7b-47ad-b7e3-7c4118533686";
        private const string BoneGrinder = "ad5073c8-3fba-43b3-8fa3-6504293bd65a";
        private const string PillarFragment = "71fb1252-fc09-4b34-b58e-098ffba3130f";
        private const string ClutchingRoot = "27cfbba6-086d-41e8-9eb8-5090356426d8";
        private const string WakeboneChest = "fc250c8b-92dd-4be6-9ca9-f5f4e15c30ad";
        private const string WakeboneHands = "1a813853-fd77-4c10-81f4-b0c18445ef97";
        private const string WakeboneLegs = "4f94210c-3cfe-4f06-b126-ff436c388931";
        private const string Rawblade = "98a9263c-9e5e-4de6-9e48-e6e109aee793";
        private const string HollowrootChest = "48ba44d0-4559-42a6-bf8b-64b66be043f9";
        private const string HollowrootHands = "5e1a4f0d-1f8e-41ad-9037-538d501233c1";
        private const string HollowrootLegs = "6d216e19-a367-4050-9fb3-a7f9575b32ec";
        private const string CarvenGreatsword = "5156dc11-92bf-4d04-a5cb-d8218f552152";
        private const string Bowdaggers = "3ba737ab-79df-4b9f-a1ce-c15d89058f2a";
        private const string WispLantern = "baec98c1-ea66-4c65-9a12-21b8de9b887d";
        private const string CharcoalRoot = "b39adde4-ddc3-4937-8799-dbd1db538a9c";
        private const string AwakeningGasp = "aa716187-a0c8-43be-9c18-a68684fd6f2e";
        private const string JawAxe = "d139bb95-f61a-402c-86f2-1b6baf2fc731";
        private const string JawplateChest = "c9910726-0e82-4c34-b2c0-dc675ae45814";
        private const string JawplateHands = "c5d5a821-0c0c-4913-9fc0-63fe8c6e779b";
        private const string JawplateLegs = "a2660aab-7a14-4d33-a7f9-261508494d3b";
        private const string ToothHammer = "37583206-f58c-450c-882e-51096f665b2d";
        private const string PincerGlaive = "4f7f069e-a1e7-49fc-8d88-4c69cc7178df";
        private const string TarbileTooth = "7bd69ca1-a92a-46cc-8057-84f7616aa23d";
        private const string UrnOfVolatileEyes = "0d19715e-bbc2-4116-95af-6cc4618fa192";
        private const string KilyahStone = "36df0fa1-a266-4973-85b8-702ac10c2f6f";
        private const string FaceSlasher = "d0680cda-e2c5-44fe-aaaf-5f8644ad6dc7";
        private const string DrainedShellChest = "efc6230c-772e-4971-b580-90cab2c4e41f";
        private const string DrainedShellHands = "e89213d9-fab2-432c-ad5d-b264e35a4852";
        private const string DrainedShellLegs = "3d08f4a2-a912-48d5-8cdb-49467916b8cb";
        private const string BurstLantern = "690d120a-f504-4d06-8785-68073aa77d9b";
        private const string WholeHusk = "647b551c-834c-4d87-9ede-564a9f2222e1";
        private const string PearlplateChest = "467943ba-50a3-4cb9-b86c-10f6b6cb44b4";
        private const string PearlplateHands = "2a03c529-224e-425b-80f6-52dd6e9d065d";
        private const string PearlplateLegs = "be8b34d3-5dea-4c05-92b5-6b6565b61e1c";
        private const string SicklebackChest = "97cddb71-85af-4c0a-8181-8aabee16ad97";
        private const string SicklebackHands = "bbb5d822-6c7f-4f93-afca-6434fc83a8a2";
        private const string SicklebackLegs = "307786cb-4a57-4acc-bec6-de04a5befc10";
        private const string HornedTravelerChest = "0a9049b4-c54c-43ee-a9dc-0b8c0cb00451";
        private const string HornedTravelerHands = "834a45df-6590-4666-88b4-7fcfef83a16a";
        private const string HornedTravelerLegs = "b00f4cdc-8599-4e0d-abd4-1a9a4682c6bb";
        private const string Spinesword = "b5b873da-21d5-443e-9241-cec1b060f0f0";
        private const string Spineaxe = "74d9e0a7-3ddc-464d-9d94-959c03ad713e";
        private const string CentipedeWhip = "24172405-1ae6-4395-b1d7-29f2f4f6ec34";
        private const string WanebloodChest = "f030062e-af26-4f52-ae18-72506c050ffe";
        private const string WanebloodHands = "61dbc101-09de-4645-9530-b9037c500979";
        private const string WanebloodLegs = "f34f5df9-6602-4ded-91e8-b162f2e40091";
        private const string BloomingChest = "150a1e0f-1b9a-4fc1-9aa1-4afde06ff53a";
        private const string BloomingHands = "e748e4f8-907b-4dbe-8220-4d0d1625be12";
        private const string BloomingLegs = "0a08d554-3a59-40fb-bb15-71f4fb944f6a";
        private const string MarrowChest = "09bd1346-5c8d-476d-a819-b6e65096b3e8";
        private const string MarrowHands = "95eb37a3-7d32-417f-9273-556c65073eae";
        private const string MarrowLegs = "8443997b-8791-4f48-805f-6c71cfcf7db7";
        private const string ToothFists = "a83d6c64-dd14-4a1a-b64b-e66d48ca1b23";
        private const string YonsBrokenTorso = "bd8e28d0-cc75-4b16-8c15-ec9e23cf010f";
        private const string UnformedHead = "028fabf9-aa7c-4def-939d-eb27c27399bb";
        private const string StrandOfTheChild = "e497b557-1320-4df5-a844-3985e80b6d25";
        private const string FetalPearl = "d387c653-b090-4e05-8d5f-7c6cebf6cb0d";
        private const string PryingSickles = "f8d18ad2-dd6c-4168-8e83-47d98a3fdd54";
        private const string SearingSickle = "cd6d0565-994c-4889-a67a-cc7e1e5cd75d";
        private const string ChiselNails = "a3ac4427-8c61-4eb2-aee2-9e6e42077000";
        private const string CelebrationChest = "5379e84a-530a-417a-8778-194fdf60aafe";
        private const string CelebrationHands = "afe93c68-71d9-45b7-9137-8998844acd29";
        private const string CelebrationLegs = "c6083696-1c63-4324-899b-f81de5f8c7a2";
        private const string FormalCodaChest = "56d2e849-bf18-40f4-bd9f-d1bcde51983a";
        private const string FormalCodaHands = "523fbb81-ffe9-4d92-b26d-04bfafb024cc";
        private const string FormalCodaLegs = "2f01cc44-dae5-47d1-ab4f-022868c43909";
        private const string AdeptEmbroiderChest = "1dca36b9-cab4-4380-9cff-473733e5f0fe";
        private const string AdeptEmbroiderHands = "7fa1f9af-6861-447d-b82b-4bc52a2c6140";
        private const string AdeptEmbroiderLegs = "692790b6-ee52-4ca8-aa16-3911140bac0a";
        private const string OtherwherePhloxChest = "46fb3598-1dc7-471b-a015-4a15ab2a042e";
        private const string OtherwherePhloxHands = "0196647e-a4e1-42b0-a16e-8cc0ab7f7dcf";
        private const string OtherwherePhloxLegs = "304d54bc-533e-495a-8e02-a63461b8bf49";
        private const string FingerBlade = "add86fe0-b533-4865-9bff-0c6eaca05edf";
        private const string MaulAxe = "a54651d7-e14c-4b7d-ac19-7f64cb916d7a";
        private const string MaulSword = "8a49aded-5af4-4c3f-8fe4-758b89b64dea";
        private const string TwinFangs = "bb13bbdb-52ef-4d96-88b2-7d950728485a";
        private const string PricklyWeeperChest = "6614cfbe-5ed7-483d-b608-e473868c6f51";
        private const string PricklyWeeperHands = "ae9fe662-d23a-4fd4-8045-b2c1b5558179";
        private const string PricklyWeeperLegs = "99086f2d-2ffe-4e73-98e3-6b1b5e73c9fc";
        private const string BellowMace = "1c9afbb2-623c-4bc6-ad38-811b94273fce";
        private const string ServantNeedle = "959beb10-1634-4289-9575-ceca75e1f976";
        private const string ShapelyGreatsword = "52efd679-04d8-4d22-af46-c8d6cf719c8b";
        private const string WeatheredStitcherChest = "35c9d3f3-1c29-48e5-ab98-b586bf65323a";
        private const string WeatheredStitcherHands = "a4123b2d-631e-4f6d-bcf6-40c024951fca";
        private const string WeatheredStitcherLegs = "00618c5c-ed7f-446c-bcc2-f42a213928a9";
        private const string HuskrootChest = "e5d71a89-a7ce-409d-923e-47c3e999a2f1";
        private const string HuskrootHands = "1e6972cd-e4a7-431a-aaf2-1975acdec392";
        private const string HuskrootLegs = "4498860c-bbff-467d-b211-1c354f29f311";
        private const string MotleySwords = "4ae59b1f-3304-415e-a547-1a2f31d9634f";
        private const string PetalgemChest = "58dff554-ba83-4a19-87d7-eb85c662407f";
        private const string PetalgemHands = "fbbe3a96-53e2-4d5a-b176-85e78780d421";
        private const string PetalgemLegs = "f39b3dc0-aabb-4747-89f0-89bf055c99d9";
        private const string NeonatalLevolam = "869c43ab-a2aa-4d07-89ba-3fee93873d2a";
        private const string BloodmetalSplinter = "0534f896-f294-4d0c-b1a8-2180c380d9b3";
        private const string BloodmetalShard = "01c7abc8-5ac7-4a73-bd1f-6e65e5c67e6c";
        private const string BloodmetalChunk = "7d3541b1-e631-437f-8afe-f8428a57f9ac";
        private const string Claw = "0aba52b0-527f-4ac9-8779-c1f4de8b13de";
        private const string Bowaxes = "55da3dff-2c7f-4376-8689-a0ac79859c60";
        private const string GoldgrowthChest = "274b9848-c631-4322-8a2f-481b63645d6a";
        private const string GoldgrowthHands = "cf6dc359-9b1a-4a30-9adb-0f416e64509f";
        private const string GoldgrowthLegs = "fcde1c5c-925a-487d-b5ad-787c3a6b3140";
        private const string AttuningLantern = "be51d6e3-bdb7-4547-b2e5-e73698bed778";
        private const string NailScythe = "2c7100b5-060a-494a-93a2-9165786f83ec";
        private const string DiscardedDevice = "9f299ba9-6b55-413f-9bf6-5184c9d00998";
        private const string BonebirdChest = "ce6efee8-45d7-41e6-a885-df1e0f3726f3";
        private const string BonebirdHands = "46fdbbbc-3541-4335-9260-92a665f2cfa7";
        private const string BonebirdLegs = "7d113c71-02f6-4f1f-b341-ffcca75f9844";
        private const string BloodmetalScythe = "b274cc5d-da20-4535-8b57-c6c493ad5774";
        public class ItemDefinition
        {
            public string Guid { get; }
            public int Quantity { get; }
            public bool IsWeapon { get; }
            public ItemDefinition(string guid, int quantity = 1, bool isWeapon = false)
            {
                Guid = guid;
                Quantity = quantity;
                IsWeapon = isWeapon;
            }
        }

        public static void AddItems()
        {
            itemPool.Clear();

            List<ItemDefinition> itemsToAdd = new List<ItemDefinition>
            {
                new ItemDefinition(OtherwherePhloxChest),
                new ItemDefinition(OtherwherePhloxHands),
                new ItemDefinition(OtherwherePhloxLegs),
                new ItemDefinition(FingerBlade, 1, true),
                new ItemDefinition(MaulAxe, 1, true),
                new ItemDefinition(MaulSword, 1, true),
                new ItemDefinition(TwinFangs, 1, true),
                new ItemDefinition(PricklyWeeperChest),
                new ItemDefinition(PricklyWeeperHands),
                new ItemDefinition(PricklyWeeperLegs),
                new ItemDefinition(BellowMace, 1, true),
                new ItemDefinition(LevolamDust, 1),
                new ItemDefinition(LevolamDust, 1),
                new ItemDefinition(Nail, 5),
                new ItemDefinition(Nail, 5),
                new ItemDefinition(Nail, 5),
                new ItemDefinition(Nail, 3),
                new ItemDefinition(Nail, 2),
                new ItemDefinition(Nail, 2),
                new ItemDefinition(VolatileEye, 2),
                new ItemDefinition(VolatileEye, 3),
                new ItemDefinition(BreathdewShard),
                new ItemDefinition(ArdentSand, 5),
                new ItemDefinition(ArdentSand, 1),
                new ItemDefinition(DebrisField),
                new ItemDefinition(LivingFlesh),
                new ItemDefinition(FriendlyImposterChest),
                new ItemDefinition(FriendlyImposterHands),
                new ItemDefinition(FriendlyImposterLegs),
                new ItemDefinition(Bownails),
                new ItemDefinition(UnformedFinger, 1),
                new ItemDefinition(UnformedFinger, 1),
                new ItemDefinition(UnformedFinger, 1),
                new ItemDefinition(UnformedFinger, 1),
                new ItemDefinition(UnformedFinger, 1),
                new ItemDefinition(UnformedBody, 1),
                new ItemDefinition(UnformedBody, 1),
                new ItemDefinition(UnformedHand, 1),
                new ItemDefinition(UnformedHand, 1),
                new ItemDefinition(MotleyPearl, 3),
                new ItemDefinition(MotleyPearl, 1),
                new ItemDefinition(MotleyPearl, 1),
                new ItemDefinition(CrimsonIchor, 1),
                new ItemDefinition(CrimsonIchor, 1),
                new ItemDefinition(BloodmetalShard),
                new ItemDefinition(BloodmetalSplinter),
                new ItemDefinition(BloodmetalSplinter),
                new ItemDefinition(BloodmetalSplinter),

                new ItemDefinition(FossilFist, 1, true),
                new ItemDefinition(BoulderplateChest),
                new ItemDefinition(BoulderplateHands),
                new ItemDefinition(BoulderplateLegs),
                new ItemDefinition(VolatileBlob, 5),
                new ItemDefinition(VolatileBlob, 2),
                new ItemDefinition(VolatileBlob, 2),
                new ItemDefinition(VolatileEye, 2),
                new ItemDefinition(ArdentSand, 2),
                new ItemDefinition(ArdentSand, 1),
                new ItemDefinition(ArdentSand, 1),
                new ItemDefinition(ArdentSand, 1),
                new ItemDefinition(ThirstingSand),
                new ItemDefinition(Nail, 4),
                new ItemDefinition(LevolamDust),
                new ItemDefinition(MotleyPearl),
                new ItemDefinition(FullyFormedHusk, 1),
                new ItemDefinition(FullyFormedHusk, 1),
                new ItemDefinition(FullyFormedHusk, 1),
                new ItemDefinition(UnformedBody),
                new ItemDefinition(UnformedHand, 1),
                new ItemDefinition(UnformedHand, 1),
                new ItemDefinition(CrimsonIchor),
                new ItemDefinition(BloodmetalSplinter),
                new ItemDefinition(BloodmetalSplinter),
                new ItemDefinition(BloodmetalChunk),
                new ItemDefinition(Claw),
                new ItemDefinition(Bowaxes),

                new ItemDefinition(HyalineChest),
                new ItemDefinition(HyalineHands),
                new ItemDefinition(HyalineLegs),
                new ItemDefinition(PetalstoneChest),
                new ItemDefinition(PetalstoneHands),
                new ItemDefinition(PetalstoneLegs),
                new ItemDefinition(PointedTravelerChest),
                new ItemDefinition(PointedTravelerHands),
                new ItemDefinition(PointedTravelerLegs),
                new ItemDefinition(LithichuskChest),
                new ItemDefinition(LithichuskHands),
                new ItemDefinition(LithichuskLegs),
                new ItemDefinition(PillarSlab, 1, true),
                new ItemDefinition(ObeliskFist, 1, true),
                new ItemDefinition(Nail, 5),
                new ItemDefinition(Nail, 5),
                new ItemDefinition(DebrisField, 2),
                new ItemDefinition(DebrisField, 2),
                new ItemDefinition(DebrisField, 2),
                new ItemDefinition(DebrisField, 1),
                new ItemDefinition(ArdentSand, 2),
                new ItemDefinition(ArdentSand, 2),
                new ItemDefinition(ArdentSand, 2),
                new ItemDefinition(ArdentSand, 1),
                new ItemDefinition(LivingRock, 2),
                new ItemDefinition(LivingRock, 1),
                new ItemDefinition(LivingRock, 1),
                new ItemDefinition(BreathdewShard, 3),
                new ItemDefinition(BreathdewFragment, 2),
                new ItemDefinition(BreathdewDroplet, 1),
                new ItemDefinition(BreathdewDroplet, 1),
                new ItemDefinition(BreathdewDroplet, 1),
                new ItemDefinition(ThirstingSand),
                new ItemDefinition(ShardField),
                new ItemDefinition(BrokenHusk),
                new ItemDefinition(LevolamDust),
                new ItemDefinition(UnformedHand, 2),
                new ItemDefinition(UnformedHand, 1),
                new ItemDefinition(UnformedHand, 1),
                new ItemDefinition(UnformedHand, 1),
                new ItemDefinition(UnformedTorso),
                new ItemDefinition(FullyFormedHusk),
                new ItemDefinition(LithicPortrait),
                new ItemDefinition(LithicPoem),
                new ItemDefinition(LithicEffigy),
                new ItemDefinition(MotleyPearl, 1),
                new ItemDefinition(MotleyPearl, 1),
                new ItemDefinition(MotleyPearl, 1),
                new ItemDefinition(CrimsonIchor),
                new ItemDefinition(BloodmetalSplinter),
                new ItemDefinition(BloodmetalSplinter),
                new ItemDefinition(BloodmetalSplinter),
                new ItemDefinition(BloodmetalSplinter),
                new ItemDefinition(BloodmetalSplinter),
                new ItemDefinition(BloodmetalSplinter),
                new ItemDefinition(BloodmetalSplinter),
                new ItemDefinition(BloodmetalShard),
                new ItemDefinition(BloodmetalShard),

                new ItemDefinition(CurvedGlaive, 1, true),
                new ItemDefinition(YrGlaive, 1, true),
                new ItemDefinition(BrokenYrSword, 1, true),
                new ItemDefinition(FirstYrChest),
                new ItemDefinition(FirstYrHands),
                new ItemDefinition(FirstYrLegs),
                new ItemDefinition(BreathdewShard),
                new ItemDefinition(BreathdewDroplet),
                new ItemDefinition(Rib, 10),
                new ItemDefinition(LevolamDust),
                new ItemDefinition(ArdentSand, 2),
                new ItemDefinition(UnformedTorso, 1),
                new ItemDefinition(UnformedTorso, 1),
                new ItemDefinition(UnformedTorso, 1),
                new ItemDefinition(UnformedTorso, 1),
                new ItemDefinition(CrimsonIchor),
                new ItemDefinition(BloodmetalChunk),
                new ItemDefinition(BloodmetalSplinter),
                new ItemDefinition(BloodmetalShard),
                new ItemDefinition(BloodmetalShard),
                new ItemDefinition(BloodmetalShard),
                new ItemDefinition(BloodmetalShard),
                new ItemDefinition(BloodmetalShard),

                new ItemDefinition(Shaper, 1, true),
                new ItemDefinition(BoneGrinder, 1, true),
                new ItemDefinition(PillarFragment, 1),
                new ItemDefinition(PillarFragment, 1),
                new ItemDefinition(PillarFragment, 1),
                new ItemDefinition(PillarFragment, 1),
                new ItemDefinition(PillarFragment, 1),
                new ItemDefinition(PillarFragment, 1),
                new ItemDefinition(PillarFragment, 1),
                new ItemDefinition(PillarFragment, 1),
                new ItemDefinition(PillarFragment, 2),
                new ItemDefinition(PillarFragment, 5),
                new ItemDefinition(LevolamDust, 1),
                new ItemDefinition(LevolamDust, 1),
                new ItemDefinition(LevolamDust, 1),
                new ItemDefinition(BreathdewShard),
                new ItemDefinition(FullyFormedHusk, 1),
                new ItemDefinition(FullyFormedHusk, 1),
                new ItemDefinition(UnformedBody),
                new ItemDefinition(ClutchingRoot, 3),
                new ItemDefinition(CrimsonIchor),
                new ItemDefinition(MotleyPearl),
                new ItemDefinition(BloodmetalShard),
                new ItemDefinition(BloodmetalShard),
                new ItemDefinition(BloodmetalChunk),
                new ItemDefinition(BloodmetalChunk),
                new ItemDefinition(BloodmetalChunk),
                new ItemDefinition(BloodmetalChunk),
                new ItemDefinition(BloodmetalSplinter),
                new ItemDefinition(BloodmetalSplinter),
                new ItemDefinition(BloodmetalSplinter),
                new ItemDefinition(GoldgrowthChest),
                new ItemDefinition(GoldgrowthHands),
                new ItemDefinition(GoldgrowthLegs),
                new ItemDefinition(AttuningLantern),
                new ItemDefinition(NailScythe),
                new ItemDefinition(DiscardedDevice),

                new ItemDefinition(WakeboneChest),
                new ItemDefinition(WakeboneHands),
                new ItemDefinition(WakeboneLegs),
                new ItemDefinition(Rawblade, 1, true),
                new ItemDefinition(HollowrootChest),
                new ItemDefinition(HollowrootHands),
                new ItemDefinition(HollowrootLegs),
                new ItemDefinition(CarvenGreatsword, 1, true),
                new ItemDefinition(Bowdaggers, 1, true),
                new ItemDefinition(WispLantern, 1, true),
                new ItemDefinition(MotleyPearl, 1),
                new ItemDefinition(MotleyPearl, 1),
                new ItemDefinition(MotleyPearl, 1),
                new ItemDefinition(MotleyPearl, 1),
                new ItemDefinition(MotleyPearl, 1),
                new ItemDefinition(LevolamDust, 2),
                new ItemDefinition(LevolamDust, 1),
                new ItemDefinition(LevolamDust, 1),
                new ItemDefinition(LevolamDust, 1),
                new ItemDefinition(CharcoalRoot, 1),
                new ItemDefinition(CharcoalRoot, 1),
                new ItemDefinition(CharcoalRoot, 1),
                new ItemDefinition(CharcoalRoot, 2),
                new ItemDefinition(CharcoalRoot, 2),
                new ItemDefinition(CharcoalRoot, 2),
                new ItemDefinition(CharcoalRoot, 3),
                new ItemDefinition(PillarFragment, 2),
                new ItemDefinition(PillarFragment, 2),
                new ItemDefinition(PillarFragment, 2),
                new ItemDefinition(BreathdewFragment, 2),
                new ItemDefinition(BreathdewFragment, 1),
                new ItemDefinition(BreathdewFragment, 1),
                new ItemDefinition(BreathdewFragment, 1),
                new ItemDefinition(BreathdewFragment, 1),
                new ItemDefinition(BreathdewFragment, 1),
                new ItemDefinition(BreathdewFragment, 1),
                new ItemDefinition(BreathdewShard, 2),
                new ItemDefinition(VolatileBlob, 2),
                new ItemDefinition(UnformedBody),
                new ItemDefinition(UnformedHand),
                new ItemDefinition(ClutchingRoot, 4),
                new ItemDefinition(ClutchingRoot, 2),
                new ItemDefinition(AwakeningGasp, 3),
                new ItemDefinition(BloodmetalSplinter),
                new ItemDefinition(BloodmetalSplinter),
                new ItemDefinition(BloodmetalSplinter),
                new ItemDefinition(BloodmetalShard),
                new ItemDefinition(BloodmetalShard),
                new ItemDefinition(BloodmetalShard),
                new ItemDefinition(BloodmetalShard),
                new ItemDefinition(BloodmetalShard),
                new ItemDefinition(BloodmetalChunk),
                new ItemDefinition(BloodmetalChunk),

                new ItemDefinition(JawAxe, 1, true),
                new ItemDefinition(JawplateChest),
                new ItemDefinition(JawplateHands),
                new ItemDefinition(JawplateLegs),
                new ItemDefinition(ToothHammer, 1, true),
                new ItemDefinition(PincerGlaive, 1, true),
                new ItemDefinition(MotleyPearl, 1),
                new ItemDefinition(MotleyPearl, 1),
                new ItemDefinition(MotleyPearl, 1),
                new ItemDefinition(Rib, 10),
                new ItemDefinition(Rib, 10),
                new ItemDefinition(Rib, 2),
                new ItemDefinition(Rib, 2),
                new ItemDefinition(Rib, 5),
                new ItemDefinition(Rib, 5),
                new ItemDefinition(Rib, 5),
                new ItemDefinition(Rib, 5),
                new ItemDefinition(Rib, 3),
                new ItemDefinition(Rib, 4),
                new ItemDefinition(Rib, 1),
                new ItemDefinition(Rib, 1),
                new ItemDefinition(TarbileTooth, 3),
                new ItemDefinition(TarbileTooth, 3),
                new ItemDefinition(TarbileTooth, 2),
                new ItemDefinition(TarbileTooth, 2),
                new ItemDefinition(TarbileTooth, 2),
                new ItemDefinition(TarbileTooth, 2),
                new ItemDefinition(TarbileTooth, 2),
                new ItemDefinition(TarbileTooth, 5),
                new ItemDefinition(BrokenHusk, 2),
                new ItemDefinition(ShardField, 2),
                new ItemDefinition(ShardField, 2),
                new ItemDefinition(ThirstingSand),
                new ItemDefinition(LevolamDust),
                new ItemDefinition(BreathdewFragment),
                new ItemDefinition(BreathdewShard),
                new ItemDefinition(VolatileBlob, 3),
                new ItemDefinition(LivingRock, 2),
                new ItemDefinition(UrnOfVolatileEyes),
                new ItemDefinition(PillarFragment, 1),
                new ItemDefinition(PillarFragment, 2),
                new ItemDefinition(ArdentSand, 1),
                new ItemDefinition(ArdentSand, 1),
                new ItemDefinition(KilyahStone),
                new ItemDefinition(BloodmetalSplinter),
                new ItemDefinition(BloodmetalShard),
                new ItemDefinition(BloodmetalShard),
                new ItemDefinition(BloodmetalShard),
                new ItemDefinition(BloodmetalShard),
                new ItemDefinition(BloodmetalShard),
                new ItemDefinition(BloodmetalShard),
                new ItemDefinition(BloodmetalShard),
                new ItemDefinition(BloodmetalShard),
                new ItemDefinition(BloodmetalShard),
                new ItemDefinition(BloodmetalShard),
                new ItemDefinition(BloodmetalShard),
                new ItemDefinition(BloodmetalShard),
                new ItemDefinition(BloodmetalChunk),
                new ItemDefinition(CrimsonIchor),
                new ItemDefinition(BonebirdChest),
                new ItemDefinition(BonebirdHands),
                new ItemDefinition(BonebirdLegs),
                new ItemDefinition(BloodmetalScythe),
                new ItemDefinition(BloodmetalChunk),

                new ItemDefinition(FaceSlasher, 1, true),
                new ItemDefinition(DrainedShellChest),
                new ItemDefinition(DrainedShellHands),
                new ItemDefinition(DrainedShellLegs),
                new ItemDefinition(BurstLantern, 1, true),
                new ItemDefinition(Bowdaggers, 1, true),
                new ItemDefinition(BreathdewShard, 3),
                new ItemDefinition(BreathdewShard, 1),
                new ItemDefinition(VolatileEye, 3),
                new ItemDefinition(VolatileEye, 2),
                new ItemDefinition(VolatileBlob, 10),
                new ItemDefinition(BrokenHusk, 2),
                new ItemDefinition(BrokenHusk, 2),
                new ItemDefinition(AwakeningGasp),
                new ItemDefinition(ThirstingSand, 3),
                new ItemDefinition(ThirstingSand, 1),
                new ItemDefinition(UrnOfVolatileEyes, 2),
                new ItemDefinition(UrnOfVolatileEyes, 3),
                new ItemDefinition(WholeHusk),
                new ItemDefinition(CrimsonIchor),
                new ItemDefinition(MotleyPearl),
                new ItemDefinition(ArdentSand, 3),
                new ItemDefinition(BloodmetalShard),
                new ItemDefinition(BloodmetalShard),
                new ItemDefinition(BloodmetalShard),
                new ItemDefinition(BloodmetalShard),
                new ItemDefinition(BloodmetalChunk),
                new ItemDefinition(BloodmetalSplinter),
                new ItemDefinition(BloodmetalSplinter),
                new ItemDefinition(BloodmetalSplinter),

                new ItemDefinition(PearlplateChest),
                new ItemDefinition(PearlplateHands),
                new ItemDefinition(PearlplateLegs),
                new ItemDefinition(SicklebackChest),
                new ItemDefinition(SicklebackHands),
                new ItemDefinition(SicklebackLegs),
                new ItemDefinition(HornedTravelerChest),
                new ItemDefinition(HornedTravelerHands),
                new ItemDefinition(HornedTravelerLegs),
                new ItemDefinition(Spinesword, 1, true),
                new ItemDefinition(Spineaxe, 1, true),
                new ItemDefinition(CentipedeWhip, 1, true),
                new ItemDefinition(WanebloodChest),
                new ItemDefinition(WanebloodHands),
                new ItemDefinition(WanebloodLegs),
                new ItemDefinition(BloomingChest),
                new ItemDefinition(BloomingHands),
                new ItemDefinition(BloomingLegs),
                new ItemDefinition(MarrowChest),
                new ItemDefinition(MarrowHands),
                new ItemDefinition(MarrowLegs),
                new ItemDefinition(ToothFists, 1, true),
                new ItemDefinition(MotleyPearl, 1),
                new ItemDefinition(MotleyPearl, 1),
                new ItemDefinition(MotleyPearl, 1),
                new ItemDefinition(MotleyPearl, 1),
                new ItemDefinition(ClutchingRoot, 2),
                new ItemDefinition(ClutchingRoot, 2),
                new ItemDefinition(ClutchingRoot, 3),
                new ItemDefinition(ClutchingRoot, 3),
                new ItemDefinition(ClutchingRoot, 4),
                new ItemDefinition(ClutchingRoot, 5),
                new ItemDefinition(BreathdewFragment, 1),
                new ItemDefinition(BreathdewFragment, 1),
                new ItemDefinition(BreathdewShard, 1),
                new ItemDefinition(BreathdewShard, 2),
                new ItemDefinition(BreathdewDroplet, 1),
                new ItemDefinition(BreathdewDroplet, 1),
                new ItemDefinition(BreathdewDroplet, 1),
                new ItemDefinition(UrnOfVolatileEyes, 1),
                new ItemDefinition(UrnOfVolatileEyes, 1),
                new ItemDefinition(UrnOfVolatileEyes, 2),
                new ItemDefinition(UrnOfVolatileEyes, 2),
                new ItemDefinition(UrnOfVolatileEyes, 2),
                new ItemDefinition(UrnOfVolatileEyes, 2),
                new ItemDefinition(UrnOfVolatileEyes, 5),
                new ItemDefinition(ShardField, 6),
                new ItemDefinition(PillarFragment, 1),
                new ItemDefinition(PillarFragment, 2),
                new ItemDefinition(PillarFragment, 3),
                new ItemDefinition(AwakeningGasp, 1),
                new ItemDefinition(AwakeningGasp, 2),
                new ItemDefinition(AwakeningGasp, 2),
                new ItemDefinition(AwakeningGasp, 3),
                new ItemDefinition(AwakeningGasp, 3),
                new ItemDefinition(AwakeningGasp, 3),
                new ItemDefinition(CrimsonIchor, 1),
                new ItemDefinition(CrimsonIchor, 1),
                new ItemDefinition(LevolamDust, 1),
                new ItemDefinition(LevolamDust, 2),
                new ItemDefinition(LevolamDust, 3),
                new ItemDefinition(LevolamDust, 5),
                new ItemDefinition(WholeHusk, 1),
                new ItemDefinition(WholeHusk, 2),
                new ItemDefinition(WholeHusk, 3),
                new ItemDefinition(StrandOfTheChild),
                new ItemDefinition(FullyFormedHusk, 1),
                new ItemDefinition(FullyFormedHusk, 1),
                new ItemDefinition(FullyFormedHusk, 1),
                new ItemDefinition(UnformedBody, 1),
                new ItemDefinition(UnformedBody, 1),
                new ItemDefinition(UnformedTorso),
                new ItemDefinition(NeonatalLevolam),
                new ItemDefinition(FetalPearl),
                new ItemDefinition(BloodmetalSplinter),
                new ItemDefinition(BloodmetalSplinter),
                new ItemDefinition(BloodmetalSplinter),
                new ItemDefinition(BloodmetalSplinter),
                new ItemDefinition(BloodmetalSplinter),
                new ItemDefinition(BloodmetalShard),
                new ItemDefinition(BloodmetalShard),
                new ItemDefinition(BloodmetalShard),
                new ItemDefinition(BloodmetalShard),
                new ItemDefinition(BloodmetalShard),
                new ItemDefinition(BloodmetalShard),
                new ItemDefinition(BloodmetalShard),
                new ItemDefinition(BloodmetalChunk),
                new ItemDefinition(BloodmetalChunk),
                new ItemDefinition(BloodmetalChunk),
                new ItemDefinition(BloodmetalChunk),
                new ItemDefinition(BloodmetalChunk),
                new ItemDefinition(BloodmetalChunk),
                new ItemDefinition(BloodmetalChunk),
                new ItemDefinition(BloodmetalChunk),
                new ItemDefinition(BloodmetalChunk),
                new ItemDefinition(BloodmetalChunk),
                new ItemDefinition(BloodmetalChunk),

                new ItemDefinition(PryingSickles, 1, true),
                new ItemDefinition(SearingSickle, 1, true),
                new ItemDefinition(ChiselNails, 1, true),
                new ItemDefinition(CelebrationChest),
                new ItemDefinition(CelebrationHands),
                new ItemDefinition(CelebrationLegs),
                new ItemDefinition(FormalCodaChest),
                new ItemDefinition(FormalCodaHands),
                new ItemDefinition(FormalCodaLegs),
                new ItemDefinition(AdeptEmbroiderChest),
                new ItemDefinition(AdeptEmbroiderHands),
                new ItemDefinition(AdeptEmbroiderLegs),
                new ItemDefinition(MotleyPearl, 3),
                new ItemDefinition(MotleyPearl, 1),
                new ItemDefinition(MotleyPearl, 1),
                new ItemDefinition(MotleyPearl, 1),
                new ItemDefinition(MotleyPearl, 1),
                new ItemDefinition(MotleyPearl, 1),
                new ItemDefinition(MotleyPearl, 1),
                new ItemDefinition(MotleyPearl, 1),
                new ItemDefinition(MotleyPearl, 1),
                new ItemDefinition(VolatileEye, 2),
                new ItemDefinition(VolatileEye, 3),
                new ItemDefinition(VolatileEye, 3),
                new ItemDefinition(VolatileEye, 5),
                new ItemDefinition(VolatileBlob, 3),
                new ItemDefinition(VolatileBlob, 3),
                new ItemDefinition(VolatileBlob, 5),
                new ItemDefinition(UrnOfVolatileEyes, 1),
                new ItemDefinition(UrnOfVolatileEyes, 2),
                new ItemDefinition(AwakeningGasp, 2),
                new ItemDefinition(AwakeningGasp, 3),
                new ItemDefinition(AwakeningGasp, 3),
                new ItemDefinition(AwakeningGasp, 6),
                new ItemDefinition(AwakeningGasp, 8),
                new ItemDefinition(LivingFlesh, 3),
                new ItemDefinition(LivingFlesh, 1),
                new ItemDefinition(LivingFlesh, 1),
                new ItemDefinition(LivingFlesh, 1),
                new ItemDefinition(LivingFlesh, 1),
                new ItemDefinition(LivingFlesh, 2),
                new ItemDefinition(LivingFlesh, 2),
                new ItemDefinition(LivingFlesh, 2),
                new ItemDefinition(LivingFlesh, 2),
                new ItemDefinition(LivingFlesh, 2),
                new ItemDefinition(LivingFlesh, 2),
                new ItemDefinition(LivingFlesh, 2),
                new ItemDefinition(Rib, 2),
                new ItemDefinition(Rib, 3),
                new ItemDefinition(PillarFragment, 2),
                new ItemDefinition(PillarFragment, 3),
                new ItemDefinition(PillarFragment, 3),
                new ItemDefinition(PillarFragment, 5),
                new ItemDefinition(BreathdewFragment, 3),
                new ItemDefinition(BreathdewDroplet),
                new ItemDefinition(YonsBrokenTorso),
                new ItemDefinition(UnformedTorso, 1),
                new ItemDefinition(UnformedTorso, 1),
                new ItemDefinition(UnformedTorso, 1),
                new ItemDefinition(UnformedTorso, 1),
                new ItemDefinition(UnformedTorso, 1),
                new ItemDefinition(UnformedTorso, 1),
                new ItemDefinition(UnformedHead, 1),
                new ItemDefinition(UnformedHead, 1),
                new ItemDefinition(UnformedHead, 1),
                new ItemDefinition(UnformedHead, 1),
                new ItemDefinition(UnformedBody),
                new ItemDefinition(FullyFormedHusk),
                new ItemDefinition(UnformedHand, 1),
                new ItemDefinition(UnformedHand, 1),
                new ItemDefinition(UnformedHand, 1),
                new ItemDefinition(UnformedHand, 1),
                new ItemDefinition(ThirstingSand),
                new ItemDefinition(LivingRock, 1),
                new ItemDefinition(LivingRock, 2),
                new ItemDefinition(LivingRock, 3),
                new ItemDefinition(ShardField, 2),
                new ItemDefinition(ShardField, 2),
                new ItemDefinition(ShardField, 3),
                new ItemDefinition(ShardField, 3),
                new ItemDefinition(ShardField, 3),
                new ItemDefinition(ClutchingRoot, 2),
                new ItemDefinition(ClutchingRoot, 2),
                new ItemDefinition(ClutchingRoot, 3),
                new ItemDefinition(CharcoalRoot, 3),
                new ItemDefinition(CrimsonIchor),
                new ItemDefinition(LevolamDust, 1),
                new ItemDefinition(LevolamDust, 1),
                new ItemDefinition(LevolamDust, 1),
                new ItemDefinition(LevolamDust, 1),
                new ItemDefinition(ArdentSand, 3),
                new ItemDefinition(BloodmetalSplinter),
                new ItemDefinition(BloodmetalSplinter),
                new ItemDefinition(BloodmetalSplinter),
                new ItemDefinition(BloodmetalShard),
                new ItemDefinition(BloodmetalShard),
                new ItemDefinition(BloodmetalShard),
                new ItemDefinition(BloodmetalShard),
                new ItemDefinition(BloodmetalShard),
                new ItemDefinition(BloodmetalShard),
                new ItemDefinition(BloodmetalShard),
                new ItemDefinition(BloodmetalShard),
                new ItemDefinition(BloodmetalShard),
                new ItemDefinition(BloodmetalShard),
                new ItemDefinition(BloodmetalShard),
                new ItemDefinition(BloodmetalChunk),
                new ItemDefinition(BloodmetalChunk),
                new ItemDefinition(BloodmetalChunk),
                new ItemDefinition(BloodmetalChunk),
                new ItemDefinition(BloodmetalChunk),
                new ItemDefinition(BloodmetalChunk),
                new ItemDefinition(BloodmetalChunk),

                new ItemDefinition(MotleySwords, 1, true),
                new ItemDefinition(PetalgemChest),
                new ItemDefinition(PetalgemHands),
                new ItemDefinition(PetalgemLegs),
                new ItemDefinition(PillarFragment, 5),
                new ItemDefinition(BreathdewFragment, 1),
                new ItemDefinition(BreathdewFragment, 2),
                new ItemDefinition(BreathdewFragment, 3),
                new ItemDefinition(BreathdewDroplet, 2),
                new ItemDefinition(BreathdewDroplet, 1),
                new ItemDefinition(BreathdewDroplet, 1),
                new ItemDefinition(BreathdewDroplet, 1),
                new ItemDefinition(BreathdewShard, 2),
                new ItemDefinition(BreathdewShard, 2),
                new ItemDefinition(BreathdewShard, 3),
                new ItemDefinition(AwakeningGasp, 4),
                new ItemDefinition(AwakeningGasp, 3),
                new ItemDefinition(AwakeningGasp, 3),
                new ItemDefinition(AwakeningGasp, 3),
                new ItemDefinition(LivingRock, 2),
                new ItemDefinition(LivingRock, 2),
                new ItemDefinition(UrnOfVolatileEyes, 3),
                new ItemDefinition(MotleyPearl, 1),
                new ItemDefinition(MotleyPearl, 1),
                new ItemDefinition(MotleyPearl, 1),
                new ItemDefinition(MotleyPearl, 1),
                new ItemDefinition(MotleyPearl, 1),
                new ItemDefinition(UnformedBody, 1),
                new ItemDefinition(UnformedBody, 1),
                new ItemDefinition(UnformedBody, 1),
                new ItemDefinition(UnformedBody, 1),
                new ItemDefinition(FullyFormedHusk),
                new ItemDefinition(ClutchingRoot, 1),
                new ItemDefinition(ClutchingRoot, 1),
                new ItemDefinition(ClutchingRoot, 3),
                new ItemDefinition(ClutchingRoot, 3),
                new ItemDefinition(ClutchingRoot, 5),
                new ItemDefinition(LevolamDust, 1),
                new ItemDefinition(LevolamDust, 2),
                new ItemDefinition(CrimsonIchor),
                new ItemDefinition(ShardField, 2),
                new ItemDefinition(ShardField, 3),
                new ItemDefinition(BloodmetalChunk),
                new ItemDefinition(BloodmetalChunk),
                new ItemDefinition(BloodmetalChunk),
                new ItemDefinition(BloodmetalChunk),
                new ItemDefinition(BloodmetalChunk),
                new ItemDefinition(BloodmetalChunk),
                new ItemDefinition(BloodmetalSplinter),
                new ItemDefinition(BloodmetalShard),
                new ItemDefinition(BloodmetalShard),
                new ItemDefinition(BloodmetalShard),
                new ItemDefinition(BloodmetalShard),

                new ItemDefinition(ServantNeedle, 1, true),
                new ItemDefinition(ShapelyGreatsword, 1, true),
                new ItemDefinition(WeatheredStitcherChest),
                new ItemDefinition(WeatheredStitcherHands),
                new ItemDefinition(WeatheredStitcherLegs),
                new ItemDefinition(HuskrootChest),
                new ItemDefinition(HuskrootHands),
                new ItemDefinition(HuskrootLegs),
                new ItemDefinition(PillarFragment, 2),
                new ItemDefinition(LivingRock, 3),
                new ItemDefinition(LivingRock, 2),
                new ItemDefinition(LivingRock, 1),
                new ItemDefinition(LivingRock, 1),
                new ItemDefinition(LivingRock, 1),
                new ItemDefinition(MotleyPearl, 1),
                new ItemDefinition(MotleyPearl, 1),
                new ItemDefinition(MotleyPearl, 1),
                new ItemDefinition(MotleyPearl, 1),
                new ItemDefinition(CharcoalRoot, 2),
                new ItemDefinition(LevolamDust, 2),
                new ItemDefinition(ClutchingRoot, 2),
                new ItemDefinition(ClutchingRoot, 2),
                new ItemDefinition(ClutchingRoot, 5),
                new ItemDefinition(LivingFlesh, 1),
                new ItemDefinition(LivingFlesh, 1),
                new ItemDefinition(ShardField),
                new ItemDefinition(UnformedTorso, 1),
                new ItemDefinition(UnformedTorso, 1),
                new ItemDefinition(BreathdewShard, 1),
                new ItemDefinition(BloodmetalSplinter),
                new ItemDefinition(BloodmetalShard),
                new ItemDefinition(BloodmetalShard),
                new ItemDefinition(BloodmetalChunk),
                new ItemDefinition(BloodmetalChunk),

                new ItemDefinition(BreathdewShard, 1),
                new ItemDefinition(BreathdewShard, 1),
                new ItemDefinition(CrimsonIchor, 1),
                new ItemDefinition(CrimsonIchor, 1),
                new ItemDefinition(FullyFormedHusk),
                new ItemDefinition(LevolamDust),
                new ItemDefinition(UnformedHead, 1),
                new ItemDefinition(UnformedHead, 1),
                new ItemDefinition(UnformedHead, 1),
                new ItemDefinition(UnformedHead, 1),
                new ItemDefinition(UnformedHead, 1),
                new ItemDefinition(UnformedHead, 1),
                new ItemDefinition(UnformedHead, 1),

                new ItemDefinition(BreathdewDroplet, 2),
                new ItemDefinition(BreathdewDroplet, 2),
                new ItemDefinition(BreathdewDroplet, 1),
                new ItemDefinition(BreathdewDroplet, 1),
                new ItemDefinition(BreathdewFragment),
                new ItemDefinition(CrimsonIchor),
                new ItemDefinition(LivingFlesh, 5)
            };

            foreach (var item in itemsToAdd)
            {
                itemPool.Add(itemPool.Count, item);
            }
        }
    }
}