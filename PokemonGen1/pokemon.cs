


namespace PokemonGen1
{
    public class Pokemon
    {
        //attributes
        private string name { get; set; } = string.Empty;
        private int level { get; set; }
        private int baseSpecial { get; set; }
        private int currentSpecial { get; set; }
        private int special { get; set; }
        private int currentAttack { get; set; }
        private int baseHp { get; set; }
        private int maxHp { get; set; }
        private int currentHp { get; set; }
        private int baseSpeed { get; set; }
        private int speed { get; set; }
        private int currentSpeed { get; set; }
        private int baseAttack { get; set; }
        private int attack { get; set; }
        private int baseDefense { get; set; }
        private int defense { get; set; }
        private int currentDefense { get; set; }
        private List<Type> types { get; set; }
        private StatChangeManager statChanges { get; set; }
        private StatusCondition statusCondition { get; set; }
        private List<Move> moves { get; set; }

        //getters and setters
        public int getLevel() { return level; }
        public string getName() { return name; }
        public int getSpecial() { return special; }
        public int getCurrentSpecial() { return currentSpecial; }
        public int getBaseSpecial() { return baseSpecial; }
        public int getMaxHp() { return maxHp; }
        public int getCurrentHp() { return currentHp; }
        public int getBaseHp() { return baseHp; }
        public int getBaseSpeed() { return baseSpeed; }
        public int getSpeed() { return speed; }
        public int getCurrentSpeed() { return currentSpeed; }
        public int getBaseAttack() { return baseAttack; }
        public int getCurrentAttack() { return currentAttack; }
        public int getDefense() { return defense; }
        public int getBaseDefense() { return baseDefense; }
        public int getCurrentDefense() { return currentDefense; }
        public List<Type> getTypes() { return types; }
        public StatChangeManager getStatChanges() { return statChanges; }
        public StatusCondition getStatusCondition() { return statusCondition; }
        public List<Move> getMoves() { return moves; }

        public void setLevel(int value) { level = value; }
        public void setName(string value) { name = value; }
        public void setSpecial(int value) { special = value; }
        public void setCurrentSpecial(int value) { currentSpecial = value; }
        public void setBaseSpecial(int value) { baseSpecial = value; }
        public void setMaxHp(int value) {maxHp = value;}
        public void setCurrentHp(int value) { currentHp = value; }
        public void setBaseHp(int value) { baseHp = value; }
        public void setBaseSpeed(int value) { baseSpeed = value; }
        public void setSpeed(int value) { speed = value; }
        public void setCurrentAttack(int value) { currentAttack = value; }
        public void setAttack(int value) { attack = value; }
        public void setCurrentSpeed(int value) { currentSpeed = value; }
        public void setBaseAttack(int value) { baseAttack = value; }
        public void setCurrentDefense(int value) { currentDefense = value; }
        public void setBaseDefense(int value) { baseDefense = value; }
        public void setTypes(List<Type> value) { types = value; }
        public void setStatChanges(StatChangeManager value) { statChanges = value; }
        public void setStatusCondition(StatusCondition value) { statusCondition = value; }
        public void setMoves(List<Move> value) { moves = value; }

        // member functions
        public void takeDamage(int damage)
        {
            currentHp -= damage;
            if (currentHp < 0) currentHp = 0;
        }
        public void heal(int amount)
        {
            currentHp += amount;
            if (currentHp > maxHp) currentHp = maxHp;
        }


        public void setStats()
        {
            //IVS and evs assumed to be max for simplicity
            maxHp = determineStat("hp");
            attack = determineStat("attack");
            defense = determineStat("defense");
            speed = determineStat("speed");
            special = determineStat("special");
            currentAttack = attack;
            currentDefense = defense;
            currentSpeed = speed;
            currentSpecial = special;
        }
        //helper function for setStats()
        private int determineStat(string stat)
        {
            int statValue;
            switch (stat)
            {
                case "hp": statValue = baseHp; break;
                case "attack": statValue = baseAttack; break;
                case "defense": statValue = baseDefense; break;
                case "speed": statValue = baseSpeed; break;
                case "special": statValue = baseSpecial; break;
                default: throw new ArgumentException("Invalid stat");
            }
            int statExperience = (int)Math.Sqrt(65535) / 4;
            int value = (int)(((2 * statValue + 15 + statExperience) * level) / 100.0);
            if (stat == "hp") return value + level + 10;
            return value + 5;
        }


        //constructor
        public Pokemon()
        {
            statChanges = new StatChangeManager();
            types = new List<Type>();
            moves = new List<Move>();
            statusCondition = new NoStatus(this);
        }
        public bool hasType(string type)
        {
            foreach (var t in types)
            {
                if (t.getName() == type)
                    return true;
            }
            return false;
        }
    }
}