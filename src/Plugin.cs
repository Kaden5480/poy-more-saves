using HarmonyLib;

#if BEPINEX
using BepInEx;

namespace MoreSaves {
    [BepInPlugin("com.github.Kaden5480.poy-more-saves", "MoreSaves", PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin {
        public void Awake() {
            Harmony.CreateAndPatchAll(typeof(Patches.PatchBivouacRemoveRopes));
            Harmony.CreateAndPatchAll(typeof(Patches.PatchBivouacSaveRopes));
            Harmony.CreateAndPatchAll(typeof(Patches.PatchBivouacLoadRopes));
            Harmony.CreateAndPatchAll(typeof(Patches.PatchGameManagerLoad));
            Harmony.CreateAndPatchAll(typeof(Patches.PatchGameManagerSave));
            Harmony.CreateAndPatchAll(typeof(Patches.PatchGameManagerCreateBackup));
            Harmony.CreateAndPatchAll(typeof(Patches.PatchMenuSaveManagerPlay));
            Harmony.CreateAndPatchAll(typeof(Patches.PatchMenuSaveManagerNew));
            Harmony.CreateAndPatchAll(typeof(Patches.PatchNPCEvents));
            Harmony.CreateAndPatchAll(typeof(Patches.PatchRopeCabinDescription));
            Harmony.CreateAndPatchAll(typeof(Patches.PatchTimeAttackSave));
            Harmony.CreateAndPatchAll(typeof(Patches.PatchTimeAttackLoad));
            Harmony.CreateAndPatchAll(typeof(Patches.PatchTimeAttackSetterSave));
            Harmony.CreateAndPatchAll(typeof(Patches.PatchTimeAttackSetterLoad));
            Harmony.CreateAndPatchAll(typeof(Patches.PatchTimeAttackTierAchievements));
        }

#elif MELONLOADER
using MelonLoader;

[assembly: MelonInfo(typeof(MoreSaves.Plugin), "MoreSaves", PluginInfo.PLUGIN_VERSION, "Kaden5480")]
[assembly: MelonGame("TraipseWare", "Peaks of Yore")]

namespace MoreSaves {
    public class Plugin: MelonMod {

#endif

    }
}
