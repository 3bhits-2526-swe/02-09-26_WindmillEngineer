using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Configurable Variables")]

    public float demandTimerMax;



    [Header("UI")]
    public Image demandBar;
    public Image supplyBar;
    public Image batteryBar;
    public TextMeshProUGUI moneyText;

    [Header("Other Variables")]
    public float demandTimer;
    public int money;


    void Start()
    {
        CalcDemand();
    }

    // Update is called once per frame
    void Update()
    {
        CalcDemand();
        RenderMoney();
    }
    
    public void CalcDemand()
    {
        demandTimer += Time.deltaTime;
        if (demandTimer >= demandTimerMax)
        {
            float demand = 0;
            demand = UnityEngine.Random.Range(0f, 1f);
            demandBar.fillAmount = demand;
            demandTimer = 0f;
        }
        
    }
    public void RenderMoney()
    {
        moneyText.text = "Money: $" + money.ToString();
    }
}
