using System;

namespace Human
{
    class Human
{
    // Fields for Human
    public string Name;
    public int Strength;
    public int Intelligence;
    public int Dexterity;
    private int health;
    // add a public "getter" property to access health
    public int Health
    {
        get {return health;}
    }
        // Add a constructor that takes a value to set Name, and set the remaining fields to default values
     
    public void setName(string givenName)
    {
        Strength = 3;
        Intelligence = 3;
        Dexterity = 3;
        health = 100;
        Name = givenName;
    }
     

    // Add a constructor to assign custom values to all fields
    public void setCustom(int givenStrength, int givenIntelligence, int givenDexterity, int givenHealth, string givenName)
    {
        Strength = givenStrength;
        Intelligence = givenIntelligence;
        Dexterity = givenDexterity; 
        health = givenHealth;
        Name = givenName;
    }
    // Build Attack method
    public int Attack(Human target)
    {
        int damage = Strength * 3;
        target.health = target.health - 3;
        Console.WriteLine($"{Name} attacked {target.Name} for {damage} damage!");
        return target.health;
    }
}
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}
