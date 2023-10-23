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

namespace Extra_Decor_Rusty_Pack.Buildables.Interior
{
    public static class BuildableSubmarineConsole
    {
        public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static string iconPath = Path.Combine(modFolder, "Assets", "Console", "Console.png");
        public static PrefabInfo Info { get; } = PrefabInfo.WithTechType("BuildableConsoleMedium", "Console Medium", "A console usually placed in alterra ships.")
            .WithIcon(ImageUtils.LoadSpriteFromFile(iconPath));

        public static void Register()
        {
            float PlaceDistance = 10;
            float MinPlaceDistance = 0;
            float MaxPlaceDistance = 10;
            CustomPrefab ConsolePrefab = new CustomPrefab(Info);
            CloneTemplate ConsoleClone = new CloneTemplate(Info, "38b89b53-2506-4f90-aaaa-2f0174e6425f");

            ConsoleClone.ModifyPrefab += obj =>
            {
                ConstructableFlags constructableFlagsInsideOutside = ConstructableFlags.Outside | ConstructableFlags.Inside | ConstructableFlags.Rotatable | ConstructableFlags.Ground | ConstructableFlags.AllowedOnConstructable;

                GameObject ConsoleModel = obj.transform.Find("submarine_engine_console_01").gameObject;

                Constructable ConsoleConstructable = PrefabUtils.AddConstructable(obj, Info.TechType, constructableFlagsInsideOutside, ConsoleModel);
                ConsoleConstructable.placeDefaultDistance = PlaceDistance;
                ConsoleConstructable.placeMinDistance = MinPlaceDistance;
                ConsoleConstructable.placeMaxDistance = MaxPlaceDistance;
                ConsoleConstructable.rotationEnabled = true;
            };

            ConsolePrefab.SetGameObject(ConsoleClone);
            ConsolePrefab.SetPdaGroupCategory(TechGroup.Miscellaneous, TechCategory.Misc);

            ConsolePrefab.SetRecipe(new RecipeData(
                new Ingredient(TechType.Titanium, 2)
                ));

            ConsolePrefab.Register();
        }
    }
}
