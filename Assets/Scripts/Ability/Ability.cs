using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability
{
    // Enums that effect the abilities
    public Enumeration.AbilityType[] abilityTypes;
    public Enumeration.AbilityCost abilityCostType = Enumeration.AbilityCost.AC_NONE;

    public int resourceCost = 0;
    public string abilityName = "";
    public int id;

    public float castTime = 0.0f;
    public float cooldownTime = 0.0f;

    public Ability()
    {
        id = 0;
    }

    public Ability(string name, int cost, int id, float cooldownTime, float cTime, Enumeration.AbilityType[] types, Enumeration.AbilityCost costType)
    {
        this.abilityName = name;
        this.resourceCost = cost;
        this.id = id;
        this.cooldownTime = cooldownTime;
        this.castTime = cTime;
        this.abilityCostType = costType;
        this.abilityTypes = types;
    }

    public virtual void UseAbility(Character owner)
    {

    }



    //// The active cooldown of the ability(Can only be used if 0 or lower)
    //public float cooldown = 0;
    //// The internal cooldown to reset the ability 
    //[SerializeField]
    //protected float internalCooldown = 0;
    //// The active cost of the ability
    //public float resourceCost = 0;

    //public Character ownerCharacter;

    //// Called on start to reset ability
    //public virtual void Init(Character character)
    //{
    //    cooldown = 0;
    //    ownerCharacter = character;
    //}

    //// Called to use the ability from the player
    //public bool UseAbility()
    //{
    //    if (cooldown > 0)
    //        return false;

    //    OnAbilityUse();
    //    cooldown = internalCooldown;
    //    return true;     
    //}

    //// Overrrideable function to define what happens within the ability
    //protected virtual void OnAbilityUse()
    //{
    //}

    //// Updates the abilities(Will be used in case of passives, reset cooldown, etc)
    //public virtual void UpdateAbility()
    //{
    //    if(cooldown > 0)
    //    {
    //        cooldown -= Time.deltaTime;
    //    }

    //}

    //// Returns the interal cooldown of the ability
    //public float GetInternalCooldown()
    //{
    //    return internalCooldown;
    //}


}
