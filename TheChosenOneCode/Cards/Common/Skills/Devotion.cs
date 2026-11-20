using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.HoverTips;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.Powers;
using MegaCrit.Sts2.Core.ValueProps;

namespace TheChosenOne.TheChosenOneCode.Cards.Common.Skills;

public class Devotion() 
    : TheChosenOneCard(1, CardType.Skill, CardRarity.Common, TargetType.Self)
{
    protected override IEnumerable<DynamicVar> CanonicalVars =>
    [
        new PowerVar<RitualPower>(1m),
        new BlockVar(5m, ValueProp.Move)
    ];

    protected override IEnumerable<IHoverTip> ExtraHoverTips => [HoverTipFactory.FromPower<RitualPower>(10)];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await PowerCmd.Apply<RitualPower>(
            choiceContext, 
            Owner.Creature, 
            DynamicVars[nameof(RitualPower)].BaseValue,
            Owner.Creature,
            this
        );

        if (Owner.Creature.GetPowerAmount<RitualPower>() < 3)
            return;

        await CreatureCmd.GainBlock(
            Owner.Creature,
            DynamicVars.Block,
            cardPlay
        );
    }

    protected override void OnUpgrade()
    {
        DynamicVars[nameof(RitualPower)].UpgradeValueBy(1m);
    }
}