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
    public static class BuildableDegasiRustedFarmingTray
    {
        public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static string iconPath = Path.Combine(modFolder, "Assets", "Exterior", "RustedFarmingTray", "RustedFarmingTrayIcon.png");
        public static string texturePath = Path.Combine(modFolder, "Assets", "Exterior", "RustedFarmingTray", "RustedFarmingTrayTexture.png");
        public static string normalPath = Path.Combine(modFolder, "Assets", "Exterior", "RustedFarmingTray", "RustedFarmingTrayNormal.png");
        public static PrefabInfo Info { get; } = PrefabInfo.WithTechType("BuildableDegasiRustedFarmingTray", "Degasi Rusted Farming Tray", "Rusted Farming Tray found on the degasi bases.")
            .WithIcon(ImageUtils.LoadSpriteFromFile(iconPath));

        public static Texture2D Texture = ImageUtils.LoadTextureFromFile(texturePath);
        public static Texture2D Normal = ImageUtils.LoadTextureFromFile(normalPath);

        public static void Register()
        {
            CustomPrefab DegasiRustedFarmingTrayPrefab = new CustomPrefab(Info);
            CloneTemplate DegasiRustedFarmingTrayClone = new CloneTemplate(Info, TechType.FarmingTray);

            DegasiRustedFarmingTrayClone.ModifyPrefab += obj =>
            {
                MeshRenderer mr = obj.transform.Find("model").gameObject.transform.Find("Base_exterior_Planter_Tray_01").gameObject.transform.Find("Base_exterior_Planter_Tray_01 1").gameObject.GetComponent<MeshRenderer>();
                mr.material.mainTexture = Texture;
                mr.material.SetTexture(ShaderPropertyID._SpecTex, Texture);
                mr.material.SetTexture(ShaderPropertyID._DetailNormalMap, Normal);
            };

            DegasiRustedFarmingTrayPrefab.SetGameObject(DegasiRustedFarmingTrayClone);
            DegasiRustedFarmingTrayPrefab.SetPdaGroupCategory(TechGroup.ExteriorModules, TechCategory.ExteriorModule).SetBuildable(true);

            DegasiRustedFarmingTrayPrefab.SetRecipe(new RecipeData(
                new Ingredient(TechType.Glass, 1), 
                new Ingredient(TechType.Titanium, 2) 
                ));

            DegasiRustedFarmingTrayPrefab.Register();
        }
    }
}
