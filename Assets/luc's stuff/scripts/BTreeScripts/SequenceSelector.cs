using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SequenceSelector : BTnode {

    protected int childIterator;
    public SequenceSelector(GameObject owningGameobject): base(owningGameobject)
    {
        childIterator = 0;

    }
}
