using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leap : Ability
{
    public float leapForce = 7500;

    public Leap()
    {
        id = 0;
    }

    public Leap(string name, int cost, int id, float cooldownTime, float cTime, Enumeration.AbilityType[] types, Enumeration.AbilityCost costType) : base(name, cost, id, cooldownTime, cTime, types, costType)
    {

    }

    public override void UseAbility(Character owner)
    {
        base.UseAbility(owner);
        Rigidbody rigidBody = owner.GetComponent<Rigidbody>();
        rigidBody.AddForce((owner.transform.forward + new Vector3(0, 0.35f, 0)) * leapForce, ForceMode.Impulse);
        owner.ForceStopMovement();
        owner.StartCoroutine(CheckIfLanded(owner));
    }

    private IEnumerator CheckIfLanded(Character owner)
    {

        yield return new WaitForSeconds(0.1f);
        if(owner.bIsGrounded)
        {
            owner.StartMovement();
        }
        else
        {
            owner.StartCoroutine(CheckIfLanded(owner));
        }
    }

    //// The distance the leap will send the player
    //public float leapForce = 100;
    //public bool isLeaping = false;

    //// Called on start to reset ability
    //public override void Init(Character character)
    //{
    //    base.Init(character);
    //}

    //// Overrrideable function to define what happens within the ability
    //protected override void OnAbilityUse()
    //{
    //    base.OnAbilityUse();
    //    if(isLeaping)
    //    {
    //        return;
    //    }

    //    Rigidbody rigidBody = ownerCharacter.GetComponent<Rigidbody>();
    //    rigidBody.AddForce((ownerCharacter.transform.forward + new Vector3(0, 0.5f, 0)) * leapForce, ForceMode.Impulse);
    //    isLeaping = true;
    //    ownerCharacter.ForceStopMovement();
    //}

    //// Updates the abilities(Will be used in case of passives, reset cooldown, etc)
    //public override void UpdateAbility()
    //{
    //    base.UpdateAbility();
    //    if (isLeaping && ownerCharacter.bIsGrounded)
    //    {
    //        isLeaping = false;
    //        ownerCharacter.StartMovement();
    //    }
    //}
}
