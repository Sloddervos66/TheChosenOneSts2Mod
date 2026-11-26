using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.Models;
using TheChosenOne.TheChosenOneCode.Minions;
using TheChosenOne.TheChosenOneCode.Powers;

namespace TheChosenOne.TheChosenOneCode.Extensions;

public static class PlayerExtensions
{
    public static bool HasRelic<T>(this Player player) where T : RelicModel
    {
        var found = player.GetRelic<T>();
        return found != null;
    }

    public static void RegisterMinion(this Player player, BaseMinion minion)
    {
        player.Creature.GetPower<BloodOfferingPower>()?.RegisterMinion(minion);
    }
}