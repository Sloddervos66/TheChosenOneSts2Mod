using HarmonyLib;
using MegaCrit.Sts2.addons.mega_text;
using MegaCrit.Sts2.Core.RichTextTags;
using TheChosenOne.TheChosenOneCode.RichTextTags;

namespace TheChosenOne.TheChosenOneCode.Patches;

[HarmonyPatch(typeof(MegaRichTextLabel), "InstallEffectsIfNeeded")]
public class MegaRichTextLabelPatch
{
    private static readonly AbstractMegaRichTextEffect[] _customEffects =
    [
        new RichTextBloodRed(),
        new RichTextHeartbeat()
    ];

    [HarmonyPostfix]
    public static void PostFix(MegaRichTextLabel __instance)
    {
        if (!__instance.BbcodeEnabled)
            return;

        foreach (var effect in _customEffects)
        {
            if (!__instance.CustomEffects.Contains(effect))
                __instance.CustomEffects.Add(effect);
        }
    }
}