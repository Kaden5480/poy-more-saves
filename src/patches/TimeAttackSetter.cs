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
    [HarmonyPatch(typeof(TimeAttackSetter), "SaveTimeAttack")]
    static class PatchTimeAttackSetterSave {
        static void Prefix() {
            Console.WriteLine($"TimeAttackSetter.SaveTimeAttack: {Injects.filePath}");
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
    [HarmonyPatch(typeof(TimeAttackSetter), "LoadBest")]
    static class PatchTimeAttackSetterLoad {
        static void Prefix() {
            Console.WriteLine($"TimeAttackSetter.LoadBest: {Injects.filePath}");
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
