namespace PokemonGen1
{
    public class SwitchActive : Move
    {
      

        public SwitchActive(Team teamEffected, Pokemon target)
        {
            setPower(0);
            setAccuracy(100); // Switching is always accurate
            setType(new Type("Normal")); // Switching is a normal type move
            setCaster(teamEffected.getActiveMember()); // The caster will be set when the move is used
            setTeamEffected(teamEffected); // The team effected will be set when the move is used
            setTarget(target); // Store the target Pokemon for switching
        }

        public override void moveEffect(Pokemon target)
        {
            getTeamEffected().setActiveMember(target);
            getCaster().getStatChanges().clearStatChanges();
        }
    }
}