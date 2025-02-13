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
    [HarmonyPatch(typeof(NPCEvents), "TimeAttackStoreDefaultArrays")]
    static class PatchNPCEvents {
        static void Prefix() {
            Console.WriteLine($"NPCEvents.TimeAttackStoreDefaultArrays: {Injects.filePath}");
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
