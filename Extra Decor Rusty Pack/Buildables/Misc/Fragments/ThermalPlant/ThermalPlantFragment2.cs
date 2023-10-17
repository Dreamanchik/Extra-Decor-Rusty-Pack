using BepInEx;
using Nautilus.Crafting;
using Nautilus.Assets;
using Nautilus.Assets.Gadgets;
using Nautilus.Utility;
using UnityEngine;
using Nautilus.Assets.PrefabTemplates;
using static CraftData;

namespace Extra_Decor_Rusty_Pack.Buildables.Misc.Fragments.Cyclops
{
    public static class BuildableThermalPlantFragment2
    {
        public static PrefabInfo Info { get; } = PrefabInfo.WithTechType("BuildableThermalPlantFragment2", "Thermal Plant Fragment 2", "Thermal Plant fragment from Aurora's wreckages. Please return to the Alterra Corporation immediately.")
            .WithIcon(SpriteManager.Get(TechType.Cyclops));

        public static void Register()
        {
            float PlaceDistance = 10;
            float MinPlaceDistance = 2;
            float MaxPlaceDistance = 20;
            CustomPrefab ThermalPlantFragmentPrefab = new CustomPrefab(Info);
            CloneTemplate ThermalPlantFragmentClone = new CloneTemplate(Info, "06cc39eb-af4c-4573-866a-d92e5d4c2bf1");

            ThermalPlantFragmentClone.ModifyPrefab += obj =>
            {
                ConstructableFlags constructableFlagsInsideOutside = ConstructableFlags.Outside | ConstructableFlags.Inside | ConstructableFlags.Rotatable | ConstructableFlags.Ground | ConstructableFlags.AllowedOnConstructable;

                GameObject ThermalPlantFragmentModel = obj.transform.Find("Thermal_reactor_damaged_02").gameObject;

                Constructable ThermalPlantFragmentConstructable = PrefabUtils.AddConstructable(obj, Info.TechType, constructableFlagsInsideOutside, ThermalPlantFragmentModel);
                ThermalPlantFragmentConstructable.placeDefaultDistance = PlaceDistance;
                ThermalPlantFragmentConstructable.placeMinDistance = MinPlaceDistance;
                ThermalPlantFragmentConstructable.placeMaxDistance = MaxPlaceDistance;
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
