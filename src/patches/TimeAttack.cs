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
    [HarmonyPatch(typeof(TimeAttack), "SaveTimeAttack")]
    static class PatchTimeAttackSave {
        static void Prefix() {
            Console.WriteLine($"TimeAttack.SaveTimeAttack: {Injects.filePath}");
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
    [HarmonyPatch(typeof(TimeAttack), "LoadSTTime")]
    static class PatchTimeAttackLoad {
        static void Prefix() {
            Console.WriteLine($"TimeAttack.LoadSTTime: {Injects.filePath}");
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
