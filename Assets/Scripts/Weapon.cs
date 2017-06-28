using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int weaponDamage = 1;
    public float weaponLength = 1.0f;
    public Vector3 weaponOffset;

    [SerializeField]
    private GameObject owner;
    [SerializeField]
    private List<GameObject> hitObjects = new List<GameObject>();
    
	// Use this for initialization
	void Start ()
    {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position - (transform.up * weaponLength)/2, transform.up * weaponLength);
    }

    public void StartAttack()
    {
        hitObjects.Add(owner);
        StartCoroutine(AttackCheck());
    }

    public void EndAttack()
    {
        StopAllCoroutines();
        hitObjects.Clear();
    }

    public IEnumerator AttackCheck()
    {
        RaycastHit[] hits;

        hits = Physics.RaycastAll(transform.position - (transform.up * weaponLength) / 2, transform.up, weaponLength);

        bool allreadyHit = false;


        foreach (RaycastHit hit in hits)
        {
            GameObject hitObject = hit.collider.gameObject;
            for (int i = 0; i < hitObjects.Count; i++)
            {
                if(hitObjects[i] == hitObject)
                {
                    allreadyHit = true;
                    break;
                }
            }

            if(allreadyHit)
            {
                continue;
            }

            Debug.Log("Hit - " + hitObject.name);
            //Send damage and add the object to a list of allready hit objects
            DamageableObject.DamageInfo damageInfo;
            damageInfo.amountDone = weaponDamage;
            damageInfo.damageDealer = Enumeration.Alliance.A_ALLY;
            damageInfo.damageType = Enumeration.DamageType.DT_DAMAGE;

            hitObject.SendMessage("TakeDamage", damageInfo, SendMessageOptions.DontRequireReceiver);
            hitObjects.Add(hitObject);
        }

        yield return new WaitForEndOfFrame();

        StartCoroutine(AttackCheck());

    }

    public void SetOwner(GameObject owner)
    {
        this.owner = owner;
    }


}
