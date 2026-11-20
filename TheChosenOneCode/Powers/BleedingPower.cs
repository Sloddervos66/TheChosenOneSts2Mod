using BaseLib.Cards.Variables;
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
		new DamageVar(5m, ValueProp.Move),
		new(DamageDecrease, 0.9m),
		.. CustomCalculatedVar.Create(
			BleedDamage,
			0,
			static (source, _) => source is PowerModel power ? power.Amount : 0,
			5
		)
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
		foreach (var participant in participants)
		{
			await CreatureCmd.Damage(
				choiceContext,
				participant,
				DynamicVars[BleedDamage].BaseValue,
				ValueProp.Move,
				null,
				null
			);
			
			await PowerCmd.TickDownDuration(this);
		}
	}
}