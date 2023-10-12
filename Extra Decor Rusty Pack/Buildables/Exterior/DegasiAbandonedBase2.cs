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
    public static class BuildableDegasiAbandonedBase2
    {
        public static PrefabInfo Info { get; } = PrefabInfo.WithTechType("BuildableDegasiAbandonedBase2", "Degasi Abandoned Base 2", "Unknown base that was supposedly built by the Degasi long time ago.")
            .WithIcon(SpriteManager.Get(TechType.BaseCorridorI));

        public static void Register()
        {
            float PlaceDistance = 10;
            float MinPlaceDistance = 5;
            float MaxPlaceDistance = 20;
            CustomPrefab DegasiFloatingIslandBasePrefab = new CustomPrefab(Info);
            CloneTemplate DegasiFloatingIslandBaseClone = new CloneTemplate(Info, "8f20a08c-c981-4fad-a57b-2de2106b8abf");

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
