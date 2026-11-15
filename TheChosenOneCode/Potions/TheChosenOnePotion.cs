using BaseLib.Abstracts;
using BaseLib.Extensions;
using BaseLib.Utils;
using TheChosenOne.TheChosenOneCode.Character;
using TheChosenOne.TheChosenOneCode.Extensions;

namespace TheChosenOne.TheChosenOneCode.Potions;

[Pool(typeof(TheChosenOnePotionPool))]
public abstract class TheChosenOnePotion : CustomPotionModel
{
    public override string? CustomPackedImagePath =>
        $"{Id.Entry.RemovePrefix().ToLowerInvariant()}.png".PotionImagePath();

    public override string? CustomPackedOutlinePath =>
        $"{Id.Entry.RemovePrefix().ToLowerInvariant()}.png".PotionOutlineImagePath();
}