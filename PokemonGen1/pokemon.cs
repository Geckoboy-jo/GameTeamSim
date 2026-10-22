

public class Pokemon
{
    private int special { get; set; }
    private int hp { get; set; }
    private int speed { get; set; }
    private int attack { get; set; }
    private int defense { get; set; }



    //getters and setters
    public int getSpecial() { return special; }
    public int getHp() { return hp; }
    public int getSpeed() { return speed; }
    public int getAttack() { return attack; }
    public int getDefense() { return defense; }

    public void setSpecial(int value) { special = value; }
    public void setHp(int value) {hp = value; }
    public void setSpeed(int value) { speed = value; }
    public void setAttack(int value) { attack = value; }
    public void setDefense(int value) { defense = value; }

}