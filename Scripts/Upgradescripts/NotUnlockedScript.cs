using UnityEngine;

public class NotUnlockedScript : MonoBehaviour
{
    [SerializeField] private string LevelValue;
    // Start is called before the first frame update
    private void OnEnable()
    {
        if (!(PlayerPrefs.GetInt(LevelValue) > 0)) gameObject.SetActive(false);
    }
    private void Start()
    {
        if (!(PlayerPrefs.GetInt(LevelValue) > 0)) gameObject.SetActive(false);
    }
}
