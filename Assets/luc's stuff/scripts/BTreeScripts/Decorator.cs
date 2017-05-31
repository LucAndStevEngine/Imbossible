using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Decorator  {
    protected GameObject owningGameObject;
    public Decorator(GameObject oGameobject)
    {
        owningGameObject = oGameobject;
    }
    public abstract bool checkDecorator();
 
}
