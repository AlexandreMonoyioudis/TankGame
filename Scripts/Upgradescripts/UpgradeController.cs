using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI MoneyDisplay;
    [SerializeField] private TextMeshProUGUI UpgradeButtonTitle;
    [SerializeField] private TextMeshProUGUI UpgradeButtonRow1;
    [SerializeField] private TextMeshProUGUI UpgradeButtonRow2;
    private int money;
    private bool Pressed;
    // Start is called before the first frame update
    private void OnEnable()
    {
        //PlayerPrefs.DeleteAll();
        //PlayerPrefs.SetInt("Coins", 10000);//remove for release
        //sets money and upgrade menu
        money = PlayerPrefs.GetInt("Coins");
        MoneyDisplay.text ="Money: "+ money;
        //sets all tanks to level 1 on open
        if (!PlayerPrefs.HasKey("tanklvl"))
            PlayerPrefs.SetInt("tanklvl", 1);
        
        if (!PlayerPrefs.HasKey("sniperlvl"))

            PlayerPrefs.SetInt("sniperlvl", 1);
        
        if (!PlayerPrefs.HasKey("titanlvl"))

            PlayerPrefs.SetInt("titanlvl", 1);

        if (!PlayerPrefs.HasKey("cascadelvl"))

            PlayerPrefs.SetInt("cascadelvl", 0);

        if (!PlayerPrefs.HasKey("eviceratorlvl"))

            PlayerPrefs.SetInt("eviceratorlvl", 0);

        PlayerPrefs.Save();
        Invoke(nameof(Upgrade),.1f);
    }

    public void Upgrade(bool pressed)
    {
        Pressed = pressed;
        //finds unit then upgrades unit
        //Debug.Log(Pressed);
        print(GameObject.FindGameObjectsWithTag("Team1"));
        //tamk upgrade
        if (GameObject.Find("Tank1") || GameObject.Find("Tank1 (3)"))
        {
            int lvl = PlayerPrefs.GetInt("tanklvl");
            //Debug.Log("Tank");
            switch (lvl)
            {
                case 1:
                    ChangeText(150, lvl, "tank", 6, 3, 1, 1.2f, "1.5", "0", "0");
                    if (money >= 150 && Pressed)
                    {
                        money -= 150;
                        PlayerPrefs.SetInt("tanklvl", 2);
                    }
                    break;
                case 2:
                    ChangeText(450, lvl, "tank", 6, 3, 1, 1.5f, "0", "0", "2.7");
                    if (money >= 450 && Pressed)
                    {
                        money -= 450;
                        PlayerPrefs.SetInt("tanklvl", 3);
                    }
                    break;
                case 3:
                    ChangeText(1000, lvl, "tank", 6, 2.7f, 1, 1.5f, "0", "0", "2.5");
                    if (money >= 1000 && Pressed)
                    {
                        money -= 1000;
                        PlayerPrefs.SetInt("tanklvl", 4);
                    }
                    break;
                case 4:
                    ChangeText(1500, lvl, "tank", 6, 2.5f, 1, 1.5f, "0", "7", "2.4");
                    if (money >= 1500 && Pressed)
                    {
                        money -= 1500;
                        PlayerPrefs.SetInt("tanklvl", 5);
                    }
                    break;
                case 5:
                    ChangeText(2500, lvl, "tank", 7, 2.4f, 1, 1.5f, "1.6", "8", "2.3");
                    if (money >= 2500 && Pressed)
                    {
                        money -= 2500;
                        PlayerPrefs.SetInt("tanklvl", 6);
                    }
                    break;
                case 6:
                    ChangeText(0, lvl, "tank", 8, 2.3f, 1, 1.6f, "0", "0", "0");
                    break;
            }
        }
        else if (GameObject.Find("Sniper Tank 1 (1)"))
        {
            int lvl = PlayerPrefs.GetInt("sniperlvl");
            //Debug.Log("sniper");
            switch (lvl)
            {
                case 1:
                    ChangeText(200, lvl, "Sniper Tank", 3, 3.2f, 5, 1.2f, "1.5", "0", "0");
                    if (money >= 150 && Pressed)
                    {
                        money -= 150;
                        PlayerPrefs.SetInt("sniperlvl", 2);
                    }
                    break;
                case 2:
                    ChangeText(500, lvl, "Sniper Tank", 3, 3.2f, 5, 1.5f, "0", "0", "3");
                    if (money >= 450 && Pressed)
                    {
                        money -= 450;
                        PlayerPrefs.SetInt("sniperlvl", 3);
                    }
                    break;
                case 3:
                    ChangeText(1000, lvl, "Sniper Tank", 3, 3f, 5, 1.5f, "0", "4", "0");
                    if (money >= 1000 && Pressed)
                    {
                        money -= 1000;
                        PlayerPrefs.SetInt("sniperlvl", 4);
                    }
                    break;
                case 4:
                    ChangeText(1500, lvl, "Sniper Tank", 4, 3f, 5, 1.5f, "1.7", "0", "2.8");
                    if (money >= 1500 && Pressed)
                    {
                        money -= 1500;
                        PlayerPrefs.SetInt("sniperlvl", 5);
                    }
                    break;
                case 5:
                    ChangeText(2500, lvl, "Sniper Tank", 4, 2.8f, 5, 1.5f, "0", "5", "2.5");
                    if (money >= 2500 && Pressed)
                    {
                        money -= 2500;
                        PlayerPrefs.SetInt("sniperlvl", 6);
                    }
                    break;
                case 6:
                    ChangeText(0, lvl, "Sniper Tank", 5, 2.5f, 5, 1.5f, "0", "0", "0");
                    break;
            }
        }
        else if (GameObject.Find("Large Tank(Clone)") || GameObject.Find("Large Tank"))
        {
            int lvl = PlayerPrefs.GetInt("titanlvl");
            //Debug.Log("Titan");
            switch (lvl)
            {
                case 1:
                    ChangeText(250, lvl, "Titan", 35, 2.5f, 1, 1.7f, "2", "36", "2.4");
                    if (money >= 250 && Pressed)
                    {
                        money -= 250;
                        PlayerPrefs.SetInt("titanlvl", 2);
                    }
                    break;
                case 2:
                    ChangeText(600, lvl, "Titan", 36, 2.4f, 1, 2, "0", "38", "2.3");
                    if (money >= 600 && Pressed)
                    {
                        money -= 600;
                        PlayerPrefs.SetInt("titanlvl", 3);
                    }
                    break;
                case 3:
                    ChangeText(1200, lvl, "Titan", 38, 2.3f, 1, 2, "0", "40", "0");
                    if (money >= 1200 && Pressed)
                    {
                        money -= 1200;
                        PlayerPrefs.SetInt("titanlvl", 4);
                    }
                    break;
                case 4:
                    ChangeText(1600, lvl, "Titan", 40, 2.3f, 1, 2, "2.1", "43", "2.2");
                    if (money >= 1600 && Pressed)
                    {
                        money -= 1600;
                        PlayerPrefs.SetInt("titanlvl", 5);
                    }
                    break;
                case 5:
                    ChangeText(2600, lvl, "Titan", 43, 2.2f, 1, 2.1f, "2.2", "45", "0");
                    if (money >= 2600 && Pressed)
                    {
                        money -= 2600;
                        PlayerPrefs.SetInt("titanlvl", 6);
                    }
                    break;
                case 6:
                    ChangeText(0, lvl, "Titan", 45, 2.2f, 1, 2.2f, "0", "0", "0");
                    break;
            }
        }
        else if (GameObject.Find("Cascade1(Clone)"))
        {
            int lvl = PlayerPrefs.GetInt("cascadelvl");
            //Debug.Log("Titan");
            switch (lvl)
            {
                case 0:
                    ChangeText(2000, lvl, "Unlock Cascade", 35, 7.5f, 10, 1.7f, "0", "0", "0");
                    if (money >= 2000 && Pressed)
                    {
                        money -= 2000;
                        PlayerPrefs.SetInt("cascadelvl", 1);
                    }
                    break;
                case 1:
                    ChangeText(1250, lvl, "Cascade", 35, 7.5f, 10, 1.7f, "2", "36", "7");
                    if (money >= 1250 && Pressed)
                    {
                        money -= 1250;
                        PlayerPrefs.SetInt("cascadelvl", 2);
                    }
                    break;
                case 2:
                    ChangeText(1600, lvl, "Cascade", 36, 7f, 10, 2, "0", "38", "6.5");
                    if (money >= 1600 && Pressed)
                    {
                        money -= 1600;
                        PlayerPrefs.SetInt("cascadelvl", 3);
                    }
                    break;
                case 3:
                    ChangeText(2200, lvl, "Cascade", 38, 6.5f, 10, 2, "0", "40", "6");
                    if (money >= 2200 && Pressed)
                    {
                        money -= 2200;
                        PlayerPrefs.SetInt("cascadelvl", 4);
                    }
                    break;
                case 4:
                    ChangeText(3600, lvl, "Cascade", 40, 6f, 10, 2, "2.1", "43", "5.5");
                    if (money >= 3600 && Pressed)
                    {
                        money -= 3600;
                        PlayerPrefs.SetInt("cascadelvl", 5);
                    }
                    break;
                case 5:
                    ChangeText(4000, lvl, "Cascade", 43, 5.5f, 10, 2.1f, "2.2", "45", "5");
                    if (money >= 4000 && Pressed)
                    {
                        money -= 4000;
                        PlayerPrefs.SetInt("cascadelvl", 6);
                    }
                    break;
                case 6:
                    ChangeText(0, lvl, "Cascade", 45, 5f, 10, 2.2f, "0", "0", "0");
                    break;
            }
        }
        else if (GameObject.Find("Evicerator(Clone)"))
        {
            int lvl = PlayerPrefs.GetInt("eviceratorlvl");
            //Debug.Log("Titan");
            switch (lvl)
            {
                case 0:
                    ChangeText(2000, lvl, "Unlock Evicerator", 40, 7.5f, 10, 1.7f, "0", "0", "0");
                    if (money >= 2000 && Pressed)
                    {
                        money -= 2000;
                        PlayerPrefs.SetInt("eviceratorlvl", 1);
                    }
                    break;
                case 1:
                    ChangeText(1250, lvl, "Evicerator", 40, .12f, 10, 1.5f, "0", "42", "0");
                    if (money >= 1250 && Pressed)
                    {
                        money -= 1250;
                        PlayerPrefs.SetInt("eviceratorlvl", 2);
                    }
                    break;
                case 2:
                    ChangeText(1600, lvl, "Evicerator", 42, .12f, 10, 1.5f, "1.6", "44", "0");
                    if (money >= 1600 && Pressed)
                    {
                        money -= 1600;
                        PlayerPrefs.SetInt("eviceratorlvl", 3);
                    }
                    break;
                case 3:
                    ChangeText(2200, lvl, "Evicerator", 44, .12f, 10, 1.6f, "0", "46", "0.11");
                    if (money >= 2200 && Pressed)
                    {
                        money -= 2200;
                        PlayerPrefs.SetInt("eviceratorlvl", 4);
                    }
                    break;
                case 4:
                    ChangeText(3600, lvl, "Evicerator", 46, .11f, 10, 1.6f, "2.1", "48", "0.1");
                    if (money >= 3600 && Pressed)
                    {
                        money -= 3600;
                        PlayerPrefs.SetInt("eviceratorlvl", 5);
                    }
                    break;
                case 5:
                    ChangeText(4000, lvl, "Evicerator", 48, .1f, 10, 1.6f, "2.2", "50", "0.8");
                    if (money >= 4000 && Pressed)
                    {
                        money -= 4000;
                        PlayerPrefs.SetInt("eviceratorlvl", 6);
                    }
                    break;
                case 6:
                    ChangeText(0, lvl, "Evicerator", 50, .08f, 10, 1.6f, "0", "0", "0");
                    break;
            }
        }
        //Debug.Log(Pressed);
        if (Pressed)
        {
            Invoke(nameof(UpgradeAfterAfewSecs), 0.1f);  //updates display if the value changes
            PlayerPrefs.SetInt("Coins", money);
            PlayerPrefs.Save();
        }
    }

    public void Upgrade()
    {
        Pressed = false;
        Invoke(nameof(UpgradeAfterAfewSecs), 0.2f);
        Pressed = false;
        Invoke(nameof(UpgradeAfterAfewSecs), 0.3f);
    }

    private void UpgradeAfterAfewSecs()
    {
        Upgrade(false);
    }

    private void ChangeText(int cost,int level, string name, int hp, float firerate,int damage,float speed,string UpgradeSpeed, string Upgradehp, string Upgradefirerate)
    {
       
        //upgrade display correct number
        if (UpgradeSpeed == "0") UpgradeSpeed = "";
        else UpgradeSpeed = "-> " + UpgradeSpeed;
        if (Upgradehp == "0") Upgradehp = "";
        else Upgradehp = "-> " + Upgradehp;
        if (Upgradefirerate == "0") Upgradefirerate = "";
        else Upgradefirerate = "-> " + Upgradefirerate+"s";

        //set display
        if (cost>0)MoneyDisplay.text = "Money: "+money+"\nUpgrade Cost: "+cost;
        else MoneyDisplay.text = "Money: " + money;
        UpgradeButtonTitle.text = "Upgrade " + name + " lvl "+ level;
        UpgradeButtonRow1.text = "\n HeathPoints " + hp + " " + Upgradehp + "\n Damage " + damage;
        UpgradeButtonRow2.text = "\n FireRate " + firerate + "s" + Upgradefirerate + "\n Speed " + speed + " " + UpgradeSpeed;
    }
}
