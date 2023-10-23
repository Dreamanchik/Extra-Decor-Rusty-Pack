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
    public static class BuildableDegasiJellyshroomBase1
    {
        public static PrefabInfo Info { get; } = PrefabInfo.WithTechType("BuildableDegasiJellyshroomBase1", "Degasi Jellyshroom Base 1", "Base built by the Degasi.")
            .WithIcon(SpriteManager.Get(TechType.BaseCorridorI));

        public static void Register()
        {
            float PlaceDistance = 10;
            float MinPlaceDistance = 5;
            float MaxPlaceDistance = 20;
            CustomPrefab DegasiJellyshroomBasePrefab = new CustomPrefab(Info);
            CloneTemplate DegasiJellyshroomBaseClone = new CloneTemplate(Info, "0e394d55-da8c-4b3e-b038-979477ce77c1");

            DegasiJellyshroomBaseClone.ModifyPrefab += obj =>
            {
                ConstructableFlags constructableFlagsInsideOutside = ConstructableFlags.Outside | ConstructableFlags.Inside | ConstructableFlags.Rotatable | ConstructableFlags.Ground | ConstructableFlags.AllowedOnConstructable;

                GameObject DegasiJellyshroomBaseModel = obj.transform.Find("BaseCell").gameObject;

                Constructable DegasiJellyshroomBaseConstructable = PrefabUtils.AddConstructable(obj, Info.TechType, constructableFlagsInsideOutside, DegasiJellyshroomBaseModel);
                Vector3 LocalPosition = DegasiJellyshroomBaseConstructable.transform.localPosition;
                LocalPosition.y = 10f;   
                DegasiJellyshroomBaseConstructable.placeDefaultDistance = PlaceDistance;
                DegasiJellyshroomBaseConstructable.placeMinDistance = MinPlaceDistance;
                DegasiJellyshroomBaseConstructable.placeMaxDistance = MaxPlaceDistance;
                DegasiJellyshroomBaseConstructable.rotationEnabled = true;
            };

            DegasiJellyshroomBasePrefab.SetGameObject(DegasiJellyshroomBaseClone);
            DegasiJellyshroomBasePrefab.SetPdaGroupCategory(TechGroup.ExteriorModules, TechCategory.ExteriorModule);

            DegasiJellyshroomBasePrefab.SetRecipe(new RecipeData(
                new Ingredient(TechType.Titanium, 4) 
                ));

            DegasiJellyshroomBasePrefab.Register();
        }
    }
}
