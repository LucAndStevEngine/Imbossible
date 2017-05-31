using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testNode : BTnode {

    public testNode(GameObject owningGameobject): base(owningGameobject)
    {
        decorators.Add(new testDecorator(owningGameobject));
    }

    public override status Behavior()
    {
        if (checkDecorators() == false)
            return status.Fail;

        if (owningGameobject.transform.position.x >= 30)
            return status.Success;

        owningGameobject.transform.position += new Vector3(0.001f, 0, 0);

   
        return status.Running;
    }


}
