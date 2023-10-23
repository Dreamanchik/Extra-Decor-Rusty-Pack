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
    public static class BuildableDegasiFloatingIslandBase2
    {
        public static PrefabInfo Info { get; } = PrefabInfo.WithTechType("BuildableDegasiFloatingIslandBase2", "Degasi Floating Island Base 2", "Base built by the Degasi.")
            .WithIcon(SpriteManager.Get(TechType.BaseCorridorI));

        public static void Register()
        {
            float PlaceDistance = 10;
            float MinPlaceDistance = 5;
            float MaxPlaceDistance = 20;
            CustomPrefab DegasiFloatingIslandBasePrefab = new CustomPrefab(Info);
            CloneTemplate DegasiFloatingIslandBaseClone = new CloneTemplate(Info, "569f22e0-274d-49b0-ae5e-21ef0ce907ca");

            DegasiFloatingIslandBaseClone.ModifyPrefab += obj =>
            {
                ConstructableFlags constructableFlagsInsideOutside = ConstructableFlags.Outside | ConstructableFlags.Inside | ConstructableFlags.Rotatable | ConstructableFlags.Ground | ConstructableFlags.AllowedOnConstructable;

                GameObject DegasiFloatingIslandBaseModel = obj.transform.Find("BaseCell").gameObject;

                Constructable DegasiFloatingIslandBaseConstructable = PrefabUtils.AddConstructable(obj, Info.TechType, constructableFlagsInsideOutside, DegasiFloatingIslandBaseModel);
                Vector3 LocalPosition = DegasiFloatingIslandBaseConstructable.transform.localPosition;
                LocalPosition.y = 10f;   
                DegasiFloatingIslandBaseConstructable.placeDefaultDistance = PlaceDistance;
                DegasiFloatingIslandBaseConstructable.placeMinDistance = MinPlaceDistance;
                DegasiFloatingIslandBaseConstructable.placeMaxDistance = MaxPlaceDistance;
                DegasiFloatingIslandBaseConstructable.rotationEnabled = true;
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
