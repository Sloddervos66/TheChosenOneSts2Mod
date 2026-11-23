using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models.Powers;
using TheChosenOne.TheChosenOneCode.Minions;

namespace TheChosenOne.TheChosenOneCode.Powers;

public class BloodOfferingPower : TheChosenOnePower
{
    public override PowerType Type => PowerType.Buff;
    public override PowerStackType StackType => PowerStackType.Counter;
    
    public void RegisterMinion(BaseMinion minion)
    {
        minion.OnDeath += HandleMinionDeath;
    }

    private async void HandleMinionDeath(BaseMinion minion)
    {
        minion.OnDeath -= HandleMinionDeath;
        if (!minion.WasSacrificed)
            return;
        
        await PowerCmd.Apply<RitualPower>(
            new ThrowingPlayerChoiceContext(),
            Owner,
            Amount,
            Owner,
            null
        );
    }
}