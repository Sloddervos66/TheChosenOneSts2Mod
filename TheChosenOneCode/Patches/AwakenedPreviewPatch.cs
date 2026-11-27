using Godot;
using HarmonyLib;
using MegaCrit.Sts2.Core.Nodes.CommonUi;
using MegaCrit.Sts2.Core.Nodes.Screens;
using TheChosenOne.TheChosenOneCode.Ui;

namespace TheChosenOne.TheChosenOneCode.Patches;

[HarmonyPatch(typeof(NInspectCardScreen), nameof(NInspectCardScreen._Ready))]
public class AwakenedPreviewPatch
{
    public static void Postfix(NInspectCardScreen __instance)
    {
        var scene = GD.Load<PackedScene>("res://TheChosenOneCode/Scenes/awakened_preview_tickbox.tscn");
        var awakened = scene.Instantiate<NAwakenedPreviewTickbox>();

        __instance.AddChild(awakened);

        // awakened.Connect(
        //     NTickbox.SignalName.Toggled,
        //     Callable.From<NTickbox>(_ => ToggleAwakenedPreview(__instance))
        // );
    }

    private static void ToggleAwakenedPreview(NInspectCardScreen screen)
    {
        
    }
}