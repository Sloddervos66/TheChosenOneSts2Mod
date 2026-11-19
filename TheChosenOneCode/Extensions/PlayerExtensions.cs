using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.Models;

namespace TheChosenOne.TheChosenOneCode.Extensions;

public static class PlayerExtensions
{
    public static bool HasRelic<T>(this Player player) where T : RelicModel
    {
        var found = player.GetRelic<T>();
        return found != null;
    }
}