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
    public static class BuildableSeaglideFragment1
    {
        public static PrefabInfo Info { get; } = PrefabInfo.WithTechType("BuildableSeaglideFragment1", "Seaglide Fragment 1", "Seaglide fragment from Aurora's wreckages. Please return to the Alterra Corporation immediately.")
            .WithIcon(SpriteManager.Get(TechType.Cyclops));

        public static void Register()
        {
            float PlaceDistance = 10;
            float MinPlaceDistance = 2;
            float MaxPlaceDistance = 20;
            CustomPrefab SeaglideFragmentPrefab = new CustomPrefab(Info);
            CloneTemplate SeaglideFragmentClone = new CloneTemplate(Info, "127f22a3-44cd-4341-adb8-8937317f53de");

            SeaglideFragmentClone.ModifyPrefab += obj =>
            {
                ConstructableFlags constructableFlagsInsideOutside = ConstructableFlags.Outside | ConstructableFlags.Inside | ConstructableFlags.Rotatable | ConstructableFlags.Ground | ConstructableFlags.AllowedOnConstructable;

                GameObject SeaglideFragmentModel = obj.transform.Find("model").gameObject;

                Constructable SeaglideFragmentConstructable = PrefabUtils.AddConstructable(obj, Info.TechType, constructableFlagsInsideOutside, SeaglideFragmentModel);
                SeaglideFragmentConstructable.placeDefaultDistance = PlaceDistance;
                SeaglideFragmentConstructable.placeMinDistance = MinPlaceDistance;
                SeaglideFragmentConstructable.placeMaxDistance = MaxPlaceDistance;
            };

            SeaglideFragmentPrefab.SetGameObject(SeaglideFragmentClone);
            SeaglideFragmentPrefab.SetPdaGroupCategory(TechGroup.ExteriorModules, TechCategory.ExteriorModule);

            SeaglideFragmentPrefab.SetRecipe(new RecipeData(
                new Ingredient(TechType.Titanium, 2)
                ));

            SeaglideFragmentPrefab.Register();
        }
    }
}