using UnityEngine;
using UnityEngine.SceneManagement;

public class ReastartOnDeath : MonoBehaviour
{
    private void OnDestroy()
    {
        Camera.main.transform.position = new Vector3(transform.position.x, Camera.main.transform.position.y, transform.position.z);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}