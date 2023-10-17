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
    public static class BuildableConstructorFragment3
    {
        public static PrefabInfo Info { get; } = PrefabInfo.WithTechType("BuildableConstructorFragment3", "Constructor Fragment 3", "Constructor fragment from Aurora's wreckages. Please return to the Alterra Corporation immediately.")
            .WithIcon(SpriteManager.Get(TechType.Cyclops));

        public static void Register()
        {
            float PlaceDistance = 10;
            float MinPlaceDistance = 0;
            float MaxPlaceDistance = 20;
            CustomPrefab ConstructorFragmentPrefab = new CustomPrefab(Info);
            CloneTemplate ConstructorFragmentClone = new CloneTemplate(Info, "f60b5fb5-9430-4a1d-9978-390cd4685132");

            ConstructorFragmentClone.ModifyPrefab += obj =>
            {
                ConstructableFlags constructableFlagsInsideOutside = ConstructableFlags.Outside | ConstructableFlags.Inside | ConstructableFlags.Rotatable | ConstructableFlags.Ground | ConstructableFlags.AllowedOnConstructable;

                GameObject ConstructorFragmentModel = obj.transform.Find("model").gameObject;

                Constructable ConstructorFragmentConstructable = PrefabUtils.AddConstructable(obj, Info.TechType, constructableFlagsInsideOutside, ConstructorFragmentModel);
                ConstructorFragmentConstructable.placeDefaultDistance = PlaceDistance;
                ConstructorFragmentConstructable.placeMinDistance = MinPlaceDistance;
                ConstructorFragmentConstructable.placeMaxDistance = MaxPlaceDistance;
            };

            ConstructorFragmentPrefab.SetGameObject(ConstructorFragmentClone);
            ConstructorFragmentPrefab.SetPdaGroupCategory(TechGroup.ExteriorModules, TechCategory.ExteriorModule);

            ConstructorFragmentPrefab.SetRecipe(new RecipeData(
                new Ingredient(TechType.Titanium, 2)
                ));

            ConstructorFragmentPrefab.Register();
        }
    }
}
