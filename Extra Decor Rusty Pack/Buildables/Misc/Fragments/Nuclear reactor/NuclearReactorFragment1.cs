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
    public static class BuildableNuclearReactorFragment1
    {
        public static PrefabInfo Info { get; } = PrefabInfo.WithTechType("BuildableNuclearReactorFragment1", "Nuclear Reactor Fragment 1", "Nuclear reactor fragment from Aurora's wreckages. Please return to the Alterra Corporation immediately.")
            .WithIcon(SpriteManager.Get(TechType.Cyclops));

        public static void Register()
        {
            float PlaceDistance = 10;
            float MinPlaceDistance = 2;
            float MaxPlaceDistance = 20;
            CustomPrefab NuclearReactorFragmentPrefab = new CustomPrefab(Info);
            CloneTemplate NuclearReactorFragmentClone = new CloneTemplate(Info, "403b8d2f-b009-483d-8358-bfcde62daa42");

            NuclearReactorFragmentClone.ModifyPrefab += obj =>
            {
                ConstructableFlags constructableFlagsInsideOutside = ConstructableFlags.Outside | ConstructableFlags.Inside | ConstructableFlags.Rotatable | ConstructableFlags.Ground | ConstructableFlags.AllowedOnConstructable;

                GameObject NuclearReactorFragmentModel = obj.transform.Find("Nuclear_reactor_damaged_01").gameObject;

                Constructable NuclearReactorFragmentConstructable = PrefabUtils.AddConstructable(obj, Info.TechType, constructableFlagsInsideOutside, NuclearReactorFragmentModel);
                NuclearReactorFragmentConstructable.placeDefaultDistance = PlaceDistance;
                NuclearReactorFragmentConstructable.placeMinDistance = MinPlaceDistance;
                NuclearReactorFragmentConstructable.placeMaxDistance = MaxPlaceDistance;
            };

            NuclearReactorFragmentPrefab.SetGameObject(NuclearReactorFragmentClone);
            NuclearReactorFragmentPrefab.SetPdaGroupCategory(TechGroup.ExteriorModules, TechCategory.ExteriorModule);

            NuclearReactorFragmentPrefab.SetRecipe(new RecipeData(
                new Ingredient(TechType.Titanium, 2)
                ));

            NuclearReactorFragmentPrefab.Register();
        }
    }
}
