# The Chosen One — Card Database

**Target: 96 cards**

Progress: 4 / 96

## Basic Cards (3)

| Name    | Cost | Type   | Rarity | Target    | Description                                 | Upgraded | Implemented (Y/N) |
|---------|------|--------|--------|-----------|---------------------------------------------|----------|-------------------|
| Defend  | 1    | Skill  | Basic  | Self      | Gain 5 Block.                               | 5 -> 8.  | Y                 |
| Strike  | 1    | Attack | Basic  | Any enemy | Deal 6 damage.                              | 6 -> 9.  | Y                 |
| Harvest | 2    | Attack | Basic  | Any enemy | Deal 8 damage. If this kills gain 3 Ritual. | 8 -> 11. | Y                 |

## Ancient Cards (2)

| Name          | Cost | Type  | Rarity  | Target | Description                                                                       | Upgraded      | Implemented (Y/N) |
|---------------|------|-------|---------|--------|-----------------------------------------------------------------------------------|---------------|-------------------|
| Transcendence | 2    | Skill | Ancient | Self   | Deal 10 damage to yourself. Transform into Awakened. Exhaust.                     | 10 -> 5.      | Y                 |
| Recognition   | 3    | Power | Ancient | Self   | Heal 1 HP for every 5 HP lost. Gain 10 Plating. Gain 2 Ritual. Ethereal. Exhaust. | 1 HP -> 2 HP. | N                 |

## Common Cards (20)

*Target distribution: 14 Ritual / 5 Minion / 1 Awakened*

| Name                   | Cost | Type              | Rarity | Target    | Description                                                                        | Upgraded                         | Implemented (Y/N) |
|------------------------|------|-------------------|--------|-----------|------------------------------------------------------------------------------------|----------------------------------|-------------------|
| Sacrifial Dagger       | 1    | Attack - Ritual   | Common | Any enemy | Deal 4 damage. Apply 2 Bleeding.                                                   | 4 -> 7.                          | N                 |
| Secrecy                | 1    | Skill - Ritual    | Common | Self      | Gain 7 Block. Add Retain to a random card in Hand.                                 | 7 -> 10.                         | N                 |
| Fortification          | 2    | Skill - Ritual    | Common | Self      | Gain 6 Block. Gain 2 additional Block for every 2 Ritual you have.                 | 6 -> 8.                          | N                 |
| Blood Pact             | 1    | Attack - Ritual   | Common | Any enemy | Deal 5 damage. Deal 2 additional damage for every 2 Ritual you have.               | 5 -> 7.                          | N                 |
| Bloodshed              | 2    | Attack - Ritual   | Common | Any enemy | Deal 7 damage twice.                                                               | 7 -> 9.                          | N                 |
| Impalement             | 1    | Attack - Ritual   | Common | Any enemy | Deal 8 damage. If you have at least 4 Ritual, apply 2 Bleeding.                    | 8 -> 11.                         | N                 |
| Sacrificial Strike     | 1    | Attack - Ritual   | Common | Any enemy | Lose 1 Ritual. Deal 8 damage.                                                      | 8 -> 11.                         | N                 |
| Execution              | 2    | Attack - Ritual   | Common | Any enemy | Deal 10 damage. If the enemy has Bleeding, deal 10 additional damage.              | 10 -> 13.                        | N                 |
| Forbidden Power        | 1    | Attack - Ritual   | Common | Any enemy | Deal 6 damage. Gain 1 Ritual if this kills the enemy.                              | 6 -> 9.                          | N                 |
| Devotion               | 1    | Skill - Ritual    | Common | Self      | Gain 1 Ritual. If you have 3 or more Ritual, gain 5 Block.                         | 1 Ritual -> 2.                   | N                 |
| Inscription            | 0    | Skill - Ritual    | Common | Self      | Gain 2 Ritual. Exhaust.                                                            | 2 -> 3.                          | N                 |
| Blood Infusion         | 1    | Power - Ritual    | Common | Self      | The first time each turn you lose HP, gain 1 Ritual.                               | 1 Ritual -> 2.                   | N                 |
| Blood Offering         | 2    | Power - Ritual    | Common | Self      | Whenever you sacrifice a Minion, gain 1 Ritual.                                    | 1 Ritual -> 2.                   | N                 |
| Bloodlust              | 1    | Power - Ritual    | Common | Self      | Whenever you kill an enemy, gain 1 Ritual.                                         | 1 Ritual -> 2.                   | N                 |
| Bulwark Slime          | 2    | Skill - Minion    | Common | Self      | Summon 1 Bulwark Slime.                                                            | Cost 2 -> 1.                     | Y                 |
| Ravager Slime          | 2    | Skill - Minion    | Common | Self      | Summon 1 Ravager Slime.                                                            | Cost 2 -> 1.                     | N                 |
| Coordinated Assault    | 1    | Attack - Minion   | Common | Any enemy | Deal 6 damage. Your minions each deal 3 damage to the same enemy.                  | 6 -> 9.                          | N                 |
| Savage Command         | 1    | Attack - Minion   | Common | Any enemy | Deal 8 damage. If you have a Minion, deal 5 additional damage.                     | 8 -> 11.                         | N                 |
| Sacrificial Detonation | 1    | Skill - Minion    | Common | Any ally  | Sacrifice a Minion. Deal damage to a random enemy equal to 3 times its current HP. | 3 -> 5.                          | N                 |
| Unbound                | 1    | Attack - Awakened | Common | Any enemy | Calm: Deal 5 damage. Gain 4 Block. Awakened: Deal 9 damage.                        | Calm: 5 -> 7. Awakened: 9 -> 11. | N                 |

