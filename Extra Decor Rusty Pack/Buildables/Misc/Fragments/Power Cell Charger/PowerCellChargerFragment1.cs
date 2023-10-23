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
    public static class BuildablePowerCellChargerFragment1
    {
        public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static string iconPath = Path.Combine(modFolder, "Assets", "Fragments", "PowerCellCharger", "PowerCellCharger1.png");
        public static PrefabInfo Info { get; } = PrefabInfo.WithTechType("BuildablePowerCellChargerFragment1", "Power Cell Charger Fragment 1", "Power Cell Charger fragment from Aurora's wreckages. Please return to the Alterra Corporation immediately.")
            .WithIcon(ImageUtils.LoadSpriteFromFile(iconPath));

        public static void Register()
        {
            float PlaceDistance = 10;
            float MinPlaceDistance = 0;
            float MaxPlaceDistance = 20;
            CustomPrefab PowerCellChargerFragmentPrefab = new CustomPrefab(Info);
            CloneTemplate PowerCellChargerFragmentClone = new CloneTemplate(Info, "f41a1855-1dc1-495a-adf2-c4495fd39936");

            PowerCellChargerFragmentClone.ModifyPrefab += obj =>
            {
                ConstructableFlags constructableFlagsInsideOutside = ConstructableFlags.Outside | ConstructableFlags.Inside | ConstructableFlags.Rotatable | ConstructableFlags.Ground | ConstructableFlags.AllowedOnConstructable;

                GameObject PowerCellChargerFragmentModel = obj.transform.Find("model").gameObject;

                Constructable PowerCellChargerFragmentConstructable = PrefabUtils.AddConstructable(obj, Info.TechType, constructableFlagsInsideOutside, PowerCellChargerFragmentModel);
                PowerCellChargerFragmentConstructable.placeDefaultDistance = PlaceDistance;
                PowerCellChargerFragmentConstructable.placeMinDistance = MinPlaceDistance;
                PowerCellChargerFragmentConstructable.placeMaxDistance = MaxPlaceDistance;
                PowerCellChargerFragmentConstructable.rotationEnabled = true;
            };

            PowerCellChargerFragmentPrefab.SetGameObject(PowerCellChargerFragmentClone);
            PowerCellChargerFragmentPrefab.SetPdaGroupCategory(TechGroup.ExteriorModules, TechCategory.ExteriorModule);

            PowerCellChargerFragmentPrefab.SetRecipe(new RecipeData(
                new Ingredient(TechType.Titanium, 2)
                ));

            PowerCellChargerFragmentPrefab.Register();
        }
    }
}
