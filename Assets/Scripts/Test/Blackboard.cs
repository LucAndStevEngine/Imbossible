using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blackboard : MonoBehaviour
{
    public enum ClassType
    {
        CT_GAMEOBJECT,
        CT_VECTOR
    };

    [System.Serializable]
    public struct DictionaryInfo
    {
        public string ID;
        public ClassType classType;
        public GameObject target;
    } 

    public DictionaryInfo[] info;
    

    private Dictionary<string, GameObject> gameObjects = new Dictionary<string, GameObject>();
    private Dictionary<string, Vector3> vectors = new Dictionary<string, Vector3>();
  
    // Use this for initialization
    void Start ()
    {
        		
	}

    // Update is called once per frame
    void Update()
    {
        UpdateInfo();
    }


    // Returns a gameobject within the gameobject dictionary
    public GameObject GetGameObject(string ID)
    {
        GameObject obj = null;
        gameObjects.TryGetValue(ID, out obj);

        return obj;
    }
    
    // Returns a vector3 within the vector3 dictionary
    public Vector3 GetVector3(string ID)
    {
        Vector3 vec3;
        vectors.TryGetValue(ID, out vec3);

        return vec3;
    }


    // Changes the value of the object in the stored ID
    public void ChangeValue(string ID, GameObject obj)
    {
        for (int i = 0; i < info.Length; i++)
        {
            if (info[i].ID == ID)
            {
                info[i].target = obj;
            }
        }
    }

    // Sorts each object into its corresponding update function
    private void UpdateInfo()
    {
        for (int i = 0; i < info.Length; i++)
        {
            DictionaryInfo singleInfo = info[i];
            switch (singleInfo.classType)
            {
                case ClassType.CT_GAMEOBJECT:
                    UpdateGameObject(singleInfo);
                    break;
                case ClassType.CT_VECTOR:
                    UpdateVector3(singleInfo);
                    break;
                default:
                    break;     
            }
        }
    }

    // Updates the gameobject in the object list
    private void UpdateGameObject(DictionaryInfo information)
    {
        GameObject obj = null;
        gameObjects.TryGetValue(information.ID, out obj);
        if (obj != null)
        {
            gameObjects[information.ID] = information.target;
        }
        else
        {
            gameObjects.Add(information.ID, information.target);
        }
    }

    // Updates the vectors in the vector list
    private void UpdateVector3(DictionaryInfo information)
    {
        Vector3 vec3;
        vectors.TryGetValue(information.ID, out vec3);
        if (vec3 != null)
        {
            vectors[information.ID] = information.target.transform.position;
        }
        else
        {
            vectors.Add(information.ID, information.target.transform.position);
        }
    }

}
