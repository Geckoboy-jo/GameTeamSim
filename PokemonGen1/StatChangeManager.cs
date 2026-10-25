namespace PokemonGen1
{
    public class StatChangeManager
    {
        private StatChange[] statChanges;

        public StatChangeManager()
        {
            statChanges = new StatChange[6];
            statChanges[0] = new StatChange("Attack");
            statChanges[1] = new StatChange("Defense");
            statChanges[2] = new StatChange("Special");
            statChanges[3] = new StatChange("Speed");
            statChanges[4] = new StatChange("Accuracy");
            statChanges[5] = new StatChange("Evasion");

        }

        public void applyStatChange(string stat, int increment)
        {
            for (int i = 0; i < statChanges.Length; i++)
            {
                if (statChanges[i].getStat() == stat)
                {
                    if (increment > 0)
                        for (int j = 0; j < increment; j++)
                            statChanges[i].incrementChangeLevel();
                    else if (increment < 0)
                        for (int j = 0; j < -increment; j++)
                            statChanges[i].decrementChangeLevel();
                    break;
                }
            }
        }
        public StatChange findStatChange(string stat)
        {
            foreach (var statChange in statChanges)
            {
                if(statChange.getStat() == stat)
                {
                    return statChange;
                }
            }
            return null;
        }
        public void clearStatChanges()
        {
            foreach (var statChange in statChanges)
            {
                while (statChange.getChangeLevel() != 0)
                {
                    if (statChange.getChangeLevel() > 0)
                        statChange.decrementChangeLevel();
                    else
                        statChange.incrementChangeLevel();
                }
            }
        }       
        public double getAttackMultiplier()
        {
            return getMultiplier("Attack");
        }

        public double getDefenseMultiplier()
        {
            return getMultiplier("Defense");
        }

        public double getSpecialMultiplier()
        {
            return getMultiplier("Special");
        }

        public double getSpeedMultiplier()
        {
            return getMultiplier("Speed");
        }

        public double getAccuracyMultiplier()
        {
            return getMultiplier("Accuracy");
        }

        public double getEvasionMultiplier()
        {
            return getMultiplier("Evasion");
        }

        public double getMultiplier(string stat)
        {
            StatChange statChange = findStatChange(stat);
            if (statChange == null) return 1.0;
            int level = statChange.getChangeLevel();
            if (level > 0)
                return (2 + level) / 2.0;
            else if (level < 0)
                return 2.0 / (2 + level);
            else
                return 1.0;
        }
    }
}