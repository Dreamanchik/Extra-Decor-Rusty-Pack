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
    public static class BuildableDegasiRustedPlanterBox
    {
        public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static string iconPath = Path.Combine(modFolder, "Assets", "Exterior", "RustedPlanterBox", "RustedPlanterBoxIcon.png");
        public static string texturePath = Path.Combine(modFolder, "Assets", "Exterior", "RustedPlanterBox", "RustedPlanterBoxTexture.png");
        public static string normalPath = Path.Combine(modFolder, "Assets", "Exterior", "RustedPlanterBox", "RustedPlanterBoxNormal.png");
        public static PrefabInfo Info { get; } = PrefabInfo.WithTechType("BuildableDegasiRustedPlanterBox", "Degasi Rusted Planter Box", "Rusted Planter Box found on the degasi bases.")
            .WithIcon(ImageUtils.LoadSpriteFromFile(iconPath));

        public static Texture2D Texture = ImageUtils.LoadTextureFromFile(texturePath);
        public static Texture2D Normal = ImageUtils.LoadTextureFromFile(normalPath);

        public static void Register()
        {
            CustomPrefab DegasiRustedPlanterBoxPrefab = new CustomPrefab(Info);
            CloneTemplate DegasiRustedPlanterBoxClone = new CloneTemplate(Info, TechType.PlanterBox);

            DegasiRustedPlanterBoxClone.ModifyPrefab += obj =>
            {
                MeshRenderer mr = obj.transform.Find("model").gameObject.transform.Find("Base_interior_Planter_Tray_01").gameObject.transform.Find("Base_interior_Planter_Tray_01 1").gameObject.GetComponent<MeshRenderer>();
                mr.material.mainTexture = Texture;
                mr.material.SetTexture(ShaderPropertyID._SpecTex, Texture);
                mr.material.SetTexture(ShaderPropertyID._DetailNormalMap, Normal);
            };

            DegasiRustedPlanterBoxPrefab.SetGameObject(DegasiRustedPlanterBoxClone);
            DegasiRustedPlanterBoxPrefab.SetPdaGroupCategory(TechGroup.InteriorModules, TechCategory.InteriorModule).SetBuildable(true);
            DegasiRustedPlanterBoxPrefab.SetUnlock(TechType.PlanterBox)

            DegasiRustedPlanterBoxPrefab.SetRecipe(new RecipeData(
                new Ingredient(TechType.Glass, 1), 
                new Ingredient(TechType.Titanium, 2) 
                ));

            DegasiRustedPlanterBoxPrefab.Register();
        }
    }
}
