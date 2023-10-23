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

namespace Extra_Decor_Rusty_Pack.Buildables.Misc.Fragments.Cyclops
{
    public static class BuildableMoonPoolFragment6
    {
        public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static string iconPath = Path.Combine(modFolder, "Assets", "Fragments", "MoonPool", "MoonPool6.png");
        public static PrefabInfo Info { get; } = PrefabInfo.WithTechType("BuildableMoonPoolFragment6", "MoonPool Fragment 6", "MoonPool fragment from Aurora's wreckages. Please return to the Alterra Corporation immediately.")
            .WithIcon(ImageUtils.LoadSpriteFromFile(iconPath));

        public static void Register()
        {
            float PlaceDistance = 10;
            float MinPlaceDistance = 2;
            float MaxPlaceDistance = 20;
            CustomPrefab MoonPoolPrefab = new CustomPrefab(Info);
            CloneTemplate MoonPoolClone = new CloneTemplate(Info, "bd3c0070-3af4-4e44-b50d-506c438829ec");

            MoonPoolClone.ModifyPrefab += obj =>
            {
                ConstructableFlags constructableFlagsInsideOutside = ConstructableFlags.Outside | ConstructableFlags.Inside | ConstructableFlags.Rotatable | ConstructableFlags.Ground | ConstructableFlags.AllowedOnConstructable;

                GameObject MoonPoolModel = obj.transform.Find("Moon_Pool_fragment_06").gameObject;

                Constructable MoonPoolConstructable = PrefabUtils.AddConstructable(obj, Info.TechType, constructableFlagsInsideOutside, MoonPoolModel);
                MoonPoolConstructable.placeDefaultDistance = PlaceDistance;
                MoonPoolConstructable.placeMinDistance = MinPlaceDistance;
                MoonPoolConstructable.placeMaxDistance = MaxPlaceDistance;
                MoonPoolConstructable.rotationEnabled = true;
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
