using System;
using System.Collections.Generic;
using System.Reflection.Emit;

using HarmonyLib;

namespace MoreSaves.Patches {
    /**
     * <summary>
     * Injects the file path into "text3" (ldloc.2)
     * </summary>
     */
    [HarmonyPatch(typeof(GameManager), "Load")]
    static class PatchGameManagerLoad {
        static void Prefix() {
            Console.WriteLine($"GameManager.Load: {Injects.filePath}");
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
     * Injects the file path into "text3" (ldloc.2)
     * </summary>
     */
    [HarmonyPatch(typeof(GameManager), "Save")]
    static class PatchGameManagerSave {
        static void Prefix() {
            Console.WriteLine($"GameManager.Save: {Injects.filePath}");
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
     * Injects the file path into "text3" (ldloc.2)
     * </summary>
     */
    [HarmonyPatch(typeof(GameManager), "CreateBackup")]
    static class PatchGameManagerCreateBackup {
        static void Prefix() {
            Console.WriteLine($"GameManager.CreateBackup: {Injects.filePath}");
        }

        static IEnumerable<CodeInstruction> Transpiler(
            IEnumerable<CodeInstruction> insts
        ) {
            return Injects.InjectFilePath(
                insts, new CodeInstruction(OpCodes.Ldloc_2)
            );
        }
    }
}
