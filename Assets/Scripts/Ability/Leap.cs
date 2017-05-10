using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Leap"),]
public class Leap : Ability
{
    // The distance the leap will send the player
    public float leapForce = 100;

    // Called on start to reset ability
    public override void Init(Character character)
    {
        base.Init(character);
    }

    // Overrrideable function to define what happens within the ability
    protected override void OnAbilityUse()
    {
        base.OnAbilityUse();

        Rigidbody rigidBody = ownerCharacter.GetComponent<Rigidbody>();
        rigidBody.AddForce((ownerCharacter.transform.forward + new Vector3(0, 0.5f, 0)) * leapForce, ForceMode.Impulse);
    }

    // Updates the abilities(Will be used in case of passives, reset cooldown, etc)
    public override void UpdateAbility()
    {
        base.UpdateAbility();
    }
}
