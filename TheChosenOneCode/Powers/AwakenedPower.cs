using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.HoverTips;
using MegaCrit.Sts2.Core.Models.Powers;

namespace TheChosenOne.TheChosenOneCode.Powers;

public sealed class AwakenedPower : TheChosenOnePower
{
    public const string Name = nameof(AwakenedPower);
    
    public override PowerType Type => PowerType.Buff;
    public override PowerStackType StackType => PowerStackType.None;
    
    protected override IEnumerable<IHoverTip> ExtraHoverTips => [HoverTipFactory.FromPower<StrengthPower>()];

    public override async Task AfterCardPlayed(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        if (cardPlay.Card.Type != CardType.Power ||
            cardPlay.Player != Owner.Player)
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