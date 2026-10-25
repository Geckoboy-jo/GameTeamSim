namespace PokemonGen1
{
    public class LeechSeedEffect : StageEffect
    {
        public LeechSeedEffect(Pokemon target, Pokemon caster) : base(target, caster) {}
        public override void applyEffect(Battle battle)
        {
            getTarget().takeDamage(getTarget().getMaxHp() / 16);
            getCaster().heal(getTarget().getMaxHp() / 16);
        }
    }
}