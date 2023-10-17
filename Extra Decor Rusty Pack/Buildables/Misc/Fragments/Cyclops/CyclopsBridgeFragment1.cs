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
    public static class BuildableCyclopsBridgeFragment1
    {
        public static PrefabInfo Info { get; } = PrefabInfo.WithTechType("BuildableCyclopsFragmentBridge1", "Cyclops Bridge Fragment 1", "Cyclops bridge fragment from Aurora's wreckages. Please return to the Alterra Corporation immediately.")
            .WithIcon(SpriteManager.Get(TechType.Cyclops));

        public static void Register()
        {
            float PlaceDistance = 10;
            float MinPlaceDistance = 2;
            float MaxPlaceDistance = 20;
            CustomPrefab CyclopsFragmentPrefab = new CustomPrefab(Info);
            CloneTemplate CyclopsFragmentClone = new CloneTemplate(Info, "d0115374-d251-4e52-8404-af15cc6244c3");

            CyclopsFragmentClone.ModifyPrefab += obj =>
            {
                ConstructableFlags constructableFlagsInsideOutside = ConstructableFlags.Outside | ConstructableFlags.Inside | ConstructableFlags.Rotatable | ConstructableFlags.Ground | ConstructableFlags.AllowedOnConstructable;

                GameObject CyclopsFragmentModel = obj.transform.Find("model").gameObject;

                Constructable CyclopsFragmentConstructable = PrefabUtils.AddConstructable(obj, Info.TechType, constructableFlagsInsideOutside, CyclopsFragmentModel);
                CyclopsFragmentConstructable.placeDefaultDistance = PlaceDistance;
                CyclopsFragmentConstructable.placeMinDistance = MinPlaceDistance;
                CyclopsFragmentConstructable.placeMaxDistance = MaxPlaceDistance;
            };

            CyclopsFragmentPrefab.SetGameObject(CyclopsFragmentClone);
            CyclopsFragmentPrefab.SetPdaGroupCategory(TechGroup.ExteriorModules, TechCategory.ExteriorModule);

            CyclopsFragmentPrefab.SetRecipe(new RecipeData(
                new Ingredient(TechType.Titanium, 2)
                ));

            CyclopsFragmentPrefab.Register();
        }
    }
}
