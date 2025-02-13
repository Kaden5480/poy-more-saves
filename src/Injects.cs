using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

using HarmonyLib;

namespace MoreSaves {
    public static class Injects {
        public static string[] filePathPrefixes = new[] {
            "Mode_Normal/PeaksData_Normal",
            "Mode_YouFallYouDie/PeaksData_YFYD",
            "Mode_FreeSolo/PeaksData_FreeSolo",
        };

        /**
         * <summary>
         * Field for injecting a custom file path.
         * </summary>
         */
        public static string filePath;

        /**
         * <summary>
         * Sets the file path given a slot to use.
         * </summary>
         * <param name="slot">The save slot to use</param>
         */
        public static void SetFilePath(int slot) {
            string prefix = filePathPrefixes[MenuSaveManager.modeSelect];
            filePath = $"{prefix}_{slot}.es3";
        }

        /**
         * <summary>
         * Checks whether an instruction is being used as a file name
         * in a given sequence of instructions, throwing an exception if it isn't.
         * </summary>
         * </param name="insts">The instructions to check</param>
         * <param name="injectInto">The instruction being injected into</param>
         */
        private static void IsFilePath(
            List<CodeInstruction> insts,
            CodeInstruction injectInto
        ) {
            CodeInstruction[] pattern = new[] {
                injectInto,
                new CodeInstruction(OpCodes.Ldc_I4_1),
                new CodeInstruction(OpCodes.Newarr, null),
                new CodeInstruction(OpCodes.Dup),
                new CodeInstruction(OpCodes.Ldc_I4_0),
                null,
                new CodeInstruction(OpCodes.Box, null),
                new CodeInstruction(OpCodes.Stelem_Ref),
                new CodeInstruction(OpCodes.Newobj, null),
            };

            int index = Helper.FindSeq(insts, pattern);

            if (index == -1) {
                throw new Exception(
                    "Unable to patch instructions, the field to inject into is not a file path"
                );
            }

            ConstructorInfo constructor = (ConstructorInfo) insts[index + 8].operand;
            bool correctType = "ES3Settings".Equals(constructor.DeclaringType.ToString());

            if (correctType == false) {
                throw new Exception(
                    "Unable to patch instructions, the field to inject into is not a file path"
                );
            }
        }

        /**
         * <summary>
         * Injects a custom file path into the specified
         * instruction, wherever it appears.
         * </summary>
         * <param name="insts">The instructions to inject into</param>
         * <param name="inst">The instruction to inject the custom file path into</param>
         */
        public static IEnumerable<CodeInstruction> InjectFilePath(
            IEnumerable<CodeInstruction> enumInsts,
            CodeInstruction injectInto
        ) {
            FieldInfo filePathInfo = AccessTools.Field(
                typeof(Injects), nameof(filePath)
            );

            List<CodeInstruction> insts = enumInsts.ToList();
            IsFilePath(insts, injectInto);

            foreach (CodeInstruction inst in insts) {
                if (injectInto.Equals(inst) == true) {
                    inst.opcode = OpCodes.Ldsfld;
                    inst.operand = filePathInfo;
                }

                yield return inst;
            }
        }
    }
}
