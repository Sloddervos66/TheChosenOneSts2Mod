using System.Reflection;
using HarmonyLib;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Nodes.Combat;
using TheChosenOne.TheChosenOneCode.Minions;

namespace TheChosenOne.TheChosenOneCode.Patches;

[HarmonyPatch]
public class AllowMinionTargetingPatch
{
    public static MethodBase TargetMethod()
    {
        return AccessTools.Method(
            typeof(NTargetManager),
            "AllowedToTargetCreature",
            [typeof(Creature)]
        );
    }

    public static void Postfix(NTargetManager __instance, Creature __0, ref bool __result)
    {
        if (__result || __0.IsDead)
            return;

        if (__0.Monster is BaseMinion)
            __result = true;
    }
}