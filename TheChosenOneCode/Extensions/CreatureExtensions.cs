using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Models.Powers;
using TheChosenOne.TheChosenOneCode.Relics;

namespace TheChosenOne.TheChosenOneCode.Extensions;

public static class CreatureExtensions
{
    public static async Task DecayRitual(this Creature creature)
    {
        var ritualPower = creature.GetPower<RitualPower>();
        if (ritualPower is null)
            return;

        if (creature.IsPlayer && creature.Player!.HasRelic<EnlightenedAuraRelic>())
            return;

        await PowerCmd.TickDownDuration(ritualPower);
    }
}