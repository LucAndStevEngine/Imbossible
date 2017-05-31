using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testTree : BTree {

    public override void initialize()
    {
        root = new Selector(owningGameobject);
        root.AddChild(new testNode(owningGameobject));
    }
}
