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
    public static class BuildableExosuitTorpedoArmFragment
    {
        public static PrefabInfo Info { get; } = PrefabInfo.WithTechType("BuildableExosuitTorpedoArmFragment", "Exosuit Torpedo Arm Fragment", "Exosuit torpedo arm fragment from Aurora's wreckages. Please return to the Alterra Corporation immediately.")
            .WithIcon(SpriteManager.Get(TechType.Cyclops));

        public static void Register()
        {
            float PlaceDistance = 10;
            float MinPlaceDistance = 2;
            float MaxPlaceDistance = 20;
            CustomPrefab ExosuitFragmentPrefab = new CustomPrefab(Info);
            CloneTemplate ExosuitFragmentClone = new CloneTemplate(Info, "1c953310-8436-4012-8e0d-3b4634f07e57");

            ExosuitFragmentClone.ModifyPrefab += obj =>
            {
                ConstructableFlags constructableFlagsInsideOutside = ConstructableFlags.Outside | ConstructableFlags.Inside | ConstructableFlags.Rotatable | ConstructableFlags.Ground | ConstructableFlags.AllowedOnConstructable;

                GameObject ExosuitFragmentModel = obj.transform.Find("exosuit_01_armRight").gameObject;

                Constructable ExosuitFragmentConstructable = PrefabUtils.AddConstructable(obj, Info.TechType, constructableFlagsInsideOutside, ExosuitFragmentModel);
                ExosuitFragmentConstructable.placeDefaultDistance = PlaceDistance;
                ExosuitFragmentConstructable.placeMinDistance = MinPlaceDistance;
                ExosuitFragmentConstructable.placeMaxDistance = MaxPlaceDistance;
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