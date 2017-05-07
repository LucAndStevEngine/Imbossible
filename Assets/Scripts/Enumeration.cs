using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enumeration : MonoBehaviour
{
    // The type of modifiers that effect the ability
    public enum AbilityType
    {
        AT_MELEE = 0,
        AT_SPELL,
        AT_CHANNEL

    }

    // The cost type of each ability
    public enum AbilityCost
    {
        AC_NONE = 0,
        AC_MANA,
        AC_HEALTH
    }

    // enum for each ability
    public enum AbilityName
    {
        AN_DEFAULT = 0,
        AN_SLASH,

    }
}
