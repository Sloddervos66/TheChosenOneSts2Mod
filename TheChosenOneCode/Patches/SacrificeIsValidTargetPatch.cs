using System.Reflection;
using HarmonyLib;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Models;
using TheChosenOne.TheChosenOneCode.Cards;
using TheChosenOne.TheChosenOneCode.Enums;
using TheChosenOne.TheChosenOneCode.Minions;

namespace TheChosenOne.TheChosenOneCode.Patches;

[HarmonyPatch]
public class SacrificeIsValidTargetPatch
{
    public static MethodBase TargetMethod()
    {
        return AccessTools.Method(
            typeof(CardModel),
            nameof(CardModel.IsValidTarget),
            [typeof(Creature)]
        );
    }
    
    public static void Postfix(CardModel __instance, Creature? __0, ref bool __result)
    {
        if (__instance is not TheChosenOneCard card)
            return;

        if (card.Status != CardStatus.Sacrifice ||
            card.TargetType != TargetType.AnyAlly)
            return;
        
        if (__0?.Monster is BaseMinion)
            __result = true;
    }
}