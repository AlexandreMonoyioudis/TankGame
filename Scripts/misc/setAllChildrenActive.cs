using UnityEngine;

public class setAllChildrenActive : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        int children = transform.childCount;
        for (int i = 0; i < children; ++i)
            transform.GetChild(i).gameObject.SetActive(true);
    }
}
