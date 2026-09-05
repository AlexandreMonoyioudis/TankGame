using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAI : MonoBehaviour
{
    [SerializeField] private float fireRate;
    [SerializeField] private string enemy;
    [SerializeField] private float range;
    [SerializeField] private LayerMask enemyMask = 0;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform shootingPoint;
    [SerializeField] private float shootingOffset;

    List<GameObject> NearGameobjects = new List<GameObject>();
    GameObject closetsObject;
    private float oldDistance = 9999;


    private void Something()
    {
        oldDistance = 9999;
        NearGameobjects = new List<GameObject>(GameObject.FindGameObjectsWithTag(enemy));
        if (NearGameobjects.Count != 0)
        {
            foreach (GameObject g in NearGameobjects)
            {
                float dist = Vector3.Distance(gameObject.transform.position, g.transform.position);
                if (dist < oldDistance)
                {
                    closetsObject = g;
                    oldDistance = dist;
                }
            }
            transform.LookAt(closetsObject.transform);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if (shootingPoint == null) shootingPoint = GetComponent<Transform>();
        if (enemy != "") Something();
        Invoke(nameof(shoot), fireRate*1.5f+3+shootingOffset);
    }

    private void Update()
    {
        if (!closetsObject)
        {
            if (enemy != "") Something();
        }
    }

    private void shoot() {
        if (enemyMask == 0)
        {
            Instantiate(bullet, shootingPoint.position, Quaternion.identity);
            Invoke(nameof(shoot), fireRate);
        }
        else if (Physics.CheckSphere(transform.position, range, enemyMask))
        {
            Instantiate(bullet,shootingPoint.position,Quaternion.identity);
            Invoke(nameof(shoot), fireRate);
        }
        else
        {
            Invoke(nameof(shoot), 1);
        }
        if (enemy != "") Something();

    }
    public void SetFireRate(float newFireRate)
    {
        fireRate = newFireRate;
    }
}
