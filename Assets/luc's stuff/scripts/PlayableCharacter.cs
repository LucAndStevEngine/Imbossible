using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableCharacter : Character {

    virtual protected void MovementControl()
    {
        if (Input.GetAxis("LeftJoystickX") != 0 || Input.GetAxis("LeftJoystickY") != 0)
            Move(new Vector3(1 * Input.GetAxis("LeftJoystickX"), 0, 1 * Input.GetAxis("LeftJoystickY")), MaxSpeed, Force);
        if (Input.GetAxis("RightJoystickX") != 0 || Input.GetAxis("RightJoystickX") != 0)
            Rotate(new Vector3(Input.GetAxis("RightJoystickX"), 0, Input.GetAxis("RightJoystickY")));
    }

    // Use this for initialization
      protected override void Start () {
        base.Start();
	}
	
	// Update is called once per frame
	void Update () {
        MovementControl();
	}
}
