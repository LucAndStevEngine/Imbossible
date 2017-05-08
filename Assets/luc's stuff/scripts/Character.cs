using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    public float MaxSpeed;
    public float Force;
    public float TurnSpeed;
    public Vector3 Accel;
    private Rigidbody rb;
    private Vector3 originalDirection;
    protected float angle;

    protected void Move(Vector3 direction, float maxSpeed, float force)
    {   
        rb.AddForce(direction.normalized * force, ForceMode.Impulse);
        float xSpeed = Mathf.Clamp(rb.velocity.x, -maxSpeed, maxSpeed);
        float ySpeed = rb.velocity.y; 
        float zSpeed = Mathf.Clamp(rb.velocity.z, -maxSpeed, maxSpeed);
        rb.velocity = new Vector3(xSpeed, ySpeed, zSpeed);
        Accel = rb.velocity;
    }

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

    protected void MovementControl()
    {
        if (Input.GetAxis("LeftJoystickX") != 0 || Input.GetAxis("LeftJoystickY") != 0)
            Move(new Vector3(1 * Input.GetAxis("LeftJoystickX"), 0, 1 * Input.GetAxis("LeftJoystickY")), MaxSpeed, Force);
        if (Input.GetAxis("RightJoystickX") != 0 || Input.GetAxis("RightJoystickX") != 0)
            Rotate(new Vector3(Input.GetAxis("RightJoystickX"), 0, Input.GetAxis("RightJoystickY")));
    }

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        originalDirection = new Vector3(0,0,1);
    }

    // Update is called once per frame
    void Update () {
        MovementControl();

    }
}
