﻿using BepInEx;
using Nautilus.Crafting;
using Nautilus.Assets;
using Nautilus.Assets.Gadgets;
using Nautilus.Utility;
using UnityEngine;
using Nautilus.Assets.PrefabTemplates;
using static CraftData;

namespace Extra_Decor_Rusty_Pack.Buildables.Misc.Fragments.Cyclops
{
    public static class BuildableMoonPoolFragment4
    {
        public static PrefabInfo Info { get; } = PrefabInfo.WithTechType("BuildableMoonPoolFragment4", "MoonPool Fragment 4", "MoonPool fragment from Aurora's wreckages. Please return to the Alterra Corporation immediately.")
            .WithIcon(SpriteManager.Get(TechType.Cyclops));

        public static void Register()
        {
            float PlaceDistance = 10;
            float MinPlaceDistance = 2;
            float MaxPlaceDistance = 20;
            CustomPrefab MoonPoolPrefab = new CustomPrefab(Info);
            CloneTemplate MoonPoolClone = new CloneTemplate(Info, "498a843d-efed-4fc0-8243-13453aee2559");

            MoonPoolClone.ModifyPrefab += obj =>
            {
                ConstructableFlags constructableFlagsInsideOutside = ConstructableFlags.Outside | ConstructableFlags.Inside | ConstructableFlags.Rotatable | ConstructableFlags.Ground | ConstructableFlags.AllowedOnConstructable;

                GameObject MoonPoolModel = obj.transform.Find("Moon_Pool_fragment_04").gameObject;

                Constructable MoonPoolConstructable = PrefabUtils.AddConstructable(obj, Info.TechType, constructableFlagsInsideOutside, MoonPoolModel);
                MoonPoolConstructable.placeDefaultDistance = PlaceDistance;
                MoonPoolConstructable.placeMinDistance = MinPlaceDistance;
                MoonPoolConstructable.placeMaxDistance = MaxPlaceDistance;
            };

            MoonPoolPrefab.SetGameObject(MoonPoolClone);
            MoonPoolPrefab.SetPdaGroupCategory(TechGroup.ExteriorModules, TechCategory.ExteriorModule);

            MoonPoolPrefab.SetRecipe(new RecipeData(
                new Ingredient(TechType.Titanium, 2)
                ));

            MoonPoolPrefab.Register();
        }
    }
}
