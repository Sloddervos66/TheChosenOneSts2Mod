using BaseLib.Abstracts;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.ValueProps;
using TheChosenOne.TheChosenOneCode.Cards;
using TheChosenOne.TheChosenOneCode.Enums;

namespace TheChosenOne.TheChosenOneCode.Minions;

public abstract class BaseMinion(bool interactable) : CustomPetModel(interactable)
{
    public event Action<BaseMinion>? OnDeath;
    
    public bool WasSacrificed { get; private set; }
    
    public override Creature ModifyUnblockedDamageTarget(Creature target, decimal amount, ValueProp props, Creature? dealer)
    {
        if (target.PetOwner?.Creature == target ||
            Creature.IsDead)
            return base.ModifyUnblockedDamageTarget(target, amount, props, dealer);

        return Creature;
    }

    public override Task AfterDeath(PlayerChoiceContext choiceContext, Creature creature, CardModel? source, bool wasRemovalPrevented,
        float deathAnimLength)
    {
        WasSacrificed = source is TheChosenOneCard card &&
                        card.HasStatus(CardStatus.Sacrifice);
        
        OnDeath?.Invoke(this);
        return base.AfterDeath(choiceContext, creature, source, wasRemovalPrevented, deathAnimLength);
    }
}