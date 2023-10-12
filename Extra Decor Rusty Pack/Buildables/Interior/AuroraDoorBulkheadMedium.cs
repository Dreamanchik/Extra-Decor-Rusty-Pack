﻿using BepInEx;
using Nautilus.Crafting;
using Nautilus.Assets;
using Nautilus.Assets.Gadgets;
using Nautilus.Utility;
using UnityEngine;
using Nautilus.Assets.PrefabTemplates;
using static CraftData;

namespace Extra_Decor_Rusty_Pack.Buildables.Interior
{
    public static class BuildableAuroraDoorBulkheadMedium
    {
        public static PrefabInfo Info { get; } = PrefabInfo.WithTechType("BuildableAuroraDoorBulkheadMedium", "Aurora Door Bulkhead Medium", "Door usually placed in alterra ships.")
            .WithIcon(SpriteManager.Get(TechType.BaseBulkhead));

        public static void Register()
        {
            float PlaceDistance = 10;
            float MinPlaceDistance = 0;
            float MaxPlaceDistance = 10;
            CustomPrefab AuroraDoorBulkheadPrefab = new CustomPrefab(Info);
            CloneTemplate AuroraDoorBulkheadClone = new CloneTemplate(Info, "d9524ffa-11cf-4265-9f61-da6f0fe84a3f");

            AuroraDoorBulkheadClone.ModifyPrefab += obj =>
            {
                ConstructableFlags constructableFlagsInsideOutside = ConstructableFlags.Outside | ConstructableFlags.Inside | ConstructableFlags.Rotatable | ConstructableFlags.Ground | ConstructableFlags.AllowedOnConstructable;

                GameObject AuroraDoorBulkheadModel = obj.transform.Find("Starship_doors_manual_01").gameObject;

                Constructable AuroraDoorBulkheadConstructable = PrefabUtils.AddConstructable(obj, Info.TechType, constructableFlagsInsideOutside, AuroraDoorBulkheadModel);
                Vector3 DoorScale = AuroraDoorBulkheadConstructable.transform.localScale;
                DoorScale.y = 1.15f;
                AuroraDoorBulkheadConstructable.placeDefaultDistance = PlaceDistance;
                AuroraDoorBulkheadConstructable.placeMinDistance = MinPlaceDistance;
                AuroraDoorBulkheadConstructable.placeMaxDistance = MaxPlaceDistance;
                AuroraDoorBulkheadConstructable.transform.localScale = DoorScale;
            };

            AuroraDoorBulkheadPrefab.SetGameObject(AuroraDoorBulkheadClone);
            AuroraDoorBulkheadPrefab.SetPdaGroupCategory(TechGroup.InteriorModules, TechCategory.InteriorModule);

            AuroraDoorBulkheadPrefab.SetRecipe(new RecipeData(
                new Ingredient(TechType.Titanium, 2),
                new Ingredient(TechType.Silicone, 1)
                ));

            AuroraDoorBulkheadPrefab.Register();
        }
    }
}
