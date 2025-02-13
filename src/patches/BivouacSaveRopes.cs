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
    [HarmonyPatch(typeof(BivouacSaveRopes), "RemoveAllBivouacRopes")]
    static class PatchBivouacRemoveRopes {
        static void Prefix() {
            Console.WriteLine($"BivouacSaveRopes.RemoveAllBivouacRopes: {Injects.filePath}");
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
    [HarmonyPatch(typeof(BivouacSaveRopes), "SaveStoredRopes")]
    static class PatchBivouacSaveRopes {
        static void Prefix() {
            Console.WriteLine($"BivouacSaveRopes.SaveStoredRopes: {Injects.filePath}");
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
    [HarmonyPatch(typeof(BivouacSaveRopes), "LoadStoredropes")]
    static class PatchBivouacLoadRopes {
        static void Prefix() {
            Console.WriteLine($"BivouacSaveRopes.LoadStoredRopes: {Injects.filePath}");
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
