using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponToss : Ability
{
    float weaponThrowSpeed = 60.0f;

    public WeaponToss()
    {
        id = 0;
    }

    public WeaponToss(string name, int id, int cost, float cooldownTime, float cTime, Enumeration.AbilityType[] types, Enumeration.AbilityCost costType) : base(name, id, cost, cooldownTime, cTime, types, costType)
    {

    }

    public override void UseAbility(Character owner)
    {
        base.UseAbility(owner);
        
        PlayableCharacter pChar = (PlayableCharacter)owner;
        Weapon weapon = pChar.RemoveWeapon();
        
        if (weapon)
        {
            Rigidbody rb = weapon.GetComponent<Rigidbody>();
            rb.AddForce(pChar.transform.forward * weaponThrowSpeed, ForceMode.Impulse);
        }
    }
}
