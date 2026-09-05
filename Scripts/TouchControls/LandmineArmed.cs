using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandmineArmed : MonoBehaviour
{
    private void OnDestroy()
    {
        transform.parent.tag = "Mine";//landmines cannot be targeted
        transform.parent.GetChild(0).gameObject.SetActive(true);//explosive set
    }
}
