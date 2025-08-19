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
using System.Collections;

namespace Extra_Decor_Rusty_Pack.Buildables.Misc.Fragments.Cyclops
{
    public static class BuildableLaserCutterFragment
    {
        public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static string iconPath = Path.Combine(modFolder, "Assets", "Fragments", "LaserCutter", "LaserCutter.png");
        public static PrefabInfo Info { get; } = PrefabInfo.WithTechType("BuildableLaserCutterFragment", "Laser Cutter Fragment", "Laser cutter fragment from Aurora's wreckages. Please return to the Alterra Corporation immediately.")
            .WithIcon(ImageUtils.LoadSpriteFromFile(iconPath));

        public static void Register()
        {
            float PlaceDistance = 10;
            float MinPlaceDistance = 0;
            float MaxPlaceDistance = 20;
            CustomPrefab LaserCutterFragmentPrefab = new CustomPrefab(Info);
            CloneTemplate LaserCutterFragmentClone = new CloneTemplate(Info, "aeff4dad-8256-475b-a764-d5e7028220ce");
            
            LaserCutterFragmentClone.ModifyPrefab += obj =>
            {
                ConstructableFlags constructableFlagsInsideOutside = ConstructableFlags.Outside | ConstructableFlags.Inside | ConstructableFlags.Rotatable | ConstructableFlags.Ground | ConstructableFlags.AllowedOnConstructable;

                GameObject LaserCutterFragmentModel = obj.transform.Find("Laser_Cutter_damaged").gameObject;
                LaserCutterFragmentModel.EnsureComponent<LargeWorldEntity>();
                LargeWorldEntity.Register(LaserCutterFragmentModel);

                Constructable LaserCutterFragmentConstructable = PrefabUtils.AddConstructable(obj, Info.TechType, constructableFlagsInsideOutside, LaserCutterFragmentModel);
                LaserCutterFragmentConstructable.placeDefaultDistance = PlaceDistance;
                LaserCutterFragmentConstructable.placeMinDistance = MinPlaceDistance;
                LaserCutterFragmentConstructable.placeMaxDistance = MaxPlaceDistance;
                LaserCutterFragmentConstructable.rotationEnabled = true;
                //var LargeWorldStreamer = LaserCutterFragmentModel.transform.parent.gameObject.GetComponent<LargeWorldStreamer>();
                //yield return new WaitUntil(() => LargeWorldStreamer.IsReady());
                obj.AddComponent<ImmuneToPropulsioncannon>();
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
