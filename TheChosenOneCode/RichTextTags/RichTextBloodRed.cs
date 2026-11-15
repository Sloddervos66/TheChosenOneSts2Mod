using Godot;
using MegaCrit.Sts2.Core.RichTextTags;
using TheChosenOne.TheChosenOneCode.Constants;

namespace TheChosenOne.TheChosenOneCode.RichTextTags;

[GlobalClass]
[Tool]
public partial class RichTextBloodRed : AbstractMegaRichTextEffect
{
    public new string bbcode = "bloodred";
    protected override string Bbcode => bbcode;

    public override bool _ProcessCustomFX(CharFXTransform charFx)
    {
        charFx.Color = TheChosenOneColours.BloodRed;
        return true;
    }
}