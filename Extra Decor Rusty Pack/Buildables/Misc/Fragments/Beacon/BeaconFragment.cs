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
    public static class BuildableBeaconFragment
    {
        public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static string iconPath = Path.Combine(modFolder, "Assets", "Fragments", "Beacon", "Beacon.png");
        public static PrefabInfo Info { get; } = PrefabInfo.WithTechType("BuildableBeaconFragment", "Beacon Fragment", "Beacon fragment from Aurora's wreckages. Please return to the Alterra Corporation immediately.")
            .WithIcon(ImageUtils.LoadSpriteFromFile(iconPath));

        public static void Register()
        {
            float PlaceDistance = 10;
            float MinPlaceDistance = 0;
            float MaxPlaceDistance = 20;
            CustomPrefab BeaconFragmentPrefab = new CustomPrefab(Info);
            CloneTemplate BeaconFragmentClone = new CloneTemplate(Info, "a50c91eb-f7cf-4fbf-8157-0aa8d444820c");

            BeaconFragmentClone.ModifyPrefab += obj =>
            {
                ConstructableFlags constructableFlagsInsideOutside = ConstructableFlags.Outside | ConstructableFlags.Inside | ConstructableFlags.Rotatable | ConstructableFlags.Ground | ConstructableFlags.AllowedOnConstructable;

                GameObject BeaconFragmentModel = obj.transform.Find("beacon_damaged").gameObject;

                Constructable BeaconFragmentConstructable = PrefabUtils.AddConstructable(obj, Info.TechType, constructableFlagsInsideOutside, BeaconFragmentModel);
                BeaconFragmentConstructable.placeDefaultDistance = PlaceDistance;
                BeaconFragmentConstructable.placeMinDistance = MinPlaceDistance;
                BeaconFragmentConstructable.placeMaxDistance = MaxPlaceDistance;
                BeaconFragmentConstructable.rotationEnabled = true;
            };

            BeaconFragmentPrefab.SetGameObject(BeaconFragmentClone);
            BeaconFragmentPrefab.SetPdaGroupCategory(TechGroup.ExteriorModules, TechCategory.ExteriorModule);

            BeaconFragmentPrefab.SetRecipe(new RecipeData(
                new Ingredient(TechType.Titanium, 2)
                ));

            BeaconFragmentPrefab.Register();
        }
    }
}
