using BaseLib.Cards.Variables;
using BaseLib.Utils;
using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Powers;
using MegaCrit.Sts2.Core.Models.Relics;
using MegaCrit.Sts2.Core.ValueProps;

namespace TheChosenOne.TheChosenOneCode.Powers;

public class BleedingPower : TheChosenOnePower
{
	private const string DamageDecrease = "DamageDecrease";
	private const string BleedDamage = "BleedDamage";
	
	public override PowerType Type => PowerType.Debuff; 
	public override PowerStackType StackType => PowerStackType.Counter;

	protected override IEnumerable<DynamicVar> CanonicalVars =>
	[
		new(DamageDecrease, 0.9m),
		new(BleedDamage, 0m)
	];
	
	public override decimal ModifyDamageMultiplicative(Creature? target, decimal amount, ValueProp props, Creature? dealer,
		CardModel? cardSource, CardPlay? cardPlay)
	{
		if (dealer != Owner || !props.IsPoweredAttack())
			return 1m;

		var num = DynamicVars[DamageDecrease].BaseValue;
		
		var paperKrane = target?.Player?.GetRelic<PaperKrane>();
		if (paperKrane is not null)
			num = paperKrane.ModifyWeakMultiplier(target!, num, props, dealer, cardSource);

		var debilitatePower = dealer.GetPower<DebilitatePower>();
		if (debilitatePower is not null)
			num = debilitatePower.ModifyWeakMultiplier(dealer, num, props, dealer, cardSource);
		
		return num;
	}

	public override async Task AfterSideTurnEnd(PlayerChoiceContext choiceContext, CombatSide side, IEnumerable<Creature> participants)
	{
		if (!participants.Contains(Owner))
			return;

		await Trigger(choiceContext);
	}

	public override async Task AfterPowerAmountChanged(PlayerChoiceContext choiceContext, PowerModel power, decimal amount, Creature? applier,
		CardModel? cardSource)
	{
		await base.AfterPowerAmountChanged(choiceContext, power, amount, applier, cardSource);

		if (power != this)
			return;

		DynamicVars[BleedDamage].BaseValue = Amount * 5;
	}

	private async Task Trigger(PlayerChoiceContext choiceContext)
	{
		await CreatureCmd.Damage(
			choiceContext,
			Owner,
			DynamicVars[BleedDamage].BaseValue,
			ValueProp.Unblockable | ValueProp.Unpowered,
			null,
			null
		);

		if (Owner.IsDead)
			return;

		await PowerCmd.Decrement(this);
	}
}