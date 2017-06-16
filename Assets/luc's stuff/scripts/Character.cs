using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // Movement variables
    public bool bCanMove = true;
    public bool bCanTurn = true;
    public bool bIsGrounded = true;

    // Max Speed and default max speed
    public float MaxSpeed;
    [SerializeField]
    protected float defaultMaxSpeed;

    // Max turn speed and default turn speed
    public float TurnSpeed;
    [SerializeField]
    protected float defaultTurnSpeed;

    // The force of acceleration for the character
    public float Force;
   
    public Vector3 Accel;
    protected Rigidbody rb;
    public Vector3 originalDirection;
    protected float angle;

    // Move the character in a direction with a set force using the maximum speed to clamp
    protected void Move(Vector3 direction, float maxSpeed, float force)
    {   
        rb.AddForce(direction.normalized * force, ForceMode.Impulse);
        float xSpeed = Mathf.Clamp(rb.velocity.x, -maxSpeed, maxSpeed);
        float ySpeed = rb.velocity.y; 
        float zSpeed = Mathf.Clamp(rb.velocity.z, -maxSpeed, maxSpeed);
        rb.velocity = new Vector3(xSpeed, ySpeed, zSpeed);
    }

    // Rotates the player slowly to a direction
    protected void Rotate(Vector3 direction)
    {
        angle = Vector3.Angle(originalDirection, direction);
        Vector3 crossP = Vector3.Cross(originalDirection, direction);
        if (crossP.y < 0)
        {
            angle = -angle;
        }

        Quaternion temp = Quaternion.AngleAxis(angle, Vector3.up);
        Quaternion temp2 = this.transform.localRotation;
        this.transform.localRotation = Quaternion.RotateTowards(temp2, temp, TurnSpeed);
    }

    // Use this for initialization
    virtual protected void Start ()
    {
        rb = GetComponent<Rigidbody>();
        originalDirection = new Vector3(0,0,1);
        MaxSpeed = defaultMaxSpeed;
        TurnSpeed = defaultTurnSpeed;
    }


    virtual protected void Update ()
    {
        bIsGrounded = CheckGrounded();
        Accel = rb.velocity;
    }

    // locks the turning movement for the character
    public void StopRotationalMovement()
    {
        bCanTurn = false;
    }

    // Locks the positional movement for the character
    public void StopPositionalMovement()
    {
        bCanMove = false;
    }

    //Locks all movement
    public void StopAllMovement()
    {
        StopRotationalMovement();
        StopPositionalMovement();
    }
    
    // Starts the movement of the character again
    public void StartRotationalMovement()
    {
        bCanTurn = true;
    }

    // Starts the movement of the character again
    public void StartPositionalMovement()
    {
        bCanMove = true;
    }
    
    // Starts all movement
    public void StartAllMovement()
    {
        StartRotationalMovement();
        StartPositionalMovement();
    }

    protected bool CheckGrounded()
    {
        RaycastHit[] hits;

        hits = Physics.RaycastAll(gameObject.transform.position, -Vector3.up, 1.0f);

        foreach(RaycastHit hit in hits)
        {
            if(hit.collider.gameObject.tag == "Ground")
            {
                return true;
            }
        }

        return false;

    }

    public void ResetMovement()
    {
        MaxSpeed = defaultMaxSpeed;
        TurnSpeed = defaultTurnSpeed;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(gameObject.transform.position, gameObject.transform.position - Vector3.up * 1.0f);
    }
}
