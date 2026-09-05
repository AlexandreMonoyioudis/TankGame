using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UpgradeScript : MonoBehaviour
{
    [SerializeField] private int level;
    [SerializeField] private string tankLevel;
    // Start is called before the first frame update
    [SerializeField] private UpgradeType Upgrade;
    [SerializeField] private float UpgradeVal;
    private enum UpgradeType{ 
        hp,
        speed,
        fireRate
    }

    void OnEnable()
    {
        if ((PlayerPrefs.GetInt(tankLevel) >= level && gameObject.layer ==6) || (gameObject.layer == 7 && level*2 < PlayerPrefs.GetInt("Waves")))//checks if high enough level
        {
            if (Upgrade == UpgradeType.hp)
            {
                UpgradeHp();
            }
            else if (Upgrade == UpgradeType.fireRate)
            {
                UpgradeFireRate();
            }
            else
            {
                UpgradeSpeed();
            }
        }
    }

    private void UpgradeHp()
    {
        gameObject.GetComponent<Hp>().SetMaxHp((int)UpgradeVal);
    }

    private void UpgradeFireRate()
    {
        gameObject.GetComponent<GunAI>().SetFireRate(UpgradeVal);
    }

    private void UpgradeSpeed()
    {
        gameObject.GetComponent<NavMeshAgent>().speed = UpgradeVal;
    }

}
