using System;

abstract class Character
{
    protected string charType;
    
    protected Character(string characterType) => this.charType = characterType;

    public abstract int DamagePoints(Character target);

    public virtual bool Vulnerable() => false;

    public override string ToString() => $"Character is a {charType}";
}

class Warrior : Character
{
    public Warrior() : base("Warrior")
    {
    }

    public override int DamagePoints(Character target)
    {
        if (target.Vulnerable())
        {
            return 10;
        }
        return 6;
    }
}

class Wizard : Character
{
    private bool spell = false;

    public Wizard() : base("Wizard")
    {
    }

    public override int DamagePoints(Character target)
    {
        if (spell)
        {
            return 12;
        }
        return 3;
    }

    public void PrepareSpell() => spell = true;

    public override bool Vulnerable() => !spell;
}