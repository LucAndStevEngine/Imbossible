using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : SequenceSelector {

        public Selector(GameObject owningGo): base(owningGo)
        {

        }

        public override  status Behavior()
        {
        if (childIterator > children.Count)
        {
            childIterator = 0;
            return status.Success;
        }

        else if (children[childIterator].Behavior() == status.Success)
        {
            childIterator = 0;
            return status.Success;
        }
        else if (children[childIterator].Behavior() == status.Fail)
        {
            childIterator++;
        }

        return status.Running;
    }


}