## Uncommon Cards (44)

*Target distribution: 14 Ritual / 20 Minion / 10 Awakened*

| Name             | Cost | Type           | Rarity   | Target    | Description                                                   | Upgraded              | Implemented (Y/N) |
|------------------|------|----------------|----------|-----------|---------------------------------------------------------------|-----------------------|-------------------|
| Stitch Up        | 2    | Skill - Ritual | Uncommon | Self      | Stops Bleeding. Heals 5 HP.                                   | 5 -> 7.               | N                 |
| Drain            | 2    | Skill - Ritual | Uncommon | Any Enemy | Apply 3 Weak. Gain 3 Strength.                                | 4 Weak, 4 Strength.   | N                 |
| Invocation       | 2    | Skill - Ritual | Uncommon | Self      | Immediately trigger your Ritual. Then remove all your Ritual. | Trigger Ritual twice. | N                 |
| Eternal Devotion | 2    | Power - Ritual | Uncommon | Self      | At the start of your turn gain 3 Ritual.                      | 2 cost -> 1 cost.     | N                 |
|                  |      | - Ritual       | Uncommon |           |                                                               |                       | N                 |
|                  |      | - Ritual       | Uncommon |           |                                                               |                       | N                 |
|                  |      | - Ritual       | Uncommon |           |                                                               |                       | N                 |
|                  |      | - Ritual       | Uncommon |           |                                                               |                       | N                 |
|                  |      | - Ritual       | Uncommon |           |                                                               |                       | N                 |
|                  |      | - Ritual       | Uncommon |           |                                                               |                       | N                 |
|                  |      | - Ritual       | Uncommon |           |                                                               |                       | N                 |
|                  |      | - Ritual       | Uncommon |           |                                                               |                       | N                 |
|                  |      | - Ritual       | Uncommon |           |                                                               |                       | N                 |
|                  |      | - Ritual       | Uncommon |           |                                                               |                       | N                 |
|                  |      | - Minion       | Uncommon |           |                                                               |                       | N                 |
|                  |      | - Minion       | Uncommon |           |                                                               |                       | N                 |
|                  |      | - Minion       | Uncommon |           |                                                               |                       | N                 |
|                  |      | - Minion       | Uncommon |           |                                                               |                       | N                 |
|                  |      | - Minion       | Uncommon |           |                                                               |                       | N                 |
|                  |      | - Minion       | Uncommon |           |                                                               |                       | N                 |
|                  |      | - Minion       | Uncommon |           |                                                               |                       | N                 |
|                  |      | - Minion       | Uncommon |           |                                                               |                       | N                 |
|                  |      | - Minion       | Uncommon |           |                                                               |                       | N                 |
|                  |      | - Minion       | Uncommon |           |                                                               |                       | N                 |
|                  |      | - Minion       | Uncommon |           |                                                               |                       | N                 |
|                  |      | - Minion       | Uncommon |           |                                                               |                       | N                 |
|                  |      | - Minion       | Uncommon |           |                                                               |                       | N                 |
|                  |      | - Minion       | Uncommon |           |                                                               |                       | N                 |
|                  |      | - Minion       | Uncommon |           |                                                               |                       | N                 |
|                  |      | - Minion       | Uncommon |           |                                                               |                       | N                 |
|                  |      | - Minion       | Uncommon |           |                                                               |                       | N                 |
|                  |      | - Minion       | Uncommon |           |                                                               |                       | N                 |
|                  |      | - Minion       | Uncommon |           |                                                               |                       | N                 |
|                  |      | - Minion       | Uncommon |           |                                                               |                       | N                 |
|                  |      | - Minion       | Uncommon |           |                                                               |                       | N                 |
|                  |      | - Awakened     | Uncommon |           |                                                               |                       | N                 |
|                  |      | - Awakened     | Uncommon |           |                                                               |                       | N                 |
|                  |      | - Awakened     | Uncommon |           |                                                               |                       | N                 |
|                  |      | - Awakened     | Uncommon |           |                                                               |                       | N                 |
|                  |      | - Awakened     | Uncommon |           |                                                               |                       | N                 |
|                  |      | - Awakened     | Uncommon |           |                                                               |                       | N                 |
|                  |      | - Awakened     | Uncommon |           |                                                               |                       | N                 |
|                  |      | - Awakened     | Uncommon |           |                                                               |                       | N                 |
|                  |      | - Awakened     | Uncommon |           |                                                               |                       | N                 |
|                  |      | - Awakened     | Uncommon |           |                                                               |                       | N                 |

