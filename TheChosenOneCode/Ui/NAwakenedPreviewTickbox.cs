using MegaCrit.Sts2.Core.ControllerInput;
using MegaCrit.Sts2.Core.Nodes.CommonUi;

namespace TheChosenOne.TheChosenOneCode.Ui;

public partial class NAwakenedPreviewTickbox : NTickbox
{
    protected override string[] Hotkeys => [MegaInput.confirm];

    public override void _Ready()
    {
        ConnectSignals();
    }
}