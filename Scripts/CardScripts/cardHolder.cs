using UnityEngine;

public class cardHolder : MonoBehaviour
{
    [SerializeField]private GameObject card;

    public GameObject getCardPrefab() {
        return card;
            }
}