## Rare Cards (27)

*Target distribution: 2 Ritual / 5 Minion / 20 Awakened*

| Name     | Cost | Type            | Rarity | Target    | Description                                                   | Upgraded            | Implemented (Y/N) |
|----------|------|-----------------|--------|-----------|---------------------------------------------------------------|---------------------|-------------------|
| Amputate | 3    | Attack - Ritual | Rare   | Any enemy | Deals 12 damage. Applies 5 bleeding. Gain 2 Ritual. Ethereal. | 5 -> 7, 2 -> 4.     | N                 |
| Amplify  | 2    | Skill - Ritual  | Rare   | Self      | Double your Ritual. Exhaust.                                  | Triple your Ritual. | N                 |
|          |      | - Minion        | Rare   |           |                                                               |                     | N                 |
|          |      | - Minion        | Rare   |           |                                                               |                     | N                 |
|          |      | - Minion        | Rare   |           |                                                               |                     | N                 |
|          |      | - Minion        | Rare   |           |                                                               |                     | N                 |
|          |      | - Minion        | Rare   |           |                                                               |                     | N                 |
|          |      | - Awakened      | Rare   |           |                                                               |                     | N                 |
|          |      | - Awakened      | Rare   |           |                                                               |                     | N                 |
|          |      | - Awakened      | Rare   |           |                                                               |                     | N                 |
|          |      | - Awakened      | Rare   |           |                                                               |                     | N                 |
|          |      | - Awakened      | Rare   |           |                                                               |                     | N                 |
|          |      | - Awakened      | Rare   |           |                                                               |                     | N                 |
|          |      | - Awakened      | Rare   |           |                                                               |                     | N                 |
|          |      | - Awakened      | Rare   |           |                                                               |                     | N                 |
|          |      | - Awakened      | Rare   |           |                                                               |                     | N                 |
|          |      | - Awakened      | Rare   |           |                                                               |                     | N                 |
|          |      | - Awakened      | Rare   |           |                                                               |                     | N                 |
|          |      | - Awakened      | Rare   |           |                                                               |                     | N                 |
|          |      | - Awakened      | Rare   |           |                                                               |                     | N                 |
|          |      | - Awakened      | Rare   |           |                                                               |                     | N                 |
|          |      | - Awakened      | Rare   |           |                                                               |                     | N                 |
|          |      | - Awakened      | Rare   |           |                                                               |                     | N                 |
|          |      | - Awakened      | Rare   |           |                                                               |                     | N                 |
|          |      | - Awakened      | Rare   |           |                                                               |                     | N                 |
|          |      | - Awakened      | Rare   |           |                                                               |                     | N                 |
|          |      | - Awakened      | Rare   |           |                                                               |                     | N                 |

## Token Cards

| Name         | Cost | Type   | Rarity | Target    | Description    | Upgraded | Implemented (Y/N) |
|--------------|------|--------|--------|-----------|----------------|----------|-------------------|
| Slime Guard  | 0    | Skill  | Token  | Self      | Gain 2 Block.  | 2 -> 4.  | Y                 |
| Slime Strike | 0    | Attack | Token  | Any enemy | Deal 2 damage. | 2 -> 4.  | N                 |

## Card Distribution Overview

| Rarity    | Ritual | Minion | Awakened |  Total |
|-----------|-------:|-------:|---------:|-------:|
| Basic     |      — |      — |        — |      3 |
| Ancient   |      — |      — |        — |      2 |
| Common    |     14 |      5 |        1 |     20 |
| Uncommon  |     14 |     20 |       10 |     44 |
| Rare      |      2 |      5 |       20 |     27 |
| **Total** | **30** | **30** |   **31** | **96** |

## Additional Character Content

### Relics (9)

| # | Relic Name       | Description                                                                 | Implemented (Y/N) |
|---|------------------|-----------------------------------------------------------------------------|-------------------|
| 1 | Shattering Aura  | Ritual now decays by 1 at the end of the turn. Before combat gain 3 Ritual. | Y                 |
| 2 | Enlightened Aura | Ritual now longer decays for you. Before combat gain 3 Ritual.              | Y                 |
| 3 |                  |                                                                             | N                 |
| 4 |                  |                                                                             | N                 |
| 5 |                  |                                                                             | N                 |
| 6 |                  |                                                                             | N                 |
| 7 |                  |                                                                             | N                 |
| 8 |                  |                                                                             | N                 |
| 9 |                  |                                                                             | N                 |

### Custom Potions (3)

| # | Potion Name | Description | Implemented (Y/N) |
|---|-------------|-------------|-------------------|
| 1 |             |             | N                 |
| 2 |             |             | N                 |
| 3 |             |             | N                 |

### Custom Powers
| # | Name     | Description                                                                               | Implemented (Y/N) |
|---|----------|-------------------------------------------------------------------------------------------|-------------------|
| 1 | Bleeding | Deals X damage, where X is stack amount * 5. Weakens the enemy for Y%, where Y is amount. | N                 |

