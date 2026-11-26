using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;
using TheChosenOne.TheChosenOneCode.Enums;
using TheChosenOne.TheChosenOneCode.Minions;

namespace TheChosenOne.TheChosenOneCode.Cards.Common.Skills;

public class SacrificialDetonation() 
    : TheChosenOneCard(1, CardType.Skill, CardRarity.Common, TargetType.AnyAlly)
{
    private const string MultiplyAmount = "MultiplyAmount";

    public override CardStatus Status => CardStatus.Sacrifice;

    protected override IEnumerable<DynamicVar> CanonicalVars => [new(MultiplyAmount, 3m)];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        if (cardPlay.Target?.Monster is not BaseMinion minion)
            return;

        var cmd = await DamageCmd
            .Attack(minion.MaxInitialHp)
            .FromCard(this, cardPlay)
            .Targeting(cardPlay.Target)
            .WithHitFx(DefaultAttackVfx)
            .Execute(choiceContext);
        var result = cmd.Results.FirstOrDefault()?.FirstOrDefault();
        if (result is null)
            return;

        var damageTaken = result.UnblockedDamage;
        var enemy = Owner.RunState.Rng.CombatTargets.NextItem(Owner.Creature.CombatState?.HittableEnemies ?? []);
        if (enemy is null)
            return;

        await CreatureCmd.Damage(
            choiceContext,
            enemy,
            damageTaken * DynamicVars[MultiplyAmount].BaseValue,
            ValueProp.Unpowered,
            Owner.Creature
        );
    }
}