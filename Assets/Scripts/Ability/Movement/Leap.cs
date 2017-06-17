using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leap : Ability
{
    public float leapForce = 7500;
    public int damageDone = 10;
    public float damageRadius = 10;
    

    public Leap()
    {
        id = 0;
    }

    public Leap(string name, int id, int cost, float cooldownTime, float cTime, Enumeration.AbilityType[] types, Enumeration.AbilityCost costType) : base(name, id, cost, cooldownTime, cTime, types, costType)
    {

    }

    public override void UseAbility(Character owner)
    {
        base.UseAbility(owner);
        Rigidbody rigidBody = owner.GetComponent<Rigidbody>();
        rigidBody.AddForce((owner.transform.forward + new Vector3(0, 0.35f, 0)) * leapForce, ForceMode.Impulse);
        owner.StopPositionalMovement();
        owner.StartCoroutine(CheckIfLanded(owner));
        PlayableCharacter pChar = (PlayableCharacter)owner;
        if(pChar)
        {
            pChar.UseAnimation(Enumeration.AnimationUse.AU_MOVEMENT);
        }
    }

    private IEnumerator CheckIfLanded(Character owner)
    {

        yield return new WaitForEndOfFrame();
        if(owner.bIsGrounded)
        {
            owner.StartPositionalMovement();
            DamageUponLanding(owner);
        }
        else
        {
            owner.StartCoroutine(CheckIfLanded(owner));
        }
    }
    

    // Need to implement damage upon landing
    private void DamageUponLanding(Character owner)
    {
  
        
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
