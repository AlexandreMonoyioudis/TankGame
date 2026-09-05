using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    private int Money;
    private int DisplayMoney = 1;
    [SerializeField] private string PlayerPrefsName;
    [SerializeField] private string DisplayName;


    // Update is called once per frame
    void Awake()
    {
        StartCoroutine(nameof(UpdateScore));
    }

    private IEnumerator UpdateScore()
    {
        while(true){
        Money = PlayerPrefs.GetInt(PlayerPrefsName);
        if (Money != DisplayMoney)
        {
            DisplayMoney = Mathf.Clamp((int)((DisplayMoney * 1.05) + 1), 0, Money);
            GetComponent<TextMeshProUGUI>().text = DisplayName + DisplayMoney;
        }
            yield return null;

            PlayerPrefs.DeleteKey("InUpgradeMenu");
            PlayerPrefs.Save();//saving results
        }
    }
}
