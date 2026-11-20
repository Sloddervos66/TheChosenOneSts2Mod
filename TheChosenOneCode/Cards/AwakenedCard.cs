using MegaCrit.Sts2.Core.Entities.Cards;

namespace TheChosenOne.TheChosenOneCode.Cards;

public abstract class AwakenedCard(int cost, CardType type, CardRarity rarity, TargetType target)
    : TheChosenOneCard(cost, type, rarity, target)
{
    
}