﻿using BepInEx;
using Nautilus.Crafting;
using Nautilus.Assets;
using Nautilus.Assets.Gadgets;
using Nautilus.Utility;
using UnityEngine;
using Nautilus.Assets.PrefabTemplates;
using static CraftData;

namespace Extra_Decor_Rusty_Pack.Buildables.Misc.Fragments.Cyclops
{
    public static class BuildableMapRoomFragment4
    {
        public static PrefabInfo Info { get; } = PrefabInfo.WithTechType("BuildableMapRoomFragment4", "Map Room Fragment 4", "Map Room fragment from Aurora's wreckages. Please return to the Alterra Corporation immediately.")
            .WithIcon(SpriteManager.Get(TechType.Cyclops));

        public static void Register()
        {
            float PlaceDistance = 10;
            float MinPlaceDistance = 2;
            float MaxPlaceDistance = 20;
            CustomPrefab MapRoomPrefab = new CustomPrefab(Info);
            CloneTemplate MapRoomClone = new CloneTemplate(Info, "cf4ca320-bb13-45b6-b4c9-2a079023e787");

            MapRoomClone.ModifyPrefab += obj =>
            {
                ConstructableFlags constructableFlagsInsideOutside = ConstructableFlags.Outside | ConstructableFlags.Inside | ConstructableFlags.Rotatable | ConstructableFlags.Ground | ConstructableFlags.AllowedOnConstructable;

                GameObject MapRoomModel = obj.transform.Find("Map_Room_fragment_04").gameObject;

                Constructable MapRoomConstructable = PrefabUtils.AddConstructable(obj, Info.TechType, constructableFlagsInsideOutside, MapRoomModel);
                MapRoomConstructable.placeDefaultDistance = PlaceDistance;
                MapRoomConstructable.placeMinDistance = MinPlaceDistance;
                MapRoomConstructable.placeMaxDistance = MaxPlaceDistance;
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
