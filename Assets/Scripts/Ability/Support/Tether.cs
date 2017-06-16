using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tether : Ability
{
    protected float tetherForce = 100.0f;
    private GameObject tetherObject;

    public Tether()
    {
        id = 0;
    }

    public Tether(string name, int id, int cost, float cooldownTime, float cTime, Enumeration.AbilityType[] types, Enumeration.AbilityCost costType) : base(name, id, cost, cooldownTime, cTime, types, costType)
    {
        tetherObject = LoadObject("Prefabs/Tether_PFB");
    }

    public override void UseAbility(Character owner)
    {
        base.UseAbility(owner);
        Vector3 direction = owner.transform.forward;
        GameObject tetherObjCopy = GameObject.Instantiate<GameObject>(tetherObject, owner.transform.position, owner.transform.rotation, null);
        Rigidbody rigidBody = tetherObjCopy.GetComponent<Rigidbody>();
        rigidBody.AddForce(direction * tetherForce, ForceMode.Impulse);
    }

}
