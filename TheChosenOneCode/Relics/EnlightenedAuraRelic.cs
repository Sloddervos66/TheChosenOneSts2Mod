using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Relics;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.HoverTips;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.Powers;
using TheChosenOne.TheChosenOneCode.Extensions;

namespace TheChosenOne.TheChosenOneCode.Relics;

public class EnlightenedAuraRelic : TheChosenOneRelic
{
    public override RelicRarity Rarity => RelicRarity.Starter;

    protected override IEnumerable<DynamicVar> CanonicalVars =>
    [
        new("RitualDecay", 1m),
        new(nameof(RitualPower), 3m)
    ];

    protected override IEnumerable<IHoverTip> ExtraHoverTips => [HoverTipFactory.FromPower<RitualPower>()];

    private readonly List<Creature> _creaturesToDecay = [];
    
    public override async Task BeforeCombatStart()
    {
        Flash();
        await PowerCmd.Apply<RitualPower>(
            new ThrowingPlayerChoiceContext(),
            Owner.Creature,
            DynamicVars[nameof(RitualPower)].BaseValue,
            Owner.Creature,
            null
        );
    }

    public override async Task AfterSideTurnEndLate(PlayerChoiceContext choiceContext, CombatSide side, IEnumerable<Creature> participants)
    {
	    _creaturesToDecay.AddRange(participants.Where(c => !_creaturesToDecay.Contains(c)));

	    if (side != CombatSide.Enemy)
		    return;

	    foreach (var creature in _creaturesToDecay.Where(creature => creature != Owner.Creature)) 
		    await creature.DecayRitual();
	    
	    _creaturesToDecay.Clear();
    }
}