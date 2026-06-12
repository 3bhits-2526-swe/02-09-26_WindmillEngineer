using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Configurable Variables")]
    public float demandTimerMax;
    public float windTimerMax;

    [Header("UI")]
    public Image demandBar;
    public Image supplyBar;
    public Image batteryBar;
    public Image windBar;
    public TextMeshProUGUI moneyText;

    [Header("Other Variables")]
    public float demandTimer;
    public float windTimer;
    public Vector2 windLevel;
    public int money;


    void Start()
    {
        demandTimer = demandTimerMax;
        windTimer = windTimerMax;
    }

    // Update is called once per frame
    void Update()
    {
        CalcDemand();
        CalcWind();
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
    public void CalcWind()
    {
        windTimer += Time.deltaTime;
        if (windTimer >= windTimerMax)
        {
            windLevel = UnityEngine.Random.insideUnitCircle.normalized;
            windBar.fillAmount = windLevel.magnitude;
            windTimer = 0f;
        }
    }
}
