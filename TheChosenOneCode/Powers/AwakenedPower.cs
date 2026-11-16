using BaseLib.Utils;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.HoverTips;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Cards;
using MegaCrit.Sts2.Core.Models.Powers;

namespace TheChosenOne.TheChosenOneCode.Powers;

// Changes form to Awakened
// Grants 2 strength on apply
// Grants a new power that whenever a power card is played gain strength equal to the amount of energy
public sealed class AwakenedPower : TheChosenOnePower
{
    public const string Name = nameof(AwakenedPower);
    protected override IEnumerable<DynamicVar> CanonicalVars =>
    [
        new PowerVar<StrengthPower>(3m)
    ];

    protected override IEnumerable<IHoverTip> ExtraHoverTips =>
    [
        HoverTipFactory.FromPower<StrengthPower>()
    ];

    public override PowerType Type => PowerType.Buff;
    public override PowerStackType StackType => PowerStackType.None;

    public override async Task AfterApplied(Creature? applier, CardModel? cardSource)
    {
        if (Owner != applier)
            return;

        await PowerCmd.Apply<StrengthPower>(
            new ThrowingPlayerChoiceContext(),
            Owner,
            DynamicVars.Strength.BaseValue,
            Owner,
            cardSource
        );
    }

    public override async Task AfterCardPlayed(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        if (cardPlay.Card.Type != CardType.Power)
            return;

        var cost = cardPlay.Card.EnergyCost.Canonical;
        
        await PowerCmd.Apply<StrengthPower>(
            choiceContext,
            Owner,
            cost,
            Owner,
            null
        );
    }
}