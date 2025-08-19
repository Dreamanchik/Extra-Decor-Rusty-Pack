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
    public static class BuildableLedLightFragment
    {
        public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static string iconPath = Path.Combine(modFolder, "Assets", "Fragments", "LedLight", "LedLight.png");
        public static PrefabInfo Info { get; } = PrefabInfo.WithTechType("BuildableLedLightFragment", "Led Light Fragment", "Led light fragment from Aurora's wreckages. Please return to the Alterra Corporation immediately.")
            .WithIcon(ImageUtils.LoadSpriteFromFile(iconPath));

        public static void Register()
        {
            float PlaceDistance = 10;
            float MinPlaceDistance = 0;
            float MaxPlaceDistance = 20;
            CustomPrefab LedLightFragmentPrefab = new CustomPrefab(Info);
            CloneTemplate LedLightFragmentClone = new CloneTemplate(Info, "c1f8aa68-0ac0-419e-81ec-b7a388027c24");

            LedLightFragmentClone.ModifyPrefab += obj =>
            {
                ConstructableFlags constructableFlagsInsideOutside = ConstructableFlags.Outside | ConstructableFlags.Inside | ConstructableFlags.Rotatable | ConstructableFlags.Ground | ConstructableFlags.AllowedOnConstructable;

                GameObject LedLightFragmentModel = obj.transform.Find("model").gameObject;

                Constructable LedLightFragmentConstructable = PrefabUtils.AddConstructable(obj, Info.TechType, constructableFlagsInsideOutside, LedLightFragmentModel);
                LedLightFragmentConstructable.placeDefaultDistance = PlaceDistance;
                LedLightFragmentConstructable.placeMinDistance = MinPlaceDistance;
                LedLightFragmentConstructable.placeMaxDistance = MaxPlaceDistance;
                LedLightFragmentConstructable.rotationEnabled = true;
                obj.AddComponent<ImmuneToPropulsioncannon>();
            };

            LedLightFragmentPrefab.SetGameObject(LedLightFragmentClone);
            LedLightFragmentPrefab.SetPdaGroupCategory(TechGroup.ExteriorModules, TechCategory.ExteriorModule);

            LedLightFragmentPrefab.SetRecipe(new RecipeData(
                new Ingredient(TechType.Titanium, 2)
                ));

            LedLightFragmentPrefab.Register();
        }
    }
}
