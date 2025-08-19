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
    public static class BuildableConstructorFragment4
    {
        public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static string iconPath = Path.Combine(modFolder, "Assets", "Fragments", "Constructor", "Constructor4.png");
        public static PrefabInfo Info { get; } = PrefabInfo.WithTechType("BuildableConstructorFragment4", "Constructor Fragment 4", "Constructor fragment from Aurora's wreckages. Please return to the Alterra Corporation immediately.")
            .WithIcon(ImageUtils.LoadSpriteFromFile(iconPath));

        public static void Register()
        {
            float PlaceDistance = 10;
            float MinPlaceDistance = 0;
            float MaxPlaceDistance = 20;
            CustomPrefab ConstructorFragmentPrefab = new CustomPrefab(Info);
            CloneTemplate ConstructorFragmentClone = new CloneTemplate(Info, "871b7a1f-1b43-487f-87af-877fb6260613");

            ConstructorFragmentClone.ModifyPrefab += obj =>
            {
                ConstructableFlags constructableFlagsInsideOutside = ConstructableFlags.Outside | ConstructableFlags.Inside | ConstructableFlags.Rotatable | ConstructableFlags.Ground | ConstructableFlags.AllowedOnConstructable;

                GameObject ConstructorFragmentModel = obj.transform.Find("model").gameObject;

                Constructable ConstructorFragmentConstructable = PrefabUtils.AddConstructable(obj, Info.TechType, constructableFlagsInsideOutside, ConstructorFragmentModel);
                ConstructorFragmentConstructable.placeDefaultDistance = PlaceDistance;
                ConstructorFragmentConstructable.placeMinDistance = MinPlaceDistance;
                ConstructorFragmentConstructable.placeMaxDistance = MaxPlaceDistance;
                ConstructorFragmentConstructable.rotationEnabled = true;
                obj.AddComponent<ImmuneToPropulsioncannon>();
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
