using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTnode : MonoBehaviour {

    private List<BTnode> children = new List<BTnode>();
    private BTnode Parent;
    
    public void AddChild(BTnode node)
    {
        children.Add(node); 
    }
    public void RemoveChild(BTnode node)
    {
        children.Remove(node);
    }                                                                                
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
