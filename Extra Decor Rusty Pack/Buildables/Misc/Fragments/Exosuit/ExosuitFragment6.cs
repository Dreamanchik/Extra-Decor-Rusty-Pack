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
    public static class BuildableExosuitFragment6
    {
        public static PrefabInfo Info { get; } = PrefabInfo.WithTechType("BuildableExosuitFragment6", "Exosuit Fragment 6", "Exosuit fragment from Aurora's wreckages. Please return to the Alterra Corporation immediately.")
            .WithIcon(SpriteManager.Get(TechType.Cyclops));

        public static void Register()
        {
            float PlaceDistance = 10;
            float MinPlaceDistance = 2;
            float MaxPlaceDistance = 20;
            CustomPrefab ExosuitFragmentPrefab = new CustomPrefab(Info);
            CloneTemplate ExosuitFragmentClone = new CloneTemplate(Info, "071cee67-bcac-486c-acd9-a4413221eee3");

            ExosuitFragmentClone.ModifyPrefab += obj =>
            {
                ConstructableFlags constructableFlagsInsideOutside = ConstructableFlags.Outside | ConstructableFlags.Inside | ConstructableFlags.Rotatable | ConstructableFlags.Ground | ConstructableFlags.AllowedOnConstructable;

                GameObject ExosuitFragmentModel = obj.transform.Find("exosuit_damaged_06").gameObject;

                Constructable ExosuitFragmentConstructable = PrefabUtils.AddConstructable(obj, Info.TechType, constructableFlagsInsideOutside, ExosuitFragmentModel);
                ExosuitFragmentConstructable.placeDefaultDistance = PlaceDistance;
                ExosuitFragmentConstructable.placeMinDistance = MinPlaceDistance;
                ExosuitFragmentConstructable.placeMaxDistance = MaxPlaceDistance;
            };

            ExosuitFragmentPrefab.SetGameObject(ExosuitFragmentClone);
            ExosuitFragmentPrefab.SetPdaGroupCategory(TechGroup.ExteriorModules, TechCategory.ExteriorModule);

            ExosuitFragmentPrefab.SetRecipe(new RecipeData(
                new Ingredient(TechType.Titanium, 2)
                ));

            ExosuitFragmentPrefab.Register();
        }
    }
}
