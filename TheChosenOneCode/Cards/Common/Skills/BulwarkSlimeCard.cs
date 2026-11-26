using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.HoverTips;
using TheChosenOne.TheChosenOneCode.Cards.Token;
using TheChosenOne.TheChosenOneCode.Minions;
using HoverTipExtensions = TheChosenOne.TheChosenOneCode.Extensions.HoverTipExtensions;

namespace TheChosenOne.TheChosenOneCode.Cards.Common.Skills;

public class BulwarkSlimeCard()
    : TheChosenOneCard(2, CardType.Skill, CardRarity.Common, TargetType.Self)
{
    protected override IEnumerable<IHoverTip> ExtraHoverTips =>
    [
        HoverTipExtensions.FromMonster<BulwarkSlimeMinion>(),
        HoverTipFactory.FromCard<SlimeGuard>()
    ];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay play)
    {
        await AddMinion<BulwarkSlimeMinion>();
    }
    
    protected override void OnUpgrade()
    {
        EnergyCost.UpgradeBy(-1);
    }
}