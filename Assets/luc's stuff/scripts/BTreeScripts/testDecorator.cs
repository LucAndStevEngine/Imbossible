using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testDecorator : Decorator
{
    public testDecorator(GameObject oG) : base(oG)
    {

    }
    public override bool checkDecorator()
    {
        if (owningGameObject.transform.position.x > 50)
            return false;
        return true;
    }
}
