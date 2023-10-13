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
            CustomPrefab DegasiAbandonedBasePrefab = new CustomPrefab(Info);
            CloneTemplate DegasiAbandonedBaseClone = new CloneTemplate(Info, "8f20a08c-c981-4fad-a57b-2de2106b8abf");

            DegasiAbandonedBaseClone.ModifyPrefab += obj =>
            {
                ConstructableFlags constructableFlagsInsideOutside = ConstructableFlags.Outside | ConstructableFlags.Inside | ConstructableFlags.Rotatable | ConstructableFlags.Ground | ConstructableFlags.AllowedOnConstructable;

                GameObject DegasiAbandonedBaseModel = obj.transform.Find("BaseCell(Clone)").gameObject;

                Constructable DegasiAbandonedBaseConstructable = PrefabUtils.AddConstructable(obj, Info.TechType, constructableFlagsInsideOutside, DegasiAbandonedBaseModel);
                DegasiAbandonedBaseConstructable.placeDefaultDistance = PlaceDistance;
                DegasiAbandonedBaseConstructable.placeMinDistance = MinPlaceDistance;
                DegasiAbandonedBaseConstructable.placeMaxDistance = MaxPlaceDistance;
                Vector3 Localpos = DegasiAbandonedBaseConstructable.transform.localPosition;
                Localpos.y += 3f;
            };

            DegasiAbandonedBasePrefab.SetGameObject(DegasiAbandonedBaseClone);
            DegasiAbandonedBasePrefab.SetPdaGroupCategory(TechGroup.ExteriorModules, TechCategory.ExteriorModule);

            DegasiAbandonedBasePrefab.SetRecipe(new RecipeData(
                new Ingredient(TechType.Titanium, 4) 
                ));

            DegasiAbandonedBasePrefab.Register();
        }
    }
}
