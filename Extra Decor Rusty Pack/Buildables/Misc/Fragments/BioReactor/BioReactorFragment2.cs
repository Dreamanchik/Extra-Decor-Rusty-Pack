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
    public static class BuildableBioReactorFragment2
    {
        public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static string iconPath = Path.Combine(modFolder, "Assets", "Fragments", "Bioreactor", "Bioreactor2.png");
        public static PrefabInfo Info { get; } = PrefabInfo.WithTechType("BuildableBioReactorFragment2", "Bioreactor Fragment 2", "Bioreactor fragment from Aurora's wreckages. Please return to the Alterra Corporation immediately.")
            .WithIcon(ImageUtils.LoadSpriteFromFile(iconPath));

        public static void Register()
        {
            float PlaceDistance = 10;
            float MinPlaceDistance = 2;
            float MaxPlaceDistance = 20;
            CustomPrefab BioReactorFragmentPrefab = new CustomPrefab(Info);
            CloneTemplate BioReactorFragmentClone = new CloneTemplate(Info, "db2df7f8-db1a-4210-8ca0-73531b93b889");

            BioReactorFragmentClone.ModifyPrefab += obj =>
            {
                ConstructableFlags constructableFlagsInsideOutside = ConstructableFlags.Outside | ConstructableFlags.Inside | ConstructableFlags.Rotatable | ConstructableFlags.Ground | ConstructableFlags.AllowedOnConstructable;

                GameObject BioReactorFragmentModel = obj.transform.Find("Bio_reactor_damaged_02").gameObject;

                Constructable BioReactorFragmentConstructable = PrefabUtils.AddConstructable(obj, Info.TechType, constructableFlagsInsideOutside, BioReactorFragmentModel);
                BioReactorFragmentConstructable.placeDefaultDistance = PlaceDistance;
                BioReactorFragmentConstructable.placeMinDistance = MinPlaceDistance;
                BioReactorFragmentConstructable.placeMaxDistance = MaxPlaceDistance;
                BioReactorFragmentConstructable.rotationEnabled = true;
            };

            BioReactorFragmentPrefab.SetGameObject(BioReactorFragmentClone);
            BioReactorFragmentPrefab.SetPdaGroupCategory(TechGroup.ExteriorModules, TechCategory.ExteriorModule);

            BioReactorFragmentPrefab.SetRecipe(new RecipeData(
                new Ingredient(TechType.Titanium, 2)
                ));

            BioReactorFragmentPrefab.Register();
        }
    }
}
