namespace PokemonGen1
{
    public enum Gen1TrainerClass
    {
        Youngster,
        BugCatcher,
        Lass,
        Sailor,
        JrTrainerM,
        JrTrainerF,
        Pokemaniac,
        SuperNerd,
        Hiker,
        Biker,
        Burglar,
        Engineer,
        UnusedJuggler,
        Fisher,
        Swimmer,
        CueBall,
        Gambler,
        Beauty,
        PsychicTrainer,
        Rocker,
        Juggler,
        Tamer,
        BirdKeeper,
        Blackbelt,
        Rival1,
        ProfessorOak,
        Chief,
        Scientist,
        Giovanni,
        Rocket,
        CooltrainerM,
        CooltrainerF,
        Bruno,
        Brock,
        Misty,
        LtSurge,
        Erika,
        Koga,
        Blaine,
        Sabrina,
        Gentleman,
        Rival2,
        Rival3,
        Lorelei,
        Channeler,
        Agatha,
        Lance
    }

    [Flags]
    internal enum TrainerMoveSelectionModifications
    {
        None = 0,
        DiscourageRedundantStatus = 1,
        EncourageEffects = 2,
        PreferEffectiveMoves = 4
    }

    public sealed class AIEngine
    {
        private static readonly HashSet<string> StatusAilmentEffects = new(StringComparer.Ordinal)
        {
            "SLEEP_EFFECT",
            "POISON_EFFECT",
            "PARALYZE_EFFECT"
        };

        private static readonly HashSet<string> EncouragedEffects = new(StringComparer.Ordinal)
        {
            "ATTACK_UP1_EFFECT",
            "DEFENSE_UP1_EFFECT",
            "SPEED_UP1_EFFECT",
            "SPECIAL_UP1_EFFECT",
            "ACCURACY_UP1_EFFECT",
            "EVASION_UP1_EFFECT",
            "PAY_DAY_EFFECT",
            "SWIFT_EFFECT",
            "ATTACK_DOWN1_EFFECT",
            "DEFENSE_DOWN1_EFFECT",
            "SPEED_DOWN1_EFFECT",
            "SPECIAL_DOWN1_EFFECT",
            "ACCURACY_DOWN1_EFFECT",
            "EVASION_DOWN1_EFFECT",
            "CONVERSION_EFFECT",
            "HAZE_EFFECT",
            "ATTACK_UP2_EFFECT",
            "DEFENSE_UP2_EFFECT",
            "SPEED_UP2_EFFECT",
            "SPECIAL_UP2_EFFECT",
            "ACCURACY_UP2_EFFECT",
            "EVASION_UP2_EFFECT",
            "HEAL_EFFECT",
            "TRANSFORM_EFFECT",
            "ATTACK_DOWN2_EFFECT",
            "DEFENSE_DOWN2_EFFECT",
            "SPEED_DOWN2_EFFECT",
            "SPECIAL_DOWN2_EFFECT",
            "ACCURACY_DOWN2_EFFECT",
            "EVASION_DOWN2_EFFECT",
            "LIGHT_SCREEN_EFFECT",
            "REFLECT_EFFECT"
        };

        private readonly Random random;
        private readonly TrainerMoveSelectionModifications modifications;

        public AIEngine() : this(Gen1TrainerClass.Youngster)
        {
        }

        public AIEngine(Gen1TrainerClass trainerClass, Random? random = null)
        {
            this.random = random ?? Random.Shared;
            modifications = GetModifications(trainerClass);
        }

        public Move ChooseMove(
            Pokemon trainerPokemon,
            Pokemon opposingPokemon,
            IReadOnlyList<Move> activeMoves,
            int? disabledMoveIndex = null)
        {
            ArgumentNullException.ThrowIfNull(trainerPokemon);
            ArgumentNullException.ThrowIfNull(opposingPokemon);
            ArgumentNullException.ThrowIfNull(activeMoves);
            if (activeMoves.Count is < 1 or > 4)
                throw new ArgumentException("Generation I trainer AI requires one to four active move slots.", nameof(activeMoves));
            if (activeMoves.Any(move => move is null))
                throw new ArgumentException("Active move slots cannot contain null.", nameof(activeMoves));
            if (disabledMoveIndex is < 0 || disabledMoveIndex >= activeMoves.Count)
                throw new ArgumentOutOfRangeException(nameof(disabledMoveIndex), "The disabled move index must identify an active move slot.");

            int[] scores = Enumerable.Repeat(10, activeMoves.Count).ToArray();
            if (disabledMoveIndex.HasValue)
                scores[disabledMoveIndex.Value] += 0x50;

            if (modifications.HasFlag(TrainerMoveSelectionModifications.DiscourageRedundantStatus)
                && opposingPokemon.getStatusCondition() is not NoStatus)
            {
                for (int i = 0; i < activeMoves.Count; i++)
                {
                    Move move = activeMoves[i];
                    if (move.getPower() == 0 && StatusAilmentEffects.Contains(move.getEffect()))
                        scores[i] += 5;
                }
            }

            if (modifications.HasFlag(TrainerMoveSelectionModifications.EncourageEffects))
            {
                for (int i = 0; i < activeMoves.Count; i++)
                {
                    if (EncouragedEffects.Contains(activeMoves[i].getEffect()))
                        scores[i]--;
                }
            }

            if (modifications.HasFlag(TrainerMoveSelectionModifications.PreferEffectiveMoves))
                AdjustForTypeEffectiveness(activeMoves, opposingPokemon, scores);

            int bestScore = scores.Min();
            var bestMoveSlots = new List<int>(activeMoves.Count);
            for (int i = 0; i < scores.Length; i++)
            {
                if (scores[i] == bestScore)
                    bestMoveSlots.Add(i);
            }

            Move selectedMove = activeMoves[bestMoveSlots[random.Next(bestMoveSlots.Count)]];
            selectedMove.setCaster(trainerPokemon);
            selectedMove.setTarget(opposingPokemon);
            return selectedMove;
        }

