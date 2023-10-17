using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using Extra_Decor_Rusty_Pack.Buildables.Exterior;
using System.Reflection;
using Extra_Decor_Rusty_Pack.Buildables.Interior;
using Extra_Decor_Rusty_Pack.Buildables.Misc.Fragments.Cyclops;

namespace Extra_Decor_Rusty_Pack
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    [BepInDependency("com.snmodding.nautilus")]
    public class Plugin : BaseUnityPlugin
    {
        public new static ManualLogSource Logger { get; private set; }

        private static Assembly Assembly { get; } = Assembly.GetExecutingAssembly();

        private void Awake()
        {
            // set project-scoped logger instance
            Logger = base.Logger;

            // Initialize custom prefabs
            InitializePrefabs();

            // register harmony patches, if there are any
            Harmony.CreateAndPatchAll(Assembly, $"{PluginInfo.PLUGIN_GUID}");
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
        }

        private void InitializePrefabs()
        {
            // Lifepods
            BuildableLifePod2Exploded.Register();
            BuildableLifePod3Exploded.Register();
            BuildableLifePod4Exploded.Register();
            BuildableLifePod6Exploded.Register();
            BuildableLifePod7Exploded.Register();
            BuildableLifePod12Exploded.Register();
            BuildableLifePod13Exploded.Register();
            BuildableLifePod17Exploded.Register();
            BuildableLifePod19Exploded.Register();
            // Alterra
            BuildableAuroraDoorFrameMedium.Register();
            BuildableAuroraDoorFrameThin.Register();
            BuildableAuroraDoorMedium.Register();
            BuildableAuroraDoorThin.Register();
            BuildableAuroraDoorBulkheadMedium.Register();
            BuildableAuroraDoorBulkheadThin.Register();
            BuildableReinforceHull.Register();
            //BuildableHullCrack.Register(); --- Cant rotate things :(
            BuildableExplodedDebris6.Register();
            BuildableExplodedDebris7.Register();
            BuildableExplodedDebris16.Register();
            BuildableExplodedDebris18.Register();
            BuildableExplodedDebris20.Register();
            // Degasi --- Most of the bases are broken and will be added back after the issues are fixed
            //BuildableDegasiAbandonedBase1.Register();
            //BuildableDegasiAbandonedBase2.Register();
            BuildableDegasiFoundation1.Register();
            BuildableDegasiFoundation2.Register();
            BuildableDegasiFoundation3.Register();
            //BuildableDegasiFloatingIslandBase1.Register();
            //BuildableDegasiFloatingIslandBase2.Register();
            //BuildableDegasiFloatingIslandBase3.Register();
            //BuildableDegasiGrandReefBase.Register();
            //BuildableDegasiJellyshroomBase1.Register();
            //BuildableDegasiRustedSpotlight.Register();
            // Fragments
            BuildableBeaconFragment.Register();
            BuildableBioReactorFragment4.Register();
            BuildableConstructorFragment1.Register();
            BuildableConstructorFragment2.Register();
            BuildableConstructorFragment3.Register();
            BuildableConstructorFragment4.Register();
            BuildableCyclopsBridgeFragment1.Register();
            BuildableCyclopsBridgeFragment2.Register();
            BuildableCyclopsBridgeFragment3.Register();
            BuildableCyclopsEngineFragment1.Register();
            BuildableCyclopsEngineFragment2.Register();
            BuildableCyclopsEngineFragment3.Register();
            BuildableCyclopsHullFragment1.Register();
            BuildableCyclopsHullFragment2.Register();
            BuildableCyclopsHullFragment3.Register();
            BuildableCyclopsHullFragment4.Register();
            BuildableCyclopsHullFragment5.Register();
            BuildableCyclopsHullFragment6.Register();
            BuildableCyclopsHullFragment7.Register();
            BuildableCyclopsHullFragment8.Register();
            BuildableExosuitFragment1.Register();
            BuildableExosuitFragment2.Register();
            BuildableExosuitFragment3.Register();
            BuildableExosuitFragment4.Register();
            BuildableExosuitFragment5.Register();
            BuildableExosuitFragment6.Register();
            BuildableExosuitGrapplingArmFragment.Register();
            BuildableExosuitTorpedoArmFragment.Register();
            BuildableExosuitPropulsionArmFragment.Register();
            BuildableExosuitDrillArmFragment.Register();
            BuildableGravSphereFragment.Register();
            BuildableLaserCutterFragment.Register();
            BuildableLedLightFragment.Register();
            BuildableMapRoomFragment1.Register();
            BuildableMapRoomFragment2.Register();
            BuildableMapRoomFragment3.Register();
            BuildableMapRoomFragment4.Register();
            BuildableMoonPoolFragment1.Register();
            BuildableMoonPoolFragment2.Register();
            BuildableMoonPoolFragment3.Register();
            BuildableMoonPoolFragment4.Register();
            BuildableMoonPoolFragment5.Register();
            BuildableMoonPoolFragment6.Register();
            BuildablePowerCellChargerFragment1.Register();
            BuildablePowerTransmitterFragment.Register();
            BuildablePropulsionCannonFragment.Register();
            BuildableSeaglideFragment1.Register();
            BuildableStasisRifleFragment1.Register();
            BuildableThermalPlantFragment2.Register();
            BuildableWorkbenchFragment1.Register();
        }
    }
}