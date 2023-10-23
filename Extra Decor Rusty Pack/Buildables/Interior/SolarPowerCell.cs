using BepInEx;
using Nautilus.Crafting;
using Nautilus.Assets;
using Nautilus.Assets.Gadgets;
using Nautilus.Utility;
using UnityEngine;
using Nautilus.Assets.PrefabTemplates;
using static CraftData;

namespace Extra_Decor_Rusty_Pack.Buildables.Interior
{
    public static class BuildableSolarPowerCell
    {
        public static PrefabInfo Info { get; } = PrefabInfo.WithTechType("BuildableSolarPowerCell", "Solar Power Cell", "Solar Power Cell, useful for bases.")
            .WithIcon(SpriteManager.Get(TechType.BaseBulkhead));

        public static void Register()
        {
            float PlaceDistance = 10;
            float MinPlaceDistance = 0.5f;
            float MaxPlaceDistance = 10;
            CustomPrefab SolarPowerCellPrefab = new CustomPrefab(Info);
            CloneTemplate SolarPowerCellClone = new CloneTemplate(Info, "0cb22d0e-ba5e-4e4b-b7a7-a67931fb5e0c");

            SolarPowerCellClone.ModifyPrefab += obj =>
            {
                ConstructableFlags constructableFlagsInsideOutside = ConstructableFlags.Inside | ConstructableFlags.Rotatable | ConstructableFlags.Wall | ConstructableFlags.AllowedOnConstructable;
                GameObject SolarPowerCellModel = obj.transform.Find("model").gameObject;
                SolarPowerCellModel.transform.rotation = new Quaternion(0,0,0,0);

                Constructable SolarPowerCellConstructable = PrefabUtils.AddConstructable(obj, Info.TechType, constructableFlagsInsideOutside, SolarPowerCellModel);
                SolarPowerCellConstructable.placeDefaultDistance = PlaceDistance;
                SolarPowerCellConstructable.placeMinDistance = MinPlaceDistance;
                SolarPowerCellConstructable.placeMaxDistance = MaxPlaceDistance;
            };

            SolarPowerCellPrefab.SetGameObject(SolarPowerCellClone);
            SolarPowerCellPrefab.SetPdaGroupCategory(TechGroup.InteriorModules, TechCategory.InteriorModule);

            SolarPowerCellPrefab.SetRecipe(new RecipeData(
                new Ingredient(TechType.Titanium, 2)
                ));

            SolarPowerCellPrefab.Register();
        }
    }
}
