using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.HoverTips;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.Powers;
using MegaCrit.Sts2.Core.ValueProps;
using TheChosenOne.TheChosenOneCode.Powers;

namespace TheChosenOne.TheChosenOneCode.Cards.Common.Attacks;

public class Impalement() 
    : TheChosenOneCard(1, CardType.Attack, CardRarity.Common, TargetType.AnyEnemy)
{
    protected override IEnumerable<DynamicVar> CanonicalVars =>
    [
        new DamageVar(8m, ValueProp.Move),
        new PowerVar<BleedingPower>(nameof(BleedingPower), 2m)
    ];

    protected override IEnumerable<IHoverTip> ExtraHoverTips =>
    [
        HoverTipFactory.FromPower<RitualPower>(),
        HoverTipFactory.FromPower<BleedingPower>()
    ];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        ArgumentNullException.ThrowIfNull(cardPlay.Target, "cardPlay.Target");
        await DamageCmd
            .Attack(DynamicVars.Damage.BaseValue)
            .FromCard(this, cardPlay)
            .Targeting(cardPlay.Target)
            .WithHitFx(DefaultAttackVfx)
            .Execute(choiceContext);

        if (cardPlay.Target.IsDead || Owner.Creature.GetPowerAmount<RitualPower>() < 4)
            return;

        await PowerCmd.Apply<BleedingPower>(
            choiceContext,
            cardPlay.Target,
            DynamicVars[nameof(BleedingPower)].BaseValue,
            cardPlay.Player.Creature,
            this
        );
    }

    protected override void OnUpgrade()
    {
        DynamicVars.Damage.UpgradeValueBy(3m);
    }
}