using BepInEx;
using Nautilus.Crafting;
using Nautilus.Assets;
using Nautilus.Assets.Gadgets;
using Nautilus.Utility;
using UnityEngine;
using Nautilus.Assets.PrefabTemplates;
using static CraftData;

namespace Extra_Decor_Rusty_Pack.Buildables.Misc.Fragments.Cyclops
{
    public static class BuildableLaserCutterFragment
    {
        public static PrefabInfo Info { get; } = PrefabInfo.WithTechType("BuildableLaserCutterFragment", "Laser Cutter Fragment", "Laser cutter fragment from Aurora's wreckages. Please return to the Alterra Corporation immediately.")
            .WithIcon(SpriteManager.Get(TechType.Cyclops));

        public static void Register()
        {
            float PlaceDistance = 10;
            float MinPlaceDistance = 2;
            float MaxPlaceDistance = 20;
            CustomPrefab LaserCutterFragmentPrefab = new CustomPrefab(Info);
            CloneTemplate LaserCutterFragmentClone = new CloneTemplate(Info, "aeff4dad-8256-475b-a764-d5e7028220ce");

            LaserCutterFragmentClone.ModifyPrefab += obj =>
            {
                ConstructableFlags constructableFlagsInsideOutside = ConstructableFlags.Outside | ConstructableFlags.Inside | ConstructableFlags.Rotatable | ConstructableFlags.Ground | ConstructableFlags.AllowedOnConstructable;

                GameObject LaserCutterFragmentModel = obj.transform.Find("Laser_Cutter_damaged").gameObject;

                Constructable LaserCutterFragmentConstructable = PrefabUtils.AddConstructable(obj, Info.TechType, constructableFlagsInsideOutside, LaserCutterFragmentModel);
                LaserCutterFragmentConstructable.placeDefaultDistance = PlaceDistance;
                LaserCutterFragmentConstructable.placeMinDistance = MinPlaceDistance;
                LaserCutterFragmentConstructable.placeMaxDistance = MaxPlaceDistance;
            };

            LaserCutterFragmentPrefab.SetGameObject(LaserCutterFragmentClone);
            LaserCutterFragmentPrefab.SetPdaGroupCategory(TechGroup.ExteriorModules, TechCategory.ExteriorModule);

            LaserCutterFragmentPrefab.SetRecipe(new RecipeData(
                new Ingredient(TechType.Titanium, 2)
                ));

            LaserCutterFragmentPrefab.Register();
        }
    }
}
