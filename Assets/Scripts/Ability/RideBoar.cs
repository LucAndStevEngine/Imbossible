using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RideBoar : Ability
{
    public float speedChange = 8;
    public float abilityLength = 2.0f;

    public RideBoar()
    {
        id = 0;
    }

    public RideBoar(string name, int cost, int id, float cooldownTime, float cTime, Enumeration.AbilityType[] types, Enumeration.AbilityCost costType) : base(name, cost, id, cooldownTime, cTime, types, costType)
    {

    }

    public override void UseAbility(Character owner)
    {
        base.UseAbility(owner);
        owner.ForceStopMovement();
        owner.MaxSpeed = speedChange;
        owner.StartCoroutine(StartAbility(owner));
    }

    private IEnumerator StartAbility(Character owner)
    {
        yield return new WaitForSeconds(castTime);
        owner.StartMovement();
        owner.StartCoroutine(EndAbility(owner));
    }

    private IEnumerator EndAbility(Character owner)
    {
        yield return new WaitForSeconds(abilityLength);
        owner.ResetMovement();
        
    }

}
