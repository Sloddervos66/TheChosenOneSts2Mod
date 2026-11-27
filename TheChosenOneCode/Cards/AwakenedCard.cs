using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Localization;
using TheChosenOne.TheChosenOneCode.Enums;

namespace TheChosenOne.TheChosenOneCode.Cards;

public abstract class AwakenedCard(int cost, CardType type, CardRarity rarity, TargetType target)
    : TheChosenOneCard(cost, type, rarity, target)
{
    private bool? _previewAwakenedState;
    
    protected bool IsAwakened =>
        _previewAwakenedState ??
        Owner.Character is Character.TheChosenOne { CurrentState: CharacterState.Awakened };

    protected override void AddExtraArgsToDescription(LocString description)
    {
        base.AddExtraArgsToDescription(description);
        description.Add("IsAwakened", IsAwakened);
    }

    public void SetPreviewAwakenedState(bool? state)
    {
        _previewAwakenedState = state;
    }
}