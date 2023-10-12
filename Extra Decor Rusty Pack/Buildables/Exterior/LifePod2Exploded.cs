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
    public static class BuildableLifePod2Exploded
    {
        public static PrefabInfo Info { get; } = PrefabInfo.WithTechType("BuildableLifePod2Exploded", "Life Pod 2 Exploded", "Alterra escape pod from the Aurora. Highly damaged")
            .WithIcon(SpriteManager.Get(TechType.Locker));

        public static void Register()
        {
            float PlaceDistance = 10;
            float MinPlaceDistance = 5;
            float MaxPlaceDistance = 20;
            CustomPrefab LifePodExplodedPrefab = new CustomPrefab(Info);
            CloneTemplate LifePodExplodedClone = new CloneTemplate(Info, "66cc5a83-142b-4d8d-8d16-2d6e960f59c3");

            LifePodExplodedClone.ModifyPrefab += obj =>
            {
                ConstructableFlags constructableFlagsInsideOutside = ConstructableFlags.Outside | ConstructableFlags.Inside | ConstructableFlags.Rotatable | ConstructableFlags.Ground | ConstructableFlags.AllowedOnConstructable;

                GameObject LifePodExplodedModel = obj.transform.Find("life_pod_exploded_02").gameObject;

                Constructable LifePodExplodedConstructable = PrefabUtils.AddConstructable(obj, Info.TechType, constructableFlagsInsideOutside, LifePodExplodedModel);
                LifePodExplodedConstructable.placeDefaultDistance = PlaceDistance;
                LifePodExplodedConstructable.placeMinDistance = MinPlaceDistance;
                LifePodExplodedConstructable.placeMaxDistance = MaxPlaceDistance;
            };

            LifePodExplodedPrefab.SetGameObject(LifePodExplodedClone);
            LifePodExplodedPrefab.SetPdaGroupCategory(TechGroup.ExteriorModules, TechCategory.ExteriorModule);

            LifePodExplodedPrefab.SetRecipe(new RecipeData(
                new Ingredient(TechType.Titanium, 3), 
                new Ingredient(TechType.Glass, 1)
                ));

            LifePodExplodedPrefab.Register();
        }
    }
}
