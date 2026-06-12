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
    public Image windArrow;
    public TextMeshProUGUI moneyText;

    [Header("Other Variables")]
    public float demandTimer;
    public float windTimer;
    public Vector2 windDirection;
    public float windLevel;
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
        RenderWind();
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
        moneyText.text = "$" + money.ToString();
    }
    public void CalcWind()
    {
        windTimer += Time.deltaTime;
        if (windTimer >= windTimerMax)
        {
            windLevel = UnityEngine.Random.Range(0f, 1f);
            windDirection = new Vector2(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)).normalized;
            float angle = Mathf.Atan2(windDirection.y, windDirection.x) * Mathf.Rad2Deg;
            windTimer = 0f;
        }
    }
    public void RenderWind()
    {
        float angle = Mathf.Atan2(windDirection.y, windDirection.x) * Mathf.Rad2Deg;
        windArrow.rectTransform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
