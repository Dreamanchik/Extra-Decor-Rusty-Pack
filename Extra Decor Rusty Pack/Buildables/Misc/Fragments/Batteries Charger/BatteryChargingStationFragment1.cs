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
    public static class BuildableBatteryChargingStationFragment1
    {
        public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static string iconPath = Path.Combine(modFolder, "Assets", "Fragments", "BatteryChargingStation", "BatteryChargingStation1.png");
        public static PrefabInfo Info { get; } = PrefabInfo.WithTechType("BuildableBatteryChargingStationFragment1", "Battery Charging Station Fragment 1", "Battery charging station fragment from Aurora's wreckages. Please return to the Alterra Corporation immediately.")
            .WithIcon(ImageUtils.LoadSpriteFromFile(iconPath));

        public static void Register()
        {
            float PlaceDistance = 10;
            float MinPlaceDistance = 0;
            float MaxPlaceDistance = 20;
            CustomPrefab BatteriesChargerFragmentPrefab = new CustomPrefab(Info);
            CloneTemplate BatteriesChargerFragmentClone = new CloneTemplate(Info, "18521f9a-4b46-4994-9475-984d64993d9c");

            BatteriesChargerFragmentClone.ModifyPrefab += obj =>
            {
                ConstructableFlags constructableFlagsInsideOutside = ConstructableFlags.Outside | ConstructableFlags.Inside | ConstructableFlags.Rotatable | ConstructableFlags.Ground | ConstructableFlags.AllowedOnConstructable;

                GameObject BatteriesChargerFragmentModel = obj.transform.Find("model").gameObject;

                Constructable BatteriesChargerFragmentConstructable = PrefabUtils.AddConstructable(obj, Info.TechType, constructableFlagsInsideOutside, BatteriesChargerFragmentModel);
                BatteriesChargerFragmentConstructable.placeDefaultDistance = PlaceDistance;
                BatteriesChargerFragmentConstructable.placeMinDistance = MinPlaceDistance;
                BatteriesChargerFragmentConstructable.placeMaxDistance = MaxPlaceDistance;
                BatteriesChargerFragmentConstructable.rotationEnabled = true;
            };

            BatteriesChargerFragmentPrefab.SetGameObject(BatteriesChargerFragmentClone);
            BatteriesChargerFragmentPrefab.SetPdaGroupCategory(TechGroup.ExteriorModules, TechCategory.ExteriorModule);

            BatteriesChargerFragmentPrefab.SetRecipe(new RecipeData(
                new Ingredient(TechType.Titanium, 2)
                ));

            BatteriesChargerFragmentPrefab.Register();
        }
    }
}
