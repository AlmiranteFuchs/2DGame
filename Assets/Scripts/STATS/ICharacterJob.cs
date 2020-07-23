using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface ICharacterJob
{
    //Precisa ter armas/armaduras específicas
    //Precisa ter habilidades específicas

    void Attack();
    // If different jobs have different abilities, might a list of available commands.
    // Ability[] Abilities { get; }
}

public class Wizard : ICharacterJob
{
    public void Attack()
    { // cast spell here }
    }
}
public class Warrior : ICharacterJob
{
    public void Attack()
    { // cast spell here }
    }
}
public class Ranger : ICharacterJob
{
    public void Attack()
    { // cast spell here }
    }
}
public class None : ICharacterJob
{
    public void Attack()
    {

    }
}

