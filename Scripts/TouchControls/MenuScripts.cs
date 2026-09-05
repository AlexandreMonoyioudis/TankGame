using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScripts : MonoBehaviour
{
    public void changeScene(string nextScene) {
        Time.timeScale = 1;
        SceneManager.LoadScene(nextScene); 
    }
}
