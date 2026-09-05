using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hp : MonoBehaviour
{
    [SerializeField] private float hp;
    [SerializeField] private GameObject deathAffect;
    [SerializeField] private GameObject hpBar;
    [SerializeField] private float resistance;
    [SerializeField] private int damageReduction;
    private float startSize;
    private float startHp;
    // Start is called before the first frame update
    private void Start()
    {
        if (startHp < hp)
            startHp = hp;
        if (hpBar != null) startSize = hpBar.transform.localScale.x;
    }

    private void DestroyBullets()
    {
        bullet[] bullets = FindObjectsOfType<bullet>();
        foreach (bullet Bullet in bullets)
        {
            Destroy(Bullet.gameObject);
        }
    }

    private void OnEnable()
    {
        if (startHp > hp )
        {
            hp = startHp;
            if (hpBar != null && hpBar.TryGetComponent(out TextMeshProUGUI _) == true)//display hp as a number
            {
                hpBar.GetComponent<TextMeshProUGUI>().text = "Damage: 0";
                DestroyBullets();
            }
        }
    }

    public void gethit(float baseDamage, bool ignoreArmour)
    {
        int damage = Mathf.Clamp(Mathf.RoundToInt((baseDamage / resistance) - damageReduction), 1, int.MaxValue);
        if (ignoreArmour) hp -= baseDamage;
        else hp -= damage;

        if (hpBar != null && hpBar.TryGetComponent(out TextMeshProUGUI _) == true)//display hp as a number
        {
            hpBar.GetComponent<TextMeshProUGUI>().text = "Damage: " + (startHp - hp);
        }
        if(hpBar != null) { 
           hpBar.transform.localScale = new(hp / startHp * startSize, hpBar.transform.localScale.y, hpBar.transform.localScale.z);//calculating hpbar size
        }
        if (hp<= 0)
        {
            Destroy(gameObject);
            Instantiate(deathAffect, transform.position, Quaternion.identity);
        }
    }

    public void SetMaxHp(int newHp)
    {
        //Debug.Log("Called");
        startHp = newHp;
        hp = startHp;
        //OnEnable();
    }
}
