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
    public static class BuildableDegasiFoundation1
    {
        public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static string iconPath = Path.Combine(modFolder, "Assets", "Degasi", "Foundation1.png");
        public static PrefabInfo Info { get; } = PrefabInfo.WithTechType("BuildableDegasiFoundation1", "Degasi Foundation 1", "Foundation built by the Degasi.")
            .WithIcon(ImageUtils.LoadSpriteFromFile(iconPath));

        public static void Register()
        {
            float PlaceDistance = 10;
            float MinPlaceDistance = 5;
            float MaxPlaceDistance = 20;
            CustomPrefab DegasiFoundationPrefab = new CustomPrefab(Info);
            CloneTemplate DegasiFoundationClone = new CloneTemplate(Info, "026c39c1-d0cc-442c-aa42-e574c9c281b2");

            DegasiFoundationClone.ModifyPrefab += obj =>
            {
                ConstructableFlags constructableFlagsInsideOutside = ConstructableFlags.Outside | ConstructableFlags.Inside | ConstructableFlags.Rotatable | ConstructableFlags.Ground | ConstructableFlags.AllowedOnConstructable;

                GameObject DegasiFoundationModel = obj.transform.Find("BaseCell").gameObject;

                Constructable DegasiFoundationConstructable = PrefabUtils.AddConstructable(obj, Info.TechType, constructableFlagsInsideOutside, DegasiFoundationModel);
                DegasiFoundationConstructable.placeDefaultDistance = PlaceDistance;
                DegasiFoundationConstructable.placeMinDistance = MinPlaceDistance;
                DegasiFoundationConstructable.placeMaxDistance = MaxPlaceDistance;
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
