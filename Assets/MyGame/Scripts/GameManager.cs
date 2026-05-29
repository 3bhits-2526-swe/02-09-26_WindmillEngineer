using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Configurable Variables")]

    public float demandTimerMax;



    [Header("UI Bars")]
    public Image demandBar;
    public Image supplyBar;
    public Image batteryBar;
    [Header("Other Variables")]
    public float demandTimer;


    void Start()
    {
        CalcDemand();
    }

    // Update is called once per frame
    void Update()
    {
        CalcDemand();        
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
}
