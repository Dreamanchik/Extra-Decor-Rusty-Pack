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
    public static class BuildableHullCrack
    {
        public static PrefabInfo Info { get; } = PrefabInfo.WithTechType("BuildableHullCrack", "Hull Crack", "Hull crack replica for decorational purposes.")
            .WithIcon(SpriteManager.Get(TechType.Nickel));

        public static void Register()
        {
            float PlaceDistance = 5;
            float MinPlaceDistance = 0;
            float MaxPlaceDistance = 20;
            CustomPrefab DegasiFoundationPrefab = new CustomPrefab(Info);
            CloneTemplate DegasiFoundationClone = new CloneTemplate(Info, "29680106-d337-46ea-a55b-5eb5fd8445f3");

            DegasiFoundationClone.ModifyPrefab += obj =>
            {
                ConstructableFlags constructableFlagsInsideOutside = ConstructableFlags.Outside | ConstructableFlags.Inside | ConstructableFlags.Rotatable | ConstructableFlags.Ground | ConstructableFlags.AllowedOnConstructable;

                GameObject DegasiFoundationModel = obj.transform.Find("Base_hull_crack_03").gameObject;

                Constructable DegasiFoundationConstructable = PrefabUtils.AddConstructable(obj, Info.TechType, constructableFlagsInsideOutside, DegasiFoundationModel);
                DegasiFoundationConstructable.placeDefaultDistance = PlaceDistance;
                DegasiFoundationConstructable.placeMinDistance = MinPlaceDistance;
                DegasiFoundationConstructable.placeMaxDistance = MaxPlaceDistance;
            };

            DegasiFoundationPrefab.SetGameObject(DegasiFoundationClone);
            DegasiFoundationPrefab.SetPdaGroupCategory(TechGroup.ExteriorModules, TechCategory.ExteriorModule);

            DegasiFoundationPrefab.SetRecipe(new RecipeData(
                new Ingredient(TechType.Titanium, 1) 
                ));

            DegasiFoundationPrefab.Register();
        }
    }
}
