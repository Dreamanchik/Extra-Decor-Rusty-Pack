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
    public static class BuildableExosuitFragment2
    {
        public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static string iconPath = Path.Combine(modFolder, "Assets", "Fragments", "Exosuit", "Exosuit2.png");
        public static PrefabInfo Info { get; } = PrefabInfo.WithTechType("BuildableExosuitFragment2", "Exosuit Fragment 2", "Exosuit fragment from Aurora's wreckages. Please return to the Alterra Corporation immediately.")
            .WithIcon(ImageUtils.LoadSpriteFromFile(iconPath));

        public static void Register()
        {
            float PlaceDistance = 10;
            float MinPlaceDistance = 2;
            float MaxPlaceDistance = 20;
            CustomPrefab ExosuitFragmentPrefab = new CustomPrefab(Info);
            CloneTemplate ExosuitFragmentClone = new CloneTemplate(Info, "740258f8-bf36-484b-bdb8-d9e5dc3f1e3e");

            ExosuitFragmentClone.ModifyPrefab += obj =>
            {
                ConstructableFlags constructableFlagsInsideOutside = ConstructableFlags.Outside | ConstructableFlags.Inside | ConstructableFlags.Rotatable | ConstructableFlags.Ground | ConstructableFlags.AllowedOnConstructable;

                GameObject ExosuitFragmentModel = obj.transform.Find("exosuit_damaged_02").gameObject;

                Constructable ExosuitFragmentConstructable = PrefabUtils.AddConstructable(obj, Info.TechType, constructableFlagsInsideOutside, ExosuitFragmentModel);
                ExosuitFragmentConstructable.placeDefaultDistance = PlaceDistance;
                ExosuitFragmentConstructable.placeMinDistance = MinPlaceDistance;
                ExosuitFragmentConstructable.placeMaxDistance = MaxPlaceDistance;
                ExosuitFragmentConstructable.rotationEnabled = true;
            };

            ExosuitFragmentPrefab.SetGameObject(ExosuitFragmentClone);
            ExosuitFragmentPrefab.SetPdaGroupCategory(TechGroup.ExteriorModules, TechCategory.ExteriorModule);

            ExosuitFragmentPrefab.SetRecipe(new RecipeData(
                new Ingredient(TechType.Titanium, 2)
                ));

            ExosuitFragmentPrefab.Register();
        }
    }
}
