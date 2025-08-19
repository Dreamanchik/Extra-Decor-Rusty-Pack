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
    public static class BuildableDegasiRustedSpotlight
    {
        public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static string iconPath = Path.Combine(modFolder, "Assets", "Exterior", "RustedSpotlight", "RustedSpotlightIcon.png");
        public static string texturePath = Path.Combine(modFolder, "Assets", "Exterior", "RustedSpotlight", "RustedSpotlightTexture.png");
        public static string normalPath = Path.Combine(modFolder, "Assets", "Exterior", "RustedSpotlight", "RustedSpotlightNormal.png");
        public static PrefabInfo Info { get; } = PrefabInfo.WithTechType("BuildableDegasiRustedSpotlight", "Degasi Rusted Spotlight", "Rusted spotlight found on the degasi bases.")
            .WithIcon(ImageUtils.LoadSpriteFromFile(iconPath));

        public static Texture2D Texture = ImageUtils.LoadTextureFromFile(texturePath);
        public static Texture2D Normal = ImageUtils.LoadTextureFromFile(normalPath);

        public static void Register()
        {
            CustomPrefab DegasiRustedSpotlightPrefab = new CustomPrefab(Info);
            CloneTemplate DegasiRustedSpotlightClone = new CloneTemplate(Info, TechType.Spotlight);

            DegasiRustedSpotlightClone.ModifyPrefab += obj =>
            {
                var rendered = obj.GetAllComponentsInChildren<Renderer>();
                foreach (var ren in rendered)
                {
                    ren.material.mainTexture = Texture;
                    ren.material.SetTexture(ShaderPropertyID._SpecTex, Texture);
                    ren.material.SetTexture(ShaderPropertyID._DetailNormalMap, Normal);
                }
            };

            DegasiRustedSpotlightPrefab.SetGameObject(DegasiRustedSpotlightClone);
            DegasiRustedSpotlightPrefab.SetPdaGroupCategory(TechGroup.ExteriorModules, TechCategory.ExteriorModule).SetBuildable(true);
            DegasiRustedSpotlightPrefab.SetUnlock(TechType.Spotlight);

            DegasiRustedSpotlightPrefab.SetRecipe(new RecipeData(
                new Ingredient(TechType.Glass, 1), 
                new Ingredient(TechType.Titanium, 2) 
                ));

            DegasiRustedSpotlightPrefab.Register();
        }
    }
}
