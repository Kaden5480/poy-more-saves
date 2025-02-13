using System;
using System.Collections.Generic;
using System.Reflection.Emit;

using HarmonyLib;

namespace MoreSaves.Patches {
    /**
     * <summary>
     * Injects the file path into "text2" (ldloc.2)
     * </summary>
     */
    [HarmonyPatch(typeof(MenuSaveManager), "PlaySlot")]
    static class PatchMenuSaveManagerPlay {
        static void Prefix(int slotToUse) {
            Injects.SetFilePath(slotToUse);
            Console.WriteLine($"MenuSaveManager.PlaySlot: {Injects.filePath}");
        }

        static IEnumerable<CodeInstruction> Transpiler(
            IEnumerable<CodeInstruction> insts
        ) {
            return Injects.InjectFilePath(
                insts, new CodeInstruction(OpCodes.Ldloc_2)
            );
        }
    }

    /**
     * <summary>
     * Injects the file path into "text" (ldloc.0)
     * </summary>
     */
    [HarmonyPatch(typeof(MenuSaveManager), "SaveNewGame")]
    static class PatchMenuSaveManagerNew {
        static void Prefix(int slotToUse) {
            Injects.SetFilePath(slotToUse);
            Console.WriteLine($"MenuSaveManager.SaveNewGame: {Injects.filePath}");
        }

        static IEnumerable<CodeInstruction> Transpiler(
            IEnumerable<CodeInstruction> insts
        ) {
            return Injects.InjectFilePath(
                insts, new CodeInstruction(OpCodes.Ldloc_0)
            );
        }
    }
}
