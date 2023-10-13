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
    public static class BuildableAuroraDoorFrameMedium
    {
        public static PrefabInfo Info { get; } = PrefabInfo.WithTechType("BuildableAuroraDoorFrameMedium", "Aurora Door Frame Medium", "Door frame usually placed in alterra ships.")
            .WithIcon(SpriteManager.Get(TechType.BaseBulkhead));

        public static void Register()
        {
            float PlaceDistance = 10;
            float MinPlaceDistance = 0;
            float MaxPlaceDistance = 10;
            CustomPrefab AuroraDoorFramePrefab = new CustomPrefab(Info);
            CloneTemplate AuroraDoorFrameClone = new CloneTemplate(Info, "00ef794e-924a-4a84-b197-448024fc2a4c");

            AuroraDoorFrameClone.ModifyPrefab += obj =>
            {
                ConstructableFlags constructableFlagsInsideOutside = ConstructableFlags.Outside | ConstructableFlags.Inside | ConstructableFlags.Rotatable | ConstructableFlags.Ground | ConstructableFlags.AllowedOnConstructable;

                GameObject AuroraDoorFrameModel = obj.transform.Find("Doorframe").gameObject;

                Constructable AuroraDoorFrameConstructable = PrefabUtils.AddConstructable(obj, Info.TechType, constructableFlagsInsideOutside, AuroraDoorFrameModel);
                Vector3 DoorScale = AuroraDoorFrameConstructable.transform.localScale;
                DoorScale.y = 1.15f;
                AuroraDoorFrameConstructable.placeDefaultDistance = PlaceDistance;
                AuroraDoorFrameConstructable.placeMinDistance = MinPlaceDistance;
                AuroraDoorFrameConstructable.placeMaxDistance = MaxPlaceDistance;
                AuroraDoorFrameConstructable.transform.localScale = DoorScale;
            };

            AuroraDoorFramePrefab.SetGameObject(AuroraDoorFrameClone);
            AuroraDoorFramePrefab.SetPdaGroupCategory(TechGroup.InteriorModules, TechCategory.InteriorModule);

            AuroraDoorFramePrefab.SetRecipe(new RecipeData(
                new Ingredient(TechType.Titanium, 1)
                ));

            AuroraDoorFramePrefab.Register();
        }
    }
}
