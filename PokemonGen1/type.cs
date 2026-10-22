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
        Strengths = new List<Type>();
        Immunities = new List<Type>();
    }
    //weaknesses for attacker ie if a fire type attacks a water type, the fire type is weak to water.
    public List<Type> setWeaknesses(string typeName)
    {
        switch(typeName)
        {
            case "fire":
                return new List<Type> { new Type("water"), new Type("fire"), new Type("rock"), new Type("Dragon")};
                
            case "water":
                return new List<Type> {  new Type("water"), new Type("grass"), new Type("Dragon")};
            case "grass":
                return new List<Type> { new Type("fire"), new Type("ice"), new Type("poison"), new Type("flying"), new Type("bug"), new Type("Dragon")};
            case "normal":
                return new List<Type> { new Type("rock"), new Type("ghost")};
            case "electric":
                return new List<Type> { new Type("electric"), new Type("grass"), new Type("ground"), new Type("Dragon") };
            case "ice":
                return new List<Type> { new Type("water"), new Type("ice")};
            case "fighting":
                return new List<Type> { new Type("poison"), new Type("flying"), new Type("psychic"), new Type("bug"), new Type("fairy")};
        }
    }
    
}