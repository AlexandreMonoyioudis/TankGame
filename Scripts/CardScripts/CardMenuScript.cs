using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CardMenuScript : MonoBehaviour
{
    [SerializeField] private bool InUpgradeMenu;
    private Transform Parent;
    private TextMeshProUGUI CostDisplay;
    [SerializeField] private GameObject unit;//what card will spawn
    
    private void Start()
    {
        Parent = GameObject.Find("Image(0)").transform;
        if(transform.parent.parent.parent.parent.GetChild(2).GetChild(0).childCount != 0)//makes sure the object exists
        CostDisplay =transform.parent.parent.parent.parent.GetChild(2).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        //Debug.Log(InUpgradeMenu +"   "+ gameObject.name);
        if(transform.childCount == 1)
        {
            GameObject Card = Instantiate(unit, Parent);
            int cost = Card.GetComponent<CardScript>().getCost();
            Destroy(Card);
            transform.GetComponentInChildren<TextMeshProUGUI>().text = cost.ToString();
        }
        if (InUpgradeMenu) Clicked();
    }
    private void OnEnable()
    {
        if (InUpgradeMenu) Clicked();
    }


    public void Clicked()
    {
        //Debug.Log("Pressed");
        if (InUpgradeMenu)//removes prevous tanks
        {
            GameObject[] tanks = GameObject.FindGameObjectsWithTag("Team1");
            foreach (GameObject tank in tanks)//destroys all current tanks
            {
                if (tank.name != "Base") Destroy(tank);
            }
        }
        GameObject Card =Instantiate(unit,Parent);
        Card.GetComponent<CardScript>().SetMenu(InUpgradeMenu);
        Card.SetActive(false); Card.SetActive(true);
        int money = PlayerPrefs.GetInt("Money");
        int cost = Card.GetComponent<CardScript>().getCost();
        
        if (cost > money && !InUpgradeMenu)
        {
            Destroy(Card);
        }
        else
        {
            money -= cost;
            if (CostDisplay)
                CostDisplay.text = money.ToString();
        }

        PlayerPrefs.SetInt("Money", money);
        PlayerPrefs.Save();
    }

    public void SwapItem()
    {
        //if (InUpgradeMenu) Clicked();
        //Debug.Log(transform.parent.GetSiblingIndex());
        //Debug.Log(transform.parent.parent.childCount);
        //Debug.Log((transform.parent.GetSiblingIndex()+1) % transform.parent.parent.childCount);
        //Debug.Log(transform.parent.parent);
        transform.parent.gameObject.SetActive(false);
        transform.parent.parent.GetChild((transform.parent.GetSiblingIndex()+1) % transform.parent.parent.childCount).gameObject.SetActive(true);
        
    }
}

