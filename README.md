# GameTeamSim
a tool to let players run simulations for games to determine the best team on paper

## Generation I Pokémon catalog

`PokemonGen1` uses the Pokémon Red/Blue data set: all 151 species, all 165 moves, base stats, types, level-up moves, TM/HM compatibility, and move power/type/accuracy/PP/effect identifiers. This is deliberately the original Red/Blue data and does not include later-generation changes or Yellow-specific learnsets.

Each species and move has its own public class and source file under [`PokemonGen1/Species`](./PokemonGen1/Species) and [`PokemonGen1/Moves`](./PokemonGen1/Moves), respectively. `Gen1Catalog.CreatePokemon("Bulbasaur", level)` and `Gen1Catalog.CreateMove("Vine Whip")` return those concrete classes. Names that contain punctuation are represented as valid C# identifiers, such as `MrMime`, `NidoranF`, `NidoranM`, and `Farfetchd`.

`Gen1Catalog.GetAvailableMoves(species, level)` returns the species' initial and level-up moves through that level, plus its compatible Red/Blue TM/HM moves.

The data is transcribed from the [pret/pokered Pokémon Red and Blue disassembly](https://github.com/pret/pokered), specifically its [`base_stats`](https://github.com/pret/pokered/tree/master/data/pokemon/base_stats), [`evos_moves.asm`](https://github.com/pret/pokered/blob/master/data/pokemon/evos_moves.asm), [`moves.asm`](https://github.com/pret/pokered/blob/master/data/moves/moves.asm), and [type matchup table](https://github.com/pret/pokered/blob/master/data/types/type_matchups.asm).

## Generation I trainer move AI

`AIEngine` follows the Red/Blue move-choice scoring and trainer-class modification table in [`trainer_ai.asm`](https://github.com/pret/pokered/blob/master/engine/battle/trainer_ai.asm) and [`move_choices.asm`](https://github.com/pret/pokered/blob/master/data/trainers/move_choices.asm). Pass the trainer's active 1–4 move slots to `ChooseMove`; `Battle.chooseOpponentMove` supplies the active Pokémon pair. Ties among the lowest-scored moves are selected uniformly, as in the games. Trainer item use and class-specific switching are not part of this move-selection API.
