using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BTnode  {

    protected List<Decorator> decorators = new List<Decorator>();

    protected List<BTnode> children = new List<BTnode>();
    protected BTnode Parent;
    protected GameObject owningGameobject;

    public enum status
    {
        Success,
        Running,
        Fail
    }


    public BTnode(GameObject gObject)
    {
        owningGameobject = gObject;
    }

    public void AddChild(BTnode node)
    {
        node.Parent = this;
        children.Add(node); 
    }
    public void RemoveChild(BTnode node)
    {
        children.Remove(node);
    }

    public void AddDecorator(Decorator dec)
    {
        decorators.Add(dec);
    }
    public void RemoveDecorator(Decorator dec)
    {
        decorators.Remove(dec);
    }

    public abstract status Behavior();
                                                                           
    public bool checkDecorators()
    {
        for(int i = 0; i < decorators.Count; i++)
        {
            if (decorators[i].checkDecorator() == false)
                return false;
        }
        return true;
    }
}
