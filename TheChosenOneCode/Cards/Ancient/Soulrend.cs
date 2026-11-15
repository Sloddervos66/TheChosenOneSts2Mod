using BaseLib.Utils;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.HoverTips;
using TheChosenOne.TheChosenOneCode.Character;
using TheChosenOne.TheChosenOneCode.Powers;

namespace TheChosenOne.TheChosenOneCode.Cards.Ancient;

[Pool(typeof(TheChosenOneCardPool))]
public partial class Soulrend()
    : TheChosenOneCard(2, CardType.Skill, CardRarity.Ancient, TargetType.Self)
{
    protected override IEnumerable<IHoverTip> ExtraHoverTips =>
    [
        HoverTipFactory.FromPower<AwakenedPower>()
    ];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        var target = cardPlay.Target;
        if (target is null || target != Owner.Creature)
            return;

        await PowerCmd.Apply<AwakenedPower>(
            choiceContext,
            Owner.Creature,
            1m,
            Owner.Creature,
            this
        );
    }
}