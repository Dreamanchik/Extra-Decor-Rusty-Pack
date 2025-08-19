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
    public static class BuildableDegasiRustedPlanterPot2
    {
        public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static string iconPath = Path.Combine(modFolder, "Assets", "Exterior", "RustedPlanterPot2", "RustedPlanterPot2Icon.png");
        public static string texturePath = Path.Combine(modFolder, "Assets", "Exterior", "RustedPlanterPot2", "RustedPlanterPot2Texture.png");
        public static string normalPath = Path.Combine(modFolder, "Assets", "Exterior", "RustedPlanterPot2", "RustedPlanterPot2Normal.png");
        public static PrefabInfo Info { get; } = PrefabInfo.WithTechType("BuildableDegasiRustedPlanterPot2", "Degasi Rusted Basic Plant Pot", "Rusted Basic Plant Pot found on the degasi bases.")
            .WithIcon(ImageUtils.LoadSpriteFromFile(iconPath));

        public static Texture2D Texture = ImageUtils.LoadTextureFromFile(texturePath);
        public static Texture2D Normal = ImageUtils.LoadTextureFromFile(normalPath);

        public static void Register()
        {
            CustomPrefab DegasiRustedPlanterPot2Prefab = new CustomPrefab(Info);
            CloneTemplate DegasiRustedPlanterPot2Clone = new CloneTemplate(Info, TechType.PlanterPot2);

            DegasiRustedPlanterPot2Clone.ModifyPrefab += obj =>
            {
                MeshRenderer mr = obj.transform.Find("model").gameObject.transform.Find("Base_interior_Planter_Pot_02").gameObject.transform.Find("Base_interior_Planter_Pot_02 1").gameObject.GetComponent<MeshRenderer>();
                mr.material.mainTexture = Texture;
                mr.material.SetTexture(ShaderPropertyID._SpecTex, Texture);
                mr.material.SetTexture(ShaderPropertyID._DetailNormalMap, Normal);
            };

            DegasiRustedPlanterPot2Prefab.SetGameObject(DegasiRustedPlanterPot2Clone);
            DegasiRustedPlanterPot2Prefab.SetPdaGroupCategory(TechGroup.InteriorModules, TechCategory.InteriorModule).SetBuildable(true);
            DegasiRustedPlanterPot2Prefab.SetUnlock(TechType.PlanterPot2);

            DegasiRustedPlanterPot2Prefab.SetRecipe(new RecipeData(
                new Ingredient(TechType.Glass, 1), 
                new Ingredient(TechType.Titanium, 2) 
                ));

            DegasiRustedPlanterPot2Prefab.Register();
        }
    }
}
