using BaseLib.Abstracts;
using BaseLib.Extensions;
using BaseLib.Utils;
using TheChosenOne.TheChosenOneCode.Character;
using TheChosenOne.TheChosenOneCode.Extensions;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Creatures;
using TheChosenOne.TheChosenOneCode.Enums;
using TheChosenOne.TheChosenOneCode.Minions;

namespace TheChosenOne.TheChosenOneCode.Cards;

/// <summary>
/// This is the base class for your mod's cards, which is set up to load the card's images from your mod's resources.
/// When creating a card, right click the Cards folder and create a new file with the Custom Card template.
/// This will generate a class that extends this one.
/// You can also just create the class manually; just make sure to inherit from this class.
/// </summary>
[Pool(typeof(TheChosenOneCardPool))]
public abstract class TheChosenOneCard(int cost, CardType type, CardRarity rarity, TargetType target) :
    CustomCardModel(cost, type, rarity, target)
{
    protected const string DefaultAttackVfx = "vfx/vfx_attack_slash";
    
    public virtual CardStatus Status => CardStatus.None;
    
    //Image size:
    //Normal art: 1000x760 (Using 500x380 should also work, it will simply be scaled.)
    //Full art: 606x852
    public override string CustomPortraitPath => $"{Id.Entry.RemovePrefix().ToLowerInvariant()}.png".BigCardImagePath();
    
    //Smaller variants of card images for efficiency:
    //Smaller variant of fullart: 250x350
    //Smaller variant of normalart: 250x190

    //Uses card_portraits/card_name.png as image path. These should be smaller images.
    public override string PortraitPath => $"{Id.Entry.RemovePrefix().ToLowerInvariant()}.png".CardImagePath();
    public override string BetaPortraitPath => $"beta/{Id.Entry.RemovePrefix().ToLowerInvariant()}.png".CardImagePath();

    public bool HasStatus(CardStatus status)
    {
        return Status.HasFlag(status);
    }

    public override bool ShouldAllowTargeting(Creature target)
    {
        if (HasStatus(CardStatus.Sacrifice))
            return target.Monster is BaseMinion;
        
        return base.ShouldAllowTargeting(target);
    }
}