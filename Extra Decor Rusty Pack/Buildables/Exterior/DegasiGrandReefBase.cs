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
    public static class BuildableDegasiGrandReefBase
    {
        public static PrefabInfo Info { get; } = PrefabInfo.WithTechType("BuildableDegasiGrandReefBase", "Degasi Grand Reef Base", "Base built by the Degasi.")
            .WithIcon(SpriteManager.Get(TechType.BaseCorridorI));

        public static void Register()
        {
            float PlaceDistance = 10;
            float MinPlaceDistance = 5;
            float MaxPlaceDistance = 20;
            CustomPrefab DegasiGrandReefBasePrefab = new CustomPrefab(Info);
            CloneTemplate DegasiGrandReefBaseClone = new CloneTemplate(Info, "42a80cbc-d9fd-49d2-94b3-b5178024b3cb");

            DegasiGrandReefBaseClone.ModifyPrefab += obj =>
            {
                ConstructableFlags constructableFlagsInsideOutside = ConstructableFlags.Outside | ConstructableFlags.Inside | ConstructableFlags.Rotatable | ConstructableFlags.Ground | ConstructableFlags.AllowedOnConstructable;

                GameObject DegasiGrandReefBaseModel = obj.transform.Find("BaseCell").gameObject;

                Constructable DegasiGrandReefBaseConstructable = PrefabUtils.AddConstructable(obj, Info.TechType, constructableFlagsInsideOutside, DegasiGrandReefBaseModel);
                Vector3 LocalPosition = DegasiGrandReefBaseConstructable.transform.localPosition;
                LocalPosition.y = 10f;   
                DegasiGrandReefBaseConstructable.placeDefaultDistance = PlaceDistance;
                DegasiGrandReefBaseConstructable.placeMinDistance = MinPlaceDistance;
                DegasiGrandReefBaseConstructable.placeMaxDistance = MaxPlaceDistance;
            };

            DegasiGrandReefBasePrefab.SetGameObject(DegasiGrandReefBaseClone);
            DegasiGrandReefBasePrefab.SetPdaGroupCategory(TechGroup.ExteriorModules, TechCategory.ExteriorModule);

            DegasiGrandReefBasePrefab.SetRecipe(new RecipeData(
                new Ingredient(TechType.Titanium, 8) 
                ));

            DegasiGrandReefBasePrefab.Register();
        }
    }
}
