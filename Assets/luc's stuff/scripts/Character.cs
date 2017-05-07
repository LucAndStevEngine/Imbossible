using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    public float axisV;
    public float axisH;

    public Vector3 direct;
    private Rigidbody rb;
   

    private void Move(Vector3 direction, float maxSpeed, float force)
    {
        direct = direction * force;
        rb.AddForce(direction * force, ForceMode.Impulse);
        float xSpeed = Mathf.Clamp(rb.velocity.x, -maxSpeed, maxSpeed);
        float ySpeed = rb.velocity.y; //Mathf.Clamp(rb.velocity.y, -maxSpeed, maxSpeed);
        float zSpeed = Mathf.Clamp(rb.velocity.z, -maxSpeed, maxSpeed);
        rb.velocity = new Vector3(xSpeed, ySpeed, zSpeed);
    }

   private void MovementControl()
    {
        if (Input.GetAxis("Vertical") > 0.9)
        {
            Move(Vector3.forward, 50, 40);
        }
        if (Input.GetAxis("Vertical") < -0.9)
        {
            Move(Vector3.back, 50, 40);
        }
        //if (Input.GetAxis("Horizontal") > 0.9f)
        //{
        //    Move(Vector3.right, 50, 40);
        //}
        // if (Input.GetAxis("Horizontal") < -0.9f)
        // {
        //     Move(Vector3.left, 50, 40);
        // }
    }

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        MovementControl();
        axisV = Input.GetAxis("Vertical");
        axisH = Input.GetAxis("Horizontal");

    }
}
