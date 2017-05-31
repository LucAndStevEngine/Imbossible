using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTree : MonoBehaviour {

    public SequenceSelector root;
    public GameObject owningGameobject;
	// Use this for initialization
	void Awake () {
        owningGameobject = this.gameObject;
        initialize();
	}
    public virtual void initialize()
    {

    }
	
	// Update is called once per frame
	void Update () {
        root.Behavior();
	}
}
