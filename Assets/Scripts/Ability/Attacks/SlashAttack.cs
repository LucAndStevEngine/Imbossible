﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashAttack : Ability
{

    public SlashAttack()
    {
        id = 0;
    }

    public SlashAttack(string name, int id, int cost, float cooldownTime, float cTime, Enumeration.AbilityType[] types, Enumeration.AbilityCost costType) : base(name, id, cost, cooldownTime, cTime, types, costType)
    {

    }


    public override void UseAbility(Character owner)
    {
        base.UseAbility(owner);

        owner.StopAllMovement();
        PlayableCharacter pChar = (PlayableCharacter)owner;
        if (pChar)
        {
            pChar.UseAnimation(Enumeration.AnimationUse.AU_BASICATTACK);
            Debug.Log(pChar.GetAnimationLength(Enumeration.AnimationUse.AU_BASICATTACK));
        }
        owner.StartCoroutine(RestartMovement(owner));
    }

    private IEnumerator RestartMovement(Character owner)
    {
        yield return new WaitForSeconds(castTime);

        owner.StartAllMovement();
    }
}