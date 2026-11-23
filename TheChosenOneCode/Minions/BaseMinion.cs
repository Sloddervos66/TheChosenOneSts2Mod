using BaseLib.Abstracts;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.ValueProps;

namespace TheChosenOne.TheChosenOneCode.Minions;

public abstract class BaseMinion(bool interactable) : CustomPetModel(interactable)
{
    public override Creature ModifyUnblockedDamageTarget(Creature target, decimal amount, ValueProp props, Creature? dealer)
    {
        if (target.PetOwner?.Creature == target ||
            Creature.IsDead)
            return base.ModifyUnblockedDamageTarget(target, amount, props, dealer);

        return Creature;
    }
}