using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableCharacter : Character
{
    [SerializeField]
    private InputManager iManager;

    [SerializeField]
    private PlayerAnimationControl m_animationControl;

    public int playerNumber = 0;

    public AbilityInfo[] abilityInfo;

    [System.Serializable]
    public struct AbilityInfo
    {
        public int ID;
        public float CD;
    }

    public float GCD = 0;
    public float resetGCD = 0.5f;

    //public List<Ability> usedAbilities = new List<Ability>();

    virtual protected void MovementControl()
    {
        if (bCanMove)
        {
            if (Input.GetAxis("LeftJoystickX") != 0 || Input.GetAxis("LeftJoystickY") != 0)
            {
                Move(new Vector3(1 * Input.GetAxis("LeftJoystickX"), 0, 1 * Input.GetAxis("LeftJoystickY")), MaxSpeed, Force);
            }
        }
        if(bCanTurn)
        {
            if (Input.GetAxis("RightJoystickX") != 0 || Input.GetAxis("RightJoystickY") != 0)
            {
                Rotate(new Vector3(Input.GetAxis("RightJoystickX"), 0, Input.GetAxis("RightJoystickY")));
            }
        }

    }

    // Use this for initialization
    protected override void Start()
    {
        base.Start();

        iManager = FindObjectOfType<InputManager>();
        if (iManager)
        {
            iManager.SetCharacter(playerNumber, this);
        }

        m_animationControl = GetComponentInChildren<PlayerAnimationControl>();
    }

    // Update is called once per frame
    protected override void Update ()
    {
        base.Update();
        MovementControl();

        for(int i = 0; i < abilityInfo.Length; i++)
        {
            if (abilityInfo[i].CD > 0) 
            {
                abilityInfo[i].CD -= Time.deltaTime;
            }
        }

        if(GCD > 0)
            GCD -= Time.deltaTime;
        

        if(m_animationControl)
        {
            m_animationControl.SetSpeed(new Vector3(rb.velocity.x * transform.forward.x, rb.velocity.y * transform.forward.y, rb.velocity.z * transform.forward.z).magnitude);
        }
    }

    // Recieve the input form the controller and do what needs to be done
    public void UseInput(Enumeration.InputUse use)
    {
        switch(use)
        {
            case Enumeration.InputUse.IU_ABILITYONE:
                UseAbility(0);
                break;
            case Enumeration.InputUse.IU_ABILITYTWO:
                UseAbility(1);
                break;
            case Enumeration.InputUse.IU_ABILITYTHREE:
                UseAbility(2);
                break;
            case Enumeration.InputUse.IU_ABILITYFOUR:
                UseAbility(3);
                break;
        }
    }

    public void UseAbility(int slot)
    {
        if(abilityInfo[slot].CD > 0 || GCD > 0)
        {
            return;
        }

        Ability ab = AbilityBook.FindAbility(abilityInfo[slot].ID);

        switch(ab.abilityCostType)
        {
            case Enumeration.AbilityCost.AC_HEALTH:
                break;
            case Enumeration.AbilityCost.AC_MANA:
                break;
            case Enumeration.AbilityCost.AC_NONE:
                break;
        }

        GCD = resetGCD;
        abilityInfo[slot].CD = ab.cooldownTime;
        ab.UseAbility(this);
    }

    public void UseAnimation(Enumeration.AnimationUse animationUsed)
    {
        if (m_animationControl)
        {
            m_animationControl.UseAnimation(animationUsed);
        }
        
    }

    public float GetAnimationLength(Enumeration.AnimationUse animationUsed)
    {
        if (m_animationControl)
        {
            return m_animationControl.GetAnimationLength(animationUsed);
        }
        return 0;
    }
}
