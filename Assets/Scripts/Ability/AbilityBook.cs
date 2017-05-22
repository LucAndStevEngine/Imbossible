using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AbilityBook
{
    public static Dictionary<int, Ability> abilityDatabase = new Dictionary<int, Ability>();

    public static Ability FindAbility(int ID)
    {
        Debug.Log(ID + "- Ability Named - " + abilityDatabase[ID].abilityName);
        return abilityDatabase[ID];
    }

    public static void AddAbility(Ability ab)
    {
        abilityDatabase.Add(ab.id, ab);
    }
}
