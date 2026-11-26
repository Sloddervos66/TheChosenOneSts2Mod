using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.HoverTips;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Powers;
using MegaCrit.Sts2.Core.ValueProps;

namespace TheChosenOne.TheChosenOneCode.Powers;

public class BloodlustPower : TheChosenOnePower
{
    public override PowerType Type => PowerType.Buff;
    public override PowerStackType StackType => PowerStackType.Counter;

    protected override IEnumerable<IHoverTip> ExtraHoverTips => [HoverTipFactory.FromPower<RitualPower>()];

    public override async Task AfterDamageGiven(
        PlayerChoiceContext choiceContext, 
        Creature? dealer, 
        DamageResult result, 
        ValueProp props,
        Creature target, 
        CardModel? cardSource)
    {
        if ((dealer != Owner && cardSource?.Owner.Creature != Owner) || 
            !result.WasTargetKilled)
            return;

        Flash();
        await PowerCmd.Apply<RitualPower>(
            choiceContext,
            Owner,
            Amount,
            Owner,
            null
        );
    }
}