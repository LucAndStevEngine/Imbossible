using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // The info for each input, holds the keycode assigned to the input and the correspodning action that it should use
    public struct InputInfo
    {
        public Enumeration.InputUse inputUse;
        public KeyCode code;
    }

    // The playercontroller info
    // if a controller is plugged in it will enable it and store the corresponding input information within
    public struct PlayerControllerInfo
    {
        public bool bIsEnabled;
        public PlayableCharacter character;
        public string joystickName;
        public int joystickNumber;
        public InputInfo[] inputs;
    }


    public PlayerControllerInfo[] pControlInfo;
    public InputInfo iInfo;
    public bool newInputValue = false;

    public float controllerCheckTime = 2;
    private float recheckTime = 0;

    // Use this for initialization
    void Awake()
    {
        // Initialize the controllers
        pControlInfo = new PlayerControllerInfo[4];
        for (int i = 0; i < 4; i++)
        {
            pControlInfo[i].inputs = new InputInfo[(int)Enumeration.InputUse.IU_SIZE];
            pControlInfo[i].character = null;
            for(int j = 0; j < (int)Enumeration.InputUse.IU_SIZE; j ++)
            {
                pControlInfo[i].inputs[j].inputUse = (Enumeration.InputUse)j;
                pControlInfo[i].inputs[j].code = (KeyCode)System.Enum.Parse(typeof(KeyCode), "Joystick"+(i+1)+"Button"+j);
            }
        }

        // Check which controllers are connected
        CheckJoystickConnections();
        DontDestroyOnLoad(gameObject);
    }

    // Checks to see which controllers are connected at this point in time
    void CheckJoystickConnections()
    {
        string[] names = Input.GetJoystickNames();

        for (int i = 0; i < 4; i++)
        {
            if (i < names.Length)
            {
                pControlInfo[i].joystickName = names[i];
            }
            else
            {
                pControlInfo[i].joystickName = "";
            }

            if(pControlInfo[i].joystickName.Length > 0)
            {
                pControlInfo[i].bIsEnabled = true;
            }
            else
            {
                pControlInfo[i].bIsEnabled = false;
            }

            pControlInfo[i].joystickNumber = i + 1;
        }

    }

    // Update is called once per frame
    void Update()
    {
        // Check the controller connections every few seconds
        recheckTime += Time.deltaTime;
        if(recheckTime >= controllerCheckTime)
        {
            CheckJoystickConnections();
            recheckTime = 0;
        }

        // Figure out the input then send the information over
        for (int i = 0; i < 4; i++)
        {
            PlayerControllerInfo info = pControlInfo[i];
            if(info.bIsEnabled && info.character)
            {
                for (int j = 0; j < info.inputs.Length; j++)
                {
                    if (Input.GetKeyDown(info.inputs[j].code))
                    {
                        info.character.UseInput(info.inputs[j].inputUse);
                        Debug.Log(info.inputs[j].inputUse.ToString() + " - " + info.joystickNumber);
                    }
                }
            }
        }

    }

    // Finds the last pressed button and returns that value
    KeyCode FetchKey()
    {
        System.Array values = System.Enum.GetValues(typeof(KeyCode));
        foreach (KeyCode code in values)
        {
            if (Input.GetKeyDown(code))
            {
                char check = code.ToString()[8];
                if (check == '0' || check == '1' || check == '2' || check == '3')
                {
                    return code;
                }
            }
        }

        return KeyCode.None;
    }

    public void SetCharacter(int playerNumber, PlayableCharacter character)
    {
        if(!pControlInfo[playerNumber].character)
            pControlInfo[playerNumber].character = character;
    }

    public void ResetCharacters()
    {
        for (int i = 0; i < 4; i++)
        {
            pControlInfo[i].character = null;
        }
    }


 }
