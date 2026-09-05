using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    [SerializeField] private bool isCard;
    // Start is called before the first frame update
    void Start()
    {
        if (isCard)
        {
            Transform parent = transform.parent;
            foreach (Transform child in transform)
            {
                child.SetParent(parent);
            }
        }
        else transform.DetachChildren();
        Destroy(gameObject);
    }
    
}
