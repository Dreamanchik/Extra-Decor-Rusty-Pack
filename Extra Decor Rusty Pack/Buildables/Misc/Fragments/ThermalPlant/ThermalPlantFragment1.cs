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
    public static class BuildableThermalPlantFragment1
    {
        public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static string iconPath = Path.Combine(modFolder, "Assets", "Fragments", "ThermalPlant", "ThermalPlant1.png");
        public static PrefabInfo Info { get; } = PrefabInfo.WithTechType("BuildableThermalPlantFragment1", "Thermal Plant Fragment 1", "Thermal Plant fragment from Aurora's wreckages. Please return to the Alterra Corporation immediately.")
            .WithIcon(ImageUtils.LoadSpriteFromFile(iconPath));

        public static void Register()
        {
            float PlaceDistance = 10;
            float MinPlaceDistance = 2;
            float MaxPlaceDistance = 20;
            CustomPrefab ThermalPlantFragmentPrefab = new CustomPrefab(Info);
            CloneTemplate ThermalPlantFragmentClone = new CloneTemplate(Info, "88c4c1fa-0b52-44cb-9db5-2ef18447ae5c");

            ThermalPlantFragmentClone.ModifyPrefab += obj =>
            {
                ConstructableFlags constructableFlagsInsideOutside = ConstructableFlags.Outside | ConstructableFlags.Inside | ConstructableFlags.Rotatable | ConstructableFlags.Ground | ConstructableFlags.AllowedOnConstructable;

                GameObject ThermalPlantFragmentModel = obj.transform.Find("Thermal_reactor_damaged_01").gameObject;

                Constructable ThermalPlantFragmentConstructable = PrefabUtils.AddConstructable(obj, Info.TechType, constructableFlagsInsideOutside, ThermalPlantFragmentModel);
                ThermalPlantFragmentConstructable.placeDefaultDistance = PlaceDistance;
                ThermalPlantFragmentConstructable.placeMinDistance = MinPlaceDistance;
                ThermalPlantFragmentConstructable.placeMaxDistance = MaxPlaceDistance;
                ThermalPlantFragmentConstructable.rotationEnabled = true;
            };

            ThermalPlantFragmentPrefab.SetGameObject(ThermalPlantFragmentClone);
            ThermalPlantFragmentPrefab.SetPdaGroupCategory(TechGroup.ExteriorModules, TechCategory.ExteriorModule);

            ThermalPlantFragmentPrefab.SetRecipe(new RecipeData(
                new Ingredient(TechType.Titanium, 2)
                ));

            ThermalPlantFragmentPrefab.Register();
        }
    }
}
