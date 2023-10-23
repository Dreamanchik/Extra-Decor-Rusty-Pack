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
    public static class BuildableSubmarineConsoleWide
    {
        public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static string iconPath = Path.Combine(modFolder, "Assets", "ConsoleWide", "ConsoleWide.png");
        public static PrefabInfo Info { get; } = PrefabInfo.WithTechType("BuildableConsoleWide", "Console Wide", "A console usually placed in alterra ships.")
            .WithIcon(ImageUtils.LoadSpriteFromFile(iconPath));

        public static void Register()
        {
            float PlaceDistance = 10;
            float MinPlaceDistance = 0;
            float MaxPlaceDistance = 10;
            CustomPrefab ConsolePrefab = new CustomPrefab(Info);
            CloneTemplate ConsoleClone = new CloneTemplate(Info, "fe24efb3-b34f-4c24-932d-b514db580f40");

            ConsoleClone.ModifyPrefab += obj =>
            {
                ConstructableFlags constructableFlagsInsideOutside = ConstructableFlags.Outside | ConstructableFlags.Inside | ConstructableFlags.Rotatable | ConstructableFlags.Ground | ConstructableFlags.AllowedOnConstructable;

                GameObject ConsoleModel = obj.transform.Find("submarine_engine_console_01_wide").gameObject;

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
