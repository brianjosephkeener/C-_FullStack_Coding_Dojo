using System;

namespace Human{
    class Ninja : Human 
{
    public Ninja(string name) : base(name, 5, 4, 175, 100)
    {
        
    }
    public override int Attack(Human target)
    {
        int dmg = base.Attack(target, Dexterity * 5);
        Random rd = new Random();
        int rand_num = rd.Next(0, 100);
        if (rand_num <= 20)
        {
            dmg = dmg + 10;
        }
        health = health - dmg; 
        return dmg; 
    }
    public void Steal(Human target)
    {
        health = health + base.Attack(target, 10);
    }
}
}