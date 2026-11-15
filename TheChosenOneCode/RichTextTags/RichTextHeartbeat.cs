using Godot;
using MegaCrit.Sts2.Core.RichTextTags;
using TheChosenOne.TheChosenOneCode.Constants;

namespace TheChosenOne.TheChosenOneCode.RichTextTags;

[GlobalClass]
[Tool]
public partial class RichTextHeartbeat : AbstractMegaRichTextEffect
{
    public new string bbcode = "heartbeat";
    protected override string Bbcode => bbcode;

    public override bool _ProcessCustomFX(CharFXTransform charFx)
    {
        if (!ShouldTransformText())
            return false;

        var time = charFx.ElapsedTime;
        var cycle = time % 1.5f;
        var pulse = cycle switch
        {
            < 0.25f => Mathf.Sin(cycle / 0.25f * Math.PI),
            >= 0.35f and < 0.55f => Mathf.Sin((cycle - 0.35f) / 0.2f * Math.PI) * 0.65f,
            _ => 0f
        };

        charFx.Color = TheChosenOneColours.MutedCrimson.Lerp(
            TheChosenOneColours.Crimson,
            (float)pulse
        );
        
        return true;
    }
}