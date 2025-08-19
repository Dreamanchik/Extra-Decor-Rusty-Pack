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
    public static class BuildableMapRoomFragment3
    {
        public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static string iconPath = Path.Combine(modFolder, "Assets", "Fragments", "MapRoom", "MapRoom3.png");
        public static PrefabInfo Info { get; } = PrefabInfo.WithTechType("BuildableMapRoomFragment3", "Map Room Fragment 3", "Map Room fragment from Aurora's wreckages. Please return to the Alterra Corporation immediately.")
            .WithIcon(ImageUtils.LoadSpriteFromFile(iconPath));

        public static void Register()
        {
            float PlaceDistance = 10;
            float MinPlaceDistance = 2;
            float MaxPlaceDistance = 20;
            CustomPrefab MapRoomPrefab = new CustomPrefab(Info);
            CloneTemplate MapRoomClone = new CloneTemplate(Info, "f350b8ae-9ee4-4349-a6de-d031b11c82b1");

            MapRoomClone.ModifyPrefab += obj =>
            {
                ConstructableFlags constructableFlagsInsideOutside = ConstructableFlags.Outside | ConstructableFlags.Inside | ConstructableFlags.Rotatable | ConstructableFlags.Ground | ConstructableFlags.AllowedOnConstructable;

                GameObject MapRoomModel = obj.transform.Find("Map_Room_fragment_03").gameObject;

                Constructable MapRoomConstructable = PrefabUtils.AddConstructable(obj, Info.TechType, constructableFlagsInsideOutside, MapRoomModel);
                MapRoomConstructable.placeDefaultDistance = PlaceDistance;
                MapRoomConstructable.placeMinDistance = MinPlaceDistance;
                MapRoomConstructable.placeMaxDistance = MaxPlaceDistance;
                MapRoomConstructable.rotationEnabled = true;
                obj.AddComponent<ImmuneToPropulsioncannon>();
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
