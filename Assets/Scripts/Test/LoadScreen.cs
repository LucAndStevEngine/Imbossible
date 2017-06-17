using System;
using System.Collections.Generic;
using UnityEngine;

public class LoadScreen : MonoBehaviour
{

    struct AbilityInfo
    {
        public System.Type classType;

        public List<Enumeration.AbilityType> abilityTypes;
        public Enumeration.AbilityCost abilityCostType;

        public int resourceCost;
        public string abilityName;
        public int id;

        public float castTime;
        public float cooldownTime;
    }

    protected enum CurrentRead
    {
        CR_CLASS,
        CR_NAME,
        CR_ID,
        CR_COST,
        CR_CD,
        CR_CASTTIME,
        CR_TYPES,
        CR_COSTTYPE,
        CR_COUNT
    }

	// Use this for initialization
	void Awake ()
    {
        string abilitiesText = LoadFile("Assets/Resources/Abilities.txt");
        LoadAllAbilities(abilitiesText);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void LoadAllAbilities(string str)
    {
        string current = "";
        int j = 0;

        //Initilize the basic information for the abilities
        AbilityInfo info;
        info.classType = System.Type.GetType("Leap");
        info.abilityName = "";
        info.id = 0;
        info.resourceCost = 0;
        info.cooldownTime = 0;
        info.castTime = 0;
        info.abilityCostType = Enumeration.AbilityCost.AC_MANA;
        info.abilityTypes = new List<Enumeration.AbilityType>();
        CurrentRead currentRead = CurrentRead.CR_CLASS;

        // Start reading in the abilities
        for(int i = 0; i < str.Length; i++)
        {
            //Debug.Log(str.Length);

            if (str[i] == '-')
            {
                switch (currentRead)
                {
                    case CurrentRead.CR_CLASS:
                        info.classType = System.Type.GetType(current);
                        break;
                    case CurrentRead.CR_NAME:
                        info.abilityName = current;
                        break;
                    case CurrentRead.CR_ID:
                        info.id = int.Parse(current);
                        break;
                    case CurrentRead.CR_COST:
                        info.resourceCost = int.Parse(current);
                        break;
                    case CurrentRead.CR_CD:
                        info.cooldownTime = float.Parse(current);
                        break;
                    case CurrentRead.CR_CASTTIME:
                        info.castTime = float.Parse(current);
                        break;
                    case CurrentRead.CR_TYPES:
                        info.abilityTypes.Add(GetType(current));
                        break;
                    case CurrentRead.CR_COSTTYPE:
                        info.abilityCostType = GetCostType(current);
                        break;
                    default:
                        break;
                }

                //Debug.Log(current);
                current = "";
                currentRead++;
                if (currentRead == CurrentRead.CR_COUNT)
                {
                    //Create and store the ability into the abilitybook
                    object[] arguments = {info.abilityName, info.id, info.resourceCost, info.cooldownTime, info.castTime, info.abilityTypes.ToArray(), info.abilityCostType};
                    object myObj = System.Activator.CreateInstance(info.classType, arguments);
                    AbilityBook.AddAbility((Ability)myObj);
                    info.abilityTypes.Clear();
                    currentRead = CurrentRead.CR_CLASS;
                    i++;
                }
            }
            else if(str[i] == '*')
            {
                break;
            }
            else if(str[i] == '\n')
            {
                continue;
            }
            else
            {
                current += str[i].ToString();   
            }
            
        }
        
    }

    private Enumeration.AbilityCost GetCostType(string current)
    {
        switch (current)
        {
            case "Mana":
                return Enumeration.AbilityCost.AC_MANA;
            case "Health":
                return Enumeration.AbilityCost.AC_HEALTH;
            case "None":
                return Enumeration.AbilityCost.AC_NONE;
            default:
                return Enumeration.AbilityCost.AC_MANA;
        }
    }

    private Enumeration.AbilityType GetType(string current)
    {
        return Enumeration.AbilityType.AT_MELEE;
    }

    private string LoadFile(string fileName)
    {
        return System.IO.File.ReadAllText(fileName);
    }
}

