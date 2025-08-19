using BepInEx;
using Nautilus.Crafting;
using Nautilus.Assets;
using Nautilus.Assets.Gadgets;
using Nautilus.Utility;
using UnityEngine;
using Nautilus.Assets.PrefabTemplates;
using static CraftData;
using System.Reflection;
using System.IO;

namespace Extra_Decor_Rusty_Pack.Buildables.Misc.Fragments.Cyclops
{
    public static class BuildableNuclearReactorFragment4
    {
        public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static string iconPath = Path.Combine(modFolder, "Assets", "Fragments", "NuclearReactor", "NuclearReactor4.png");
        public static PrefabInfo Info { get; } = PrefabInfo.WithTechType("BuildableNuclearReactorFragment4", "Nuclear Reactor Fragment 4", "Nuclear reactor fragment from Aurora's wreckages. Please return to the Alterra Corporation immediately.")
            .WithIcon(ImageUtils.LoadSpriteFromFile(iconPath));

        public static void Register()
        {
            float PlaceDistance = 10;
            float MinPlaceDistance = 2;
            float MaxPlaceDistance = 20;
            CustomPrefab NuclearReactorFragmentPrefab = new CustomPrefab(Info);
            CloneTemplate NuclearReactorFragmentClone = new CloneTemplate(Info, "872b7c65-7597-4ca2-9c96-03b2405b8784");

            NuclearReactorFragmentClone.ModifyPrefab += obj =>
            {
                ConstructableFlags constructableFlagsInsideOutside = ConstructableFlags.Outside | ConstructableFlags.Inside | ConstructableFlags.Rotatable | ConstructableFlags.Ground | ConstructableFlags.AllowedOnConstructable;

                GameObject NuclearReactorFragmentModel = obj.transform.Find("Nuclear_reactor_damaged_04").gameObject;

                Constructable NuclearReactorFragmentConstructable = PrefabUtils.AddConstructable(obj, Info.TechType, constructableFlagsInsideOutside, NuclearReactorFragmentModel);
                NuclearReactorFragmentConstructable.placeDefaultDistance = PlaceDistance;
                NuclearReactorFragmentConstructable.placeMinDistance = MinPlaceDistance;
                NuclearReactorFragmentConstructable.placeMaxDistance = MaxPlaceDistance;
                NuclearReactorFragmentConstructable.rotationEnabled = true;
                obj.AddComponent<ImmuneToPropulsioncannon>();
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
