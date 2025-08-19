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
    public static class BuildableThermalPlantFragment3
    {
        public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static string iconPath = Path.Combine(modFolder, "Assets", "Fragments", "ThermalPlant", "ThermalPlant3.png");
        public static PrefabInfo Info { get; } = PrefabInfo.WithTechType("BuildableThermalPlantFragment3", "Thermal Plant Fragment 3", "Thermal Plant fragment from Aurora's wreckages. Please return to the Alterra Corporation immediately.")
            .WithIcon(ImageUtils.LoadSpriteFromFile(iconPath));

        public static void Register()
        {
            float PlaceDistance = 10;
            float MinPlaceDistance = 2;
            float MaxPlaceDistance = 20;
            CustomPrefab ThermalPlantFragmentPrefab = new CustomPrefab(Info);
            CloneTemplate ThermalPlantFragmentClone = new CloneTemplate(Info, "47c32ae8-b168-4ddf-bbae-7467038e3457");

            ThermalPlantFragmentClone.ModifyPrefab += obj =>
            {
                ConstructableFlags constructableFlagsInsideOutside = ConstructableFlags.Outside | ConstructableFlags.Inside | ConstructableFlags.Rotatable | ConstructableFlags.Ground | ConstructableFlags.AllowedOnConstructable;

                GameObject ThermalPlantFragmentModel = obj.transform.Find("Thermal_reactor_damaged_03").gameObject;

                Constructable ThermalPlantFragmentConstructable = PrefabUtils.AddConstructable(obj, Info.TechType, constructableFlagsInsideOutside, ThermalPlantFragmentModel);
                ThermalPlantFragmentConstructable.placeDefaultDistance = PlaceDistance;
                ThermalPlantFragmentConstructable.placeMinDistance = MinPlaceDistance;
                ThermalPlantFragmentConstructable.placeMaxDistance = MaxPlaceDistance;
                ThermalPlantFragmentConstructable.rotationEnabled = true;
                obj.AddComponent<ImmuneToPropulsioncannon>();
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
