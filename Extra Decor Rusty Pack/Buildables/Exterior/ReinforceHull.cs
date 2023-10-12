using BepInEx;
using Nautilus.Crafting;
using Nautilus.Assets;
using Nautilus.Assets.Gadgets;
using Nautilus.Utility;
using UnityEngine;
using Nautilus.Assets.PrefabTemplates;
using static CraftData;

namespace Extra_Decor_Rusty_Pack.Buildables.Exterior
{
    public static class BuildableReinforceHull
    {
        public static PrefabInfo Info { get; } = PrefabInfo.WithTechType("BuildableReinforceHull", "Cyclops Reinforce Hull", "Old reinforce hull for the cyclops submarine. Does not work.")
            .WithIcon(SpriteManager.Get(TechType.Cyclops));

        public static void Register()
        {
            float PlaceDistance = 10;
            float MinPlaceDistance = 2;
            float MaxPlaceDistance = 20;
            CustomPrefab ReinforceHullPrefab = new CustomPrefab(Info);
            CloneTemplate ReinforceHullClone = new CloneTemplate(Info, "0f58e8a0-6ef9-4016-bbbf-9eb7e8070ae2");

            ReinforceHullClone.ModifyPrefab += obj =>
            {
                ConstructableFlags constructableFlagsInsideOutside = ConstructableFlags.Outside | ConstructableFlags.Inside | ConstructableFlags.Rotatable | ConstructableFlags.Ground | ConstructableFlags.AllowedOnConstructable;

                GameObject ReinforceHullModel = obj.transform.Find("model_offset").gameObject;

                Constructable ReinforceHullConstructable = PrefabUtils.AddConstructable(obj, Info.TechType, constructableFlagsInsideOutside, ReinforceHullModel);
                ReinforceHullConstructable.placeDefaultDistance = PlaceDistance;
                ReinforceHullConstructable.placeMinDistance = MinPlaceDistance;
                ReinforceHullConstructable.placeMaxDistance = MaxPlaceDistance;
            };

            ReinforceHullPrefab.SetGameObject(ReinforceHullClone);
            ReinforceHullPrefab.SetPdaGroupCategory(TechGroup.Miscellaneous, TechCategory.Misc);

            ReinforceHullPrefab.SetRecipe(new RecipeData(
                new Ingredient(TechType.Titanium, 4) 
                ));

            ReinforceHullPrefab.Register();
        }
    }
}
