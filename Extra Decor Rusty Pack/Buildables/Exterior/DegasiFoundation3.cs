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

namespace Extra_Decor_Rusty_Pack.Buildables.Exterior
{
    public static class BuildableDegasiFoundation3
    {
        public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static string iconPath = Path.Combine(modFolder, "Assets", "Degasi", "Foundation3.png");
        public static PrefabInfo Info { get; } = PrefabInfo.WithTechType("BuildableDegasiFoundation3", "Degasi Foundation 3", "Foundation built by the Degasi.")
            .WithIcon(ImageUtils.LoadSpriteFromFile(iconPath));

        public static void Register()
        {
            float PlaceDistance = 10;
            float MinPlaceDistance = 5;
            float MaxPlaceDistance = 20;
            CustomPrefab DegasiFoundationPrefab = new CustomPrefab(Info);
            CloneTemplate DegasiFoundationClone = new CloneTemplate(Info, "256a06d3-b861-487a-b8ac-050daa0d683d");

            DegasiFoundationClone.ModifyPrefab += obj =>
            {
                ConstructableFlags constructableFlagsInsideOutside = ConstructableFlags.Outside | ConstructableFlags.Inside | ConstructableFlags.Rotatable | ConstructableFlags.Ground | ConstructableFlags.AllowedOnConstructable;

                GameObject DegasiFoundationModel = obj.transform.Find("BaseCell").Find("BaseAbandonedFoundationPiece").gameObject;

                Constructable DegasiFoundationConstructable = PrefabUtils.AddConstructable(obj, Info.TechType, constructableFlagsInsideOutside, DegasiFoundationModel);
                DegasiFoundationConstructable.placeDefaultDistance = PlaceDistance;
                DegasiFoundationConstructable.placeMinDistance = MinPlaceDistance;
                DegasiFoundationConstructable.placeMaxDistance = MaxPlaceDistance;
                DegasiFoundationConstructable.rotationEnabled = true;
            };

            DegasiFoundationPrefab.SetGameObject(DegasiFoundationClone);
            DegasiFoundationPrefab.SetPdaGroupCategory(TechGroup.ExteriorModules, TechCategory.ExteriorModule);

            DegasiFoundationPrefab.SetRecipe(new RecipeData(
                new Ingredient(TechType.Titanium, 4) 
                ));

            DegasiFoundationPrefab.Register();
        }
    }
}
