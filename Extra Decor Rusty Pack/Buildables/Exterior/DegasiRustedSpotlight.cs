using BepInEx;
using Nautilus.Crafting;
using Nautilus.Assets;
using Nautilus.Assets.Gadgets;
using Nautilus.Utility;
using UnityEngine;
using Nautilus.Assets.PrefabTemplates;
using static CraftData;

namespace Extra_Decor_Rusty_Pack.Buildables.Exterior
{
    public static class BuildableDegasiRustedSpotlight
    {
        public static PrefabInfo Info { get; } = PrefabInfo.WithTechType("BuildableDegasiRustedSpotlight", "Degasi Rusted Spotlight", "Rusted spotlight found on the degasi bases.")
            .WithIcon(SpriteManager.Get(TechType.Spotlight));

        public static void Register()
        {
            float PlaceDistance = 10;
            float MinPlaceDistance = 5;
            float MaxPlaceDistance = 20;
            CustomPrefab DegasiRustedSpotlightPrefab = new CustomPrefab(Info);
            CloneTemplate DegasiRustedSpotlightClone = new CloneTemplate(Info, "0e394d55-da8c-4b3e-b038-979477ce77c1");

            DegasiRustedSpotlightClone.ModifyPrefab += obj =>
            {
                ConstructableFlags constructableFlagsInsideOutside = ConstructableFlags.Outside | ConstructableFlags.Inside | ConstructableFlags.Rotatable | ConstructableFlags.Ground | ConstructableFlags.AllowedOnConstructable;

                GameObject DegasiRustedSpotlightModel = obj.transform.Find("BaseCell").Find("Spotlight_rusted").gameObject;

                Constructable DegasiRustedSpotlightConstructable = PrefabUtils.AddConstructable(obj, Info.TechType, constructableFlagsInsideOutside, DegasiRustedSpotlightModel);
                DegasiRustedSpotlightConstructable.placeDefaultDistance = PlaceDistance;
                DegasiRustedSpotlightConstructable.placeMinDistance = MinPlaceDistance;
                DegasiRustedSpotlightConstructable.placeMaxDistance = MaxPlaceDistance;
            };

            DegasiRustedSpotlightPrefab.SetGameObject(DegasiRustedSpotlightClone);
            DegasiRustedSpotlightPrefab.SetPdaGroupCategory(TechGroup.ExteriorModules, TechCategory.ExteriorModule);

            DegasiRustedSpotlightPrefab.SetRecipe(new RecipeData(
                new Ingredient(TechType.Glass, 1), 
                new Ingredient(TechType.Titanium, 2) 
                ));

            DegasiRustedSpotlightPrefab.Register();
        }
    }
}
