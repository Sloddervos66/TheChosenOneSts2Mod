# The Chosen One — Core Mechanics

> Design notes for the custom Slay the Spire 2 character **The Chosen One**.
>
> This document captures the current design direction, not a finalized balance specification. Values and rules marked as tentative should be tested in-game.

## Character concept

The Chosen One was a cultist who witnessed the Awakened's death. Seeing what happened turned him against the Architect and the Spire as a whole.

His name is deliberate wordplay: the original **Chosen** was sacrificed to become the Awakened. The Chosen One was not that sacrifice; he is the cultist who witnessed its consequences and chose vengeance.

His personality is cold, controlled, and pragmatic. He is willing to cooperate with others when their goals align, but he ultimately wants revenge against the Spire.

## Core gameplay identity

The character's gameplay is built around three connected pillars:

1. **Ritual** — a resource that naturally decays over time.
2. **Minions and sacrifice** — summon or convert minions, then sacrifice them for immediate benefits.
3. **Calm and Awakened forms** — begin in Calm and unlock a powerful Awakened transformation through one specific card.

These mechanics should reinforce one another rather than feel like separate systems.

## 1. Calm and Awakened forms

### Calm
- The default form at the start of combat.
- The character's normal state, with access to his Ritual and minion mechanics.
- The character must be viable even if the transformation card is never found or drawn.

### Awakened
- Accessed through one specific card.
- While Awakened, whenever the character plays a **Power** card, he gains Strength equal to that Power's cost.
- This is a reference to the Awakened One's **Curiosity** ability.
- The Strength-on-Power effect is only active after becoming Awakened; it does not apply in Calm form.

### Duration — undecided
Two options are being considered:
- **Rest of combat:** makes the transformation feel significant and permanent for that encounter.
- **Five turns:** makes it a temporary power window and allows the character to return to Calm.

Current preference to test first: **Awakened for the rest of combat**. This is not finalized.

Implementation/balance questions:
- How should X-cost Powers calculate the Strength gained? A likely rule is based on the energy actually spent.
- A Power reduced to 0 cost would grant 0 Strength under the straightforward cost-based rule.
- Decide whether the transformation card itself is a Power, Skill, or another card type, and whether it should trigger the Curiosity-like effect.

## 2. Ritual decay

Ritual slowly loses 1 stack over time. This applies to **all Ritual users**, not just The Chosen One.

### Lore explanation
The Chosen One has an aura that depletes Ritual around him. His presence destabilizes the Ritual of everyone nearby, including himself, allies, and enemies.

### Current proposed rules
- The Chosen One starts combat with **3 Ritual**. (Starting with 5 was also considered, but 3 is the current initial value to test.)
- Ritual decays by **1** over time.
- The decay affects every Ritual user in combat.
- A future relic may remove the decay side effect.

### Timing still to define
Decide exactly when decay occurs:
- At the end of each Ritual user's turn; or
- At a shared/end-of-round timing point.

If enemies can use Ritual, make sure their stacks decay consistently too. Test the global rule against other Ritual users so it does not accidentally make their encounters or characters unreasonably weak.

## 3. Minions and sacrifice

The Chosen One turns the Spire's inhabitants into expendable resources. His minion system should offer meaningful decisions rather than simply converting every enemy into a free ally.

### Two sources of minions

**Summoned minions**
- Created by The Chosen One's cards.
- Provide a reliable way to build a group of minions.
- Can be kept around for their attacks or passive benefits, or sacrificed for immediate value.

**Converted enemies**
- Certain cards can turn enemies into minions.
- Conversion should have a condition or limitation so it is not automatically stronger than defeating an enemy normally.
- Possible restrictions include converting an enemy when a card kills it, converting only weakened enemies, or making conversion temporary.
- Bosses and elites may need to be immune or have special conversion rules. This is undecided.

### Sacrificing minions
Minions can be sacrificed for immediate effects, such as:
- Damage
- Block
- Ritual
- Card draw
- Other effects that scale with the minion or number of minions sacrificed

A minion should have some value while it remains alive, so the player has to choose between keeping it and sacrificing it.

### Kills versus sacrifices
Keep these as separate interactions:
- **Killing an enemy:** certain cards may reward Ritual if their damage kills the target (for example, “If this kills, gain X Ritual”).
- **Sacrificing a minion:** deliberately consumes an existing minion for a chosen effect.

A possible starting design is to let some cards generate Ritual when they kill an enemy, while other cards sacrifice minions to gain Ritual, Block, damage, or other benefits.

### Minion rules still to decide
- Maximum number of minions at once (3 was suggested as an initial test value).
- Whether minions remain until sacrificed or have a lifespan.
- Whether minions automatically attack, provide passive effects, or both.
- Whether converted enemies retain their original attacks or abilities.
- Which enemy types can be converted.

## Starter deck and special basic card

The plan is for the normal basic cards to remain the same as other characters, with **one unique basic card** to introduce The Chosen One's targeting/Ritual identity.

### Special basic card — working concept

**Offering** (working name)
- Type: Basic Attack (proposed)
- Cost: 1 Energy (proposed)
- Choose any target:
  - **Yourself or an ally:** Gain 3 Ritual.
  - **An enemy:** Deal damage.

The damage value is not decided yet. The 1 Energy cost and 3 Ritual value are illustrative starting points for testing.

This card creates an early choice between attacking an enemy and generating Ritual. If minions count as allies, targeting one could also generate Ritual.

## Initial card pool target

The target is approximately **90 cards from the start**, to be on par with the other characters.

An initial allocation to guide card design (not final):
| Category | Approximate cards |
|---|---:|
| Attacks | 18 |
| Skills and defence | 16 |
| Ritual generation and manipulation | 14 |
| Minion summoning and control | 12 |
| Minion sacrifice | 10 |
| Powers | 10 |
| Awakened form and synergies | 6 |
| Utility and miscellaneous | 4 |
| **Total** | **90** |

Categories can overlap. For example, an Attack that summons a minion and generates Ritual can serve multiple themes. The transformation card should be rare, but the character should not depend on finding it to function.

## Current combat loop

A possible high-level loop:

1. Generate and maintain Ritual while its stacks decay.
2. Summon minions or convert eligible enemies.
3. Use minions for their ongoing value, or sacrifice them for immediate effects.
4. Find and play the transformation card to become Awakened.
5. In Awakened form, Powers also generate Strength based on their cost.

## Design principles

- Keep the character viable in Calm form.
- Make Awakened feel like a meaningful transformation, not a required upgrade.
- Keep Ritual, minions, and sacrifice interconnected.
- Avoid making enemy conversion an unconditional, free source of powerful minions.
- Give the player meaningful choices about when to sacrifice minions.
- Do not add another major resource or keyword yet; first test the interactions among the existing mechanics.

## Open decisions / next steps

- [ ] Decide whether Awakened lasts for the rest of combat or five turns.
- [ ] Define exact Ritual decay timing.
- [ ] Test starting Ritual at 3; compare with 5 if the opening feels too restrictive.
- [ ] Define minion cap, lifespan, and behaviour.
- [ ] Decide conversion conditions and whether elites/bosses are immune.
- [ ] Finalize the special basic card's name, damage, and targeting rules.
- [ ] Prototype a small set of cards to test the core loop before filling out the full ~90-card pool.
