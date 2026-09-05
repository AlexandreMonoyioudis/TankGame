using UnityEngine;

public class bombMenuSelector : MonoBehaviour
{
    private Transform newParent;
    private Transform newOtherParent;
    private void Awake()
    {
        GameObject.Find("Image (1)");
        GameObject.Find("bomber Selector");
    }
    public void setPostitionInMenu()
    {
        if (transform.parent == newParent) { 
            transform.SetParent(newOtherParent);
        }

        else { 
            transform.SetParent(newParent);
        }
    }
}
