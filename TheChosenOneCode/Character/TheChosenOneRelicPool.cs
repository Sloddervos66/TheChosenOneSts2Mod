using BaseLib.Abstracts;
using TheChosenOne.TheChosenOneCode.Extensions;
using Godot;
using TheChosenOne.TheChosenOneCode.Constants;

namespace TheChosenOne.TheChosenOneCode.Character;

public class TheChosenOneRelicPool : CustomRelicPoolModel
{
    public override Color LabOutlineColor => TheChosenOneColours.BloodRed;

    public override string BigEnergyIconPath => "charui/big_energy.png".ImagePath();
    public override string TextEnergyIconPath => "charui/text_energy.png".ImagePath();
}