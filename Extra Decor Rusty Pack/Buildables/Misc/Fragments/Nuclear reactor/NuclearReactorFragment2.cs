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
    public static class BuildableNuclearReactorFragment2
    {
        public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static string iconPath = Path.Combine(modFolder, "Assets", "Fragments", "NuclearReactor", "NuclearReactor2.png");
        public static PrefabInfo Info { get; } = PrefabInfo.WithTechType("BuildableNuclearReactorFragment2", "Nuclear Reactor Fragment 2", "Nuclear reactor fragment from Aurora's wreckages. Please return to the Alterra Corporation immediately.")
            .WithIcon(ImageUtils.LoadSpriteFromFile(iconPath));

        public static void Register()
        {
            float PlaceDistance = 10;
            float MinPlaceDistance = 2;
            float MaxPlaceDistance = 20;
            CustomPrefab NuclearReactorFragmentPrefab = new CustomPrefab(Info);
            CloneTemplate NuclearReactorFragmentClone = new CloneTemplate(Info, "6c58dc6b-2ae2-41ca-8c43-f953b919f7ab");

            NuclearReactorFragmentClone.ModifyPrefab += obj =>
            {
                ConstructableFlags constructableFlagsInsideOutside = ConstructableFlags.Outside | ConstructableFlags.Inside | ConstructableFlags.Rotatable | ConstructableFlags.Ground | ConstructableFlags.AllowedOnConstructable;

                GameObject NuclearReactorFragmentModel = obj.transform.Find("Nuclear_reactor_damaged_02").gameObject;

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
