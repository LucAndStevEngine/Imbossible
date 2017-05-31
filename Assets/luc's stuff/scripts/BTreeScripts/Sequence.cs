using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : SequenceSelector {

    public Sequence(GameObject steve): base(steve)
        {

    }

    public override status Behavior()
    {
        if (childIterator > children.Count)
        {
            childIterator = 0;
            return status.Success;
        }

        else if (children[childIterator].Behavior() == status.Fail)
        {
            childIterator = 0;
            return status.Fail;
        }
        else if (children[childIterator].Behavior() == status.Success)
        {
            childIterator++;
        }

        return status.Running;
    }
}