        private static void AdjustForTypeEffectiveness(IReadOnlyList<Move> moves, Pokemon target, int[] scores)
        {
            for (int i = 0; i < moves.Count; i++)
            {
                double effectiveness = GetTypeEffectiveness(moves[i], target);
                if (effectiveness > 1)
                    scores[i]--;
                else if (effectiveness < 1 && HasBetterAlternative(moves[i], moves))
                    scores[i]++;
            }
        }

        private static double GetTypeEffectiveness(Move move, Pokemon target)
        {
            double effectiveness = 1;
            foreach (Type defenderType in target.getTypes())
                effectiveness *= move.getType().calculateEffectiveness(defenderType);
            return effectiveness;
        }

        private static bool HasBetterAlternative(Move move, IReadOnlyList<Move> moves)
        {
            foreach (Move alternative in moves)
            {
                if (alternative.getEffect() is "SUPER_FANG_EFFECT" or "SPECIAL_DAMAGE_EFFECT" or "FLY_EFFECT")
                    return true;
                if (alternative.getType().getName() != move.getType().getName() && alternative.getPower() > 0)
                    return true;
            }

            return false;
        }

        private static TrainerMoveSelectionModifications GetModifications(Gen1TrainerClass trainerClass)
        {
            const TrainerMoveSelectionModifications status = TrainerMoveSelectionModifications.DiscourageRedundantStatus;
            const TrainerMoveSelectionModifications effects = TrainerMoveSelectionModifications.EncourageEffects;
            const TrainerMoveSelectionModifications effectiveness = TrainerMoveSelectionModifications.PreferEffectiveMoves;

            return trainerClass switch
            {
                Gen1TrainerClass.Youngster or Gen1TrainerClass.CueBall => TrainerMoveSelectionModifications.None,
                Gen1TrainerClass.Pokemaniac or Gen1TrainerClass.Lorelei => status | effects | effectiveness,
                Gen1TrainerClass.SuperNerd or Gen1TrainerClass.UnusedJuggler
                    or Gen1TrainerClass.PsychicTrainer or Gen1TrainerClass.Chief
                    or Gen1TrainerClass.Scientist or Gen1TrainerClass.Gentleman => status | effects,
                Gen1TrainerClass.Sailor or Gen1TrainerClass.Burglar or Gen1TrainerClass.Fisher
                    or Gen1TrainerClass.Swimmer or Gen1TrainerClass.Beauty or Gen1TrainerClass.Rocker
                    or Gen1TrainerClass.ProfessorOak or Gen1TrainerClass.Giovanni
                    or Gen1TrainerClass.CooltrainerM or Gen1TrainerClass.CooltrainerF
                    or Gen1TrainerClass.Misty or Gen1TrainerClass.LtSurge or Gen1TrainerClass.Erika
                    or Gen1TrainerClass.Koga or Gen1TrainerClass.Blaine or Gen1TrainerClass.Sabrina
                    or Gen1TrainerClass.Rival2 or Gen1TrainerClass.Rival3 or Gen1TrainerClass.Lance => status | effectiveness,
                Gen1TrainerClass.BugCatcher or Gen1TrainerClass.Lass or Gen1TrainerClass.JrTrainerM
                    or Gen1TrainerClass.JrTrainerF or Gen1TrainerClass.Hiker or Gen1TrainerClass.Biker
                    or Gen1TrainerClass.Engineer or Gen1TrainerClass.Gambler or Gen1TrainerClass.Juggler
                    or Gen1TrainerClass.Tamer or Gen1TrainerClass.BirdKeeper or Gen1TrainerClass.Blackbelt
                    or Gen1TrainerClass.Rival1 or Gen1TrainerClass.Rocket or Gen1TrainerClass.Bruno
                    or Gen1TrainerClass.Brock or Gen1TrainerClass.Channeler or Gen1TrainerClass.Agatha => status,
                _ => throw new ArgumentOutOfRangeException(nameof(trainerClass), trainerClass, "Unknown Generation I trainer class.")
            };
        }
    }
}
