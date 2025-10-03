using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ManaManager : MonoBehaviour
{
    public Image manaBar;
    public float manaAmount = 100f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z) && manaAmount >= 20)
        {
            UseMana(20);
        }
        if (manaAmount < 100)
        {
            Regain(10);
        }
    }

    public void UseMana(float Mana)
    {
        manaAmount -= Mana;
        manaBar.fillAmount = manaAmount / 100f;
    }

    public void Regain(float regainAmount)
    {
        manaAmount += regainAmount * Time.deltaTime;
        manaAmount = Mathf.Clamp(manaAmount, 0, 100);

        manaBar.fillAmount = manaAmount / 100f;
    }
}
