﻿using BepInEx;
using Nautilus.Crafting;
using Nautilus.Assets;
using Nautilus.Assets.Gadgets;
using Nautilus.Utility;
using UnityEngine;
using Nautilus.Assets.PrefabTemplates;
using static CraftData;
using System.Reflection;
using System.IO;

namespace Extra_Decor_Rusty_Pack.Buildables.Exterior
{
    public static class BuildableExplodedDebris7
    {
        public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static string iconPath = Path.Combine(modFolder, "Assets", "Debris", "Debris7.png");
        public static PrefabInfo Info { get; } = PrefabInfo.WithTechType("BuildableExplodedDebris7", "Exploded Debris 7", "Debris found on aurora wrecks.")
            .WithIcon(ImageUtils.LoadSpriteFromFile(iconPath));

        public static void Register()
        {
            float PlaceDistance = 10;
            float MinPlaceDistance = 0;
            float MaxPlaceDistance = 20;
            CustomPrefab ExplodedDebrisPrefab = new CustomPrefab(Info);
            CloneTemplate ExplodedDebrisClone = new CloneTemplate(Info, "08a95141-7c00-4d55-b582-306fa2e217ed");

            ExplodedDebrisClone.ModifyPrefab += obj =>
            {
                ConstructableFlags constructableFlagsInsideOutside = ConstructableFlags.Outside | ConstructableFlags.Inside | ConstructableFlags.Rotatable | ConstructableFlags.Ground | ConstructableFlags.AllowedOnConstructable;

                GameObject ExplodedDebrisModel = obj.transform.Find("Starship_exploded_debris_07").gameObject;

                Constructable ExplodedDebrisConstructable = PrefabUtils.AddConstructable(obj, Info.TechType, constructableFlagsInsideOutside, ExplodedDebrisModel);
                ExplodedDebrisConstructable.placeDefaultDistance = PlaceDistance;
                ExplodedDebrisConstructable.placeMinDistance = MinPlaceDistance;
                ExplodedDebrisConstructable.placeMaxDistance = MaxPlaceDistance;
                ExplodedDebrisConstructable.rotationEnabled = true;
            };

            ExplodedDebrisPrefab.SetGameObject(ExplodedDebrisClone);
            ExplodedDebrisPrefab.SetPdaGroupCategory(TechGroup.ExteriorModules, TechCategory.ExteriorModule);

            ExplodedDebrisPrefab.SetRecipe(new RecipeData(
                new Ingredient(TechType.Titanium, 1)
                ));

            ExplodedDebrisPrefab.Register();
        }
    }
}
