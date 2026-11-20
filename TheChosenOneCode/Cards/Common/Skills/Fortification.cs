using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.HoverTips;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.Powers;
using MegaCrit.Sts2.Core.ValueProps;

namespace TheChosenOne.TheChosenOneCode.Cards.Common.Skills;

public class Fortification() 
    : TheChosenOneCard(2, CardType.Skill, CardRarity.Common, TargetType.Self)
{
    protected override IEnumerable<DynamicVar> CanonicalVars =>
    [
        new CalculationBaseVar(6m),
        new CalculationExtraVar(2m),
        new CalculatedBlockVar(ValueProp.Move)
            .WithMultiplier((card, _) => 
                (Math.Floor(card.Owner.Creature.GetPowerAmount<RitualPower>() / 2m))
            )
    ];

    protected override IEnumerable<IHoverTip> ExtraHoverTips => [HoverTipFactory.FromPower<RitualPower>()];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await CreatureCmd
            .GainBlock(
                Owner.Creature, 
                DynamicVars.CalculatedBlock.Calculate(cardPlay.Target),
                DynamicVars.CalculatedBlock.Props, 
                cardPlay
            );
    }

    protected override void OnUpgrade()
    {
        DynamicVars.CalculationBase.UpgradeValueBy(2m);
    }
}