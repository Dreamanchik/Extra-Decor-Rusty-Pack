using BepInEx;
using Nautilus.Crafting;
using Nautilus.Assets;
using Nautilus.Assets.Gadgets;
using Nautilus.Utility;
using UnityEngine;
using Nautilus.Assets.PrefabTemplates;
using static CraftData;

namespace Extra_Decor_Rusty_Pack.Buildables.Exterior
{
    public static class BuildableDegasiAbandonedBase1
    {
        public static PrefabInfo Info { get; } = PrefabInfo.WithTechType("BuildableDegasiAbandonedBase1", "Degasi Abandoned Base 1", "Unknown base that was supposedly built by the Degasi long time ago.")
            .WithIcon(SpriteManager.Get(TechType.BaseCorridorI));

        public static void Register()
        {
            float PlaceDistance = 10;
            float MinPlaceDistance = 5;
            float MaxPlaceDistance = 20;
            CustomPrefab DegasiFloatingIslandBasePrefab = new CustomPrefab(Info);
            CloneTemplate DegasiFloatingIslandBaseClone = new CloneTemplate(Info, "a1e2f322-7080-48ca-8eaf-a05afff8585d");

            DegasiFloatingIslandBaseClone.ModifyPrefab += obj =>
            {
                ConstructableFlags constructableFlagsInsideOutside = ConstructableFlags.Outside | ConstructableFlags.Inside | ConstructableFlags.Rotatable | ConstructableFlags.Ground | ConstructableFlags.AllowedOnConstructable;

                GameObject DegasiFloatingIslandBaseModel = obj.transform.Find("BaseCell(Clone)").gameObject;

                Constructable DegasiFloatingIslandBaseConstructable = PrefabUtils.AddConstructable(obj, Info.TechType, constructableFlagsInsideOutside, DegasiFloatingIslandBaseModel);
                DegasiFloatingIslandBaseConstructable.placeDefaultDistance = PlaceDistance;
                DegasiFloatingIslandBaseConstructable.placeMinDistance = MinPlaceDistance;
                DegasiFloatingIslandBaseConstructable.placeMaxDistance = MaxPlaceDistance;
            };

            DegasiFloatingIslandBasePrefab.SetGameObject(DegasiFloatingIslandBaseClone);
            DegasiFloatingIslandBasePrefab.SetPdaGroupCategory(TechGroup.ExteriorModules, TechCategory.ExteriorModule);

            DegasiFloatingIslandBasePrefab.SetRecipe(new RecipeData(
                new Ingredient(TechType.Titanium, 4) 
                ));

            DegasiFloatingIslandBasePrefab.Register();
        }
    }
}
