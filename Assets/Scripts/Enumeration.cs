using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enumeration : MonoBehaviour
{
    // The type of damage being output
    public enum DamageType
    {
        DT_HEAL = 0,
        DT_DAMAGE,
        DT_SHIELD
    }

    // The side the object is on
    public enum Alliance
    {
        A_ALLY,
        A_ENEMY,
        A_NEUTRAL
    }

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
        AN_LEAP
    }

    public enum InputUse
    {
        IU_ABILITYONE = 0,
        IU_ABILITYTWO,
        IU_ABILITYTHREE,
        IU_ABILITYFOUR,
        IU_SIZE
    }
}
