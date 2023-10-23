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
    public static class BuildableCyclopsHullFragment3
    {
        public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static string iconPath = Path.Combine(modFolder, "Assets", "Fragments", "Cyclops", "Hull3.png");
        public static PrefabInfo Info { get; } = PrefabInfo.WithTechType("BuildableCyclopsFragmentHull3", "Cyclops Hull Fragment 3", "Cyclops hull fragment from Aurora's wreckages. Please return to the Alterra Corporation immediately.")
            .WithIcon(ImageUtils.LoadSpriteFromFile(iconPath));

        public static void Register()
        {
            float PlaceDistance = 10;
            float MinPlaceDistance = 2;
            float MaxPlaceDistance = 20;
            CustomPrefab CyclopsFragmentPrefab = new CustomPrefab(Info);
            CloneTemplate CyclopsFragmentClone = new CloneTemplate(Info, "0ba2de19-0f6e-4469-bf77-8c0f9db95875");

            CyclopsFragmentClone.ModifyPrefab += obj =>
            {
                ConstructableFlags constructableFlagsInsideOutside = ConstructableFlags.Outside | ConstructableFlags.Inside | ConstructableFlags.Rotatable | ConstructableFlags.Ground | ConstructableFlags.AllowedOnConstructable;

                GameObject CyclopsFragmentModel = obj.transform.Find("model").gameObject;

                Constructable CyclopsFragmentConstructable = PrefabUtils.AddConstructable(obj, Info.TechType, constructableFlagsInsideOutside, CyclopsFragmentModel);
                CyclopsFragmentConstructable.placeDefaultDistance = PlaceDistance;
                CyclopsFragmentConstructable.placeMinDistance = MinPlaceDistance;
                CyclopsFragmentConstructable.placeMaxDistance = MaxPlaceDistance;
                CyclopsFragmentConstructable.rotationEnabled = true;
            };

            CyclopsFragmentPrefab.SetGameObject(CyclopsFragmentClone);
            CyclopsFragmentPrefab.SetPdaGroupCategory(TechGroup.ExteriorModules, TechCategory.ExteriorModule);

            CyclopsFragmentPrefab.SetRecipe(new RecipeData(
                new Ingredient(TechType.Titanium, 2)
                ));

            CyclopsFragmentPrefab.Register();
        }
    }
}
