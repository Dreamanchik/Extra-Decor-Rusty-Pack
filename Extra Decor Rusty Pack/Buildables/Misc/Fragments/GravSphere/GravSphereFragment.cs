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
    public static class BuildableGravSphereFragment
    {
        public static PrefabInfo Info { get; } = PrefabInfo.WithTechType("BuildableGravSphereFragment", "Grav Sphere Fragment", "Grav sphere fragment from Aurora's wreckages. Please return to the Alterra Corporation immediately.")
            .WithIcon(SpriteManager.Get(TechType.Cyclops));

        public static void Register()
        {
            float PlaceDistance = 10;
            float MinPlaceDistance = 2;
            float MaxPlaceDistance = 20;
            CustomPrefab GravSphereFragmentPrefab = new CustomPrefab(Info);
            CloneTemplate GravSphereFragmentClone = new CloneTemplate(Info, "6e4f85c2-ad1d-4d0a-b20c-1158204ee424");

            GravSphereFragmentClone.ModifyPrefab += obj =>
            {
                ConstructableFlags constructableFlagsInsideOutside = ConstructableFlags.Outside | ConstructableFlags.Inside | ConstructableFlags.Rotatable | ConstructableFlags.Ground | ConstructableFlags.AllowedOnConstructable;

                GameObject GravSphereFragmentModel = obj.transform.Find("Gravsphere_damaged").gameObject;

                Constructable GravSphereFragmentConstructable = PrefabUtils.AddConstructable(obj, Info.TechType, constructableFlagsInsideOutside, GravSphereFragmentModel);
                GravSphereFragmentConstructable.placeDefaultDistance = PlaceDistance;
                GravSphereFragmentConstructable.placeMinDistance = MinPlaceDistance;
                GravSphereFragmentConstructable.placeMaxDistance = MaxPlaceDistance;
            };

            GravSphereFragmentPrefab.SetGameObject(GravSphereFragmentClone);
            GravSphereFragmentPrefab.SetPdaGroupCategory(TechGroup.ExteriorModules, TechCategory.ExteriorModule);

            GravSphereFragmentPrefab.SetRecipe(new RecipeData(
                new Ingredient(TechType.Titanium, 2)
                ));

            GravSphereFragmentPrefab.Register();
        }
    }
}
