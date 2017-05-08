using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : ScriptableObject
{
    // Enums that effect the abilities
    public Enumeration.AbilityType[] abilityTypes;
    public Enumeration.AbilityCost abilityCost = Enumeration.AbilityCost.AC_NONE;
    public Enumeration.AbilityName abilityName = Enumeration.AbilityName.AN_DEFAULT;

    // The active cooldown of the ability(Can only be used if 0 or lower)
    public float cooldown = 0;
    // The internal cooldown to reset the ability 
    [SerializeField]
    protected float internalCooldown = 0;
    // The active cost of the ability
    public float resourceCost = 0;

    // Called on start to reset ability
    public void Init()
    {
        cooldown = 0;
    }
    
    // Called to use the ability from the player
    public bool UseAbility()
    {
        if (cooldown > 0)
            return false;

        OnAbilityUse();
        cooldown = internalCooldown;
        return true;     
    }

    // Overrrideable function to define what happens within the ability
    protected virtual void OnAbilityUse()
    {
    }

    // Updates the abilities(Will be used in case of passives, reset cooldown, etc)
    public void UpdateAbility()
    {
        if(cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
       
    }

    // Returns the interal cooldown of the ability
    public float GetInternalCooldown()
    {
        return internalCooldown;
    }


}
