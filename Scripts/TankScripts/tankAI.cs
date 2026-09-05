using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class tankAI : MonoBehaviour
{
    private NavMeshAgent na;
    [SerializeField] private string enemy;

    List<GameObject> NearGameobjects = new List<GameObject>();
    GameObject closetsObject;
    private float oldDistance = 9999;

    private void Something()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        na = GetComponent<NavMeshAgent>();
        repath();
    }

    // Update is called once per frame
    void Update()
    {

        if (closetsObject == null)
        {
            CancelInvoke();
            repath();
        }
    }
    private void repath()
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
            na.SetDestination(closetsObject.transform.position);
        }


        Invoke(nameof(repath), Random.Range(.5f, 2f));
    }
}
