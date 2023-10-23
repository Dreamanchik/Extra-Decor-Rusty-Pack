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
    public static class BuildableMapRoomFragment2
    {
        public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static string iconPath = Path.Combine(modFolder, "Assets", "Fragments", "MapRoom", "MapRoom2.png");
        public static PrefabInfo Info { get; } = PrefabInfo.WithTechType("BuildableMapRoomFragment2", "Map Room Fragment 2", "Map Room fragment from Aurora's wreckages. Please return to the Alterra Corporation immediately.")
            .WithIcon(ImageUtils.LoadSpriteFromFile(iconPath));

        public static void Register()
        {
            float PlaceDistance = 10;
            float MinPlaceDistance = 2;
            float MaxPlaceDistance = 20;
            CustomPrefab MapRoomPrefab = new CustomPrefab(Info);
            CloneTemplate MapRoomClone = new CloneTemplate(Info, "a72c61ae-1ab7-4ee8-bced-b76505d3f1e2");

            MapRoomClone.ModifyPrefab += obj =>
            {
                ConstructableFlags constructableFlagsInsideOutside = ConstructableFlags.Outside | ConstructableFlags.Inside | ConstructableFlags.Rotatable | ConstructableFlags.Ground | ConstructableFlags.AllowedOnConstructable;

                GameObject MapRoomModel = obj.transform.Find("Map_Room_fragment_02").gameObject;

                Constructable MapRoomConstructable = PrefabUtils.AddConstructable(obj, Info.TechType, constructableFlagsInsideOutside, MapRoomModel);
                MapRoomConstructable.placeDefaultDistance = PlaceDistance;
                MapRoomConstructable.placeMinDistance = MinPlaceDistance;
                MapRoomConstructable.placeMaxDistance = MaxPlaceDistance;
                MapRoomConstructable.rotationEnabled = true;
            };

            MapRoomPrefab.SetGameObject(MapRoomClone);
            MapRoomPrefab.SetPdaGroupCategory(TechGroup.ExteriorModules, TechCategory.ExteriorModule);

            MapRoomPrefab.SetRecipe(new RecipeData(
                new Ingredient(TechType.Titanium, 2)
                ));

            MapRoomPrefab.Register();
        }
    }
}
