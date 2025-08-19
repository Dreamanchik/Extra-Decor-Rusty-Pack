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
    public static class BuildableWorkbenchFragment2
    {
        public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static string iconPath = Path.Combine(modFolder, "Assets", "Fragments", "Workbench", "Workbench2.png");
        public static PrefabInfo Info { get; } = PrefabInfo.WithTechType("BuildableWorkbenchFragment2", "Workbench Fragment 2", "Workbench fragment from Aurora's wreckages. Please return to the Alterra Corporation immediately.")
            .WithIcon(ImageUtils.LoadSpriteFromFile(iconPath));

        public static void Register()
        {
            float PlaceDistance = 10;
            float MinPlaceDistance = 1;
            float MaxPlaceDistance = 20;
            CustomPrefab WorkbenchFragmentPrefab = new CustomPrefab(Info);
            CloneTemplate WorkbenchFragmentClone = new CloneTemplate(Info, "4cc70e47-a05f-4e27-9920-9a6d0e90083d");

            WorkbenchFragmentClone.ModifyPrefab += obj =>
            {
                ConstructableFlags constructableFlagsInsideOutside = ConstructableFlags.Outside | ConstructableFlags.Inside | ConstructableFlags.Rotatable | ConstructableFlags.Ground | ConstructableFlags.AllowedOnConstructable;

                GameObject WorkbenchFragmentModel = obj.transform.Find("model").gameObject;

                Constructable WorkbenchFragmentConstructable = PrefabUtils.AddConstructable(obj, Info.TechType, constructableFlagsInsideOutside, WorkbenchFragmentModel);
                WorkbenchFragmentConstructable.placeDefaultDistance = PlaceDistance;
                WorkbenchFragmentConstructable.placeMinDistance = MinPlaceDistance;
                WorkbenchFragmentConstructable.placeMaxDistance = MaxPlaceDistance;
                WorkbenchFragmentConstructable.rotationEnabled = true;
                obj.AddComponent<ImmuneToPropulsioncannon>();
            };

            WorkbenchFragmentPrefab.SetGameObject(WorkbenchFragmentClone);
            WorkbenchFragmentPrefab.SetPdaGroupCategory(TechGroup.ExteriorModules, TechCategory.ExteriorModule);

            WorkbenchFragmentPrefab.SetRecipe(new RecipeData(
                new Ingredient(TechType.Titanium, 2)
                ));

            WorkbenchFragmentPrefab.Register();
        }
    }
}
