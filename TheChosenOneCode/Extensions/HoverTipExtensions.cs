using MegaCrit.Sts2.Core.HoverTips;
using MegaCrit.Sts2.Core.Localization;
using MegaCrit.Sts2.Core.Models;

namespace TheChosenOne.TheChosenOneCode.Extensions;

public static class HoverTipExtensions
{
    public static IHoverTip FromMonster<T>() where T : MonsterModel
    {
        var monster = ModelDb.Monster<T>();

        return new HoverTip(
            monster.Title,
            new LocString("monsters", monster.Id.Entry + ".description")
        );
    }
}