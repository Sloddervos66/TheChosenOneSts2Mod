using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.Models;

namespace TheChosenOne.TheChosenOneCode.Powers;

public sealed class AwakenedPower : TheChosenOnePower
{
    public override PowerType Type => PowerType.Buff;
    public override PowerStackType StackType => PowerStackType.None;

    public override async Task AfterApplied(Creature? applier, CardModel? cardSource)
    {
        
    }
}