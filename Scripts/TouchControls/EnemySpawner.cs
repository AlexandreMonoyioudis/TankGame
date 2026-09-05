using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemySpawner : MonoBehaviour
{
    private bool paused;
    private int wave = 1;
    private int waveStrength =2;
    private TextMeshProUGUI MoneyDisplay;

    [Header("Events")]
    [SerializeField] private GameObject[] events;
    [Header("Units")]
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private int[] enemyStreangth;
    [SerializeField] private GameObject[] turrets;
    [Header("Display")]
    [SerializeField] private RectTransform WaveDisplay;
    [Header("difficulty")]
    [SerializeField] private int difficulty;
    private string ValueDisplayed;

    // Start is called before the first frame update
    void Start()
    {
        paused = false;
        MoneyDisplay = transform.GetChild(0).GetChild(2).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        //Debug.Log(MoneyDisplay.name);
        nextWave();
    }
    private void Awake()
    {

        PlayerPrefs.SetInt("Money", 0);
        PlayerPrefs.SetInt("InUpgradeMenu", 1);
        PlayerPrefs.SetInt("Waves", wave);
        PlayerPrefs.Save();
    }

    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("Team2") == null) nextWave();
    }

    private void nextWave()
    {
        GameObject[] tanks = GameObject.FindGameObjectsWithTag("Team1");
        foreach (GameObject tank in tanks)//destroys all current tanks
        {
            if (tank.name != "Base") Destroy(tank);
        }
        
        int rand;
        wave++;
        Time.timeScale = 0;
        paused = true;
        transform.GetChild(0).GetChild(1).gameObject.SetActive(true);//enables spawning menu
        transform.GetChild(0).GetChild(2).gameObject.SetActive(true);//enables button
        waveStrength = 7 * difficulty*wave-10;
        while (waveStrength > 1)
        {
            rand = Random.Range(0, enemyStreangth.Length);
            if (enemyStreangth[rand] <= waveStrength)
            {
                waveStrength -= enemyStreangth[rand];
                spawnEnemy(rand, waveStrength);
            }
        }

        waveStrength = Mathf.RoundToInt(wave * difficulty * 700 / (146 + wave * 4 * difficulty));
        //Debug.Log(PlayerPrefs.GetInt("Money"));
        PlayerPrefs.SetInt("Money", int.Parse(MoneyDisplay.text) + waveStrength);
        PlayerPrefs.SetInt("Waves", wave - 1);
        PlayerPrefs.Save();
        MoneyDisplay.text = PlayerPrefs.GetInt("Money").ToString();
    }

    private void spawnEnemy(int rand, int waveStrength)
    {;
        Vector2 pos = Vector2.zero;
        while (pos.x < 1f && pos.y < 1f && pos.x > -1f && pos.y > -1f)
        {
            pos = new Vector2(Random.Range(-1.2f, 1.2f), Random.Range(-1.2f, 1.2f));
        }
        Instantiate(enemies[rand], new Vector3(250 + 50 * pos.x, 0f, 250 + 50 * pos.y), Quaternion.identity);
    }

    public void StartWave()
    {
        transform.GetChild(0).GetChild(1).gameObject.SetActive(false);//disables spawning menu
        transform.GetChild(0).GetChild(2).gameObject.SetActive(false);//disables button
        Time.timeScale = 1;
        paused = false;
        ValueDisplayed = "Wave " + PlayerPrefs.GetInt("Waves");//sets name for cortine
        StartCoroutine(nameof(NextWaveDisplay));
        if (Random.Range(1, 10) == 1) StartCoroutine(nameof(Event));//1 in 5 chance to have an event
    }

    public void togglePause(bool pause)
    {
        if (!pause && !paused)
        {
            paused = false;
            Time.timeScale = 1;
            //Debug.Log("Unpause");
        }
        else
        {
            Time.timeScale = 0;
            //Debug.Log("pause");
        }
    }

    private IEnumerator NextWaveDisplay()
    {
        WaveDisplay.gameObject.SetActive(true);
        WaveDisplay.gameObject.GetComponent<TextMeshProUGUI>().text = ValueDisplayed;
        WaveDisplay.offsetMin = new Vector2(0, 100);
        for (int i = 100; i >= 0; i-=5)
        {
            WaveDisplay.offsetMin = new Vector2(WaveDisplay.offsetMin.x, i);
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(4f);
        for (int i = 0; i <= 100; i += 20)
        {
            WaveDisplay.offsetMin = new Vector2(WaveDisplay.offsetMin.x, i);
            yield return new WaitForSeconds(0.02f);
        }
        WaveDisplay.gameObject.SetActive(false);
        yield return null;
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        paused = true;
        int tanks = GameObject.FindGameObjectsWithTag("Team2").Length;
        int money = ((wave-1) * 100 + (wave -9) * 5) * difficulty + Mathf.Max((wave*10)-tanks,wave*2) * difficulty;
        PlayerPrefs.SetInt("Rewards", money);
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins")+money);
    }
    private IEnumerator Event()
    {
        int eventNo = Random.Range(0, events.Length - 1);
        ValueDisplayed = events[eventNo].name;
        GameObject CurrentEvent = Instantiate(events[eventNo]);//starts event
        yield return new WaitForSeconds(4f);
        StartCoroutine(nameof(NextWaveDisplay));
    }
}
