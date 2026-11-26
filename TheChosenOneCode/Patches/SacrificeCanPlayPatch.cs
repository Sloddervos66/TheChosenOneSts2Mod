using System.Reflection;
using HarmonyLib;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Models;
using TheChosenOne.TheChosenOneCode.Cards;
using TheChosenOne.TheChosenOneCode.Enums;
using TheChosenOne.TheChosenOneCode.Minions;

namespace TheChosenOne.TheChosenOneCode.Patches;

[HarmonyPatch]
public class SacrificeCanPlayPatch
{
    public static MethodBase TargetMethod()
    {
        return AccessTools.Method(
            typeof(CardModel),
            nameof(CardModel.CanPlay),
            [
                typeof(UnplayableReason).MakeByRefType(),
                typeof(AbstractModel).MakeByRefType()
            ]
        );
    }
    
    public static void Postfix(CardModel __instance, ref UnplayableReason __0, ref AbstractModel? __1, ref bool __result)
    {
        if (__instance is not TheChosenOneCard { Status: CardStatus.Sacrifice, TargetType: TargetType.AnyAlly } card)
            return;

        var hasMinion = card.Owner.Creature.Pets
            .Any(c => c.Monster is BaseMinion);
        if (!hasMinion)
            return;

        __0 &= ~UnplayableReason.NoLivingAllies;
        __result = __0 == UnplayableReason.None;
    }
}