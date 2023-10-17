using BepInEx;
using Nautilus.Crafting;
using Nautilus.Assets;
using Nautilus.Assets.Gadgets;
using Nautilus.Utility;
using UnityEngine;
using Nautilus.Assets.PrefabTemplates;
using static CraftData;

namespace Extra_Decor_Rusty_Pack.Buildables.Misc.Fragments.Cyclops
{
    public static class BuildableStasisRifleFragment
    {
        public static PrefabInfo Info { get; } = PrefabInfo.WithTechType("BuildableStasisRifleFragment", "Stasis Rifle Fragment", "Stasis rifle fragment from Aurora's wreckages. Please return to the Alterra Corporation immediately.")
            .WithIcon(SpriteManager.Get(TechType.Cyclops));

        public static void Register()
        {
            float PlaceDistance = 10;
            float MinPlaceDistance = 0;
            float MaxPlaceDistance = 20;
            CustomPrefab StasisRifleFragmentPrefab = new CustomPrefab(Info);
            CloneTemplate StasisRifleFragmentClone = new CloneTemplate(Info, "57c48cfa-867d-4722-8e51-5bf4fee0d9e3");

            StasisRifleFragmentClone.ModifyPrefab += obj =>
            {
                ConstructableFlags constructableFlagsInsideOutside = ConstructableFlags.Outside | ConstructableFlags.Inside | ConstructableFlags.Rotatable | ConstructableFlags.Ground | ConstructableFlags.AllowedOnConstructable;

                GameObject StasisRifleFragmentModel = obj.transform.Find("model").gameObject;

                Constructable StasisRifleFragmentConstructable = PrefabUtils.AddConstructable(obj, Info.TechType, constructableFlagsInsideOutside, StasisRifleFragmentModel);
                StasisRifleFragmentConstructable.placeDefaultDistance = PlaceDistance;
                StasisRifleFragmentConstructable.placeMinDistance = MinPlaceDistance;
                StasisRifleFragmentConstructable.placeMaxDistance = MaxPlaceDistance;
            };

            StasisRifleFragmentPrefab.SetGameObject(StasisRifleFragmentClone);
            StasisRifleFragmentPrefab.SetPdaGroupCategory(TechGroup.ExteriorModules, TechCategory.ExteriorModule);

            StasisRifleFragmentPrefab.SetRecipe(new RecipeData(
                new Ingredient(TechType.Titanium, 2)
                ));

            StasisRifleFragmentPrefab.Register();
        }
    }
}
