﻿using BepInEx;
using Nautilus.Crafting;
using Nautilus.Assets;
using Nautilus.Assets.Gadgets;
using Nautilus.Utility;
using UnityEngine;
using Nautilus.Assets.PrefabTemplates;
using static CraftData;

namespace Extra_Decor_Rusty_Pack.Buildables.Exterior
{
    public static class BuildableDegasiFloatingIslandBase3
    {
        public static PrefabInfo Info { get; } = PrefabInfo.WithTechType("BuildableDegasiFloatingIslandBase3", "Degasi Floating Island Base 3", "Base built by the Degasi.")
            .WithIcon(SpriteManager.Get(TechType.BaseCorridorI));

        public static void Register()
        {
            float PlaceDistance = 10;
            float MinPlaceDistance = 5;
            float MaxPlaceDistance = 20;
            CustomPrefab DegasiFloatingIslandBasePrefab = new CustomPrefab(Info);
            CloneTemplate DegasiFloatingIslandBaseClone = new CloneTemplate(Info, "99b164ac-dfb4-4a14-b305-8666fa227717");

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
