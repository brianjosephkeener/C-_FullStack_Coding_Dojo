using System;

namespace Human{
    class Samurai : Human 
{
    public Samurai(string name) : base(name, 6, 3, 5, 200)
    {
        
    }
    public override int Attack(Human target)
    {
        int dmg = base.Attack(target);
        if (health < 50)
        {
            health = 0;
        }
        health = health - dmg; 
        return dmg; 
    }
    public void Meditate()
    {
        health = 200;
    }
}
}