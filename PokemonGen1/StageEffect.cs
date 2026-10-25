namespace PokemonGen1
{
    public abstract class StageEffect
    {
        private Pokemon target;
        private Pokemon caster;
        public StageEffect(Pokemon target, Pokemon caster)
        {
            this.target = target;
            this.caster = caster;
        }
        public virtual void applyEffect(Battle battle){}
        public Pokemon getTarget(){return target;}
        public Pokemon getCaster(){return caster;}
    }
}