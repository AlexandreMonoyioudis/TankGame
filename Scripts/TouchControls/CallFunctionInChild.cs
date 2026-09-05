using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CallFunctionInChild : MonoBehaviour
{
    [SerializeField] private GameObject Object;
    private void OnDestroy()
    {
        Object.SetActive(true);
        transform.parent.GetComponent<EnemySpawner>().GameOver();
    }
}
