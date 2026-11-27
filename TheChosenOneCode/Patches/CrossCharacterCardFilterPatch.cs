using HarmonyLib;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Runs;
using TheChosenOne.TheChosenOneCode.Cards;

namespace TheChosenOne.TheChosenOneCode.Patches;

[HarmonyPatch(typeof(CardCreationOptions), nameof(CardCreationOptions.GetPossibleCards))]
public class CrossCharacterCardFilterPatch
{
    public static void Postfix(CardCreationOptions __instance, ref IEnumerable<CardModel> __result)
    {
        if (__instance.Source != CardCreationSource.Other)
            return;
        
        __result = __result.Where(card =>
            card is not TheChosenOneCard customCard ||
            customCard.AllowCrossCharacterGeneration);
    }
}