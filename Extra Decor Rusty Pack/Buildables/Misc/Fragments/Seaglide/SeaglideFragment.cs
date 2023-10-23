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
    public static class BuildableSeaglideFragment
    {
        public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static string iconPath = Path.Combine(modFolder, "Assets", "Fragments", "Seaglide", "Seaglide.png");
        public static PrefabInfo Info { get; } = PrefabInfo.WithTechType("BuildableSeaglideFragment", "Seaglide Fragment", "Seaglide fragment from Aurora's wreckages. Please return to the Alterra Corporation immediately.")
            .WithIcon(ImageUtils.LoadSpriteFromFile(iconPath));

        public static void Register()
        {
            float PlaceDistance = 10;
            float MinPlaceDistance = 0;
            float MaxPlaceDistance = 20;
            CustomPrefab SeaglideFragmentPrefab = new CustomPrefab(Info);
            CloneTemplate SeaglideFragmentClone = new CloneTemplate(Info, "127f22a3-44cd-4341-adb8-8937317f53de");

            SeaglideFragmentClone.ModifyPrefab += obj =>
            {
                ConstructableFlags constructableFlagsInsideOutside = ConstructableFlags.Outside | ConstructableFlags.Inside | ConstructableFlags.Rotatable | ConstructableFlags.Ground | ConstructableFlags.AllowedOnConstructable;

                GameObject SeaglideFragmentModel = obj.transform.Find("model").gameObject;

                Constructable SeaglideFragmentConstructable = PrefabUtils.AddConstructable(obj, Info.TechType, constructableFlagsInsideOutside, SeaglideFragmentModel);
                SeaglideFragmentConstructable.placeDefaultDistance = PlaceDistance;
                SeaglideFragmentConstructable.placeMinDistance = MinPlaceDistance;
                SeaglideFragmentConstructable.placeMaxDistance = MaxPlaceDistance;
                SeaglideFragmentConstructable.rotationEnabled = true;
            };

            SeaglideFragmentPrefab.SetGameObject(SeaglideFragmentClone);
            SeaglideFragmentPrefab.SetPdaGroupCategory(TechGroup.ExteriorModules, TechCategory.ExteriorModule);

            SeaglideFragmentPrefab.SetRecipe(new RecipeData(
                new Ingredient(TechType.Titanium, 2)
                ));

            SeaglideFragmentPrefab.Register();
        }
    }
}
