using BaseLib.Abstracts;
using BaseLib.Utils.NodeFactories;
using TheChosenOne.TheChosenOneCode.Extensions;
using Godot;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Characters;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Powers;
using MegaCrit.Sts2.Core.Rooms;
using TheChosenOne.TheChosenOneCode.Cards.Basic;
using TheChosenOne.TheChosenOneCode.Constants;
using TheChosenOne.TheChosenOneCode.Enums;
using TheChosenOne.TheChosenOneCode.Powers;
using TheChosenOne.TheChosenOneCode.Relics;

namespace TheChosenOne.TheChosenOneCode.Character;

public class TheChosenOne : PlaceholderCharacterModel
{
    public const string CharacterId = "TheChosenOne";
    
    public CharacterState CurrentState { get; private set; }

    public override Color NameColor => TheChosenOneColours.BloodRed;
    public override CharacterGender Gender => CharacterGender.Masculine;
    public override int StartingHp => 95;

    public override IEnumerable<CardModel> StartingDeck =>
    [
        ModelDb.Card<StrikeTheChosenOne>(),
        ModelDb.Card<StrikeTheChosenOne>(),
        ModelDb.Card<StrikeTheChosenOne>(),
        ModelDb.Card<StrikeTheChosenOne>(),
        ModelDb.Card<StrikeTheChosenOne>(),
        ModelDb.Card<DefendTheChosenOne>(),
        ModelDb.Card<DefendTheChosenOne>(),
        ModelDb.Card<DefendTheChosenOne>(),
        ModelDb.Card<DefendTheChosenOne>(),
        ModelDb.Card<DefendTheChosenOne>(),
        ModelDb.Card<Harvest>()
    ];

    public override IReadOnlyList<RelicModel> StartingRelics =>
    [
        ModelDb.Relic<ShatteringAuraRelic>()
    ];

    public override CardPoolModel CardPool => ModelDb.CardPool<TheChosenOneCardPool>();
    public override RelicPoolModel RelicPool => ModelDb.RelicPool<TheChosenOneRelicPool>();
    public override PotionPoolModel PotionPool => ModelDb.PotionPool<TheChosenOnePotionPool>();

    /*  PlaceholderCharacterModel will utilize placeholder basegame assets for most of your character assets until you
        override all the other methods that define those assets.
        These are just some of the simplest assets, given some placeholders to differentiate your character with.
        You don't have to, but you're suggested to rename these images. */
    public override Control CustomIcon
    {
        get
        {
            var icon = NodeFactory<Control>.CreateFromResource(CustomIconTexturePath);
            icon.SetAnchorsAndOffsetsPreset(Control.LayoutPreset.FullRect);
            return icon;
        }
    }

    public override string CustomIconTexturePath => "character_icon_char_name.png".CharacterUiPath();
    public override string CustomCharacterSelectIconPath => "char_select_char_name.png".CharacterUiPath();
    public override string CustomCharacterSelectLockedIconPath => "char_select_char_name_locked.png".CharacterUiPath();
    public override string CustomMapMarkerPath => "map_marker_char_name.png".CharacterUiPath();

    public async Task Awaken(PlayerChoiceContext choiceContext, Player player, CardModel cardSource)
    {
        CurrentState = CharacterState.Awakened;
        await PowerCmd.Apply<StrengthPower>(choiceContext, player.Creature, 3m, player.Creature, cardSource);
        await PowerCmd.Apply<AwakenedPower>(choiceContext, player.Creature, 1m, player.Creature, cardSource);
    }

    public async Task BecomeCalm(Creature playerCreature)
    {
        CurrentState = CharacterState.Calm;
        await PowerCmd.Remove<AwakenedPower>(playerCreature);
    }
    
    public override Task AfterCombatEnd(CombatRoom room)
    {
        CurrentState = CharacterState.Calm;
        return base.AfterCombatEnd(room);
    }
}