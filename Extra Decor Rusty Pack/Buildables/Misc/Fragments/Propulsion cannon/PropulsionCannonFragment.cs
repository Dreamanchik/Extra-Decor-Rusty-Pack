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

namespace Extra_Decor_Rusty_Pack.Buildables.Misc.Fragments.Cyclops
{
    public static class BuildablePropulsionCannonFragment
    {
        public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static string iconPath = Path.Combine(modFolder, "Assets", "Fragments", "PropulsionCannon", "PropulsionCannon.png");
        public static PrefabInfo Info { get; } = PrefabInfo.WithTechType("BuildablePropulsionCannonFragment", "Propulsion Cannon Fragment", "Propulsion cannon fragment from Aurora's wreckages. Please return to the Alterra Corporation immediately.")
            .WithIcon(ImageUtils.LoadSpriteFromFile(iconPath));

        public static void Register()
        {
            float PlaceDistance = 10;
            float MinPlaceDistance = 0;
            float MaxPlaceDistance = 20;
            CustomPrefab PropulsionCannonPrefab = new CustomPrefab(Info);
            CloneTemplate PropulsionCannonClone = new CloneTemplate(Info, "21e4c817-e3a7-4a0d-a931-0bc68243cb1e");

            PropulsionCannonClone.ModifyPrefab += obj =>
            {
                ConstructableFlags constructableFlagsInsideOutside = ConstructableFlags.Outside | ConstructableFlags.Inside | ConstructableFlags.Rotatable | ConstructableFlags.Ground | ConstructableFlags.AllowedOnConstructable;

                GameObject PropulsionCannonModel = obj.transform.Find("model").gameObject;

                Constructable PropulsionCannonConstructable = PrefabUtils.AddConstructable(obj, Info.TechType, constructableFlagsInsideOutside, PropulsionCannonModel);
                PropulsionCannonConstructable.placeDefaultDistance = PlaceDistance;
                PropulsionCannonConstructable.placeMinDistance = MinPlaceDistance;
                PropulsionCannonConstructable.placeMaxDistance = MaxPlaceDistance;
                PropulsionCannonConstructable.rotationEnabled = true;
            };

            PropulsionCannonPrefab.SetGameObject(PropulsionCannonClone);
            PropulsionCannonPrefab.SetPdaGroupCategory(TechGroup.ExteriorModules, TechCategory.ExteriorModule);

            PropulsionCannonPrefab.SetRecipe(new RecipeData(
                new Ingredient(TechType.Titanium, 2)
                ));

            PropulsionCannonPrefab.Register();
        }
    }
}
