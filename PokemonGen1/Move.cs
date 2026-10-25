namespace PokemonGen1
{
    public class Move
    {
        private int power;
        private int accuracy;
        private Type type = new Type("Normal");
        private Pokemon? caster;
        private Team? teamEffected;
        private Pokemon? target;
        private bool isSpecial;
        private string name = string.Empty;
        private int pp;
        private string effect = string.Empty;

        public string getName() { return name; }
        public int getPP() { return pp; }
        public string getEffect() { return effect; }
        public bool getIsSpecial() { return isSpecial; }
        public void setIsSpecial(bool isSpecial) { this.isSpecial = isSpecial; }
        
        public int getPower() { return power; }
        public int getAccuracy() { return accuracy; }
        public Type getType() { return type; }
        public Team getTeamEffected() { return teamEffected ?? throw new InvalidOperationException("The affected team has not been set."); }
        public Pokemon getCaster() { return caster ?? throw new InvalidOperationException("The move caster has not been set."); }
        public Pokemon getTarget() { return target ?? throw new InvalidOperationException("The move target has not been set."); }

        public void setPower(int power) { this.power = power; }
        public void setAccuracy(int accuracy) { this.accuracy = accuracy; }
        public void setType(Type type)
        {
            this.type = type;
            isSpecial = type.getName() is "Fire" or "Water" or "Grass" or "Electric" or "Ice" or "Psychic" or "Dragon";
        }
        public void setName(string name) { this.name = name; }
        public void setPP(int pp) { this.pp = pp; }
        public void setEffect(string effect) { this.effect = effect; }
        protected void setMoveData(Gen1MoveData move)
        {
            setName(move.Name);
            setPower(move.Power);
            setAccuracy(move.Accuracy);
            setPP(move.Pp);
            setEffect(move.Effect);
            setType(new Type(move.Type));
        }
        public void setTeamEffected(Team teamEffected) { this.teamEffected = teamEffected; }
        public void setCaster(Pokemon caster) { this.caster = caster; }
        public void setTarget(Pokemon target) { this.target = target; }

        public virtual void moveEffect(Pokemon target) {}
        public Move() { }

        public int calculateDamage()
        {
            // Simplified damage calculation for demonstration purposes
            Pokemon moveCaster = getCaster();
            Pokemon moveTarget = getTarget();
            double attack = isSpecial ? moveCaster.getSpecial() * moveCaster.getStatChanges().getSpecialMultiplier() : moveCaster.getCurrentAttack() * moveCaster.getStatChanges().getAttackMultiplier();
            double defense = isSpecial ? moveTarget.getSpecial() * moveTarget.getStatChanges().getSpecialMultiplier() : moveTarget.getCurrentDefense() * moveTarget.getStatChanges().getDefenseMultiplier();
            double baseDamage = (((2 * moveCaster.getLevel() * criticalMultiplier(moveCaster) / 5 + 2) * power * attack / defense) / 50) + 2;
            foreach (Type targetType in moveTarget.getTypes())
            {
                baseDamage *= type.calculateEffectiveness(targetType);
            }
            foreach(Type casterType in moveCaster.getTypes())
            {
                if(casterType.getName() == type.getName())
                {
                    baseDamage *= 1.5;
                    break;
                }
            }
            baseDamage *= Random.Shared.Next(217, 256) / 255.0;
            

            
            return (int)baseDamage;
        }
        public int criticalMultiplier(Pokemon caster)
        {
            double critRate = (caster.getCurrentSpeed() * 100.0)/512; // Example crit rate based on speed
            // Simplified critical hit calculation for demonstration purposes
            return Random.Shared.NextDouble() < critRate ? 2 : 1;
        }
        public bool getMoveHit(Pokemon target, Pokemon caster)
        {
            double moveAccuracy = getAccuracy() * caster.getStatChanges().getAccuracyMultiplier() / target.getStatChanges().getEvasionMultiplier();
            return Random.Shared.NextDouble() * 100 < moveAccuracy;
        }
    }
}