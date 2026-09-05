using UnityEngine;
using System.Collections.Generic;
public class bullet : MonoBehaviour
{
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private float damage;
    [SerializeField] private float speed;
    [SerializeField] private float inacuracy;
    [SerializeField] private float maxHits;
    [SerializeField] private bool isArmourPiercing;

    GameObject closetsObject;
    private float oldDistance = 9999;

    [SerializeField] private string enemy;
    [SerializeField] private GameObject collisionEffect;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        List<GameObject> NearGameobjects = new List<GameObject>(GameObject.FindGameObjectsWithTag(enemy));
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
            rb.linearVelocity = (closetsObject.transform.position - transform.position).normalized * speed;
            rb.linearVelocity = new Vector3(rb.linearVelocity.x * (1 + Random.Range(-inacuracy, inacuracy)), rb.linearVelocity.y, rb.linearVelocity.z * (1 + Random.Range(-inacuracy, inacuracy)));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {damageEnemy(collision.gameObject);}
    private void OnTriggerEnter(Collider collision)
    {damageEnemy(collision.gameObject);}

    private void damageEnemy(GameObject collision)
    {
        if (collision.gameObject.CompareTag(enemy) && maxHits!=0)
        {
            maxHits--;
            collision.gameObject.GetComponent<Hp>().gethit(damage, isArmourPiercing);
            if (collisionEffect != null) Instantiate(collisionEffect, transform.position, Quaternion.identity);
        }
    }
}
