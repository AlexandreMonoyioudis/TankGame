using UnityEngine;

public class bombingRun : MonoBehaviour
{
    [SerializeField] private GameObject bombDropShadow;
    [SerializeField] private GameObject explotion;
    [SerializeField] private int dropTime;
    [SerializeField] private float fallTime;
    private GameObject currentBomb;
    private float originalPos;
    private float speedMulti;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speedMulti = 2;
        transform.rotation = Quaternion.Euler(90, 0, -90);
        originalPos = transform.position.x;
        transform.position = new Vector3(transform.position.x - 200, .5f, transform.position.z);
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + speedMulti * 200 * (Time.deltaTime / dropTime), transform.position.y, transform.position.z);
        if (transform.position.x > originalPos && originalPos != 1000)
        {
            speedMulti = 0.5f;
            currentBomb = Instantiate(bombDropShadow, new Vector3(originalPos, transform.position.y, transform.position.z), Quaternion.Euler(90, 0, 0));
            originalPos = 1000;
        }
        else if (originalPos != 1000)
        {
            speedMulti = (originalPos + 50 - transform.position.x) / 100;
        }

        if (currentBomb != null)
        {
            currentBomb.transform.localScale += Vector3.one * (Time.deltaTime / fallTime);
            if (currentBomb.transform.localScale.x >= 2)
            {
                speedMulti = 1f;
                Debug.Log("bombDropped");
                Instantiate(explotion, new Vector3(currentBomb.transform.position.x, 0.2f, currentBomb.transform.position.z), Quaternion.identity);
                Destroy(currentBomb);
                currentBomb = null;
            }
        }
        if (transform.position.x > 450 && currentBomb == null)
        {
            Destroy(gameObject);
        }
    }
}
