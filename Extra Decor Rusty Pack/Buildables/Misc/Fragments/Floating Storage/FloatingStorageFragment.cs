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
    public static class BuildableSmallStorageFragment
    {
        public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static string iconPath = Path.Combine(modFolder, "Assets", "Fragments", "SmallStorage", "SmallStorage.png");
        public static PrefabInfo Info { get; } = PrefabInfo.WithTechType("BuildableSmallStorageFragment", "Small Floating Storage Fragment", "Small floating storage fragment from Aurora's wreckages. Please return to the Alterra Corporation immediately.")
            .WithIcon(ImageUtils.LoadSpriteFromFile(iconPath));

        public static void Register()
        {
            float PlaceDistance = 10;
            float MinPlaceDistance = 0;
            float MaxPlaceDistance = 20;
            CustomPrefab SmallStorageFragmentPrefab = new CustomPrefab(Info);
            CloneTemplate SmallStorageFragmentClone = new CloneTemplate(Info, "11fcc187-68a5-400a-85f6-09387db86265");

            SmallStorageFragmentClone.ModifyPrefab += obj =>
            {
                ConstructableFlags constructableFlagsInsideOutside = ConstructableFlags.Outside | ConstructableFlags.Inside | ConstructableFlags.Rotatable | ConstructableFlags.Ground | ConstructableFlags.AllowedOnConstructable;

                GameObject SmallStorageFragmentModel = obj.transform.Find("Floating_storage_cube_damaged").gameObject;

                Constructable SmallStorageFragmentConstructable = PrefabUtils.AddConstructable(obj, Info.TechType, constructableFlagsInsideOutside, SmallStorageFragmentModel);
                SmallStorageFragmentConstructable.placeDefaultDistance = PlaceDistance;
                SmallStorageFragmentConstructable.placeMinDistance = MinPlaceDistance;
                SmallStorageFragmentConstructable.placeMaxDistance = MaxPlaceDistance;
                SmallStorageFragmentConstructable.rotationEnabled = true;
                obj.AddComponent<ImmuneToPropulsioncannon>();
            };

            SmallStorageFragmentPrefab.SetGameObject(SmallStorageFragmentClone);
            SmallStorageFragmentPrefab.SetPdaGroupCategory(TechGroup.ExteriorModules, TechCategory.ExteriorModule);

            SmallStorageFragmentPrefab.SetRecipe(new RecipeData(
                new Ingredient(TechType.Titanium, 2)
                ));

            SmallStorageFragmentPrefab.Register();
        }
    }
}
