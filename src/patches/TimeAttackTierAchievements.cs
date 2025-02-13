using System;
using System.Collections.Generic;
using System.Reflection.Emit;

using HarmonyLib;

namespace MoreSaves.Patches {
    /**
     * <summary>
     * Injects the file path into "text5" (ldloc.s 4)
     * </summary>
     */
    [HarmonyPatch(typeof(TimeAttackTierAchievements), "ScoreTimeAttackAchievement")]
    static class PatchTimeAttackTierAchievements {
        static void Prefix() {
            Console.WriteLine($"TimeAttackTierAchievements.ScoreTimeAttackAchievement: {Injects.filePath}");
        }

        static IEnumerable<CodeInstruction> Transpiler(
            IEnumerable<CodeInstruction> insts
        ) {
            return Injects.InjectFilePath(
                insts, new CodeInstruction(OpCodes.Ldloc_S, 4)
            );
        }
    }
}
