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
using UnityEngine.Experimental.GlobalIllumination;

namespace Extra_Decor_Rusty_Pack.Buildables.Exterior
{
    public static class BuildableLifePodSeat1
    {
        public static string modFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static string iconPath = Path.Combine(modFolder, "Assets", "Lifepods", "Lifepod19.png");
        public static PrefabInfo Info { get; } = PrefabInfo.WithTechType("BuildableLifePodSeat1", "Life Pod Seat 1", "Alterra escape pod from the Aurora. Highly damaged")
            .WithIcon(ImageUtils.LoadSpriteFromFile(iconPath));

        public static void Register()
        {
            float PlaceDistance = 10;
            float MinPlaceDistance = 1;
            float MaxPlaceDistance = 15;
            CustomPrefab LifePodSeat1Prefab = new CustomPrefab(Info);
            CloneTemplate LifePodSeat1Clone = new CloneTemplate(Info, "3894aeaf-e1f9-426a-9249-6a4968ac2d8b");
            LifePodSeat1Clone.ModifyPrefab += obj =>
            {
                ConstructableFlags constructableFlagsInsideOutside = ConstructableFlags.Inside | ConstructableFlags.Wall | ConstructableFlags.AllowedOnConstructable;

                GameObject LifePodSeat1Model = obj.transform.Find("life_pod_exploded_02_01").gameObject.transform.Find("interior").gameObject.transform.Find("life_pod_seat_01_base").gameObject;
                LifePodSeat1Model.transform.parent = LifePodSeat1Model.transform.parent.parent;
                LifePodSeat1Model.transform.position = new Vector3(0,0,0);
                MeshFilter MshFlt = LifePodSeat1Model.GetComponent<MeshFilter>();
                Bounds bounds = MshFlt.sharedMesh.bounds;
                BoxCollider Coll = LifePodSeat1Model.AddComponent<BoxCollider>();
                Coll.center = bounds.center;
                Coll.size = bounds.size;
                SkyApplier skyApplierDelete = LifePodSeat1Model.transform.parent.parent.GetComponent<SkyApplier>();
                Object.Destroy(skyApplierDelete);
                SkyApplier skyApplier = LifePodSeat1Model.transform.parent.parent.GetComponent<SkyApplier>();
                skyApplier.anchorSky = Skies.BaseInterior;


                //foreach (GameObject Cube in obj.transform.Find("LOD").gameObject.transform)
                //{
                //    if (Cube.name.StartsWith("Cube") && Cube.name != "Cube (37)")
                //    {
                //        Object.Destroy(Cube);
                //    }
                //};
                // I cant code 😭😭😭
                GameObject[] toDelete = new GameObject[]
                {
                    LifePodSeat1Model.transform.parent.Find("exterior").gameObject,
                    LifePodSeat1Model.transform.parent.Find("interior").gameObject,
                    obj.transform.Find("LOD").gameObject
                };

                foreach (var gameObject in toDelete)
                {
                    Object.Destroy(gameObject);
                };

                Constructable LifePodSeat1Constructable = PrefabUtils.AddConstructable(obj, Info.TechType, constructableFlagsInsideOutside, LifePodSeat1Model);
                LifePodSeat1Constructable.placeDefaultDistance = PlaceDistance;
                LifePodSeat1Constructable.placeMinDistance = MinPlaceDistance;
                LifePodSeat1Constructable.placeMaxDistance = MaxPlaceDistance;
                LifePodSeat1Constructable.rotationEnabled = true;
            };

            LifePodSeat1Prefab.SetGameObject(LifePodSeat1Clone);
            LifePodSeat1Prefab.SetPdaGroupCategory(TechGroup.InteriorModules, TechCategory.InteriorModule);

            LifePodSeat1Prefab.SetRecipe(new RecipeData(
                new Ingredient(TechType.Titanium, 3), 
                new Ingredient(TechType.Glass, 1)
                ));

            LifePodSeat1Prefab.Register();
        }
    }
}
