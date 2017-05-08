using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableObject : MonoBehaviour
{
    public struct DamageInfo
    {
        public Enumeration.Alliance damageDealer;
        public Enumeration.DamageType damageType;
        public int amountDone;
    }

    public int currentHealth = 0;
    [SerializeField]
    private int m_MaxHealth = 0;
    
    public Enumeration.Alliance damageDealer;
    public Enumeration.DamageType damageType;
    public int amountDone;

    public int currentShield = 0;

    void Start()
    {
        currentHealth = m_MaxHealth;   
    }

    void Update()
    {

    }

    public void TakeDamage(DamageInfo damageInfo)
    {
        Enumeration.Alliance dealer = damageInfo.damageDealer;
        Enumeration.DamageType damageType = damageInfo.damageType;

        // Figures out how to handle the damage output depending on the alliance of the damag edealer
        switch(dealer)
        {
            //case Enumeration.Alliance.A_ALLY:
                //break;
            //case Enumeration.Alliance.A_ENEMY:
                //break;
            default:
                if(damageType == Enumeration.DamageType.DT_DAMAGE)
                {
                    HurtObject(damageInfo.amountDone);
                }

                if (damageType == Enumeration.DamageType.DT_HEAL)
                {
                    HealObject(damageInfo.amountDone);
                }

                if (damageType == Enumeration.DamageType.DT_SHIELD)
                {
                    ShieldObject(damageInfo.amountDone);
                }
                break;
        }
    }

    // Reduces the the objects shield to 0 when taken enough damage, then starts to remove the objects "Health"
    public void HurtObject(int amount)
    {
        if (currentShield > 0)
        {
            currentShield -= amount;
            if (currentShield < 0)
            {
                amount = -currentShield;
                currentShield = 0;
            }
            else
            {
                amount = 0;
            }
        }

        currentHealth -= amount;
    }
    
    // Increases the current health of the object up until it reaches the maximum health
    public void HealObject(int amount)
    {
        currentHealth += amount;
        if (currentHealth > m_MaxHealth)
        {
            currentHealth = m_MaxHealth;
        }
    }
    
    // Increases the objects shield pool
    public void ShieldObject(int amount)
    {
        currentShield += amount;
    }
}
