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
    public static class BuildableExplodedDebris16
    {
        public static PrefabInfo Info { get; } = PrefabInfo.WithTechType("BuildableExplodedDebris16", "Exploded Debris 16", "Debris found on aurora wrecks.")
            .WithIcon(SpriteManager.Get(TechType.Locker));

        public static void Register()
        {
            float PlaceDistance = 10;
            float MinPlaceDistance = 0;
            float MaxPlaceDistance = 20;
            CustomPrefab ExplodedDebrisPrefab = new CustomPrefab(Info);
            CloneTemplate ExplodedDebrisClone = new CloneTemplate(Info, "0c65ee6e-a84a-4989-a846-19eb53c13071");

            ExplodedDebrisClone.ModifyPrefab += obj =>
            {
                ConstructableFlags constructableFlagsInsideOutside = ConstructableFlags.Outside | ConstructableFlags.Inside | ConstructableFlags.Rotatable | ConstructableFlags.Ground | ConstructableFlags.AllowedOnConstructable;

                GameObject ExplodedDebrisModel = obj.transform.Find("Starship_exploded_debris_16").gameObject;

                Constructable ExplodedDebrisConstructable = PrefabUtils.AddConstructable(obj, Info.TechType, constructableFlagsInsideOutside, ExplodedDebrisModel);
                ExplodedDebrisConstructable.placeDefaultDistance = PlaceDistance;
                ExplodedDebrisConstructable.placeMinDistance = MinPlaceDistance;
                ExplodedDebrisConstructable.placeMaxDistance = MaxPlaceDistance;
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
