using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableCharacter : Character
{
    [SerializeField]
    private InputManager iManager;

    public int playerNumber = 0;

    public Ability[] abilities;

    virtual protected void MovementControl()
    {
        if (Input.GetAxis("LeftJoystickX") != 0 || Input.GetAxis("LeftJoystickY") != 0)
            Move(new Vector3(1 * Input.GetAxis("LeftJoystickX"), 0, 1 * Input.GetAxis("LeftJoystickY")), MaxSpeed, Force);
        if (Input.GetAxis("RightJoystickX") != 0 || Input.GetAxis("RightJoystickY") != 0)
            Rotate(new Vector3(Input.GetAxis("RightJoystickX"), 0, Input.GetAxis("RightJoystickY")));
    }

    // Use this for initialization
    protected override void Start()
    {
        base.Start();

        iManager = Object.FindObjectOfType<InputManager>();
        if (iManager)
        {
            iManager.SetCharacter(playerNumber, this);
        }

        for (int i = 0; i < abilities.Length; i++)
        {
            if (abilities[i])
            {
                abilities[i].Init(this);
            }
        }
    }
   
    // Update is called once per frame
    void Update ()
    {
        MovementControl();
        for (int i = 0; i < abilities.Length; i++)
        {
            if (abilities[i])
            {
                abilities[i].UpdateAbility();
            }
        }
    }

    // Recieve the input form the controller and do what needs to be done
    public void UseInput(Enumeration.InputUse use)
    {
        if(abilities[(int)use])
        {
            abilities[(int)use].UseAbility();
        }        
    }
}
