class Type
{
    private string name { get; set; }

    private List<Type> Weaknesses { get; set; }
    private List<Type> Strengths { get; set; }
    private List<Type> Immunities { get; set; }

    public string getName () { return name; }
    public void setName(string name) { this.name = name; }
    public Type(string typeName)
    {
        setName(typeName);
        Weaknesses = setWeaknesses(getName());
        Strengths = setStrengths(getName());
        Immunities = setImmunities(getName());
    }
    //weaknesses for attacker ie if a fire type attacks a water type, the fire type is weak to water.
    public List<Type> setWeaknesses(string typeName)
    {
        switch(typeName)
        {
            case "Fire":
                return new List<Type> { new Type("Water"), new Type("Fire"), new Type("Rock"), new Type("Dragon")};
                
            case "Water":
                return new List<Type> {  new Type("Water"), new Type("Grass"), new Type("Dragon")};
            case "Grass":
                return new List<Type> { new Type("Fire"), new Type("Ice"), new Type("Poison"), new Type("Flying"), new Type("Bug"), new Type("Dragon")};
            case "Normal":
                return new List<Type> { new Type("Rock"), new Type("Ghost")};
            case "Electric":
                return new List<Type> { new Type("Electric"), new Type("Grass"), new Type("Ground"), new Type("Dragon") };
            case "Ice":
                return new List<Type> { new Type("Water"), new Type("Ice")};
            case "Fighting":
                return new List<Type> { new Type("Poison"), new Type("Flying"), new Type("Psychic"), new Type("Bug"), new Type("Ghost")};
            case "Poison":
                return new List<Type> { new Type("Ground"), new Type("Ghost"), new Type("Poison"), new Type("Rock")};
            case "Ground":
                return new List<Type> { new Type("Ground"), new Type("Flying"), new Type("Bug")};
            case "Flying":
                return new List<Type> { new Type("Electric"), new Type("Rock")};
            case "Psychic":
                return new List<Type> { new Type("Psychic")};
            case "Bug":
                return new List<Type> { new Type("Fire"), new Type("Flying"), new Type("Fighting")};
            case "Rock":
                return new List<Type> { new Type("Fighting"), new Type("Ground")};
            case "Ghost":
                return new List<Type> { new Type("Normal"), new Type("Psychic")};
            case "Dragon":
                return new List<Type>();
            default:
                return new List<Type>();
        }
    }
    public List<Type> setStrengths(string typeName)
    {
        switch(typeName)
        {
            case "Normal":
                return new List<Type>();
            case "Fire":
                return new List<Type> { new Type("Grass"), new Type("Ice"), new Type("Bug")};
            case "Water":
                return new List<Type> { new Type("Fire"), new Type("Ground"), new Type("Rock")};
            case "Grass":
                return new List<Type> { new Type("Water"), new Type("Ground"), new Type("Rock")};
            case "Electric":
                return new List<Type> { new Type("Water"), new Type("Flying")};
            case "Ice":
                return new List<Type> { new Type("Grass"), new Type("Ground"), new Type("Flying"), new Type("Dragon")};
            case "Fighting":
                return new List<Type> { new Type("Normal"), new Type("Ice"), new Type("Rock")};
            case "Poison":
                return new List<Type> { new Type("Grass"), new Type("Bug")};
            case "Ground":
                return new List<Type> { new Type("Fire"), new Type("Electric"), new Type("Poison"), new Type("Rock")};
            case "Flying":
                return new List<Type> { new Type("Grass"), new Type("Fighting"), new Type("Bug")};
            case "Psychic":
                return new List<Type> { new Type("Fighting"), new Type("Poison")};
            case "Bug":
                return new List<Type> { new Type("Grass"), new Type("Psychic"), new Type("Poison")};
            case "Rock":
                return new List<Type> { new Type("Fire"), new Type("Ice"), new Type("Flying"), new Type("Bug")};
            case "Ghost":
                return new List<Type> { new Type("Ghost")};
            case "Dragon":
                return new List<Type> { new Type("Dragon")};
            default:
                return new List<Type>();
        }
    }
    public List<Type> setImmunities(string typeName)
    {
        switch(typeName)
        {
            case "Normal":
                return new List<Type> { new Type("Ghost")};
            case "Electric":
                return new List<Type> { new Type("Ground")};
            case "Fighting":
                return new List<Type> { new Type("Ghost")};
            case "Ground":
                return new List<Type> { new Type("Flying")};
            case "Ghost":
                return new List<Type> { new Type("Normal"), new Type("Fighting")};
            default:
                return new List<Type>();
        }
    }
    public List<Type> getWeaknesses() { return Weaknesses; }
    public List<Type> getStrengths() { return Strengths; }
    public List<Type> getImmunities() { return Immunities; }
    

    public double calculateEffectiveness(Type attackType)
    {
        if(Immunities.Contains(attackType))
            return 0;
        if(Weaknesses.Contains(attackType))
            return .5;
        if(Strengths.Contains(attackType))
            return 2;
        return 1;
    }
}