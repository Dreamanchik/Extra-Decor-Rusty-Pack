using BepInEx;
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
    public static class BuildableLifePod7Exploded
    {
        public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static string iconPath = Path.Combine(modFolder, "Assets", "Lifepods", "Lifepod7.png");
        public static PrefabInfo Info { get; } = PrefabInfo.WithTechType("BuildableLifePod7Exploded", "Life Pod 7 Exploded", "Alterra escape pod from the Aurora. Highly damaged")
            .WithIcon(ImageUtils.LoadSpriteFromFile(iconPath));

        public static void Register()
        {
            float PlaceDistance = 10;
            float MinPlaceDistance = 5;
            float MaxPlaceDistance = 20;
            CustomPrefab LifePodExplodedPrefab = new CustomPrefab(Info);
            CloneTemplate LifePodExplodedClone = new CloneTemplate(Info, "d3b9095f-fcac-46de-83f7-762e3275e837");

            LifePodExplodedClone.ModifyPrefab += obj =>
            {
                ConstructableFlags constructableFlagsInsideOutside = ConstructableFlags.Outside | ConstructableFlags.Inside | ConstructableFlags.Rotatable | ConstructableFlags.Ground | ConstructableFlags.AllowedOnConstructable;

                GameObject LifePodExplodedModel = obj.transform.Find("life_pod_exploded_02").gameObject;

                Constructable LifePodExplodedConstructable = PrefabUtils.AddConstructable(obj, Info.TechType, constructableFlagsInsideOutside, LifePodExplodedModel);
                LifePodExplodedConstructable.placeDefaultDistance = PlaceDistance;
                LifePodExplodedConstructable.placeMinDistance = MinPlaceDistance;
                LifePodExplodedConstructable.placeMaxDistance = MaxPlaceDistance;
                LifePodExplodedConstructable.rotationEnabled = true;
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
