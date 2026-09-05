using UnityEngine;

public class doesNotCarryThrewRounds : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        GameObject Start = GameObject.Find("Start GUI");
        if (Start)
        {
            if (Start.activeInHierarchy)
            {
                Destroy(gameObject);
            }
        }
    }
}
