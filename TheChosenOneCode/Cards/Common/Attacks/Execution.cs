using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.HoverTips;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;
using TheChosenOne.TheChosenOneCode.Powers;

namespace TheChosenOne.TheChosenOneCode.Cards.Common.Attacks;

public class Execution() 
    : TheChosenOneCard(2, CardType.Attack, CardRarity.Common, TargetType.AnyEnemy)
{
    private const string ExtraDamageVar = "ExtraDamage";
    
    protected override IEnumerable<DynamicVar> CanonicalVars =>
    [
        new DamageVar(10m, ValueProp.Move),
        new(ExtraDamageVar, 10m)
    ];

    protected override IEnumerable<IHoverTip> ExtraHoverTips => [HoverTipFactory.FromPower<BleedingPower>()];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        ArgumentNullException.ThrowIfNull(cardPlay.Target, "cardPlay.Target");
        await DamageCmd
            .Attack(DynamicVars.Damage.BaseValue)
            .FromCard(this, cardPlay)
            .Targeting(cardPlay.Target)
            .WithHitFx(DefaultAttackVfx)
            .Execute(choiceContext);

        if (cardPlay.Target.IsDead || !cardPlay.Target.HasPower<BleedingPower>())
            return;
        
        await DamageCmd
            .Attack(DynamicVars[ExtraDamageVar].BaseValue)
            .FromCard(this, cardPlay)
            .Targeting(cardPlay.Target)
            .WithHitFx(DefaultAttackVfx)
            .Execute(choiceContext);
    }

    protected override void OnUpgrade()
    {
        DynamicVars.Damage.UpgradeValueBy(3m);
        DynamicVars[ExtraDamageVar].UpgradeValueBy(3m);
    }
}