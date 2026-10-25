using System.Data;

namespace PokemonGen1
{
    public class StatChange
    {
        public StatChange(string newStat){this.stat = newStat; changeLevel = 0;}
        private string stat { get; set; }
        private int changeLevel { get; set; }

        public string getStat() { return stat; }
        public int getChangeLevel() { return changeLevel; }

        public void setStat(string value) { stat = value; }
        public void incrementChangeLevel() { changeLevel++; if(changeLevel > 6) changeLevel = 6; }
        public void decrementChangeLevel() { changeLevel--; if(changeLevel < -6) changeLevel = -6; }
    }
}