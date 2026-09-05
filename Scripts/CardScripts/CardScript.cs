using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class CardScript : MonoBehaviour
{
    private RectTransform rectTransform;
    private MovementControler moveControler;
    private Transform Parent;
    [SerializeField] private GameObject unit;//what the card will spawn
    [SerializeField] private int cost;
    [SerializeField] private GameObject markerObj;
    [SerializeField] private int markerSize = 0;
    private GameObject marker;
    private bool isBomb = false;
    private Controls controls;
    private new Camera camera;
    private Vector2 pos;
    private bool InUpgradeMenu;

    public void SetMenu(bool IsInUpgradeMenu)
    {
        InUpgradeMenu = IsInUpgradeMenu;
    }
    private void Awake()
    {
        //decides if its in the upgrade menu or not
        //if (PlayerPrefs.HasKey("InUpgradeMenu")) InUpgradeMenu = true;
        //else InUpgradeMenu = false;
        //Debug.Log(InUpgradeMenu +"   "+gameObject.name);
        //setting up controls
        camera = Camera.main;
        controls = new Controls();
        setCounter();
    }

    private void OnEnable()
    {
        controls.Enable();
        setCounter();
        if (InUpgradeMenu) drop();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        Parent = transform.parent;
        moveControler = Parent.GetComponent<MovementControler>();
        drop();
    }

    public void setCounter()
    {
        transform.GetChild(1).gameObject.SetActive(true);
        if (transform.childCount > 3) transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "x"+(transform.childCount-2);
        else transform.GetChild(1).gameObject.SetActive(false);
    }
    public void StartDrag()
    {
        if (transform.childCount > 3)
        {
            Transform nextCard = transform.GetChild(3);
            nextCard.SetParent(Parent);
            nextCard.gameObject.SetActive(true);
            while (transform.childCount > 3)
            {
                transform.GetChild(3).SetParent(nextCard);
            }
            nextCard.GetComponent<CardScript>().setCounter();
        }
        transform.SetParent(Parent.parent);
        moveControler.enabled = false;
        if (markerObj)
        {
            isBomb = true;
            marker = Instantiate(markerObj);
            marker.transform.localScale = new Vector3(markerSize, markerSize, markerSize);
        }
    }
    public void Clicked()
    {
        StartDrag();
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + cost);
        PlayerPrefs.Save();
        GameObject Money = GameObject.Find("Money (TMP)");
        if (Money)
        {
            Money.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("Money").ToString();
            Destroy(gameObject);
        }
    }
    public void moved()
    {
        pos = controls.Touch.primaryFingerPosition.ReadValue<Vector2>();
        if (isBomb) {
            Ray ray = camera.ScreenPointToRay(pos);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                marker.transform.position = new Vector3(hit.point.x , 0, hit.point.z);
            }
        }
        else rectTransform.position = pos;
    }

    public void drop()
    {
        if (markerObj && marker) Destroy(marker.gameObject);
        if (InUpgradeMenu)
        {
            Instantiate(unit);
            Destroy(gameObject);
        }
        else if (pos.y < Screen.height- Screen.height * 0.82)//put back in hand
        {
            if (Parent.Find(gameObject.name) && Parent.Find(gameObject.name).transform != gameObject.transform)
            {
                transform.SetParent(Parent.Find(gameObject.name));
                gameObject.SetActive(false);
                transform.parent.GetComponent<CardScript>().setCounter();
            }
            else transform.SetParent(Parent);
        }
        else
        {
            Ray ray = camera.ScreenPointToRay(pos);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Destroy(gameObject);
                Instantiate(unit, new Vector3(hit.point.x, 0, hit.point.z), Quaternion.identity);
            }
        }
        if (moveControler)moveControler.enabled = true;
    }

    public int getCost()
    {
        return cost;
    }
}
