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
            CustomPrefab HullCrackPrefab = new CustomPrefab(Info);
            CloneTemplate HullCrackClone = new CloneTemplate(Info, "29680106-d337-46ea-a55b-5eb5fd8445f3");

            HullCrackClone.ModifyPrefab += obj =>
            {
                ConstructableFlags constructableFlagsInsideOutside = ConstructableFlags.Outside | ConstructableFlags.Inside | ConstructableFlags.Wall | ConstructableFlags.AllowedOnConstructable;

                GameObject HullCrackModel = obj.transform.Find("base_hull_crack_03").gameObject;

                Constructable HullCrackConstructable = PrefabUtils.AddConstructable(obj, Info.TechType, constructableFlagsInsideOutside, HullCrackModel);
                Vector3 Rotation = HullCrackConstructable.transform.localEulerAngles;
                Rotation.y = 90f;
                HullCrackConstructable.placeDefaultDistance = PlaceDistance;
                HullCrackConstructable.placeMinDistance = MinPlaceDistance;
                HullCrackConstructable.placeMaxDistance = MaxPlaceDistance;
            };

            HullCrackPrefab.SetGameObject(HullCrackClone);
            HullCrackPrefab.SetPdaGroupCategory(TechGroup.ExteriorModules, TechCategory.ExteriorModule);

            HullCrackPrefab.SetRecipe(new RecipeData(
                new Ingredient(TechType.Titanium, 1) 
                ));

            HullCrackPrefab.Register();
        }
    }
}
