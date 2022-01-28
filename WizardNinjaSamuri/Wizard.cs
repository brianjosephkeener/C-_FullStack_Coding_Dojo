using System;

namespace Human
{
    class Wizard : Human 
{
    public Wizard(string name) : base(name, 3, 25, 3, 50)
    {
        
    }
    public override int Attack(Human target)
    {
        int dmg = base.Attack(target, Intelligence * 5);
        health -= dmg;
        return dmg;
    }
    public void Heal(Human target)
    {
        int healAmount = 10 * Intelligence;
        target.Health += healAmount;
    }
}
}

