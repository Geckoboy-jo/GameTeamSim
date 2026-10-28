namespace PokemonGen1
{
    public class Gen1Move : Move
    {
        public Gen1Move(string name)
            : this(Gen1Catalog.GetMove(name))
        {
        }

        internal Gen1Move(Gen1MoveData move)
        {
            setMoveData(move);
        }

        public override void moveEffect(Pokemon target)
        {
            setTarget(target);
            if (!getMoveHit(target, getCaster()))
                return;

            bool applySideEffect = !getEffect().Contains("SIDE_EFFECT", StringComparison.Ordinal)
                || Random.Shared.NextDouble() < GetSideEffectChance();

            int damage = 0;
            if (getPower() > 0)
            {
                damage = calculateDamage();
                target.takeDamage(damage);
            }

            if (applySideEffect)
                ApplyEffect(target, damage);
        }

        private double GetSideEffectChance()
        {
            return getEffect().EndsWith("2", StringComparison.Ordinal) ? 0.3 : 0.1;
        }

        private void ApplyEffect(Pokemon target, int damage)
        {
            switch (getEffect())
            {
                case "ATTACK_DOWN1_EFFECT":
                    target.getStatChanges().applyStatChange("Attack", -1);
                    break;
                case "DEFENSE_DOWN1_EFFECT":
                case "DEFENSE_DOWN_SIDE_EFFECT":
                    target.getStatChanges().applyStatChange("Defense", -1);
                    break;
                case "SPEED_DOWN1_EFFECT":
                case "SPEED_DOWN_SIDE_EFFECT":
                    target.getStatChanges().applyStatChange("Speed", -1);
                    break;
                case "ACCURACY_DOWN1_EFFECT":
                    target.getStatChanges().applyStatChange("Accuracy", -1);
                    break;
                case "ATTACK_DOWN_SIDE_EFFECT":
                    target.getStatChanges().applyStatChange("Attack", -1);
                    break;
                case "ATTACK_UP1_EFFECT":
                    getCaster().getStatChanges().applyStatChange("Attack", 1);
                    break;
                case "ATTACK_UP2_EFFECT":
                    getCaster().getStatChanges().applyStatChange("Attack", 2);
                    break;
                case "DEFENSE_UP1_EFFECT":
                    getCaster().getStatChanges().applyStatChange("Defense", 1);
                    break;
                case "DEFENSE_UP2_EFFECT":
                    getCaster().getStatChanges().applyStatChange("Defense", 2);
                    break;
                case "SPEED_UP2_EFFECT":
                    getCaster().getStatChanges().applyStatChange("Speed", 2);
                    break;
                case "SPECIAL_UP1_EFFECT":
                    getCaster().getStatChanges().applyStatChange("Special", 1);
                    break;
                case "SPECIAL_UP2_EFFECT":
                    getCaster().getStatChanges().applyStatChange("Special", 2);
                    break;
                case "EVASION_UP1_EFFECT":
                    getCaster().getStatChanges().applyStatChange("Evasion", 1);
                    break;
                case "PARALYZE_EFFECT":
                    ApplyStatus(target, getType().getName() == "Electric" ? "Ground" : null, () => new Paralyzed());
                    break;
                case "POISON_EFFECT":
                    ApplyStatus(target, "Poison", () => new Poison());
                    break;
                case "SLEEP_EFFECT":
                    ApplyStatus(target, null, () => new Sleep(target));
                    break;
                case "BURN_SIDE_EFFECT1":
                case "BURN_SIDE_EFFECT2":
                    ApplyStatus(target, "Fire", () => new Burn(target));
                    break;
                case "FREEZE_SIDE_EFFECT1":
                    ApplyStatus(target, null, () => new Frozen());
                    break;
                case "PARALYZE_SIDE_EFFECT1":
                case "PARALYZE_SIDE_EFFECT2":
                    ApplyStatus(target, getType().getName() == "Electric" ? "Ground" : null, () => new Paralyzed());
                    break;
                case "POISON_SIDE_EFFECT1":
                case "POISON_SIDE_EFFECT2":
                    ApplyStatus(target, "Poison", () => new Poison());
                    break;
                case "DRAIN_HP_EFFECT":
                    getCaster().heal(damage / 2);
                    break;
                case "RECOIL_EFFECT":
                    if (damage > 0)
                        getCaster().takeDamage(Math.Max(1, damage / 4));
                    break;
                case "HEAL_EFFECT":
                    getCaster().heal(getCaster().getMaxHp() / 2);
                    break;
            }
        }

        private static void ApplyStatus(Pokemon target, string? immuneType, Func<StatusCondition> createCondition)
        {
            if (target.getStatusCondition() is not NoStatus
                || (immuneType != null && target.hasType(immuneType)))
                return;

            target.setStatusCondition(createCondition());
        }
    }
}
