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
    public static class BuildablePowerTransmitterFragment
    {
        public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static string iconPath = Path.Combine(modFolder, "Assets", "Fragments", "PowerTransmitter", "PowerTransmitter.png");
        public static PrefabInfo Info { get; } = PrefabInfo.WithTechType("BuildablePowerTransmitterFragment", "Power Transmitter Fragment", "Power Transmitter fragment from Aurora's wreckages. Please return to the Alterra Corporation immediately.")
            .WithIcon(ImageUtils.LoadSpriteFromFile(iconPath));

        public static void Register()
        {
            float PlaceDistance = 10;
            float MinPlaceDistance = 0;
            float MaxPlaceDistance = 20;
            CustomPrefab PowerTransmitterFragmentPrefab = new CustomPrefab(Info);
            CloneTemplate PowerTransmitterFragmentClone = new CloneTemplate(Info, "7436aeba-f8df-4887-b369-e630fa01f716");

            PowerTransmitterFragmentClone.ModifyPrefab += obj =>
            {
                ConstructableFlags constructableFlagsInsideOutside = ConstructableFlags.Outside | ConstructableFlags.Inside | ConstructableFlags.Rotatable | ConstructableFlags.Ground | ConstructableFlags.AllowedOnConstructable;

                GameObject PowerTransmitterFragmentModel = obj.transform.Find("PowerTransmitter_damaged").gameObject;

                Constructable PowerTransmitterFragmentConstructable = PrefabUtils.AddConstructable(obj, Info.TechType, constructableFlagsInsideOutside, PowerTransmitterFragmentModel);
                PowerTransmitterFragmentConstructable.placeDefaultDistance = PlaceDistance;
                PowerTransmitterFragmentConstructable.placeMinDistance = MinPlaceDistance;
                PowerTransmitterFragmentConstructable.placeMaxDistance = MaxPlaceDistance;
                PowerTransmitterFragmentConstructable.rotationEnabled = true;
            };

            PowerTransmitterFragmentPrefab.SetGameObject(PowerTransmitterFragmentClone);
            PowerTransmitterFragmentPrefab.SetPdaGroupCategory(TechGroup.ExteriorModules, TechCategory.ExteriorModule);

            PowerTransmitterFragmentPrefab.SetRecipe(new RecipeData(
                new Ingredient(TechType.Titanium, 2)
                ));

            PowerTransmitterFragmentPrefab.Register();
        }
    }
}
