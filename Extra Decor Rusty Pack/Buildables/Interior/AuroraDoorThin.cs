using BepInEx;
using Nautilus.Crafting;
using Nautilus.Assets;
using Nautilus.Assets.Gadgets;
using Nautilus.Utility;
using UnityEngine;
using Nautilus.Assets.PrefabTemplates;
using static CraftData;

namespace Extra_Decor_Rusty_Pack.Buildables.Interior
{
    public static class BuildableAuroraDoorThin
    {
        public static PrefabInfo Info { get; } = PrefabInfo.WithTechType("BuildableAuroraDoorThin", "Aurora Door Thin", "Door usually placed in alterra ships.")
            .WithIcon(SpriteManager.Get(TechType.BaseBulkhead));

        public static void Register()
        {
            float PlaceDistance = 10;
            float MinPlaceDistance = 0;
            float MaxPlaceDistance = 10;
            CustomPrefab AuroraDoorPrefab = new CustomPrefab(Info);
            CloneTemplate AuroraDoorClone = new CloneTemplate(Info, "32fb101b-b834-4982-a6eb-338ff2f98ea4");

            AuroraDoorClone.ModifyPrefab += obj =>
            {
                ConstructableFlags constructableFlagsInsideOutside = ConstructableFlags.Outside | ConstructableFlags.Inside | ConstructableFlags.Rotatable | ConstructableFlags.Ground | ConstructableFlags.AllowedOnConstructable;

                GameObject AuroraDoorModel = obj.transform.Find("Starship_doors_manual_01").gameObject;

                Constructable AuroraDoorConstructable = PrefabUtils.AddConstructable(obj, Info.TechType, constructableFlagsInsideOutside, AuroraDoorModel);
                Vector3 DoorScale = AuroraDoorConstructable.transform.localScale;
                DoorScale.y = 1.15f;
                DoorScale.y = 0.77f;
                AuroraDoorConstructable.placeDefaultDistance = PlaceDistance;
                AuroraDoorConstructable.placeMinDistance = MinPlaceDistance;
                AuroraDoorConstructable.placeMaxDistance = MaxPlaceDistance;
                AuroraDoorConstructable.transform.localScale = DoorScale;
            };

            AuroraDoorPrefab.SetGameObject(AuroraDoorClone);
            AuroraDoorPrefab.SetPdaGroupCategory(TechGroup.InteriorModules, TechCategory.InteriorModule);

            AuroraDoorPrefab.SetRecipe(new RecipeData(
                new Ingredient(TechType.Titanium, 2)
                ));

            AuroraDoorPrefab.Register();
        }
    }
}
