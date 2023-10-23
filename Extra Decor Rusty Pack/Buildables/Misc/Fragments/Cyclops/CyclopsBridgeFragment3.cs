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
    public static class BuildableCyclopsBridgeFragment3
    {
        public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static string iconPath = Path.Combine(modFolder, "Assets", "Fragments", "Cyclops", "Bridge3.png");
        public static PrefabInfo Info { get; } = PrefabInfo.WithTechType("BuildableCyclopsFragmentBridge3", "Cyclops Bridge Fragment 3", "Cyclops bridge fragment from Aurora's wreckages. Please return to the Alterra Corporation immediately.")
            .WithIcon(ImageUtils.LoadSpriteFromFile(iconPath));

        public static void Register()
        {
            float PlaceDistance = 10;
            float MinPlaceDistance = 2;
            float MaxPlaceDistance = 20;
            CustomPrefab CyclopsFragmentPrefab = new CustomPrefab(Info);
            CloneTemplate CyclopsFragmentClone = new CloneTemplate(Info, "0e54e72a-3da8-4f5d-8440-f51033fcad8c");

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
