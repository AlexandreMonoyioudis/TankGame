using NUnit.Framework;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class bombSelector : MonoBehaviour
{
    [SerializeField] private Image TimerDisplay;
    private int bombSelected;
    private int bombPrep;
    private Transform hand;
    private List<GameObject> bomberCards;
    [SerializeField] private List<int> bomberCosts;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bomberCards = new List<GameObject>();
        bomberCosts = new List<int>();
        foreach (Transform child in transform)
        {
            GameObject card = child.GetComponent<cardHolder>().getCardPrefab();
            bomberCards.Add(card);
            bomberCosts.Add(card.GetComponent<CardScript>().getCost());
        }

        bombSelected = 0;
        bombPrep = 450;
        hand = GameObject.Find("Image(0)").transform;
        if (!hand) Destroy(this);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bombPrep++;
        if (bomberCosts[bombSelected] <= bombPrep) {
            bombPrep-= bomberCosts[bombSelected];
            bomberCosts[bombSelected] += 50+(bomberCosts[bombSelected]/10);
            GameObject bomberCard = Instantiate(bomberCards[bombSelected]);
            bomberCard.transform.SetParent(hand);
            bomberCard.transform.localScale = Vector3.one;
        }
    }

    public void switchBomb(Transform self)
    {
        bombSelected = self.GetSiblingIndex();
    }

    public void highlightSelected(Image button)
    {
        for (int i = 0; i<3; i++)
        {
            Image image = transform.GetChild(i).GetComponent<Image>();
            Color newColor = image.color;
            newColor.a = 0.3f;
            image.color = newColor;
        }
        Color color = button.color;
        color.a = 0.6f;
        button.color = color;
    }


    private void Update()
    {
        if (GameObject.Find("Start GUI"))
        {
            bombPrep = 450;
            bomberCosts = new List<int> {
                bomberCards[0].GetComponent<CardScript>().getCost(),
                bomberCards[1].GetComponent<CardScript>().getCost(),
                bomberCards[2].GetComponent<CardScript>().getCost(),
            };
        }
        Color newColour = Color.HSVToRGB((float)bombPrep / bomberCosts[bombSelected] * .32f, .9f, .9f);
        newColour.a = 0.3f;
        TimerDisplay.color = newColour;
        TimerDisplay.gameObject.transform.transform.localScale = new Vector3(1, (float)bombPrep / bomberCosts[bombSelected], 1);
    }
}
