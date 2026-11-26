using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using TheChosenOne.TheChosenOneCode.Cards.Token;

namespace TheChosenOne.TheChosenOneCode.Minions;

public class BulwarkSlimeMinion() : BaseMinion(true)
{
    public override int MinInitialHp => 6;
    public override int MaxInitialHp => 6;

    public override async Task BeforeHandDraw(Player player, PlayerChoiceContext choiceContext, ICombatState combatState)
    {
        if (Creature.IsDead || player != Creature.PetOwner)
            return;
        
        var guard = combatState.CreateCard<SlimeGuard>(player);
        await CardPileCmd.AddGeneratedCardToCombat(guard, PileType.Hand, null);
    }
}